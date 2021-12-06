namespace Input {
    /// <summary>
    /// 마우스 후킹
    /// </summary>
    public interface IMouseHook : IInputHook {
        /// <summary>
        /// 마우스 모델
        /// </summary>
        public MouseModel MouseModel { get; set; }
    }
}
