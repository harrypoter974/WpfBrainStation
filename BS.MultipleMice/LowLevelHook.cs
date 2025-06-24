using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MultipleMice
{
    // Low Level Hook is being used to prevent any automatic windows cursor movement, to prevent it intefering with the program.
  public  class LowLevelHook
    {
        private delegate IntPtr MouseHookHandler(int code, IntPtr wParam, IntPtr lParam);
        private IntPtr hookID = IntPtr.Zero;
        MouseHookHandler func;

        // Starts the hook.
        public void Run()
        {
            func = HookFunc;
            hookID = SetHook(func);
        }

        // Closes the hook.
        public void Dispose()
        {
            if (hookID != IntPtr.Zero)
            {
                UnhookWindowsHookEx(hookID);
                hookID = IntPtr.Zero;
            }
        }

        // Registers the hook.
        private IntPtr SetHook(MouseHookHandler proc)
        {
            using (var module = Process.GetCurrentProcess().MainModule)
            {
                return SetWindowsHookEx(mouseLowLevelInput, proc, GetModuleHandle(module.ModuleName), 0);
            }
        }

        // The function that's being called each time there's a mouse movement.
        private IntPtr HookFunc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                MouseOutput mo = (MouseOutput)Marshal.PtrToStructure(lParam, typeof(MouseOutput)); // Get the Mosue Output from the hook message.
                if (mo.extraInfo == (UIntPtr)1000) // If the hook message is user created (i.e. created in this program) then do not block it.
                {
                    return CallNextHookEx(hookID, nCode, (IntPtr)0x0200, lParam);
                }

                // Block the hook message if the message is any of the following values: right button, left button, or mouse movement
                switch ((MessageType)wParam)
                {
                    case MessageType.rButtonDown:
                    case MessageType.lButtonDown:
                    case MessageType.lButtonUp:
                    case MessageType.mouseMove:
                        return (IntPtr)1;
                    default:
                        break;
                }
            }
            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }

        private const int mouseLowLevelInput = 14;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, MouseHookHandler lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool SetCursorPos(int x, int y);

        private struct MouseOutput
        {
            internal int dx;
            internal int dy;
            internal int wheelData;
            internal int flags;
            internal uint time;
            internal UIntPtr extraInfo;
        }

        private enum MessageType
        {
            lButtonDown = 0x0201,
            lButtonUp = 0x0202,
            rButtonDown = 0x0204,
            mouseMove = 0x0200
        }
    }
}
