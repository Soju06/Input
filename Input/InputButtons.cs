namespace Input {
    /// <summary>
    /// 인풋 버튼
    /// </summary>
    public enum InputButtons : byte {
        None = 0,
        LeftMouseDown = 0x01,
        LeftMouseUp = 0x02,
        LeftDoubleClick = 0x03,
        RightMouseDown = 0x0A,
        RightMouseUp = 0x0B,
        [Obsolete]
        Wheel = 0x10,
        WheelUp = 0x11,
        WheelDown = 0x12,
        WheelMoveUp = 0x15,
        WheelMoveDown = 0x16,
        Move = 0x20,
    }

    /// <summary>
    /// 마우스 버튼
    /// </summary>
    public enum InputMouseButtons : byte {
        Left,
        Right,
        /// <summary>
        /// Windows에서는 인풋 시뮬레이션에서 사용되지 않습니다.
        /// </summary>
        Wheel
    }
}
