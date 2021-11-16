using System.Runtime.InteropServices;

namespace InputHook.Platforms.Windows {
    public class WindowsApplicationLoop {
        bool disposedValue;
        Thread? Thread;

        public void Start() {
            if (Thread != null && Thread.IsAlive) return;
            (Thread = new Thread(Main)).Start();
        }

        void Main() {
            while (!GetMessage(out MSG msg, IntPtr.Zero, 0, 0)) {
                TranslateMessage(ref msg);
                DispatchMessage(ref msg);
            }
        }

        [Serializable]
        struct MSG {
            public IntPtr hwnd, lParam, wParam;
            public int message, pt_x, pt_y, time;
        }

        [DllImport("user32.dll")]
        static extern bool GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        [DllImport("user32.dll")]
        static extern bool TranslateMessage([In] ref MSG lpMsg);

        [DllImport("user32.dll")]
        static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    try {
                        Thread?.Interrupt();
                    } catch {

                    }
                }

                disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
