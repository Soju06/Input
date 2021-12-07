# Input

멀티 플랫폼 키보드 및 마우스 후킹, 입력

# [📖 Wiki](https://github.com/Soju06/Input/wiki)

Input 위키

- ### [📄 API Document](https://github.com/Soju06/Input/wiki#document)
 
  API 사용 문서입니다.
  
- ### [💡 API Example](https://github.com/Soju06/Input/wiki#example)
 
  API 사용 예제입니다.
  
- ### [🧪 Input.Test](https://github.com/Soju06/Input/wiki#-inputtest)
 
 ![input.test](https://user-images.githubusercontent.com/34199905/144855310-19bf0a38-c744-40e8-a84a-1d0d8645bd34.png)
  
  API 사용 테스트 도구입니다.

# 📚 Samples

더 많은 샘플은 [Example](https://github.com/Soju06/Input/wiki#example)에서 확인할 수 있습니다.

## Hook

키보드 및 마우스 후킹 예제입니다.

- ⌨️ Keyboard Hook
  ```cs
  using Input;
  using System.Diagnostics;
  using Input.Platforms.Windows;
  
  var hook = Inputs.Use<IKeyboardHook>();
  var model = hook.KeyboardModel;
  
  model.KeyDown += (sender, key, state) => {
    Debug.WriteLine($"KeyDown: {key} {state}");
    return true;
  };

  model.KeyUp += (sender, key, state) => {
    Debug.WriteLine($"KeyDown: {key} {state}");
    return true;
  };
  
  hook.HookStart();
  
  if (Platform.IsWindows)
    while (WindowsMessagePump.Pumping()) { }
    
  Console.ReadLine();
  ```
  
  자세한 예제는 [여기](https://github.com/Soju06/Input/wiki/Keyboard-Interface#inputikeyboardhook)에서 확인할 수 있습니다.
  
- 🖱️ Mouse Hook
  ```cs
  using Input;
  using Input.Platforms.Windows;
  using System.Diagnostics;
  
  var hook = Inputs.Use<IKeyboardHook>();
  var model = hook.KeyboardModel;

  model.KeyDown += (sender, key, state) => {
      Debug.WriteLine($"KeyDown: {key} {state}");
      return true;
  };

  model.KeyUp += (sender, key, state) => {
      Debug.WriteLine($"KeyDown: {key} {state}");
      return true;
  };

  hook.HookStart();
  
  if (Platform.IsWindows)
    while (WindowsMessagePump.Pumping()) { }

  Console.ReadLine();
  ```
  
  자세한 예제는 [여기](https://github.com/Soju06/Input/wiki/Mouse-Interface#inputimousehook)에서 확인할 수 있습니다.
  
## Simulation
키보드 및 마우스 시뮬레이션 예제입니다.

- ⌨️ Keyboard Simulation
  ```cs
  using Input;
  using System.Diagnostics;

  var simulation = Inputs.Use<IKeyboardSimulation>();

  // 1.1 KeyClick
  
  simulation.KeyClick(InputKeys.A);
  
  simulation.KeyClick(InputKeys.LeftControl, InputKeys.Z);

  // 1.2 KeyDown

  simulation.KeyDown(InputKeys.A);

  simulation.KeyDown(InputKeys.A, InputKeys.B);

  // 1.3 KeyUp

  simulation.KeyUp(InputKeys.A);

  simulation.KeyUp(InputKeys.A, InputKeys.B);

  // 1.4 TextEntry

  simulation.TextEntry("Hello, World!");

  // 1.5 IsKeyDown

  simulation.IsKeyDown(InputKeys.A);

  // 1.6 ReleaseAllKeys

  simulation.ReleaseAllKeys();
  ```
  
  자세한 예제는 [여기](https://github.com/Soju06/Input/wiki/Keyboard-Interface#inputikeyboardsimulation)에서 확인할 수 있습니다.
  
- 🖱️ Mouse Simulation
  ```cs
  using Input;
  using System.Diagnostics;
  
  var simulation = Inputs.Use<IMouseSimulation>();

  simulation.Debug = true;

  // 1.1 Click

  simulation.Click();

  simulation.Click(10, 10);

  simulation.Click(InputMouseButtons.Right);

  simulation.Click(InputMouseButtons.Right, 10, 10);

  simulation.AbsoluteClick(100, 100);

  simulation.AbsoluteClick(InputMouseButtons.Right, 100, 100);

  // 1.2 Down

  simulation.Down(InputMouseButtons.Left);

  simulation.Down(InputMouseButtons.Left, 10, 10);

  simulation.AbsoluteDown(InputMouseButtons.Left, 100, 100);

  // 1.3 Up

  simulation.Up(InputMouseButtons.Left);

  simulation.Up(InputMouseButtons.Left, 10, 10);

  simulation.AbsoluteUp(InputMouseButtons.Left, 100, 100);

  // 1.4 Move

  simulation.Move(10, 10);

  simulation.AbsoluteMove(100, 100);

  // 1.5 Scroll

  simulation.Scroll(1);
  simulation.ScrollUp(1);

  simulation.Scroll(-1);
  simulation.ScrollDown(1);

  // 1.6 Mouse State

  simulation.GetMousePosition(out var x, out var y);

  simulation.IsMouseDown(InputMouseButtons.Left);
  ```
  
  
  자세한 예제는 [여기](https://github.com/Soju06/Input/wiki/Mouse-Interface#inputimousesimulation)에서 확인할 수 있습니다.
  
