using System.Diagnostics;

namespace Input.Test {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            //var keyboard = Input.Use<IKeyboardHook>();

            //keyboard.HookStart();

            //var func = (object sender, InputKeys key, InputKeyState state) => {
            //    Debug.WriteLine($"{key} {state}");
            //    return true;
            //};

            //keyboard.KeyboardModel.KeyUp += new(func);
            //keyboard.KeyboardModel.KeyDown += new(func);

            //while (WindowsMessagePump.Pumping()) {
            //    Console.WriteLine("pump");
            //}
        }
    }
}

//using InputHook;
//using InputHook.Models;
//using InputHook.Platforms.Windows;

//ApplicationConfiguration.Initialize();
//KeyboardModel keyboard = new();
//WindowsKeyboardHook keyboardHook;

//(keyboardHook = new() {
//    Debug = true,
//    KeyboardModel = keyboard,
//}).HookStart();

//keyboard.KeyDown += (sender, key) => {
//    Log("KeyDown: ", key);
//    return true;
//};
//keyboard.KeyUp += (sender, key) => {
//    Log("KeyUp: ", key);
//    return true;
//};

//void Log(string message, InputKeys key) {
//    Console.WriteLine($"{message} {key}");
//}
//Application.ThreadExit += (_, __) => {
//    keyboardHook.HookStop();
//    keyboardHook?.Dispose();
//    keyboard?.Dispose();
//};

//Application.Run();