namespace Input {
	/// <summary>
	/// 키 상태
	/// </summary>
	[Flags]
	public enum InputKeyState : byte {
		/// <summary>
		/// 키 뗌
		/// </summary>
		Up = 0x50,
		/// <summary>
		/// 키 눌림
		/// </summary>
		Down = 0x02,
		/// <summary>
		/// 확장 키
		/// </summary>
		Extended = 0x01,
		/// <summary>
		/// 외부 키
		/// </summary>
		Injected = 0x10,
		/// <summary>
		/// Alt 눌림
		/// </summary>
		AltPressed = 0x20
	}

    /// <summary>
    /// 키
    /// </summary>
    public enum InputKeys : byte {
        /// <summary>No key</summary>
        None = 0x00,

        /// <summary>The A key</summary>
        A = 0x01,
        /// <summary>The B key</summary>
        B = 0x02,
        /// <summary>The C key</summary>
        C = 0x03,
        /// <summary>The D key</summary>
        D = 0x04,
		/// <summary>The E key</summary>
		E = 0x05,
		/// <summary>The F key</summary>
		F = 0x06,
		/// <summary>The G key</summary>
		G = 0x07,
		/// <summary>The H key</summary>
		H = 0x08,
		/// <summary>The I key</summary>
		I = 0x09,
		/// <summary>The J key</summary>
		J = 0x0A,
		/// <summary>The K key</summary>
		K = 0x0B,
		/// <summary>The L key</summary>
		L = 0x0C,
		/// <summary>The M key</summary>
		M = 0x0D,
		/// <summary>The N key</summary>
		N = 0x0E,
		/// <summary>The O key</summary>
		O = 0x0F,
		/// <summary>The P key</summary>
		P = 0x10,
		/// <summary>The Q key</summary>
		Q = 0x11,
		/// <summary>The R key</summary>
		R = 0x12,
		/// <summary>The S key</summary>
		S = 0x13,
		/// <summary>The T key</summary>
		T = 0x14,
		/// <summary>The U key</summary>
		U = 0x15,
		/// <summary>The V key</summary>
		V = 0x16,
		/// <summary>The W key</summary>
		W = 0x17,
		/// <summary>The X key</summary>
		X = 0x18,
		/// <summary>The Y key</summary>
		Y = 0x19,
		/// <summary>The Z key</summary>
		Z = 0x1A,
		/// <summary>The F1 key</summary>
		F1 = 0x1B,
		/// <summary>The F2 key</summary>
		F2 = 0x1C,
		/// <summary>The F3 key</summary>
		F3 = 0x1D,
		/// <summary>The F4 key</summary>
		F4 = 0x1E,
		/// <summary>The F5 key</summary>
		F5 = 0x1F,
		/// <summary>The F6 key</summary>
		F6 = 0x20,
		/// <summary>The F7 key</summary>
		F7 = 0x21,

		// moved
		//F8 = 0x22,

		/// <summary>The F9 key</summary>
		F9 = 0x23,
		/// <summary>The F10 key</summary>
		F10 = 0x24,
		/// <summary>The F11 key</summary>
		F11 = 0x25,
		/// <summary>The F12 key</summary>
		F12 = 0x26,
		/// <summary>The 0 digit key</summary>
		D0 = 0x27,
		/// <summary>The 1 digit key</summary>
		D1 = 0x28,
		/// <summary>The 2 digit key</summary>
		D2 = 0x29,
		/// <summary>The 3 digit key</summary>
		D3 = 0x2A,
		/// <summary>The 4 digit key</summary>
		D4 = 0x2B,
		/// <summary>The 5 digit key</summary>
		D5 = 0x2C,
		/// <summary>The 6 digit key</summary>
		D6 = 0x2D,
		/// <summary>The 7 digit key</summary>
		D7 = 0x2E,
		/// <summary>The 8 digit key</summary>
		D8 = 0x2F,
		/// <summary>The 9 digit key</summary>
		D9 = 0x30,

