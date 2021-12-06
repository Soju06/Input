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
                    var extended = (lParam.flags & WinAPI.KeyboardHookFlags.Extended) == WinAPI.KeyboardHookFlags.Extended;
                    var lkey = WinAPI.ConvetKey(key);
                    
                    if (!extended || lkey == 0)
                        lkey = key switch {
                            #region Keys Convert
                            WindowsKeys.None => InputKeys.None,
                            WindowsKeys.Back => InputKeys.Backspace,
                            WindowsKeys.Tab => InputKeys.Tab,
                            WindowsKeys.Clear => InputKeys.Clear,
                            WindowsKeys.Enter => InputKeys.Enter,
                            WindowsKeys.ShiftKey => InputKeys.Shift,
                            WindowsKeys.ControlKey => InputKeys.Control,
                            WindowsKeys.Menu => InputKeys.ContextMenu,
                            WindowsKeys.Pause => InputKeys.Pause,
                            WindowsKeys.CapsLock => InputKeys.CapsLock,
                            WindowsKeys.Escape => InputKeys.Escape,
                            WindowsKeys.Space => InputKeys.Space,
                            WindowsKeys.PageUp => InputKeys.PageUp,
                            WindowsKeys.PageDown => InputKeys.PageDown,
                            WindowsKeys.End => InputKeys.End,
                            WindowsKeys.Home => InputKeys.Home,
                            WindowsKeys.Left => InputKeys.Left,
                            WindowsKeys.Up => InputKeys.Up,
                            WindowsKeys.Right => InputKeys.Right,
                            WindowsKeys.Down => InputKeys.Down,
                            WindowsKeys.PrintScreen => InputKeys.PrintScreen,
                            WindowsKeys.Insert => InputKeys.Insert,
                            WindowsKeys.Delete => InputKeys.Delete,
                            WindowsKeys.Help => InputKeys.Help,
                            WindowsKeys.D0 => InputKeys.D0,
                            WindowsKeys.D1 => InputKeys.D1,
                            WindowsKeys.D2 => InputKeys.D2,
                            WindowsKeys.D3 => InputKeys.D3,
                            WindowsKeys.D4 => InputKeys.D4,
                            WindowsKeys.D5 => InputKeys.D5,
                            WindowsKeys.D6 => InputKeys.D6,
                            WindowsKeys.D7 => InputKeys.D7,
                            WindowsKeys.D8 => InputKeys.D8,
                            WindowsKeys.D9 => InputKeys.D9,
                            WindowsKeys.A => InputKeys.A,
                            WindowsKeys.B => InputKeys.B,
                            WindowsKeys.C => InputKeys.C,
                            WindowsKeys.D => InputKeys.D,
                            WindowsKeys.E => InputKeys.E,
                            WindowsKeys.F => InputKeys.F,
                            WindowsKeys.G => InputKeys.G,
                            WindowsKeys.H => InputKeys.H,
                            WindowsKeys.I => InputKeys.I,
                            WindowsKeys.J => InputKeys.J,
                            WindowsKeys.K => InputKeys.K,
                            WindowsKeys.L => InputKeys.L,
                            WindowsKeys.M => InputKeys.M,
                            WindowsKeys.N => InputKeys.N,
                            WindowsKeys.O => InputKeys.O,
                            WindowsKeys.P => InputKeys.P,
                            WindowsKeys.Q => InputKeys.Q,
                            WindowsKeys.R => InputKeys.R,
                            WindowsKeys.S => InputKeys.S,
                            WindowsKeys.T => InputKeys.T,
                            WindowsKeys.U => InputKeys.U,
                            WindowsKeys.V => InputKeys.V,
                            WindowsKeys.W => InputKeys.W,
                            WindowsKeys.X => InputKeys.X,
                            WindowsKeys.Y => InputKeys.Y,
                            WindowsKeys.Z => InputKeys.Z,
                            WindowsKeys.LWin => InputKeys.LeftApplication,
                            WindowsKeys.RWin => InputKeys.RightApplication,
                            WindowsKeys.Apps => InputKeys.Application,
                            WindowsKeys.Sleep => 0,
                            WindowsKeys.NumPad0 => InputKeys.Numpad0,
                            WindowsKeys.NumPad1 => InputKeys.Numpad1,
                            WindowsKeys.NumPad2 => InputKeys.Numpad2,
                            WindowsKeys.NumPad3 => InputKeys.Numpad3,
                            WindowsKeys.NumPad4 => InputKeys.Numpad4,
                            WindowsKeys.NumPad5 => InputKeys.Numpad5,
                            WindowsKeys.NumPad6 => InputKeys.Numpad6,
                            WindowsKeys.NumPad7 => InputKeys.Numpad7,
                            WindowsKeys.NumPad8 => InputKeys.Numpad8,
                            WindowsKeys.NumPad9 => InputKeys.Numpad9,
                            WindowsKeys.Multiply => InputKeys.Multiply,
                            WindowsKeys.Subtract => InputKeys.Subtract,
                            WindowsKeys.Decimal => InputKeys.Decimal,
                            WindowsKeys.Divide => InputKeys.Divide,
                            WindowsKeys.F1 => InputKeys.F1,
                            WindowsKeys.F2 => InputKeys.F2,
                            WindowsKeys.F3 => InputKeys.F3,
                            WindowsKeys.F4 => InputKeys.F4,
                            WindowsKeys.F5 => InputKeys.F5,
                            WindowsKeys.F6 => InputKeys.F6,
                            WindowsKeys.F7 => InputKeys.F7,
                            WindowsKeys.F8 => InputKeys.F8,
                            WindowsKeys.F9 => InputKeys.F9,
                            WindowsKeys.F10 => InputKeys.F10,
                            WindowsKeys.F11 => InputKeys.F11,
                            WindowsKeys.F12 => InputKeys.F12,
                            WindowsKeys.F13 => InputKeys.F13,
                            WindowsKeys.F14 => InputKeys.F14,
                            WindowsKeys.F15 => InputKeys.F15,
                            WindowsKeys.F16 => InputKeys.F16,
                            WindowsKeys.F17 => InputKeys.F17,
                            WindowsKeys.F18 => InputKeys.F18,
                            WindowsKeys.F19 => InputKeys.F19,
                            WindowsKeys.F20 => InputKeys.F20,
                            WindowsKeys.F21 => InputKeys.F21,
                            WindowsKeys.F22 => InputKeys.F22,
                            WindowsKeys.F23 => InputKeys.F23,
                            WindowsKeys.F24 => InputKeys.F24,
                            WindowsKeys.NumLock => InputKeys.NumberLock,
                            WindowsKeys.Scroll => InputKeys.ScrollLock,
                            WindowsKeys.LShiftKey => InputKeys.LeftShift,
                            WindowsKeys.RShiftKey => InputKeys.RightShift,
                            WindowsKeys.LControlKey => InputKeys.LeftControl,
                            WindowsKeys.RControlKey => InputKeys.RightControl,
                            WindowsKeys.LMenu => InputKeys.LeftAlt,
                            WindowsKeys.RMenu => InputKeys.RightAlt,
                            WindowsKeys.OemSemicolon => InputKeys.Semicolon,
                            WindowsKeys.Oemplus => InputKeys.Add,
                            WindowsKeys.Oemcomma => InputKeys.Comma,
                            WindowsKeys.OemMinus => InputKeys.Minus,
                            WindowsKeys.OemPeriod => InputKeys.Period,
                            WindowsKeys.OemOpenBrackets => InputKeys.LeftBracket,
                            WindowsKeys.OemCloseBrackets => InputKeys.RightBracket,
                            WindowsKeys.OemQuotes => InputKeys.Quote,
                            WindowsKeys.OemBackslash => InputKeys.Backslash,
                            WindowsKeys.OemClear => InputKeys.Clear,
                            _ => 0
                            #endregion
                        };

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