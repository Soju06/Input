// 1.3 키보드 시뮬레이션 예제입니다.
using Input;
using System.Diagnostics;

Debug.WriteLine("Hello, World!");

// 키보드 시뮬레이션를 만듭니다.
// 만약 지원하지 않는 플랫폼인 경우 NotSupportedException 예외가 발생할 수 있습니다.
var simulation = Inputs.Use<IKeyboardSimulation>();

// 디버그를 활성화 합니다.
// 네이티브 오류를 디버그 출력 창에서 확인할 수 있습니다.
simulation.Debug = true;


// 1.1 KeyClick

// A 키를 클릭합니다.
simulation.KeyClick(InputKeys.A);

// 왼쪽 컨트롤 키와 Z키를 동시에 클릭합니다.
simulation.KeyClick(InputKeys.LeftControl, InputKeys.Z);

// 1.2 KeyDown

// A 키를 누릅니다.
simulation.KeyDown(InputKeys.A);

// A 키와 B키를 누릅니다.
simulation.KeyDown(InputKeys.A, InputKeys.B);

// 1.3 KeyUp

// A 키를 뗍니다.
simulation.KeyUp(InputKeys.A);

// A 키와 B키를 뗍니다.
simulation.KeyUp(InputKeys.A, InputKeys.B);

// 1.4 TextEntry

// H e l l o , W or l d ! 키를 순차적으로 누릅니다.
simulation.TextEntry("Hello, World!");

// 1.5 IsKeyDown

// A 키가 눌려있는지 여부를 가져옵니다.
simulation.IsKeyDown(InputKeys.A);

// 1.6 ReleaseAllKeys

// 키보드의 모든 키를 뗍니다.
simulation.ReleaseAllKeys();