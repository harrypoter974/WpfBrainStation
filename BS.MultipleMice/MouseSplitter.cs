using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace MultipleMice
{
    public partial class MouseSplitter : Form
    {
        private List<Mouse> mice; // A list of all available mice.
        private Mouse[] activeMice; // An array of the (at most) 4 mice used at the same time.
        public Mouse currentMouse; // The mouse that was last moved or clicked.

        private static int screenHeight; // Stores the screen's height in pixels.
        private static int screenWidth; // Stores the screen's width in pixels.

        public MouseSplitter(bool IsHide = true)
        {
            InitializeComponent();
            Run();
            this.Show();
            if (IsHide)
            {
                this.Top = 100000;
                this.Left = 100000;
            }
            OnFormLoaded(); 
        }

        // Runs after the form is loaded.
        private void OnFormLoaded()
        {
            RegisterInput();
        }

        // Registers the current form to get raw input data window messages. 
        public void RegisterInput()
        {
            int sizeOfRawInputHeader = Marshal.SizeOf(typeof(RAWINPUTDEVICE));
            RAWINPUTDEVICE rid = new RAWINPUTDEVICE() // The values used to get a raw input data mouse's messages. Do not change.
            {
                usUsagePage = 0x01,
                usUsage = 0x02,
                dwFlags = InformationFlag.inputSink,
                hwndTarget = this.Handle
            };

            if (!RegisterRawInputDevices(ref rid, 1, sizeOfRawInputHeader))
                throw new Exception("Couldn't register current window to get raw input data messages.");
        }

        // Runs when the form is closing.
        public void OnClosing()
        {
            XmlParser parser = new XmlParser();
            //parser.Save(activeMice);
            ClearDeviceList();
            RestoreCursor();
            Dispose(true);
        }

        // Restores the Windows cursor to it's default one.
        private void RestoreCursor()
        {
            SystemParametersInfo(0x0057, 0, null, 0);
        }

        // A function that runs everytime a window message is sent.
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == (int)Wm_Inputs.wmGeneralInput) // If the current window message is a raw input data message.
            {
                GetMouseFromRawInputData(msg);
            }
            if (msg.Msg == (int)Wm_Inputs.wmDeviceChanged) // If the current window message is a device connected/disconnected message.
            {
                ResetDeviceList();
            }
            base.WndProc(ref msg); // Otherwise, run the default function.
        }

        // Sets everything up.
        private void Run()
        {
            GetScreenResolution();
            Mouse.CreateCursorBitmaps();
            GetGeneralDevicesList();
            SetWindowCursorToBlank();
            _isFerst =new bool[] { true, true, true, true };
        }
        bool[] _isFerst ;
        // Sets the Windows cursor to a blank one, to prevent it from being shown along with the custom cursors.
        private void SetWindowCursorToBlank()
        {
            foreach (SystemCursors cursors in Enum.GetValues(typeof(SystemCursors)))
            {
                Stream str = new MemoryStream(Properties.Resources.blankCursor);
                Cursor blankCursor = new Cursor(str);
                SetSystemCursor(blankCursor.Handle, (uint)cursors);
                str.Close();
                str.Dispose();
            }
        }

        // Gets the screen resolution. Used to make sure the mice won't go out of bounds.
        private void GetScreenResolution()
        {
            screenHeight = Screen.PrimaryScreen.Bounds.Height;
            screenWidth = Screen.PrimaryScreen.Bounds.Width;           
        }

        // Gets all of the devices connected to the computer.
        private void GetGeneralDevicesList()
        {
            Type typeOfRawInput = typeof(GeneralDeviceType);
            int sizeOfRawInput = Marshal.SizeOf(typeOfRawInput);
            int numDevices = 0;

            GetRawInputDeviceList(null, ref numDevices, sizeOfRawInput);

            if (numDevices > 0)
            {
                GeneralDeviceType[] deviceList = new GeneralDeviceType[numDevices]; // Creates an array to store the device's list.
                GetRawInputDeviceList(deviceList, ref numDevices, sizeOfRawInput);
                GetMouseDevicesList(deviceList);
            }
            else
                throw new Exception("Could not get device list from GetRawInputDeviceList");
        }

        // Gets a list of the mouse from the general device list.
        private void GetMouseDevicesList(GeneralDeviceType[] deviceList)
        {
            mice = new List<Mouse>();
            activeMice = new Mouse[4];
            XmlParser xmlParser = new XmlParser(); // The method is using the Xml Parser to check if there's mouse information stored in the Xml file.
            foreach (GeneralDeviceType device in deviceList)
            {
                if (device.dwType == mouseInputType) // If the device type is a mouse.
                {
                    string mouseName = GetMouseName(device);
                    if (xmlParser.TryGetMouseFromName(mouseName, device.hDevice, out Mouse mouse)) // If there's a mouse data corresponding to the current mouse's name.
                        activeMice[(int)mouse.Rotation] = mouse; // Adds the current mouse to the active mice array.
                    else
                        mouse = new Mouse(device.hDevice, mouseName); // If there's not a mouse data corresponding to the current mouse in the xml, create a new mouse with default values.

                    mice.Add(mouse); // Adds the mouse to the list of available mice.
                }
            }
        }

        // Gets the device's name (The device's name is a random string).
        private string GetMouseName(GeneralDeviceType device)
        {
            char[] output = new char[0];
            int size = 0;
            GetRawInputDeviceInfo(device.hDevice, deviceNameCommand, output, ref size);
            output = new char[size];
            if (GetRawInputDeviceInfo(device.hDevice, deviceNameCommand, output, ref size) == -1)
                throw new Exception("Could not recieve name from device");
            return new string(output);
        }

        // Resets the available mouse list, and the current mouse array. 
        private void ResetDeviceList()
        {
            ClearDeviceList();
            GetGeneralDevicesList();
        }

        // Clears the available mouse list, and the current mouse array.
        private void ClearDeviceList()
        {
            foreach (Mouse mouse in mice)
            {
                if (mouse != null && mouse.IsActive)
                {
                    mouse.Dispose();
                }
            }
        }

        // Called each time a raw input data message is recieved. Used to determine which mouse was moved.
        public void GetMouseFromRawInputData(Message m)
        {
            RawInputData rawInputData = new RawInputData();
            int inputSize = Marshal.SizeOf(typeof(RawInputData));
            int headerSize = Marshal.SizeOf(typeof(RawInputDataHeader));

            if (GetRawInputData(m.LParam, inputRawDataType, out rawInputData, ref inputSize, headerSize) != -1) // If the data could be parsed from the message.
            {
                if (!IsHeaderEmpty(rawInputData)) // If the mouse's handle is not empty.
                {
                    Mouse tempMouse = FindMouseFromRawInputData(rawInputData); // Gets the mouse info from the raw input data.
                    if (tempMouse == null) // If The mouse's data couln't be found.
                    {
                        ResetDeviceList(); // Refresh the list of the currently connected mice.
                        tempMouse = FindMouseFromRawInputData(rawInputData);
                    }

                    if (currentMouse == null) // If there's no current mouse (this mouse is the first one to move).
                    {
                        currentMouse = tempMouse; // Sets the current mouse to this mouse.
                        currentMouse.IsActive = true; // Sets the mouse to active (makes the cursor being shown).
                    }

                    bool isMouseChanged = false;
                    if (currentMouse.Handle != tempMouse.Handle) // If the current mouse is different from this mouse (the last moved mouse is different from this mouse).
                    {
                        currentMouse = tempMouse; // Change the current mouse to this mosue.

                        if (!currentMouse.IsActive) // If the mouse is not active
                            currentMouse.IsActive = true; // Sets the mosue to be active.
                        isMouseChanged = true;
                    }
                    MoveMouse(rawInputData);
                    CheckForClicks(rawInputData);
                }
            }
            else
            {
                throw new Exception("Couldn't get Raw Input Data from window message.");
            }
        }

        // Checks if the header of the mouse is empty (if the mouse has no handle, etc).
        private static bool IsHeaderEmpty(RawInputData data)
        {
            if (data.header.hDevice == IntPtr.Zero)
            {
                return true;
            }
            return false;
        }

        // Tries to get the mouse value from the raw input data.
        private Mouse FindMouseFromRawInputData(RawInputData input)
        {
            IntPtr ptr = input.header.hDevice;
            foreach (Mouse mouse in mice)
            {
                if (ptr == mouse.Handle)
                {
                    return mouse;
                }
            }
            return null; // Returns null if the mosue is not found in the current mouse list.
        }

        // Moves the current mouse's cursor using the input data.
        private void MoveMouse(RawInputData rawInputData)
        {
            Point point = currentMouse.PositionOnScreen;
            point = CalculateNewMouseMovement(rawInputData, point);
            currentMouse.MouseCursor.SetDesktopLocation(point.x, point.y); // Sets the mouse's cursor form to the point's coordinates.
            currentMouse.PositionOnScreen = point;
        }

        // Checks if the raw input data contains mouse click data.
        private void CheckForClicks(RawInputData rawInputData)
        {
            ClickedButton clickedButton = WhichButtonClicked(rawInputData);
            if (clickedButton != ClickedButton.none)
            {
                PerformClick(clickedButton);

            }
        }

        // Used to check which button (if any) was clicked.
        private static ClickedButton WhichButtonClicked(RawInputData data)
        {
            if ((data.mouse.usButtonFlags & (ushort)MouseButtonsState.lButtonDown) == (ushort)MouseButtonsState.lButtonDown)
            {
                return ClickedButton.leftButton;
            }
            if ((data.mouse.usButtonFlags & (ushort)MouseButtonsState.rButtonDown) == (ushort)MouseButtonsState.rButtonDown)
            {
                return ClickedButton.rightButton;
            }
            return ClickedButton.none;
        }

        // Runs if the form is in calibration mode
        private void Calibrate(ClickedButton clickedButton)
        {
            switch (clickedButton)
            {
                case ClickedButton.leftButton: // If the left button is clicked add the mouse to the active mice array.
                    AddMouseToArray();
                    break;
                case ClickedButton.rightButton: // If the right button is clicked stop the calibration.
                    {
                        StopCalibration();
                    }
                    break;
            }
        }

        // Adds the current mouse to the active mice array using the mouse's position.
        private void AddMouseToArray()
        {
            for (int i = 0; i < activeMice.Length; i++)
            {
                if (activeMice[i] == currentMouse)
                    activeMice[i] = null;
            }
        }

        // Changes the instruction label to the next instruction.
        private void SetCalibrationLabel(Mouse.MousePosition pos)
        {
            string posString;
            switch (pos) // Sets the label to the next instruction.
            {
                case Mouse.MousePosition.A:
                    posString = "B";
                    break;
                case Mouse.MousePosition.B:
                    posString = "C";
                    break;
                case Mouse.MousePosition.C:
                    posString = "D";
                    break;
                case Mouse.MousePosition.D:
                    posString = "A";
                    break;
                default:
                    throw new Exception("Couldn't parse Mouse Position");
            }
       }

        // Stops Calibration mode.
        private void StopCalibration()
        {
            SetCalibrationLabel(Mouse.MousePosition.D);
        }

        // Performs a click.
        private void PerformClick(ClickedButton clickedButton)
        {
            Point position = PixelsToShort(currentMouse.PositionOnScreen, currentMouse.Rotation); // The position needs to be in short (0 to 65535), because that's what window messages use.

            WindowMessageOutput clickOutput;

            int sizeOfOutput = Marshal.SizeOf(typeof(WindowMessageOutput));

            switch (clickedButton)
            {
                case ClickedButton.leftButton: // Creates window messages for a left click sequence.
                    clickOutput = CreateMouseWindowMessage(position, MouseMessegeFlags.LEFTDOWN);
                    break;
                case ClickedButton.rightButton: // Creates window messages for a left click sequence.
                    clickOutput = CreateMouseWindowMessage(position, MouseMessegeFlags.RIGHTDOWN);
                    break;
                default:
                    throw new Exception("Could not determine which button was pressed");
            }

            // Send the created window message.
            SendInput(1, ref clickOutput, sizeOfOutput);
            
        }

        // Converts the given position from pixels to short (0 to 65535).
        private static Point PixelsToShort(Point pixelValue, Mouse.MousePosition pos)
        {
            switch (pos)
            {
                case Mouse.MousePosition.B:
                    pixelValue.y += Mouse.GetBitmapWidth();
                    break;
                case Mouse.MousePosition.C:
                    pixelValue.y += Mouse.GetBitmapHeight();
                    pixelValue.x += Mouse.GetBitmapWidth();
                    break;
                case Mouse.MousePosition.D:
                    pixelValue.x += Mouse.GetBitmapHeight();
                    break;
                default:
                    break;
            }
            int x = (pixelValue.x * 65536) / screenWidth;
            int y = (pixelValue.y * 65536) / screenHeight;
            return new Point(x, y);
        }

        // Creates a window message using the given values.
        private static WindowMessageOutput CreateMouseWindowMessage(Point position, MouseMessegeFlags outputType)
        {
            if (outputType == MouseMessegeFlags.LEFTDOWN)
            {
                outputType |= MouseMessegeFlags.LEFTUP;
            }
            if (outputType == MouseMessegeFlags.RIGHTDOWN)
            {
                outputType |= MouseMessegeFlags.RIGHTUP;
            }
            return new WindowMessageOutput()
            {
                type = 0,
                mouseOutput = new MouseOutput
                {
                    dx = position.x,
                    dy = position.y,
                    extraInfo = (UIntPtr)1000,
                    flags = outputType | MouseMessegeFlags.MOVE | MouseMessegeFlags.ABSOLUTE // Movement is absolute (from the top left of the screen).
                }
            };
        }

        // Calculates the cursor movement, considering the mice direction.
        private Point CalculateNewMouseMovement(RawInputData rawInputData, Point currentPosition)
        {
            int x = rawInputData.mouse.lLastX;
            int y = rawInputData.mouse.lLastY;
            switch (currentMouse.State)
            {
                case Mouse.MouseDirection.normalDirection: // In normal direction the values are added to the current values normally.

                    if (_isFerst[0])
                    {
                        currentPosition.x = (int)(System.Windows.SystemParameters.PrimaryScreenWidth * 0.5);
                        currentPosition.y =(int)( System.Windows.SystemParameters.PrimaryScreenHeight * 0.5);
                        _isFerst[0] = false;
                    }
                    else
                    {
                        currentPosition.x += x;
                        currentPosition.y += y ;
                    }
                    break;
                case Mouse.MouseDirection.inverseDirection: // In inverse direction the values are being subtracted from the current values.
                    if (_isFerst[1])
                    {
                        currentPosition.x = (int)(System.Windows.SystemParameters.PrimaryScreenWidth * 0.5);
                        currentPosition.y = (int)(System.Windows.SystemParameters.PrimaryScreenHeight * 0.5);
                        _isFerst[1] = false;
                    }
                    else
                    {
                        currentPosition.y -= y;
                        currentPosition.x -= x;
                    }
                    break;
                case Mouse.MouseDirection.leftDirection: // In left direction the y value is being subtracted from the current x value, and the x value is being added to the current y value.
                    if (_isFerst[2])
                    {
                        currentPosition.x = (int)(System.Windows.SystemParameters.PrimaryScreenWidth * 0.5);
                        currentPosition.y = (int)(System.Windows.SystemParameters.PrimaryScreenHeight * 0.5);
                        _isFerst[2] = false;
                    }
                    else
                    {
                        currentPosition.x -= y;
                        currentPosition.y += x;
                    }
                    break;
                case Mouse.MouseDirection.rightDirection: // In left direction the y value is being added to the current x value, and the x value is being subtracted from the current y value.
                    if (_isFerst[3])
                    {
                        currentPosition.x = (int)(System.Windows.SystemParameters.PrimaryScreenWidth * 0.5);
                        currentPosition.y = (int)(System.Windows.SystemParameters.PrimaryScreenHeight * 0.5);
                        _isFerst[3] = false;
                    }
                    else
                    {
                        currentPosition.x += y;
                        currentPosition.y -= x;
                    }
                    break;
                default:
                    throw new Exception("Unknown Value of MouseState");
            }
            // If the current position is now out of bounds, return it to the screen.
            if (currentPosition.x < -Mouse.GetBitmapHeight())
                currentPosition.x = -Mouse.GetBitmapHeight();
            if (currentPosition.y < -Mouse.GetBitmapHeight())
                currentPosition.y = -Mouse.GetBitmapHeight();
            if (currentPosition.x > screenWidth)
                currentPosition.x = screenWidth-30;
            if (currentPosition.y > screenHeight)
                currentPosition.y = screenHeight-30;

            if (currentPosition.x < -22)
                currentPosition.x = -22;
            if (currentPosition.y < -22)
                currentPosition.y = -22;
          
                return currentPosition;
        }

        private const int mouseInputType = 0;
        private const int inputRawDataType = 0x10000003;
        private const int deviceNameCommand = 0x20000007;

        private enum SystemCursors
        {
            normalCursor = 32512,
            crossCursor = 32515,
            handCursor = 32649,
            helpCursor = 32651,
            beamCursor = 32513,
            loadingCursor = 32650,
            hourGlassCursor = 32514
        }

        private enum MouseButtonsState
        {
            lButtonDown = 0x0001,
            rButtonDown = 0x0004,
        }

        private enum MouseMessegeFlags : uint
        {
            ABSOLUTE = 0x8000,
            MOVE = 0x0001,
            LEFTDOWN = 0x0002,
            LEFTUP = 0x0004,
            RIGHTDOWN = 0x0008,
            RIGHTUP = 0x0010,
            VIRTUALDESK = 0x4000
        }

        private enum ClickedButton
        {
            leftButton = 0,
            rightButton = 1,
            none = 10
        }

        private struct GeneralDeviceType
        {
            internal IntPtr hDevice;
            internal int dwType;
        }

        private struct RawInputData //Called "RAWINPUT" in "user32.dll".
        {
            internal RawInputDataHeader header;
            internal RawInputDataMouse mouse;
        }

        private struct RawInputDataHeader //Called "RAWINPUTHEADER" in "user32.dll".
        {
            internal uint dwType;
            internal uint dwSize;
            internal IntPtr hDevice;
            internal uint wParam;
        }

        private struct RawInputDataMouse //Called "RAWMOUSE" in "user32.dll".
        {
            internal uint usFlags; //indicator flags
            internal ushort usButtonFlags;
            internal ushort usButtonData;
            internal uint ulRawButtons; //The raw state of the mouse buttons.
            internal int lLastX; //The signed relative or absolute motion in the X direction.
            internal int lLastY; //The signed relative or absolute motion in the Y direction.
            internal uint ulExtraInformation; //Device-specific additional information for the event.
        }

        private struct WindowMessageOutput
        {
            internal int type;
            internal MouseOutput mouseOutput;
        }

        private struct MouseOutput
        {
            internal int dx;
            internal int dy;
            readonly int wheelData;
            internal MouseMessegeFlags flags;
            readonly uint time;
            internal UIntPtr extraInfo;
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private extern static bool RegisterRawInputDevices(ref RAWINPUTDEVICE pRawInputDevices, int uiNumDevices, int cbSize);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(uint uiAction, uint uiParam, string pvParam, uint fWinIni);

        private struct RAWINPUTDEVICE //Called RAWINPOUTDEVICE in "user32.dll".
        {
            internal ushort usUsagePage;
            internal ushort usUsage;
            internal InformationFlag dwFlags;
            internal IntPtr hwndTarget;
        }

        private enum Wm_Inputs
        {
            wmGeneralInput = 0x00FF,
            wmDeviceChanged = 0x0219
        }

        private enum InformationFlag //Used for RAWINPUTDEVICE Struct
        {
            appKeys = 0x00000400, //If set, the application command keys are handled. RIDEV_APPKEYS can be specified only if RIDEV_NOLEGACY is specified for a keyboard device.
            captureMouse = 0x00000200, //If set, the mouse button click does not activate the other window.
            devNotify = 0x00002000, //If set, this enables the caller to receive WM_INPUT_DEVICE_CHANGE notifications for device arrival and device removal.
            exclude = 0x00000010, //If set, this specifies the top level collections to exclude when reading a complete usage page.
            exInputSink = 0x00001000, //If set, this enables the caller to receive input in the background only if the foreground application does not process it.
            inputSink = 0x00000100, //If set, this enables the caller to receive the input even when the caller is not in the foreground. Note that hwndTarget must be specified.
            noHotKeys = 0x00000200, //If set, the application-defined keyboard device hotkeys are not handled. However, the system hotkeys; for example, ALT+TAB and CTRL+ALT+DEL, are still handled.
            noLegacy = 0x00000030, //If set, this prevents any devices specified by usUsagePage or usUsage from generating legacy messages.
            pageOnly = 0x00000020, //If set, this specifies all devices whose top level collection is from the specified usUsagePage.
            remove = 0x00000001 //If set, this removes the top level collection from the inclusion list.
        }


        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern uint GetRawInputDeviceList([In, Out] GeneralDeviceType[] RawInputDeviceList, ref int NumDevices, int Size);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetRawInputDeviceInfo(IntPtr hDevice, int command, [In, Out] char[] output, ref int outputSize);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetRawInputData(IntPtr hRawInput, int uiCommand, out RawInputData pData, ref int pcbSize, int cbSizeHeader);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern uint SendInput(uint nInputs, ref WindowMessageOutput pInputs, int cbSize);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool SetSystemCursor(IntPtr hcur, uint id);
    }

    public struct Point
    {
        public int x;
        public int y;
        public Point(int x, int y) {this.x = x; this.y = y; }

        public static Point operator +(Point point1, Point point2) { return new Point(point1.x + point2.x, point1.y + point2.y); }
        public static Point operator -(Point point1, Point point2) { return new Point(point1.x - point2.x, point1.y - point2.y); }
    }
}
