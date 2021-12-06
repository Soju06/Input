// 1.4 마우스 시뮬레이션 예제입니다.
using Input;
using System.Diagnostics;

Debug.WriteLine("Hello, World!");

// 마우스 시뮬레이션를 만듭니다.
// 만약 지원하지 않는 플랫폼인 경우 NotSupportedException 예외가 발생할 수 있습니다.
var simulation = Inputs.Use<IMouseSimulation>();

// 디버그를 활성화 합니다.
// 네이티브 오류를 디버그 출력 창에서 확인할 수 있습니다.
simulation.Debug = true;

// 1.1 Click

// 현재 마우스 위치에 클릭합니다.
simulation.Click();

// 현재 마우스 위치에서 x + 10, y + 10 위치에 클릭합니다.
simulation.Click(10, 10);

// 현재 마우스 위치에 우클릭합니다.
simulation.Click(InputMouseButtons.Right);

// 현재 마우스 위치에서 x + 10, y + 10 위치에 클릭합니다.
simulation.Click(InputMouseButtons.Right, 10, 10);

// 화면 기준 위치에서 x = 100, y = 100 위치에 클릭합니다.
simulation.AbsoluteClick(100, 100);

// 화면 기준 위치에서 x = 100, y = 100 위치에 우클릭합니다.
simulation.AbsoluteClick(InputMouseButtons.Right, 100, 100);

// 1.2 Down

// 왼쪽 마우스를 누릅니다.
simulation.Down(InputMouseButtons.Left);

// 현재 마우스 위치에서 x + 10, y + 10 위치에서 왼쪽 마우스를 누릅니다.
simulation.Down(InputMouseButtons.Left, 10, 10);

// 화면 기준 위치에서 x = 100, y = 100 위치에 누릅니다.
simulation.AbsoluteDown(InputMouseButtons.Left, 100, 100);

// 1.3 Up

// 왼쪽 마우스를 뗍니다.
simulation.Up(InputMouseButtons.Left);

// 현재 마우스 위치에서 x + 10, y + 10 위치에서 왼쪽 마우스를 뗍니다.
simulation.Up(InputMouseButtons.Left, 10, 10);

// 화면 기준 위치에서 x = 100, y = 100 위치에서 뗍니다.
simulation.AbsoluteUp(InputMouseButtons.Left, 100, 100);

// 1.4 Move

// 현재 마우스 위치에서 x + 10, y + 10 위치로 이동합니다.
simulation.Move(10, 10);

// 화면 기준 위치에서 x = 100, y = 100 위치로 이동합니다.
//simulation.AbsoluteMove(100, 100);

// 1.5 Scroll

// 스크롤을 마우스 스크롤 1 만큼 올립니다.
simulation.Scroll(1);
simulation.ScrollUp(1);

// 스크롤을 마우스 스크롤 1 만큼 내립니다.
simulation.Scroll(-1);
simulation.ScrollDown(1);

// 1.6 Mouse State

// 현재 마우스의 x, y 좌표를 가져옵니다.
simulation.GetMousePosition(out var x, out var y);

// 현재 마우스 왼쪽 버튼이 눌려있는지 가져옵니다.
simulation.IsMouseDown(InputMouseButtons.Left);