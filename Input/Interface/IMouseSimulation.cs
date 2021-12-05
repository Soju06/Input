namespace Input {
    /// <summary>
    /// 마우스 시뮬레이션 
    /// </summary>
    public interface IMouseSimulation : IInputSimulation {
        /// <summary>
        /// 모니터 기준으로 이동 후 클릭합니다.
        /// </summary>
        void AbsoluteClick(int x, int y);
        /// <summary>
        /// 모니터 기준으로 이동 후 클릭합니다.
        /// </summary>
        /// <param name="button">누를 버튼입니다.</param>
        void AbsoluteClick(InputMouseButtons button, int x, int y);
        /// <summary>
        /// 모니터 기준으로 이동 후 누릅니다.
        /// </summary>
        /// <param name="button">누를 버튼입니다.</param>
        void AbsoluteDown(InputMouseButtons button, int x, int y);
        /// <summary>
        /// 모니터 기준으로 이동합니다.
        /// </summary>
        void AbsoluteMove(int x, int y);
        /// <summary>
        /// 모니터 기준으로 이동 후 우클릭합니다.
        /// </summary>
        void AbsoluteRightClick(int x, int y);
        /// <summary>
        /// 모니터 기준으로 이동 후 뗌니다.
        /// </summary>
        /// <param name="button">뗄 버튼입니다.</param>
        void AbsoluteUp(InputMouseButtons button, int x, int y);
        /// <summary>
        /// 클릭합니다.
        /// </summary>
        void Click();
        /// <summary>
        /// 마우스 기준으로 이동 후 클릭합니다.
        /// </summary>
        void Click(int x, int y);
        /// <summary>
        /// 클릭합니다.
        /// </summary>
        /// <param name="button">클릭 할 버튼입니다.</param>
        void Click(InputMouseButtons button);
        /// <summary>
        /// 마우스 기준으로 이동 후 클릭합니다.
        /// </summary>
        /// <param name="button">클릭 할 버튼입니다.</param>
        void Click(InputMouseButtons button, int x, int y);
        /// <summary>
        /// 버튼을 누릅니다.
        /// </summary>
        /// <param name="buttons">누를 버튼입니다.</param>
        void Down(InputMouseButtons buttons);
        /// <summary>
        /// 마우스 기준으로 이동 후 누릅니다.
        /// </summary>
        /// <param name="button">누를 버튼입니다.</param>
        void Down(InputMouseButtons button, int x, int y);
        /// <summary>
        /// 마우스가 눌려있는지 가져옵니다.
        /// </summary>
        /// <param name="button">가져올 버튼입니다.</param>
        /// <returns></returns>
        bool IsMouseDown(InputMouseButtons button);
        /// <summary>
        /// 마우스의 위치를 가져옵니다.
        /// </summary>
        void GetMousePosition(out int x, out int y);
        /// <summary>
        /// 마우스 기준으로 이동합니다.
        /// </summary>
        void Move(int x, int y);
        /// <summary>
        /// 우클릭합니다.
        /// </summary>
        void RightClick();
        /// <summary>
        /// 마우스 기준으로 이동 후 우클릭 합니다.
        /// </summary>
        void RightClick(int x, int y);
        /// <summary>
        /// 스크롤 합니다.
        /// <paramref name="scale"/>이 음수인 경우 ScrollDown을 구현합니다.
        /// </summary>
        /// <param name="scale">스크롤 할 크기입니다.</param>
        void Scroll(int scale);
        /// <summary>
        /// 스크롤을 내립니다.
        /// </summary>
        /// <param name="scale">스크롤 할 크기입니다.</param>
        void ScrollDown(uint scale);
        /// <summary>
        /// 스크롤을 올립니다.
        /// </summary>
        /// <param name="scale">스크롤 할 크기입니다.</param>
        void ScrollUp(uint scale);
        /// <summary>
        /// 버튼을 뗌니다.
        /// </summary>
        /// <param name="button">뗄 버튼입니다.</param>
        void Up(InputMouseButtons button);
        /// <summary>
        /// 마우스 기준으로 이동 후 버튼을 뗌니다.
        /// </summary>
        /// <param name="button">뗄 버튼입니다.</param>
        void Up(InputMouseButtons button, int x, int y);
    }
}
