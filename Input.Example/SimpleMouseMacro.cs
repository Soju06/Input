// 2.1 마우스 매크로 예제입니다.

using Input;
using Input.Platforms.Windows;
using System;
using System.Runtime.InteropServices;

// 프로그램 시작전 상수단계입니다.

// 버튼 중복 방지 및 이동을 캡처하기 위한 변수입니다.
bool is_left_down = false, is_right_down = false;
// 마우스 이벤트 대기열입니다.
var mouse_log = new Queue<(InputButtons button, int x, int y)>();

Console.WriteLine("Hello, World!");

// 마우스 후커를 만듭니다.
// 만약 지원하지 않는 플랫폼인 경우 NotSupportedException 예외가 발생할 수 있습니다.
var hook = Inputs.Use<IMouseHook>();

// 디버그를 활성화 합니다.
// 네이티브 오류를 디버그 출력 창에서 확인할 수 있습니다.
hook.Debug = true;

// 마우스 모델입니다.
var model = hook.MouseModel;
// 마우스의 이벤트를 처리합니다.
model.State += StateLog;

Console.WriteLine();
Console.WriteLine("매크로를 기록합니다.");
Console.WriteLine();
Console.WriteLine("지원 타입 - 마우스 클릭시 이동 위치");
Console.WriteLine();

LOG_START:
Console.WriteLine("기록을 시작하려면 {Space} 키를 눌르십시오.");
Console.WriteLine();

if (Console.ReadKey(true).Key != ConsoleKey.Spacebar)
    goto LOG_START;

Console.WriteLine("기록을 시작합니다.");
bool isLogging = true;
// 후킹 시작
hook.HookStart();

// 로깅 작업을 시작합니다.
Task.Factory.StartNew(() => {
    LogTask();
})
    //로깅이 끝난 작업입니다.
    .ContinueWith(EndTask);

// 플랫폼이 윈도우인 경우 윈도우 메시지를 펌프해야합니다.
if (Platform.IsWindows)
    while (isLogging && WindowsMessagePump.Pumping())
        Console.WriteLine("message pump");
Console.ReadLine();

// 로깅을 시작합니다.
void LogTask() {
    LOG_STOP:
    Console.WriteLine();
    Console.WriteLine("기록을 중지하려면 {Space} 키를 눌르십시오.");

    if (Console.ReadKey(true).Key != ConsoleKey.Spacebar)
        goto LOG_STOP;

    var count = mouse_log.Count;

    if (count < 1) {
        Console.WriteLine("기록된 로그가 없습니다.");
        return;
    }

    hook.HookStop();

    Console.WriteLine($"이벤트 기록을 정리 출력하고 있습니다. 이벤트 갯수: {count} (이벤트 갯수에 따라 시간이 소요될 수 있습니다.)");

    var block_size = (sizeof(byte) + (sizeof(int) * 2));
    var tt_byte_count = block_size * count;

    unsafe {
        var _ptr = (byte*)Marshal.AllocHGlobal(tt_byte_count);
        var _cp = 0;

        for (int i = 0; i < count; i++) {
            var (button, x, y) = mouse_log.Dequeue();

            // button DATA
            _ptr[_cp] = (byte)button;
            // LPoint DATA
            Marshal.Copy(new int[] { x, y }, 0, (IntPtr)(_ptr + _cp + 1), 2);

            _cp += block_size;
        }

        var safe_array = new byte[tt_byte_count];
        Marshal.Copy((IntPtr)_ptr, safe_array, 0, tt_byte_count);
        Marshal.FreeHGlobal((IntPtr)_ptr);
        
        if (safe_array == null) throw new ArgumentNullException(nameof(safe_array));

        Console.WriteLine("인코딩된 스크립트 생성중..");
        Console.WriteLine(Convert.ToBase64String(safe_array));
        Console.WriteLine("스크립트가 생성되었습니다.");
        Console.WriteLine("해당 스크립트는 SimpleMouseMacroSimulation.cs 예제에서 실행시킬 수 있습니다.");
    }
}

// 로깅이 끝난 작업입니다.
void EndTask(Task log_task) {
    hook.HookStop();
    Environment.Exit(0);
}

// 마우스의 이벤트를 처리합니다.
bool StateLog(object sender, InputButtons button, int x, int y) {
    switch (button) {
        case InputButtons.LeftMouseDown:
            if (!is_left_down) {
                is_left_down = true;
                goto ADD;
            }
        break;

        case InputButtons.LeftMouseUp:
            if (is_left_down) {
                is_left_down = false;
                goto ADD;
            }
        break;

        case InputButtons.RightMouseDown:
            if (!is_right_down) {
                is_right_down = true;
                goto ADD;
            }
        break;

        case InputButtons.RightMouseUp:
            if (is_right_down) {
                is_right_down = false;
                goto ADD;
            }
        break;

        case InputButtons.Move:
            if (is_left_down || is_right_down)
                goto ADD;
        break;

        default:
        break;
    }

    return true;

    ADD:
    mouse_log.Enqueue(new(button, x, y));
    return true;
}
