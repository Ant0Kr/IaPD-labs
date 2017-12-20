using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace GlobalHooks
{
    public class EventController
    {
        public delegate void WindowShowHandler();

        private readonly IKeyboardMouseEvents _globalHooks = Hook.GlobalEvents();
        private readonly LogController _logController;
        private readonly Settings _settings;
        private readonly WindowShowHandler _windowShow;

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern int LoadKeyboardLayout(string pwszKLID, uint Flags);

        public EventController(Settings config, WindowShowHandler windowShow)
        {
            _settings = config;
            _windowShow = windowShow;
            _logController = new LogController(_settings);
            _globalHooks.KeyDown += KeyEvent;
            _globalHooks.MouseClick += MouseEvent;
        }

        private void KeyEvent(object sender, KeyEventArgs e)
        {
            if (_settings.IsHotKey)
            {
                if (e.KeyData == Keys.PrintScreen)
                {
                    SaveScreen();
                }
            }
            if (_settings.IsLog)
            {
                _logController.KeyboardLogging(e.KeyData.ToString());
            }
            if (e.KeyData == (Keys.PrintScreen | Keys.Alt))
            {
                _windowShow?.Invoke();
            }
        }

        private void MouseEvent(object sender, MouseEventArgs e)
        {
            if (_settings.IsLog)
            {
                _logController.MouseLogging(e.Button.ToString(), e.Location.ToString());
            }
        }

        private void SaveScreen()
        {
            var printScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            var graphics = Graphics.FromImage(printScreen);

            graphics.CopyFromScreen(0, 0, 0, 0, printScreen.Size);

            printScreen.Save($@"{_settings.PathForSave}\{ Guid.NewGuid()}.jpg", ImageFormat.Jpeg);
        }
    }
}
