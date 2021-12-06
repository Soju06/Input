namespace Input.Platforms.Windows {
    /// <summary>
    /// 윈도우용 메시지 펌프입니다.
    /// 메시지 펌프가 없는 애플리케이션에서 인풋 후커에서 사용할 수 있습니다.
    /// </summary>
    public class WindowsMessagePump {
        /// <summary>
        /// 메시지를 펌핑합니다.
        /// </summary>
        public static bool Pumping() {
            if (!WinAPI.GetMessage(out var msg, IntPtr.Zero, 0, 0)) {
                WinAPI.TranslateMessage(ref msg);
                WinAPI.DispatchMessage(ref msg);
                return true;
            } else return false;
        }
    }
}
