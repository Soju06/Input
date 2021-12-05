namespace Input.Platforms.Windows {
    public class WindowsMouseSimulation : IMouseSimulation {
        private bool disposedValue;

        public bool Debug { get; set; }

        [Obsolete]
        public WindowsMouseSimulation() : this(true) {

        }

        public WindowsMouseSimulation(bool _) {
            
        }


        public void Click() =>
            Click(WinAPI.MouseInputFlags.LeftDown, WinAPI.MouseInputFlags.LeftUp);

        public void Click(int x, int y) =>
            MoveClick(x, y, false, WinAPI.MouseInputFlags.LeftDown, WinAPI.MouseInputFlags.LeftUp);

        public void Click(InputMouseButtons button, int x, int y) =>
            xMoveClick(x, y, button, false);

        public void Click(InputMouseButtons button) =>
            Click(ConvertFlags(button, true), ConvertFlags(button, false));

        public void AbsoluteClick(int x, int y) =>
            MoveClick(x, y, true, WinAPI.MouseInputFlags.LeftDown, WinAPI.MouseInputFlags.LeftUp);

        public void AbsoluteClick(InputMouseButtons button, int x, int y) =>
            xMoveClick(x, y, button, true);

        void xMoveClick(int x, int y, InputMouseButtons button, bool absolute) =>
            MoveClick(x, y, absolute, button == InputMouseButtons.Right ? WinAPI.MouseInputFlags.RightDown : WinAPI.MouseInputFlags.LeftDown,
                button == InputMouseButtons.Right ? WinAPI.MouseInputFlags.RightUp : WinAPI.MouseInputFlags.LeftUp);

        public void RightClick() =>
            Click(WinAPI.MouseInputFlags.RightDown, WinAPI.MouseInputFlags.RightUp);

        public void RightClick(int x, int y) =>
            MoveClick(x, y, false, WinAPI.MouseInputFlags.RightDown, WinAPI.MouseInputFlags.RightUp);

        public void AbsoluteRightClick(int x, int y) =>
            MoveClick(x, y, true, WinAPI.MouseInputFlags.RightDown, WinAPI.MouseInputFlags.RightUp);

        public void Move(int x, int y) =>
            WinAPI.SendInput(CreateInput(x, y, WinAPI.MouseInputFlags.Move, 0));

        public void AbsoluteMove(int x, int y) {
            GetAbsolutePoint(ref x, ref y);
            WinAPI.SendInput(CreateInput(x, y, WinAPI.MouseInputFlags.Absolute | WinAPI.MouseInputFlags.Move, 0));
        }

        public void Down(InputMouseButtons buttons) =>
            WinAPI.SendInput(CreateInput(0, 0, ConvertFlags(buttons, true), 0));

        public void Down(InputMouseButtons buttons, int x, int y) =>
            MoveSend(x, y, false, ConvertFlags(buttons, true));

        public void AbsoluteDown(InputMouseButtons buttons, int x, int y) =>
            MoveSend(x, y, true, ConvertFlags(buttons, true));

        public void Up(InputMouseButtons buttons) =>
            WinAPI.SendInput(CreateInput(0, 0, ConvertFlags(buttons, false), 0));

        public void Up(InputMouseButtons buttons, int x, int y) =>
            MoveSend(x, y, false, ConvertFlags(buttons, false));

        public void AbsoluteUp(InputMouseButtons buttons, int x, int y) =>
            MoveSend(x, y, true, ConvertFlags(buttons, false));

        public void Scroll(int scale) {
            if (scale >= 0) ScrollDown((uint)scale);
            else ScrollDown((uint)scale);
        }

        public void ScrollDown(uint scale) {
            WinAPI.SendInput(CreateInput(0, 0, WinAPI.MouseInputFlags.Wheel, scale * 120));
        }

        public void ScrollUp(uint scale) {
            WinAPI.SendInput(CreateInput(0, 0, WinAPI.MouseInputFlags.Wheel, (uint)(-scale * 120)));
        }

        public bool IsMouseDown(InputMouseButtons buttons) =>
            WinAPI.GetAsyncKeyState((ushort)(WindowsKeys)(buttons switch {
                InputMouseButtons.Left => WindowsKeys.LButton,
                InputMouseButtons.Right => WindowsKeys.RButton,
                InputMouseButtons.Wheel => WindowsKeys.MButton,
                _ => 0
            })) < 0;

        public void GetMousePosition(out int x, out int y) {
            WinAPI.GetCursorPos(out var pos);
            x = pos.x;
            y = pos.y;
        }

        void Click(WinAPI.MouseInputFlags a1, WinAPI.MouseInputFlags a2) {
            WinAPI.SendInput(
                CreateInput(0, 0, a1, 0),
                CreateInput(0, 0, a2, 0)
            );
        }

        void MoveSend(int x, int y, bool absolute, WinAPI.MouseInputFlags a) {
            if (absolute) GetAbsolutePoint(ref x, ref y);

            WinAPI.SendInput(
                CreateInput(x, y, (absolute ? WinAPI.MouseInputFlags.Absolute : 0) | WinAPI.MouseInputFlags.Move, 0),
                CreateInput(0, 0, a, 0)
            );
        }

        void MoveClick(int x, int y, bool absolute, WinAPI.MouseInputFlags a1, WinAPI.MouseInputFlags a2) {
            if (absolute) GetAbsolutePoint(ref x, ref y);

            WinAPI.SendInput(
                CreateInput(x, y, (absolute ? WinAPI.MouseInputFlags.Absolute : 0) | WinAPI.MouseInputFlags.Move, 0),
                CreateInput(0, 0, a1, 0),
                CreateInput(0, 0, a2, 0)
            );
        }

        void GetAbsolutePoint(ref int x, ref int y) {
            x = (x * 65536 / WinAPI.GetSystemMetrics(0)) + (x < 0 ? -1 : 1);
            y = (y * 65536 / WinAPI.GetSystemMetrics(1)) + (y < 0 ? -1 : 1);
        }

        WinAPI.MouseInputFlags ConvertFlags(InputMouseButtons buttons, bool isDown) =>
            buttons switch {
                InputMouseButtons.Left => WinAPI.MouseInputFlags.Absolute | (isDown ? WinAPI.MouseInputFlags.LeftDown : WinAPI.MouseInputFlags.LeftUp),
                InputMouseButtons.Right => WinAPI.MouseInputFlags.Absolute | (isDown ? WinAPI.MouseInputFlags.RightDown : WinAPI.MouseInputFlags.RightUp),
                InputMouseButtons.Wheel => WinAPI.MouseInputFlags.Absolute | WinAPI.MouseInputFlags.Wheel,
                _ => 0
            };
        WinAPI.Input CreateInput(int x, int y, WinAPI.MouseInputFlags button, uint extra) {
            return new() {
                type = WinAPI.InputType.Mouse,
                u = new() {
                    mi = new() {
                        dx = x,
                        dy = y,
                        dwFlags = button,
                        mouseData = extra,
                        time = 0,
                        dwExtraInfo = UIntPtr.Zero,
                    }
                }
            };
        }

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {

                }

                disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// 윈도우용 마우스 시뮬레이션
        /// </summary>
        /// <exception cref="NotSupportedException" />
        public static WindowsMouseSimulation Create() =>
            new(true);

        public static int GetSupportPlatforms() => (int)Inputs.platform.windows;
    }
}
