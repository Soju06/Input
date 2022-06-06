using System.Runtime.InteropServices;

namespace Input.Platforms.Windows {
    /// <summary>
    /// 윈도우용 후커
    /// </summary>
    public sealed class WindowsKeyboardHook : IKeyboardHook {
        readonly WinAPI.LLKeyboardHook CallbackDelegate;
        IntPtr hookHandle;
        bool isHooking, isPaused, disposedValue;
        InputHookStatus hookStatus;

        [Obsolete]
        public WindowsKeyboardHook() : this(true) {

        }

        WindowsKeyboardHook(bool _) {
            if (!Platform.IsWindows) throw new PlatformNotSupportedException();
            CallbackDelegate = new(HookProc);
            KeyboardModel = new();
        }

        public void HookStart() {
            if (disposedValue)
                throw new ObjectDisposedException("this");

            try {
                if (isPaused && isHooking) {
                    isPaused = false;
                    hookStatus = InputHookStatus.Running;
                    return;
                }

                if (isHooking) return;

                hookHandle = WinAPI.SetWindowsHookEx(WinAPI.WH_KEYBOARD_LL,
                    CallbackDelegate, WinAPI.LoadLibrary("user32"), 0);
                System.Diagnostics.Debug.WriteLine("Hooker for Windows started.");

                isHooking = true;
                hookStatus = InputHookStatus.Running;
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"Failed to start keyboard hooker for windows.\n{ex}");
                isHooking = false;
                hookStatus = InputHookStatus.Stopped;
                throw ex;
            }
        }

        public void HookPause() {
            isPaused = true;
            hookStatus = InputHookStatus.Paused;
        }

        public void HookStop() {
            try {
                if (!isHooking) return;
                WinAPI.UnhookWindowsHookEx(hookHandle);
                System.Diagnostics.Debug.WriteLine("Hooker for Windows has ended.");
                isPaused = false;
                isHooking = false;
                hookStatus = InputHookStatus.Stopped;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex, $"Failed to stop keyboard hooking for Windows.\n{ex}");
                isHooking = true;
                throw ex;
            }
        }

        int HookProc(int code, int wParam, ref WinAPI.KeyBoardLLHookStruct lParam) {
            if (code >= 0 && !isPaused) {
                var key = (WindowsKeys)lParam.vkCode;
                var state = wParam switch {
                    WinAPI.WM_KEYDOWN or WinAPI.WM_SYSKEYDOWN => InputKeyState.Down,
                    WinAPI.WM_KEYUP or WinAPI.WM_SYSKEYUP => InputKeyState.Up,
                    _ => (InputKeyState)0
                };
                if (key != 0) {
                    //var extended = (lParam.flags & WinAPI.KeyboardHookFlags.Extended) == WinAPI.KeyboardHookFlags.Extended;
                    var lkey = WinAPI.ConvetKey(key);
                    var flag = lParam.flags;

                    if ((flag & WinAPI.KeyboardHookFlags.Released) == WinAPI.KeyboardHookFlags.Released) {
                        flag &= ~WinAPI.KeyboardHookFlags.Released;
                        state |= InputKeyState.Up;
                    }
                    
                    state |= (InputKeyState)flag;

                    if (KeyboardModel?.SetState(lkey, state) == false)
                        return 1;
                }
            } return WinAPI.CallNextHookEx(hookHandle, code, wParam, ref lParam);
        }

        public KeyboardModel KeyboardModel { get; set; }
        public bool Debug { get; set; }

        public InputHookStatus HookStatus => hookStatus;

        public bool IsRunning => isHooking;

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

        /// <summary>
        /// 윈도우용 키보드 후커
        /// </summary>
        /// <exception cref="NotSupportedException" />
        public static WindowsKeyboardHook Create() =>
            new(true);

        public static int GetSupportPlatforms() => (int)Inputs.platform.windows;
    }
}