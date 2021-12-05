namespace Input {
    public interface IInputModule : IDisposable {
        /// <summary>
        /// 디버그를 활성화 합니다.
        /// 네이티브 오류를 디버그 출력 창에서 확인할 수 있습니다.
        /// </summary>
        public bool Debug { get; set; }
    }
}
