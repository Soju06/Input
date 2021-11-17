using System.Drawing;
using System.Runtime.InteropServices;

namespace Input.Platforms.Windows {
    internal class WinAPI {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, LLKeyboardHook lpfn, IntPtr hInstance, int threadId);
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, LLMouseHook lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(IntPtr idHook);

        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref KeyBoardLLHookStruct lParam);

        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref MouseLLHookStruct lParam);

        public delegate int LLKeyboardHook(int nCode, int wParam, ref KeyBoardLLHookStruct lParam);
        public delegate int LLMouseHook(int nCode, int wParam, ref MouseLLHookStruct lParam);

        public const int WH_KEYBOARD_LL = 13;
        public const int WH_MOUSE_LL = 14;

        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYUP = 0x0101;
        public const int WM_SYSKEYDOWN = 0x0104;
        public const int WM_SYSKEYUP = 0x0105;

        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_MOUSEWHEEL = 0x020A;
        public const int WM_RBUTTONDOWN = 0x0204;
        public const int WM_RBUTTONUP = 0x0205;
        public const int WM_LBUTTONDBLCLK = 0x0203;
        public const int WM_MBUTTONDOWN = 0x0207;
        public const int WM_MBUTTONUP = 0x0208;

        public const int LLMHF_INJECTED = 0x00000001;
        public const int LLMHF_LOWER_IL_INJECTED = 0x00000002;

        public struct KeyBoardLLHookStruct {
            public byte vkCode;
            public int scanCode;
            public KeyboardHookFlags flags;
            public uint time;
            public UIntPtr dwExtraInfo;
        }

        public struct MouseLLHookStruct {
            public LPoint pt;
            public int mouseData;
            public int hwnd;
            public uint time;
            public UIntPtr dwExtraInfo;
        }

        public struct LPoint {
            public int x;
            public int y;
        }

        [Flags]
        public enum KeyboardHookFlags : byte {
            Extended = 0x01,
            Injected = 0x10,
            AltPressed = 0x20,
            Released = 0x80
        }
    }
}
