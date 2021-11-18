namespace Input {
    public interface IInputHook : IInputModule {
        /// <summary>
        /// 후커 상태
        /// </summary>
        public InputHookStatus HookStatus { get; }

        /// <summary>
        /// 후킹중
        /// </summary>
        public bool IsRunning { get; }

        /// <summary>
        /// 후킹 시작
        /// </summary>
        public void HookStart();

        /// <summary>
        /// 후킹 정지
        /// </summary>
        public void HookStop();

        /// <summary>
        /// 후킹 일시 정지
        /// </summary>
        public void HookPause();
    }
}