		/// <summary>The Minus '-' key</summary>
		Minus = 0x31,
		/// <summary>The Grave '`' key</summary>
		Grave = 0x33,
		/// <summary>The Insert key</summary>
		Insert = 0034,
		/// <summary>The Home key</summary>
		Home = 0x35,
		/// <summary>The Page Up key</summary>
		PageUp = 0x36,
		/// <summary>The Page Down key</summary>
		PageDown = 0x37,
		/// <summary>The Delete key</summary>
		Delete = 0x38,
		/// <summary>The End key</summary>
		End = 0x39,
		/// <summary>The Divide '/' key, usually on the Numpad/number pad</summary>
		Divide = 0x3A,
		/// <summary>The Decimal '.' key, usually on the Numpad/number pad</summary>
		Decimal = 0x3B,
		/// <summary>The Backspace key</summary>
		Backspace = 0x3C,
		/// <summary>The Up key</summary>
		Up = 0x3D,
		/// <summary>The Down key</summary>
		Down = 0x3E,
		/// <summary>The Left key</summary>
		Left = 0x3F,
		/// <summary>The Right key</summary>
		Right = 0x40,
		/// <summary>The Tab key</summary>
		Tab = 0x41,
		/// <summary>The Space key</summary>
		Space = 0x42,
		/// <summary>The Caps Lock key</summary>
		CapsLock = 0x43,
		/// <summary>The Scroll Lock key</summary>
		ScrollLock = 0x44,
		/// <summary>The Print Screen key</summary>
		PrintScreen = 0x45,
		/// <summary>The Number Lock key</summary>
		NumberLock = 0x46,
		/// <summary>The Enter key</summary>
		Enter = 0x47,
		/// <summary>The Escape key</summary>
		Escape = 0x48,
		/// <summary>The Multiply '*' key, usually on the Numpad/number pad</summary>
		Multiply = 0x49,
		/// <summary>The Add '+' key, usually on the Numpad/number pad</summary>
		Add = 0x4A,
		/// <summary>The Subtract '-' key, usually on the Numpad/number pad</summary>
		Subtract = 0x4B,
		/// <summary>The Help key</summary>
		Help = 0x4C,
		/// <summary>The Pause key</summary>
		Pause = 0x4D,
		/// <summary>The Clear key</summary>
		Clear = 0x4E,
		/// <summary>The Backslash '\' key</summary>
		Backslash = 0x51,
		/// <summary>The Equal '=' key</summary>
		Equal = 0x55,
		/// <summary>The Semicolon ';' key</summary>
		Semicolon = 0x56,
		/// <summary>The Quote ''' key</summary>
		Quote = 0x57,

		/// <summary>The Comma ',' key</summary>
		Comma = 0x58,
		/// <summary>The Period '.' key</summary>
		Period = 0x59,
		/// <summary>The Slash '/' key</summary>
		Slash = 0x60,

		/// <summary>The Right Bracket ']' key</summary>
		RightBracket = 0x61,
		/// <summary>The Left Bracket '['  key</summary>
		LeftBracket = 0x62,

		/// <summary>The context menu key</summary>
		ContextMenu = 0x63,

		/// <summary>The Numpad/number pad '0' key</summary>
		Numpad0 = 0x70,
		/// <summary>The Numpad/number pad '1' key</summary>
		Numpad1 = 0x71,
		/// <summary>The Numpad/number pad '2' key</summary>
		Numpad2 = 0x72,
		/// <summary>The Numpad/number pad '3' key</summary>
		Numpad3 = 0x73,
		/// <summary>The Numpad/number pad '4' key</summary>
		Numpad4 = 0x74,
		/// <summary>The Numpad/number pad '5' key</summary>
		Numpad5 = 0x75,
		/// <summary>The Numpad/number pad '6' key</summary>
		Numpad6 = 0x76,
		/// <summary>The Numpad/number pad '7' key</summary>
		Numpad7 = 0x77,
		/// <summary>The Numpad/number pad '8' key</summary>
		Numpad8 = 0x78,
		/// <summary>The Numpad/number pad '9' key</summary>
		Numpad9 = 0x79,

		/// <summary>The left shift key</summary>
		LeftShift = 0x7A,
		/// <summary>The right shift key</summary>
		RightShift = 0x7B,
		/// <summary>The left control key</summary>
		LeftControl = 0x7C,
		/// <summary>The right control key</summary>
		RightControl = 0x7D,
		/// <summary>The left alt/option key</summary>
		LeftAlt = 0x7E,
		/// <summary>The right alt/option key</summary>
		RightAlt = 0x7F,
		/// <summary>The right application/windows key</summary>
		LeftApplication = 0x80,
		/// <summary>The right application/windows key</summary>
		RightApplication = 0x81,
		/// <summary>The F13 key</summary>
		F13 = 0x82,
		/// <summary>The F14 key</summary>
		F14 = 0x83,
		/// <summary>The F15 key</summary>
		F15 = 0x84,
		/// <summary>The F16 key</summary>
		F16 = 0x85,
		/// <summary>The F17 key</summary>
		F17 = 0x86,
		/// <summary>The F18 key</summary>
		F18 = 0x87,
		/// <summary>The F19 key</summary>
		F19 = 0x88,
		/// <summary>The F20 key</summary>
		F20 = 0x89,
		/// <summary>The F21 key</summary>
		F21 = 0x8A,
		/// <summary>The F22 key</summary>
		F22 = 0x8B,
		/// <summary>The F23 key</summary>
		F23 = 0x8C,
		/// <summary>The F24 key</summary>
		F24 = 0x8D,

		/// <summary>The Numpad/number pad 'Enter' key</summary>
		NumpadEnter = 0x8E,

		/// <summary>The F8 key</summary>
		F8 = 0x8F,

		/// <summary>The Shift Key Modifier</summary>
		Shift = 0x91,
		/// <summary>The Alt Key Modifier</summary>
		Alt = 0x92,
		/// <summary>The Control Key Modifier</summary>
		Control = 0x94,
		/// <summary>The Application/Windows Key Modifier</summary>
		Application = 0x98,  // windows/command key
	}
}
