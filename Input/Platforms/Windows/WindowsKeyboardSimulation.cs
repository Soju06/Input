namespace Input.Platforms.Windows {
    public class WindowsKeyboardSimulation : IKeyboardSimulation {
        bool disposedValue;

        public bool Debug { get; set; }

        public void Click(InputKeys key) {
            if (disposedValue)
                throw new ObjectDisposedException("this");
            if (key == InputKeys.None) return;

            var lkey = WinAPI.ConvetKey(key);
            if (lkey == WindowsKeys.None) return;

            WinAPI.SendInput(WinAPI.Keyboard(lkey, WinAPI.KeyboardInputFlags.KeyDown), 
                WinAPI.Keyboard(lkey, WinAPI.KeyboardInputFlags.KeyUp));
        }

        public void Click(params InputKeys[] keys) {
            if (disposedValue)
                throw new ObjectDisposedException("this");
            var keys_length = keys.Length;
            var lkeys = new WinAPI.Input[keys_length * 2];
            for (int i = 0; i < keys_length; i++) {
                var lkey = WinAPI.ConvetKey(keys[i]);
                lkeys[i] = WinAPI.Keyboard(lkey, WinAPI.KeyboardInputFlags.KeyDown);
                lkeys[keys_length + i] = WinAPI.Keyboard(lkey, WinAPI.KeyboardInputFlags.KeyUp);
            }
            WinAPI.SendInput(lkeys);
        }

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {

                }


                disposedValue = true;
            }
        }

        ~WindowsKeyboardSimulation() {
            Dispose(disposing: false);
        }

        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
