using Input.Models;

namespace Input.Test {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            (keyboardHook = InputHook.Use<IKeyboardHook>()).Debug = true;

            keyboard = keyboardHook.KeyboardModel;
            keyboard.KeyUp += OnKeyUp;
            keyboard.KeyDown += OnKeyDown;

            (mouseHook = InputHook.Use<IMouseHook>()).Debug = true;
            mouse = mouseHook.MouseModel;

            mouse.State += OnMouseState;
        }

        private bool OnMouseState(object sender, InputButtons button, int x, int y) {
            Log($"Mouse {button}: {x} {y}");
            return true;
        }

        bool OnKeyDown(object sender, InputKeys key, InputKeyState state) {
            Log($"KeyDown: {key} {state}");
            return true;
        }

        bool OnKeyUp(object sender, InputKeys key, InputKeyState state) {
            Log($"KeyUp: {key} {state}");
            return true;
        }

        void Log(string message) =>
            Invoke(() => _log.Items.Insert(0, message));

        KeyboardModel keyboard;
        MouseModel mouse;
        IKeyboardHook keyboardHook;
        IMouseHook mouseHook;

        private void OnLoad(object sender, EventArgs e) {
            
        }

        private void OnClosing(object sender, FormClosingEventArgs e) {
            keyboardHook?.Dispose();
            mouseHook?.Dispose();

            keyboard?.Dispose();
            mouse?.Dispose();
        }

        private void OnOrganize(object sender, EventArgs e) {
            if (_log.Items.Count > 100) {
                _log.Items.RemoveAt(99);
            }
        }

        private void OnMouseHookChanged(object sender, EventArgs e) {
            if (_mouse_hook_chk.Checked)
                mouseHook.HookStart();
            else mouseHook.HookStop();
        }

        private void OnKeyboardHook(object sender, EventArgs e) {
            if (_keyboard_hook_chk.Checked)
                keyboardHook.HookStart();
            else keyboardHook.HookStop();
        }
    }
}