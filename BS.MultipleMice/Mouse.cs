using System;
using System.Drawing;
using System.Resources;

namespace MultipleMice
{
    // A class used to get and set each mouse's data.
    public class Mouse
    {
        // The cursor's images in a Bitmap format.
        private static Bitmap yellowCursorImage;
        private static Bitmap blueCursorImage;
        private static Bitmap redCursorImage;
        private static Bitmap greenCursorImage;

        public IntPtr Handle { get; }
        public MouseCursorForm MouseCursor { get; set; }
        public Point PositionOnScreen { get; set; }
        public string MouseName { get; set; }

        private bool isActive = false;
        public bool IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value;
                if (isActive == true)
                    UpdateMouseCursorForm(); // If mouse changed to active update the cursor.
            }
        }

        public MouseDirection State { get; private set; }
        public MouseColor Color { get; private set; }

        private MousePosition rotation;
        public MousePosition Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                rotation = value;
                SetMouseByPosition();
            }
        }

        public Mouse(IntPtr handle, string name, MousePosition position)
        {
            Handle = handle;
            MouseName = name;
            Rotation = position;
        }

        public Mouse(IntPtr handle, string name, int position)
        {
            Handle = handle;
            MouseName = name;
            Rotation = (MousePosition)position;
        }

        public Mouse(IntPtr handle, string name)
        {
            Handle = handle;
            MouseName = name;
            Rotation = MousePosition.A;
        }

        // A method used to set the mouse's State and Color using the mouse position (each position has different values).
        private void SetMouseByPosition()
        {
            switch (rotation)
            {
                case MousePosition.A: // Position A has green color and is in the normal direction.
                    State = MouseDirection.normalDirection;
                    Color = MouseColor.greenColor;
                    break;
                case MousePosition.B: // Position B has yellow color and is in the right direction (mouse is to the right of the screen)
                    State = MouseDirection.rightDirection;
                    Color = MouseColor.yellowColor;
                    break;
                case MousePosition.C: // Position C has blue color and is in the inverse direction (mouse is above the screen)
                    State = MouseDirection.inverseDirection;
                    Color = MouseColor.blueColor;
                    break;
                case MousePosition.D: // Position D has red color and is in the left direction (mouse is to the left of the screen).
                    State = MouseDirection.leftDirection;
                    Color = MouseColor.redColor;
                    break;
            }
            UpdateMouseCursorForm();
        }

        // Updates the cursor form to change the cursor's color.
        public void UpdateMouseCursorForm()
        {
            if (MouseCursor == null || MouseCursor.IsDisposed)
                MouseCursor = new MouseCursorForm();


            MouseCursor.SelectBitmap(GetBitmapByColor(), PositionOnScreen);
            if (IsActive)
                MouseCursor.Show();
        }

        // Returns the Corresponding Bitmap to the cursor's current color.
        private Bitmap GetBitmapByColor()
        {
            switch (Color)
            {
                case MouseColor.yellowColor:
                    return yellowCursorImage;
                case MouseColor.blueColor:
                    return blueCursorImage;
                case MouseColor.redColor:
                    return redCursorImage;
                case MouseColor.greenColor:
                    return greenCursorImage;
            }

            throw new Exception("Unknown Color");
        }

        // Closes the Cursor's Form.
        public void Dispose()
        {
            if (MouseCursor != null)
            {
                MouseCursor.Close();
                MouseCursor.Dispose();
            }
        }

        public static int GetBitmapHeight()
        {
            return greenCursorImage.Height;
        }

        public static int GetBitmapWidth()
        {
            return greenCursorImage.Width;
        }

        // Creates the Bitmaps of the cursor's images.
        public static void CreateCursorBitmaps()
        {
            yellowCursorImage = new Bitmap(Properties.Resources.yellowCursor);
            blueCursorImage = new Bitmap(Properties.Resources.blueCursor);
            redCursorImage = new Bitmap(Properties.Resources.redCursor);
            greenCursorImage = new Bitmap(Properties.Resources.greenCursor);
        }

        // The direction the mouse comes from.
        public enum MouseDirection
        {
            normalDirection = 0, // Normal mouse direction.
            inverseDirection = 1, // The mouse comes from above the screen.
            leftDirection = 2, // The mouse comes from the left of the screen.
            rightDirection = 3 // The mouse comes from the right of the screen.
        }

        // The color of the mouse's cursor.
        public enum MouseColor
        {
            yellowColor = 0,
            blueColor = 1,
            redColor = 2,
            greenColor = 3
        }

        // The position of the mouse, used to determine the color and direction of the mouse.
        public enum MousePosition
        {
            A, // Normal direction, green color.
            B, // Right direction, yellow color.
            C, // Inverse direction, blue color.
            D // Left direction, red color.
        }
    }
}
