using System.Runtime.InteropServices;

namespace LOPEZADRI_FILE_MANAGER.Herramientas
{
    internal class DragForm
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public static void WireUpControlForDrag(Control control)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            control.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage((sender as Control).FindForm().Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            };
        }
    }
}
