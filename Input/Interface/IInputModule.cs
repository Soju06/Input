namespace Input {
    public interface IInputModule : IDisposable {
        /// <summary>
        /// 디버깅
        /// </summary>
        public bool Debug { get; set; }
    }
}
