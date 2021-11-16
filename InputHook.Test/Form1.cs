using InputHook.Models;
using InputHook.Platforms.Windows;

namespace InputHook.Test {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            //keyboard.KeyUp += OnKeyUp;
            //keyboard.KeyDown += OnKeyDown;
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

        void Invoke(Action action) =>
            base.Invoke(action);

        KeyboardModel keyboard = new();
        WindowsKeyboardHook keyboardHook;

        private void OnLoad(object sender, EventArgs e) {
            (keyboardHook = new() {
                Debug = true,
                KeyboardModel = keyboard,
            }).HookStart();
        }

        private void OnClosing(object sender, FormClosingEventArgs e) {
            keyboardHook.HookStop();
            keyboardHook?.Dispose();
            keyboard?.Dispose();
        }

        private void OnOrganize(object sender, EventArgs e) {
            if (_log.Items.Count > 100) {
                _log.Items.RemoveAt(99);
            }
        }
    }
}