// 1.1 키보드 후킹 예제입니다.
using Input;
using Input.Platforms.Windows;
using System.Diagnostics;

Debug.WriteLine("Hello, World!");

// 키보드후커를 만듭니다.
// 만약 지원하지 않는 플랫폼인 경우 NotSupportedException 예외가 발생할 수 있습니다.
var hook = Inputs.Use<IKeyboardHook>();

// 디버그를 활성화 합니다.
// 네이티브 오류를 디버그 출력 창에서 확인할 수 있습니다.
hook.Debug = true;

// 키보드 모델입니다.
var model = hook.KeyboardModel;

// 키보드가 눌렸을때 발생합니다.
model.KeyDown += (sender, key, state) => {
    // Console은 쓰기 지연이 발생하므로 추천하지 않습니다.
    Debug.WriteLine($"KeyDown: {key} {state}");

    // 반환 값이 false이면 입력을 무시합니다.
    return true;
};

// 키보드가 떼졌을때 발생합니다.
model.KeyUp += (sender, key, state) => {
    // Console은 쓰기 지연이 발생하므로 추천하지 않습니다.
    Debug.WriteLine($"KeyDown: {key} {state}");

    // 반환 값이 false이면 입력을 무시합니다.
    return true;
};

// 후킹을 시작합니다.
hook.HookStart();

// 플랫폼이 윈도우인 경우 윈도우 메시지를 펌프해야합니다.
if (Platform.IsWindows) {
    while (WindowsMessagePump.Pumping()) {
        Debug.WriteLine("message pump");
    }
}

Console.ReadLine();