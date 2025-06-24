using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleMice
{
    public partial class MouseCursorForm : Form
    {
        public MouseCursorForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= WS_EX_LAYERED | WS_EX_TRANSPARENT | WS_EX_TOOLWINDOW | WS_EX_TOPMOST;
                return createParams;
            }
        }

        public void SelectBitmap(Bitmap cursorImage)
        {
            Point point = new Point(0, 0);
            SelectBitmap(cursorImage, 255, point);
        }

        public void SelectBitmap(Bitmap cursorImage, Point creationPoint)
        {
            SelectBitmap(cursorImage, 255, creationPoint);
        }

        private void SelectBitmap(Bitmap cursorImage, int opacity, Point creationPoint)
        {
            if (cursorImage.PixelFormat != System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            {
                throw new ApplicationException("The bitmap must be 32bpp with alpha-channel");
            }

            IntPtr screenDc = GetDC(IntPtr.Zero);
            IntPtr memDc = CreateCompatibleDC(screenDc);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr hOldBitmap = IntPtr.Zero;

            hBitmap = cursorImage.GetHbitmap(Color.FromArgb(0));
            hOldBitmap = SelectObject(memDc, hBitmap);

            Point newSize = new Point(cursorImage.Width, cursorImage.Height);

            Point sourceLocation = new Point(0, 0);
            Point newLocation = creationPoint;
            BLENDFUNCTIION blend = new BLENDFUNCTIION()
            {
                BlendOp = AC_SRC_OVER,
                BlendFlags = 0,
                SourceConstantAlpha = (byte)opacity,
                AlphaFormat = AC_SRC_ALPHA
            };

            UpdateLayeredWindow(this.Handle, screenDc, ref newLocation, ref newSize, memDc, ref sourceLocation, 0, ref blend, ULW_ALPHA);

            ReleaseDC(IntPtr.Zero, screenDc);
            if (hBitmap != IntPtr.Zero)
            {
                SelectObject(memDc, hOldBitmap);
                DeleteObject(hBitmap);
            }
            DeleteDC(memDc);
        }

        private const int WS_EX_LAYERED = 0x80000;

        private const int WS_EX_TRANSPARENT = 0x20;

        private const int WS_EX_TOOLWINDOW = 0x80;

        private const int WS_EX_TOPMOST = 0x08;

        private const int ULW_ALPHA = 0x02;

        private const byte AC_SRC_OVER = 0x00;

        private const byte AC_SRC_ALPHA = 0x01;

        private struct BLENDFUNCTIION
        {
            internal byte BlendOp;
            internal byte BlendFlags;
            internal byte SourceConstantAlpha;
            internal byte AlphaFormat;
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Point psize, IntPtr hdcSrc, ref Point pprSrc, int crKey, ref BLENDFUNCTIION pblend, int dwFlags);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool DeleteDC(IntPtr hDC);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool DeleteObject(IntPtr hObject);

        private void MouseCursorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
