namespace Input.Platforms.Windows {
    public sealed class WindowsMouseHook : IMouseHook {
        readonly WinAPI.LLMouseHook CallbackDelegate;
        IntPtr hookHandle;
        bool isHooking, isPaused, disposedValue;
        InputHookStatus hookStatus;

        [Obsolete]
        public WindowsMouseHook() {
            if (!Platform.IsWindows) throw new PlatformNotSupportedException();
            CallbackDelegate = new(HookProc);
            MouseModel = new();
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

                hookHandle = WinAPI.SetWindowsHookEx(WinAPI.WH_MOUSE_LL,
                    CallbackDelegate, WinAPI.LoadLibrary("user32"), 0);
                System.Diagnostics.Debug.WriteLine("Hooker for Windows started.");

                isHooking = true;
                hookStatus = InputHookStatus.Running;
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"Failed to start mouse hooker for windows.\n{ex}");
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
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex, $"Failed to stop mouse hooking for Windows.\n{ex}");
                isHooking = true;
                throw ex;
            }
        }

        int HookProc(int code, int wParam, ref WinAPI.MouseLLHookStruct lParam) {
            if (code >= 0 && !isPaused) {
                InputButtons button = wParam switch {
                    WinAPI.WM_LBUTTONDOWN => InputButtons.LeftMouseDown,
                    WinAPI.WM_LBUTTONUP => InputButtons.LeftMouseUp,
                    WinAPI.WM_LBUTTONDBLCLK => InputButtons.LeftDoubleClick,
                    WinAPI.WM_MOUSEMOVE => InputButtons.Move,
                    WinAPI.WM_MOUSEWHEEL => lParam.mouseData > 0 ? 
                                            InputButtons.WheelMoveUp : 
                                            lParam.mouseData < 0 ? 
                                            InputButtons.WheelMoveDown : 
                                            InputButtons.Wheel,

                    WinAPI.WM_RBUTTONDOWN => InputButtons.RightMouseDown,
                    WinAPI.WM_RBUTTONUP => InputButtons.RightMouseUp,
                    WinAPI.WM_MBUTTONDOWN => InputButtons.WheelDown,
                    WinAPI.WM_MBUTTONUP => InputButtons.WheelUp,
                    _ => 0
                };

                if (button != 0) {
                    var point = lParam.pt;

                    if (MouseModel?.SetState(button, point.x, point.y) == false)
                        return 1;
                }
            }
            return WinAPI.CallNextHookEx(hookHandle, code, wParam, ref lParam);
        }

        public bool Debug { get; set; }

        public MouseModel MouseModel { get; set; }

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
        /// 윈도우용 마우스 후커
        /// </summary>
        /// <exception cref="NotSupportedException" />
        public static WindowsMouseHook Create() =>
            new();

        public static int GetSupportPlatforms() => (int)Inputs.platform.windows;
    }
}
