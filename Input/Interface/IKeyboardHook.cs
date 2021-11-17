namespace Input {
    /// <summary>
    /// 인풋 후킹 컴포넌트
    /// </summary>
    public interface IKeyboardHook : IInputHook {
        /// <summary>
        /// 키보드
        /// </summary>
        KeyboardModel KeyboardModel { get; set; }
    }
}