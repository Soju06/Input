namespace Input {
    public interface IKeyboardSimulation : IInputSimulation {
        /// <summary>
        /// 최대 텍스트 엔트리 길이입니다.
        /// </summary>
        public uint MaxTextEntryLength { get; }

        /// <summary>
        /// 키를 클릭합니다.
        /// </summary>
        /// <param name="keys">키</param>
        /// <exception cref="ObjectDisposedException"></exception>
        public void KeyClick(InputKeys key);
        /// <summary>
        /// 키를 클릭합니다.
        /// </summary>
        /// <param name="keys">키</param>
        /// <exception cref="ObjectDisposedException"></exception>
        public void KeyClick(params InputKeys[] keys);

        /// <summary>
        /// 키를 뗌니다.
        /// </summary>
        /// <param name="keys">키</param>
        /// <exception cref="ObjectDisposedException"></exception>
        public void KeyUp(InputKeys key);

        /// <summary>
        /// 키를 뗌니다.
        /// </summary>
        /// <param name="keys">키</param>
        /// <exception cref="ObjectDisposedException"></exception>
        public void KeyUp(params InputKeys[] keys);

        /// <summary>
        /// 키를 누릅니다.
        /// </summary>
        /// <param name="keys">키</param>
        /// <exception cref="ObjectDisposedException"></exception>
        public void KeyDown(InputKeys key);
        /// <summary>
        /// 키를 누릅니다.
        /// </summary>
        /// <param name="keys">키</param>
        /// <exception cref="ObjectDisposedException"></exception>
        public void KeyDown(params InputKeys[] keys);

        /// <summary>
        /// 텍스트 엔트리를 입력합니다.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public void TextEntry(string text);

        /// <summary>
        /// 모든 키를 뗌니다.
        /// 플랫폼에 따라 시간이 발생할 수 있습니다.
        /// </summary>
        public void ReleaseAllKeys();

        /// <summary>
        /// 키 눌림 상태를 가저옵니다.
        /// </summary>
        /// <param name="keys">key</param>
        /// <returns>상태</returns>
        public bool IsKeyDown(InputKeys keys);
    }
}
