using Input.Models;
using Input.Platforms.Windows;
using System.Reflection;

namespace Input.Test {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();


            (keyboardHook = Inputs.Use<IKeyboardHook>()).Debug = true;

            keyboard = keyboardHook.KeyboardModel;
            keyboard.KeyUp += OnKeyUp;
            keyboard.KeyDown += OnKeyDown;

            (mouseHook = Inputs.Use<IMouseHook>()).Debug = true;
            mouse = mouseHook.MouseModel;

            (keyboardSimulation = Inputs.Use<IKeyboardSimulation>()).Debug = true;
            (mouseSimulation = Inputs.Use<IMouseSimulation>()).Debug = true;

            mouse.State += OnMouseState;

            _keyboard_input_types_box.Items.AddRange(new[] { "KeyClick", "KeyDown", "KeyUp" });
            _keyboard_input_types_box.SelectedIndex = 0;

            _is_keypressed_key_types_box.DataSource = _keyboard_key_types_box.DataSource = (InputKeys[])Enum.GetValues(typeof(InputKeys));
            _is_keypressed_key_types_box.SelectedIndex = _keyboard_input_types_box.SelectedIndex = 0;

            _mouse_button_types_box.DataSource = (InputMouseButtons[])Enum.GetValues(typeof(InputMouseButtons));
            _mouse_button_types_box.SelectedIndex = 0;

            _mouse_input_types_box.Items.AddRange(new[] { "Click", "Down", "Up" });
            _mouse_input_types_box.SelectedIndex = 0;
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
        IMouseSimulation mouseSimulation;

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

        private void OnCheckIsPressed(object sender, EventArgs e) {
            _ispressed_label.Text = keyboardSimulation.IsKeyDown((InputKeys)_is_keypressed_key_types_box.SelectedItem).ToString();
        }

        private void OnTestAreaMouseDown(object sender, MouseEventArgs e) {
            _test_area_box.BackColor = Color.Green;
            var ps = e.Location;
            var size = _test_area_box.Size;
            var center = new Point(size.Width / 2, size.Height / 2);
            _test_area_box.Text = $"{e.Button} 마우스가 눌렸습니다. {(e.Delta != 0 ? e.Delta : "")}\n 중앙으로부터 X:{center.X - ps.X}, Y: {center.Y - ps.Y} 떨어져있습니다.";
        }

        private void OnTestAreaMouseEnter(object sender, EventArgs e) {
            _test_area_box.BackColor = Color.Gray;
            _test_area_box.Text = $"마우스가 위에 있습니다.";
        }

        private void OnTestAreaMouseLeave(object sender, EventArgs e) {
            _test_area_box.BackColor = Color.Gray;
            _test_area_box.Text = $"마우스가 위에 없습니다.";
        }

        private void OnTestAreaMouseUp(object sender, MouseEventArgs e) {
            _test_area_box.BackColor = Color.Gray;
            //_test_area_box.Text = $"{e.Button} 마우스가 눌리지 않았습니다. {(e.Delta != 0 ? e.Delta : "")}";
        }

        private void OnMouseSimulation(object sender, EventArgs e) {
            var method = "";
            int x = 0, y = 0;
            var button = (InputMouseButtons)_mouse_button_types_box.SelectedItem;

            if(_mouse_set_test_area_box.Checked) {
                method += "Absolute";
                var _size = _test_area_box.Size;
                var rp = _test_area_box.PointToScreen(new(_size.Width / 2, _size.Height / 2));
                x = rp.X;
                y = rp.Y;
            } else {
                var pos_text = _mouse_position.Text;
                {
                    var sp = pos_text.Split(',');
                    if (string.IsNullOrWhiteSpace(pos_text) ||
                        sp.Length < 2 ||
                        !int.TryParse(sp[0], out x) ||
                        !int.TryParse(sp[1], out y)) {
                        MessageBox.Show("올바르지 않은 위치 값입니다. ex) 0,0");
                        return;
                    }
                }

                if (!_mouse_set_current_position.Checked)
                    method += "Absolute";
            }
            method += (string)_mouse_input_types_box.SelectedItem;

            var v_parmeters = GetType().GetMethod("_dummy_method_mouse_input")?.GetParameters();

            if (v_parmeters == null) {
                MessageBox.Show("대상 파라미터가 존재하지 않습니다.");
                return;
            }

            var i = 0;
            var methods = (from type in mouseSimulation.GetType().GetMethods()
                           where type.Name == method && Equals(v_parmeters, type.GetParameters())
                           select type).ToArray();

            if (methods.Length < 1) {
                MessageBox.Show("대상 매소드 존재하지 않습니다.");
                return;
            }


            methods[0].Invoke(mouseSimulation, new object[] { button, x, y });
        }

        bool Equals(ParameterInfo[] infos, ParameterInfo[] infos1) {
            if (infos.Length != infos1.Length) return false;
            for (int i = 0; i < infos.Length; i++)
                if(infos[i].ParameterType != infos1[i].ParameterType)
                    return false;
            return true;
        }

        public static void _dummy_method_mouse_input(InputMouseButtons button, int x, int y) {
            // 대충 중요한거니 지우면 안돼요~
        }
    }
}