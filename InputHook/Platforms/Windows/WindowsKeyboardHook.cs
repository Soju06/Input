using System.Runtime.InteropServices;

namespace InputHook.Platforms.Windows {
    /// <summary>
    /// 윈도우용 후커
    /// </summary>
    public sealed class WindowsKeyboardHook : IKeyboardHook {
        /// <summary>
        /// 로우 레벨 후킹
        /// </summary>
        public const bool LowLevelHook = true;

        readonly WinAPI.LLKeyboardHook CallbackDelegate;
        IntPtr hookHandle;
        bool isHooking, isPaused, disposedValue;

        public WindowsKeyboardHook() {
            if (!Platform.IsWindows) throw new PlatformNotSupportedException();
            CallbackDelegate = new(HookProc);
        }

        public void HookStart() {
            try {
                isPaused = false;
                if (isHooking) return;
                hookHandle = WinAPI.SetWindowsHookEx(LowLevelHook ? WinAPI.WH_KEYBOARD_LL : WinAPI.WH_KEYBOARD,
                    CallbackDelegate, WinAPI.LoadLibrary("user32"), 0);
                System.Diagnostics.Debug.WriteLine("Hooker for Windows started.");
                //(ApplicationLoop = new()).Start();
                isHooking = true;
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"Failed to start keyboard hooker for windows.\n{ex}");
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
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex, $"Failed to stop keyboard hooking for Windows.\n{ex}");
                isHooking = true;
            }
        }

        int HookProc(int code, int wParam, ref WinAPI.KeyBoardHookStruct lParam) {
            if (code >= 0 && !isPaused) {
                var key = (WindowsKeys)lParam.vkCode;
                var state = wParam switch {
                    WinAPI.WM_KEYDOWN or WinAPI.WM_SYSKEYDOWN => InputKeyState.Down,
                    WinAPI.WM_KEYUP or WinAPI.WM_SYSKEYUP or _ => InputKeyState.Released
                };
                if (key != 0) {
                    var extended = (lParam.flags & WinAPI.KeyboardHookFlags.Extended) == WinAPI.KeyboardHookFlags.Extended;
                    InputKeys lkey = key switch {
                        WindowsKeys.D0 => InputKeys.Numpad0,
                        WindowsKeys.D1 => InputKeys.Numpad1,
                        WindowsKeys.D2 => InputKeys.Numpad2,
                        WindowsKeys.D3 => InputKeys.Numpad3,
                        WindowsKeys.D4 => InputKeys.Numpad4,
                        WindowsKeys.D5 => InputKeys.Numpad5,
                        WindowsKeys.D6 => InputKeys.Numpad6,
                        WindowsKeys.D7 => InputKeys.Numpad7,
                        WindowsKeys.D8 => InputKeys.Numpad8,
                        WindowsKeys.D9 => InputKeys.Numpad9,
                        WindowsKeys.Enter => InputKeys.NumpadEnter,
                        _ => 0
                    };
                    
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

                    state |= (InputKeyState)flag;

                    if (KeyboardModel?.SetState(lkey, state) == false)
                        return 1;
                }
            } return WinAPI.CallNextHookEx(hookHandle, code, wParam, ref lParam);
        }

        public KeyboardModel KeyboardModel { get; set; }
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

    [Flags]
    public enum WindowsKeys : byte {
        /// <summary>No key pressed.</summary>
        None = 0,
        /// <summary>The left mouse button.</summary>
        LButton = 1,
        /// <summary>The right mouse button.</summary>
        RButton = 2,
        /// <summary>The CANCEL key.</summary>
        Cancel = 3,
        /// <summary>The middle mouse button (three-button mouse).</summary>
        MButton = 4,
        /// <summary>The first x mouse button (five-button mouse).</summary>
        XButton1 = 5,
        /// <summary>The second x mouse button (five-button mouse).</summary>
        XButton2 = 6,
        /// <summary>The BACKSPACE key.</summary>
        Back = 8,
        /// <summary>The TAB key.</summary>
        Tab = 9,
        /// <summary>The LINEFEED key.</summary>
        LineFeed = 10,
        /// <summary>The CLEAR key.</summary>
        Clear = 12,
        ///// <summary>The RETURN key.</summary>
        //Return = 13,
        /// <summary>The ENTER key.</summary>
        Enter = 13,
        /// <summary>The SHIFT key.</summary>
        ShiftKey = 16,
        /// <summary>The CTRL key.</summary>
        ControlKey = 17,
        /// <summary>The ALT key.</summary>
        Menu = 18,
        /// <summary>The PAUSE key.</summary>
        Pause = 19,
        ///// <summary>The CAPS LOCK key.</summary>
        //Capital = 20,
        /// <summary>The CAPS LOCK key.</summary>
        CapsLock = 20,
        ///// <summary>The IME Kana mode key.</summary>
        //KanaMode = 21,
        ///// <summary>The IME Hanguel mode key.</summary> (maintained for compatibility; use HangulMode)
        //HanguelMode = 21,
        /// <summary>The IME Hangul mode key.</summary>
        HangulMode = 21,
        /// <summary>The IME Junja mode key.</summary>
        JunjaMode = 23,
        /// <summary>The IME final mode key.</summary>
        FinalMode = 24,
        /// <summary>The IME Hanja mode key.</summary>
        HanjaMode = 25,
        ///// <summary>The IME Kanji mode key.</summary>
        //KanjiMode = 25,
        /// <summary>The ESC key.</summary>
        Escape = 27,
        /// <summary>The IME convert key.</summary>
        IMEConvert = 28,
        /// <summary>The IME nonconvert key.</summary>
        IMENonconvert = 29,
        /// <summary>The IME accept key, replaces System.</summary>Windows.</summary>Forms.</summary>Keys.</summary>IMEAceept.</summary>
        IMEAccept = 30,
        ///// <summary>The IME accept key.</summary> Obsolete, use System.</summary>Windows.</summary>Forms.</summary>Keys.</summary>IMEAccept instead.</summary>
        //IMEAceept = 30,
        /// <summary>The IME mode change key.</summary>
        IMEModeChange = 31,
        /// <summary>The SPACEBAR key.</summary>
        Space = 32,
        ///// <summary>The PAGE UP key.</summary>
        //Prior = 33,
        /// <summary>The PAGE UP key.</summary>
        PageUp = 33,
        ///// <summary>The PAGE DOWN key.</summary>
        //Next = 34,
        /// <summary>The PAGE DOWN key.</summary>
        PageDown = 34,
        /// <summary>The END key.</summary>
        End = 35,
        /// <summary>The HOME key.</summary>
        Home = 36,
        /// <summary>The LEFT ARROW key.</summary>
        Left = 37,
        /// <summary>The UP ARROW key.</summary>
        Up = 38,
        /// <summary>The RIGHT ARROW key.</summary>
        Right = 39,
        /// <summary>The DOWN ARROW key.</summary>
        Down = 40,
        /// <summary>The SELECT key.</summary>
        Select = 41,
        /// <summary>The PRINT key.</summary>
        Print = 42,
        /// <summary>The EXECUTE key.</summary>
        Execute = 43,
        ///// <summary>The PRINT SCREEN key.</summary>
        //Snapshot = 44,
        /// <summary>The PRINT SCREEN key.</summary>
        PrintScreen = 44,
        /// <summary>The INS key.</summary>
        Insert = 45,
        /// <summary>The DEL key.</summary>
        Delete = 46,
        /// <summary>The HELP key.</summary>
        Help = 47,
        /// <summary>The 0 key.</summary>
        D0 = 48,
        /// <summary>The 1 key.</summary>
        D1 = 49,
        /// <summary>The 2 key.</summary>
        D2 = 50,
        /// <summary>The 3 key.</summary>
        D3 = 51,
        /// <summary>The 4 key.</summary>
        D4 = 52,
        /// <summary>The 5 key.</summary>
        D5 = 53,
        /// <summary>The 6 key.</summary>
        D6 = 54,
        /// <summary>The 7 key.</summary>
        D7 = 55,
        /// <summary>The 8 key.</summary>
        D8 = 56,
        /// <summary>The 9 key.</summary>
        D9 = 57,
        /// <summary>The A key.</summary>
        A = 65,
        /// <summary>The B key.</summary>
        B = 66,
        /// <summary>The C key.</summary>
        C = 67,
        /// <summary>The D key.</summary>
        D = 68,
        /// <summary>The E key.</summary>
        E = 69,
        /// <summary>The F key.</summary>
        F = 70,
        /// <summary>The G key.</summary>
        G = 71,
        /// <summary>The H key.</summary>
        H = 72,
        /// <summary>The I key.</summary>
        I = 73,
        /// <summary>The J key.</summary>
        J = 74,
        /// <summary>The K key.</summary>
        K = 75,
        /// <summary>The L key.</summary>
        L = 76,
        /// <summary>The M key.</summary>
        M = 77,
        /// <summary>The N key.</summary>
        N = 78,
        /// <summary>The O key.</summary>
        O = 79,
        /// <summary>The P key.</summary>
        P = 80,
        /// <summary>The Q key.</summary>
        Q = 81,
        /// <summary>The R key.</summary>
        R = 82,
        /// <summary>The S key.</summary>
        S = 83,
        /// <summary>The T key.</summary>
        T = 84,
        /// <summary>The U key.</summary>
        U = 85,
        /// <summary>The V key.</summary>
        V = 86,
        /// <summary>The W key.</summary>
        W = 87,
        /// <summary>The X key.</summary>
        X = 88,
        /// <summary>The Y key.</summary>
        Y = 89,
        /// <summary>The Z key.</summary>
        Z = 90,
        /// <summary>The left Windows logo key (Microsoft Natural Keyboard).</summary>
        LWin = 91,
        /// <summary>The right Windows logo key (Microsoft Natural Keyboard).</summary>
        RWin = 92,
        /// <summary>The application key (Microsoft Natural Keyboard).</summary>
        Apps = 93,
        /// <summary>The computer sleep key.</summary>
        Sleep = 95,
        /// <summary>The 0 key on the numeric keypad.</summary>
        NumPad0 = 96,
        /// <summary>The 1 key on the numeric keypad.</summary>
        NumPad1 = 97,
        /// <summary>The 2 key on the numeric keypad.</summary>
        NumPad2 = 98,
        /// <summary>The 3 key on the numeric keypad.</summary>
        NumPad3 = 99,
        /// <summary>The 4 key on the numeric keypad.</summary>
        NumPad4 = 100,
        /// <summary>The 5 key on the numeric keypad.</summary>
        NumPad5 = 101,
        /// <summary>The 6 key on the numeric keypad.</summary>
        NumPad6 = 102,
        /// <summary>The 7 key on the numeric keypad.</summary>
        NumPad7 = 103,
        /// <summary>The 8 key on the numeric keypad.</summary>
        NumPad8 = 104,
        /// <summary>The 9 key on the numeric keypad.</summary>
        NumPad9 = 105,
        /// <summary>The multiply key.</summary>
        Multiply = 106,
        /// <summary>The add key.</summary>
        Add = 107,
        /// <summary>The separator key.</summary>
        Separator = 108,
        /// <summary>The subtract key.</summary>
        Subtract = 109,
        /// <summary>The decimal key.</summary>
        Decimal = 110,
        /// <summary>The divide key.</summary>
        Divide = 111,
        /// <summary>The F1 key.</summary>
        F1 = 112,
        /// <summary>The F2 key.</summary>
        F2 = 113,
        /// <summary>The F3 key.</summary>
        F3 = 114,
        /// <summary>The F4 key.</summary>
        F4 = 115,
        /// <summary>The F5 key.</summary>
        F5 = 116,
        /// <summary>The F6 key.</summary>
        F6 = 117,
        /// <summary>The F7 key.</summary>
        F7 = 118,
        /// <summary>The F8 key.</summary>
        F8 = 119,
        /// <summary>The F9 key.</summary>
        F9 = 120,
        /// <summary>The F10 key.</summary>
        F10 = 121,
        /// <summary>The F11 key.</summary>
        F11 = 122,
        /// <summary>The F12 key.</summary>
        F12 = 123,
        /// <summary>The F13 key.</summary>
        F13 = 124,
        /// <summary>The F14 key.</summary>
        F14 = 125,
        /// <summary>The F15 key.</summary>
        F15 = 126,
        /// <summary>The F16 key.</summary>
        F16 = 127,
        /// <summary>The F17 key.</summary>
        F17 = 128,
        /// <summary>The F18 key.</summary>
        F18 = 129,
        /// <summary>The F19 key.</summary>
        F19 = 130,
        /// <summary>The F20 key.</summary>
        F20 = 131,
        /// <summary>The F21 key.</summary>
        F21 = 132,
        /// <summary>The F22 key.</summary>
        F22 = 133,
        /// <summary>The F23 key.</summary>
        F23 = 134,
        /// <summary>The F24 key.</summary>
        F24 = 135,
        /// <summary>The NUM LOCK key.</summary>
        NumLock = 144,
        /// <summary>The SCROLL LOCK key.</summary>
        Scroll = 145,
        /// <summary>The left SHIFT key.</summary>
        LShiftKey = 160,
        /// <summary>The right SHIFT key.</summary>
        RShiftKey = 161,
        /// <summary>The left CTRL key.</summary>
        LControlKey = 162,
        /// <summary>The right CTRL key.</summary>
        RControlKey = 163,
        /// <summary>The left ALT key.</summary>
        LMenu = 164,
        /// <summary>The right ALT key.</summary>
        RMenu = 165,
        /// <summary>The browser back key.</summary>
        BrowserBack = 166,
        /// <summary>The browser forward key.</summary>
        BrowserForward = 167,
        /// <summary>The browser refresh key.</summary>
        BrowserRefresh = 168,
        /// <summary>The browser stop key.</summary>
        BrowserStop = 169,
        /// <summary>The browser search key.</summary>
        BrowserSearch = 170,
        /// <summary>The browser favorites key.</summary>
        BrowserFavorites = 171,
        /// <summary>The browser home key.</summary>
        BrowserHome = 172,
        /// <summary>The volume mute key.</summary>
        VolumeMute = 173,
        /// <summary>The volume down key.</summary>
        VolumeDown = 174,
        /// <summary>The volume up key.</summary>
        VolumeUp = 175,
        /// <summary>The media next track key.</summary>
        MediaNextTrack = 176,
        /// <summary>The media previous track key.</summary>
        MediaPreviousTrack = 177,
        /// <summary>The media Stop key.</summary>
        MediaStop = 178,
        /// <summary>The media play pause key.</summary>
        MediaPlayPause = 179,
        /// <summary>The launch mail key.</summary>
        LaunchMail = 180,
        /// <summary>The select media key.</summary>
        SelectMedia = 181,
        /// <summary>The start application one key.</summary>
        LaunchApplication1 = 182,
        /// <summary>The start application two key.</summary>
        LaunchApplication2 = 183,
        /// <summary>The OEM Semicolon key on a US standard keyboard.</summary>
        OemSemicolon = 186,
        ///// <summary>The OEM 1 key.</summary>
        //Oem1 = 186,
        /// <summary>The OEM plus key on any country/region keyboard.</summary>
        Oemplus = 187,
        /// <summary>The OEM comma key on any country/region keyboard.</summary>
        Oemcomma = 188,
        /// <summary>The OEM minus key on any country/region keyboard.</summary>
        OemMinus = 189,
        /// <summary>The OEM period key on any country/region keyboard.</summary>
        OemPeriod = 190,
        /// <summary>The OEM question mark key on a US standard keyboard.</summary>
        OemQuestion = 191,
        ///// <summary>The OEM 2 key.</summary>
        //Oem2 = 191,
        /// <summary>The OEM tilde key on a US standard keyboard.</summary>
        Oemtilde = 192,
        ///// <summary>The OEM 3 key.</summary>
        //Oem3 = 192,
        /// <summary>The OEM open bracket key on a US standard keyboard.</summary>
        OemOpenBrackets = 219,
        /// <summary>The OEM pipe key on a US standard keyboard.</summary>
        OemPipe = 220,
        ///// <summary>The OEM 5 key.</summary>
        //Oem5 = 220,
        /// <summary>The OEM close bracket key on a US standard keyboard.</summary>
        OemCloseBrackets = 221,
        ///// <summary>The OEM 6 key.</summary>
        //Oem6 = 221,
        /// <summary>The OEM singled/double quote key on a US standard keyboard.</summary>
        OemQuotes = 222,
        ///// <summary>The OEM 7 key.</summary>
        //Oem7 = 222,
        /// <summary>The OEM 8 key.</summary>
        Oem8 = 223,
        /// <summary>The OEM angle bracket or backslash key on the RT 102 key keyboard.</summary>
        OemBackslash = 226,
        ///// <summary>The OEM 102 key.</summary>
        //Oem102 = 226,
        /// <summary>The PROCESS KEY key.</summary>
        ProcessKey = 229,
        /// <summary>
        /// Used to pass Unicode characters as if they were keystrokes.</summary> The Packet key value
        /// is the low word of a 32-bit virtual-key value used for non-keyboard input methods.
        /// </summary>
        Packet = 231,
        /// <summary>The ATTN key.</summary>
        Attn = 246,
        /// <summary>The CRSEL key.</summary>
        Crsel = 247,
        /// <summary>The EXSEL key.</summary>
        Exsel = 248,
        /// <summary>The ERASE EOF key.</summary>
        EraseEof = 249,
        /// <summary>The PLAY key.</summary>
        Play = 250,
        /// <summary>The ZOOM key.</summary>
        Zoom = 251,
        /// <summary>A constant reserved for future use.</summary>
        NoName = 252,
        /// <summary>The PA1 key.</summary>
        Pa1 = 253,
        /// <summary>The CLEAR key.</summary>
        OemClear = 254,
    }
}