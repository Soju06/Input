namespace Input.Platforms.Windows {
    public class WindowsKeyboardSimulation : IKeyboardSimulation {
        bool disposedValue;
        readonly ScanCodeMap scanCode_map;

        public uint MaxTextEntryLength => ushort.MaxValue / 2;

        [Obsolete]
        public WindowsKeyboardSimulation() : this(true) {

        }

        public WindowsKeyboardSimulation(bool _) {
            scanCode_map = ScanCodeMap.Create();
        }

        public bool Debug { get; set; }

        public void KeyClick(InputKeys key) =>
            KeyClick(keys: key);

        public void KeyClick(params InputKeys[] keys) {
            if (disposedValue)
                throw new ObjectDisposedException("this");

            var keys_length = keys.Length;
            var lkeys = new WinAPI.Input[keys_length * 2];

            for (int i = 0; i < keys_length; i++) {
                var input = CreateInput(WinAPI.ConvetKey(keys[i]));
                var d_input = input;

                d_input.u.ki.dwFlags |= WinAPI.KeyboardInputFlags.KeyDown;
                lkeys[i] = d_input;

                input.u.ki.dwFlags |= WinAPI.KeyboardInputFlags.KeyUp;
                lkeys[keys_length + i] = input;
            }
            WinAPI.SendInput(lkeys);
        }

        public void KeyDown(InputKeys key) =>
            KeyDown(keys: key);

        public void KeyDown(params InputKeys[] keys) =>
            xInput(keys, WinAPI.KeyboardInputFlags.KeyDown);

        public void KeyUp(InputKeys key) =>
            KeyUp(keys: key);

        public void KeyUp(params InputKeys[] keys) =>
            xInput(keys, WinAPI.KeyboardInputFlags.KeyUp);

        public void TextEntry(string text) {
            if (text.Length > ushort.MaxValue / 2) throw new ArgumentOutOfRangeException(nameof(text), $"텍스트 길이가 너무 깁니다. 최대 길이는 {MaxTextEntryLength}입니다.");
            var length = text.Length;

            var inputs = new WinAPI.Input[length * 2];

            for (int i = 0; i < length; i++) {
                var _char = text[i];
                inputs[i * 2] = CreateInput(_char, false);
                inputs[i * 2 + 1] = CreateInput(_char, true);
            }

            WinAPI.SendInput(inputs);
        }

        public void ReleaseAllKeys() {
            var keys = (WindowsKeys[])Enum.GetValues(typeof(WindowsKeys));
            if (disposedValue)
                throw new ObjectDisposedException("this");

            var keys_length = keys.Length;
            var lkeys = new WinAPI.Input[keys_length];

            for (int i = 0; i < keys_length; i++) {
                var input = CreateInput(keys[i]);
                var d_input = input;

                d_input.u.ki.dwFlags |= WinAPI.KeyboardInputFlags.KeyUp;
                lkeys[i] = d_input;
            }
            WinAPI.SendInput(lkeys);
        }

        public bool IsKeyDown(InputKeys keys) =>
            WinAPI.GetAsyncKeyState((ushort)WinAPI.ConvetKey(keys)) < 0;

        void xInput(InputKeys[] keys, WinAPI.KeyboardInputFlags flags) {
            if (disposedValue)
                throw new ObjectDisposedException("this");

            var keys_length = keys.Length;
            var lkeys = new WinAPI.Input[keys_length];

            for (int i = 0; i < keys_length; i++) {
                var input = CreateInput(WinAPI.ConvetKey(keys[i]));
                var d_input = input;

                d_input.u.ki.dwFlags |= flags;
                lkeys[i] = d_input;
            }
            WinAPI.SendInput(lkeys);
        }


        WinAPI.Input CreateInput(char code, bool isDown) {
            return new() {
                type = WinAPI.InputType.Keyboard,
                u = new() {
                    ki = new() {
                        wVk = 0,
                        wScan = code,
                        dwFlags = WinAPI.KeyboardInputFlags.Unicode |
                                  ((code & 0xFF00) == 0xE000 ? WinAPI.KeyboardInputFlags.ExtendedKey : 0) |
                                  (!isDown ? WinAPI.KeyboardInputFlags.KeyUp : 0),
                        time = 0,
                        dwExtraInfo = UIntPtr.Zero,
                    }
                }
            };
        }

        WinAPI.Input CreateInput(WindowsKeys lkey) {
            return new() {
                type = WinAPI.InputType.Keyboard,
                u = new() {
                    ki = new() {
                        wVk = lkey,
                        wScan = scanCode_map.GetScanCode(lkey),
                        dwFlags = lkey.IsExtendedKey() ? WinAPI.KeyboardInputFlags.ExtendedKey : 0,
                        time = 0,
                        dwExtraInfo = UIntPtr.Zero,
                    }
                }
            };
        }

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {

                }


                disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 윈도우용 키보드 시뮬레이션
        /// </summary>
        /// <exception cref="NotSupportedException" />
        public static WindowsKeyboardSimulation Create() =>
            new(true);

        public static int GetSupportPlatforms() => (int)Inputs.platform.windows;
    }
}
