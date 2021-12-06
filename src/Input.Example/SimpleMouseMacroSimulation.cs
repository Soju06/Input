// 2.2 마우스 매크로 시뮬레이션 예제입니다.
using Input;

Console.WriteLine("Hello, World!");

// 마우스 시뮬레이션를 만듭니다.
// 만약 지원하지 않는 플랫폼인 경우 NotSupportedException 예외가 발생할 수 있습니다.
var simulation = Inputs.Use<IMouseSimulation>();

// 디버그를 활성화 합니다.
// 네이티브 오류를 디버그 출력 창에서 확인할 수 있습니다.
simulation.Debug = true;

INIT_SCRIPT:
Console.WriteLine();
Console.WriteLine("SimpleMouseMacroRec.cs 예제에서 만들어진 스크립트를 붙여넣으십시오. (스크립트 파일 경로 가능)");
var s_script = Console.ReadLine();
if (string.IsNullOrWhiteSpace(s_script))
    goto INIT_SCRIPT;

Console.WriteLine("스크립트를 디코딩하고 있습니다..");

if(s_script.Length < 10000 && File.Exists(s_script))
    s_script = File.ReadAllText(s_script);

var script = Convert.FromBase64String(s_script);
var block_size = (sizeof(byte) + (sizeof(int) * 2));
var count = script.Length / block_size;
var cp = 0;

Console.WriteLine($"이벤트 갯수: {count}");
await Task.Delay(1000);

for (int i = 0; i < count; i++) {
    var button = (InputButtons)script[cp];
    var x = BitConverter.ToInt32(script, cp + sizeof(byte));
    var y = BitConverter.ToInt32(script, cp + sizeof(byte) + sizeof(int));

    Console.WriteLine($"{button}, {x}, {y}");

    switch (button) {
        case InputButtons.LeftMouseDown:
            simulation.AbsoluteDown(InputMouseButtons.Left, x, y);
            break;
        case InputButtons.LeftMouseUp:
            simulation.AbsoluteUp(InputMouseButtons.Left, x, y);
            break;
        case InputButtons.RightMouseDown:
            simulation.AbsoluteDown(InputMouseButtons.Right, x, y);
            break;
        case InputButtons.RightMouseUp:
            simulation.AbsoluteUp(InputMouseButtons.Right, x, y);
            break;
        case InputButtons.Move:
            simulation.AbsoluteMove(x, y);
            break;
    }

    cp += block_size;

    // 안전모드
    //await Task.Delay(1);
}