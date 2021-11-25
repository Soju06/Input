namespace Input.Platforms.Windows {
    public class WindowsKeyboardSimulation : IKeyboardSimulation {
        bool disposedValue;
        readonly ScanCodeMap scanCode_map;

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

        public static int GetSupportPlatforms() => (int)Input.platform.windows;
    }
}
