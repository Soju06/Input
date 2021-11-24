using Input.Models;
using Input.Platforms.Windows;

namespace Input.Test {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();


            (keyboardHook = Input.Use<IKeyboardHook>()).Debug = true;

            keyboard = keyboardHook.KeyboardModel;
            keyboard.KeyUp += OnKeyUp;
            keyboard.KeyDown += OnKeyDown;

            (mouseHook = Input.Use<IMouseHook>()).Debug = true;
            mouse = mouseHook.MouseModel;

            (keyboardSimulation = Input.Use<IKeyboardSimulation>()).Debug = true;

            mouse.State += OnMouseState;

            _keyboard_input_types_box.Items.AddRange(new[] { "KeyDown", "KeyUp", "KeyClick" });
            _keyboard_input_types_box.SelectedIndex = 0;

            _keyboard_key_types_box.DataSource = (InputKeys[])Enum.GetValues(typeof(InputKeys));
            _keyboard_input_types_box.SelectedIndex = 0;
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
        IKeyboardSimulation keyboardSimulation;

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

        private void OnRemoveKeyboardSimulation(object sender, EventArgs e) {
            var selected_index = _keyboard_simulation_list_box.SelectedIndex;
            if (selected_index >= 0)
                _keyboard_simulation_list_box.Items.RemoveAt(selected_index);
        }

        private void OnAddKeyboardSimulation(object sender, EventArgs e) {
            _keyboard_simulation_list_box.Items.Add((InputKeys)_keyboard_key_types_box.SelectedItem);
        }

        private void OnKeyboardSimulation(object sender, EventArgs e) {
            if (_keyboard_simulation_list_box.Items.Count > 0) {
                _test_input_box.Focus();

                var _keys = new object[_keyboard_simulation_list_box.Items.Count];
                _keyboard_simulation_list_box.Items.CopyTo(_keys, 0);

                var keys = (from key in _keys select (InputKeys)key).ToArray();
                var state = (string)_keyboard_input_types_box.SelectedItem;


                switch (state) {
                    case "KeyDown":
                        keyboardSimulation.KeyDown(keys);
                    break;

                    case "KeyUp":
                        keyboardSimulation.KeyUp(keys);
                    break;

                    case "KeyClick":
                        keyboardSimulation.KeyClick(keys);
                    break;
                }
            }
        }

        private void OnReleaseAllKeys(object sender, EventArgs e) {
            keyboardSimulation.ReleaseAllKeys();
        }
    }
}