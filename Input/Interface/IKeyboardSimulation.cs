namespace Input {
    public interface IKeyboardSimulation : IInputSimulation {
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
        /// 모든 키를 뗌니다.
        /// 플랫폼에 따라 비용이 비쌀 수도 있습니다.
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
