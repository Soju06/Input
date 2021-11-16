namespace InputHook.Platforms.Windows {
    public sealed class WindowsMouseHook : IInputHook {
        readonly WinAPI.LLMouseHook CallbackDelegate;
        IntPtr hookHandle;
        bool isHooking, isPaused, disposedValue;

        public WindowsMouseHook() {
            if (!Platform.IsWindows) throw new PlatformNotSupportedException();
            CallbackDelegate = new(HookProc);
        }

        public void HookStart() {
            try {
                isPaused = false;
                if (isHooking) return;
                hookHandle = WinAPI.SetWindowsHookEx(WinAPI.WH_MOUSE_LL,
                    CallbackDelegate, WinAPI.LoadLibrary("user32"), 0);
                System.Diagnostics.Debug.WriteLine("Hooker for Windows started.");
                isHooking = true;
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"Failed to start mouse hooker for windows.\n{ex}");
                isHooking = false;
            }
        }

        public void HookPause() {
            isPaused = true;
        }

        public void HookStop() {
            try {
                if (!isHooking) return;
                WinAPI.UnhookWindowsHookEx(hookHandle);
                System.Diagnostics.Debug.WriteLine("Hooker for Windows has ended.");
                isPaused = true;
                isHooking = false;
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex, $"Failed to stop mouse hooking for Windows.\n{ex}");
                isHooking = true;
            }
        }

        int HookProc(int code, int wParam, ref WinAPI.MouseHookStruct lParam) {
            if (code >= 0 && !isPaused) {
                
            }
            return WinAPI.CallNextHookEx(hookHandle, code, wParam, ref lParam);
        }

        public bool Debug { get; set; }

        private void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {

                }

                try {
                    HookStop();
                } catch {

                }
                disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
