// 2.3 키보드 시뮬레이션 예제입니다.
using Input;
using System.Diagnostics;

Debug.WriteLine("Hello, World!");

// 키보드 시뮬레이션를 만듭니다.
// 만약 지원하지 않는 플랫폼인 경우 NotSupportedException 예외가 발생할 수 있습니다.
var simulation = Inputs.Use<IKeyboardSimulation>();

// 디버그를 활성화 합니다.
// 네이티브 오류를 디버그 출력 창에서 확인할 수 있습니다.
simulation.Debug = true;

// 윈도우:
//  메모장을 키고 Hello, World!를 입력하는 예제입니다.
if (Platform.IsWindows) {
    // Win + R  실행 창을 엽니다.
    simulation.KeyClick(InputKeys.LeftApplication, InputKeys.R);

    await Task.Delay(1000);

    // notepad를 입력 후 Enter합니다.
    simulation.TextEntry("notepad");

    await Task.Delay(1000);

    simulation.KeyClick(InputKeys.Enter);

    await Task.Delay(2000);

    // Hello, World!를 입력합니다.
    simulation.TextEntry("Hello, World!");

    await Task.Delay(500);

    // Enter 후 WA SANS를 입력합니다.
    simulation.KeyClick(InputKeys.Enter);
    simulation.KeyDown(InputKeys.LeftShift);
    simulation.KeyClick(InputKeys.W);
    simulation.KeyClick(InputKeys.A);
    simulation.KeyClick(InputKeys.Space);
    simulation.KeyClick(InputKeys.S);
    simulation.KeyClick(InputKeys.A);
    simulation.KeyClick(InputKeys.N);
    simulation.KeyClick(InputKeys.S);
    simulation.KeyUp(InputKeys.LeftShift);

} else if (Platform.IsLinux) {
    // 예제가 없습니다.
    Debug.WriteLine("예제가 없습니다.");
} else if (Platform.IsOSX) {
    // 예제가 없습니다.
    Debug.WriteLine("예제가 없습니다.");
}