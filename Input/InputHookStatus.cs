namespace Input {
    /// <summary>
    /// 후커 상태
    /// </summary>
    public enum InputHookStatus : byte {
        /// <summary>
        /// 작동중
        /// </summary>
        Running,
        /// <summary>
        /// 일시 정지됨
        /// </summary>
        Paused,
        /// <summary>
        /// 정지됨
        /// </summary>
        Stopped,
    }
}
