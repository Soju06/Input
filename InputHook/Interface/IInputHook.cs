namespace InputHook {
    public interface IInputHook : IDisposable {
        /// <summary>
        /// 디버깅
        /// </summary>
        public bool Debug { get; set; }

        /// <summary>
        /// 후킹 시작
        /// </summary>
        protected void HookStart();

        /// <summary>
        /// 후킹 정지
        /// </summary>
        protected void HookStop();

        /// <summary>
        /// 후킹 일시 정지
        /// </summary>
        protected void HookPause();
    }
}
