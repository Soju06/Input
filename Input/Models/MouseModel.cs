using System.Drawing;
using System.Runtime.InteropServices;

namespace Input.Models {
    public class MouseModel : IDisposable {
        readonly int fixed_data_length;
        readonly unsafe int* input_data;
        bool disposedValue;

        public event MouseState? State;

        public MouseModel() {
            unsafe {
                // 필요한 int 배열 수;
                // 0 = X
                // 1 = Y
                // 2 = STATE
                fixed_data_length = 2 + 1;
                // 메모리 할당 (헤더 + 데이터)
                input_data = (int*)Marshal.AllocHGlobal(sizeof(int) * fixed_data_length);
                // 초기화
                for (int i = 0; i < fixed_data_length; i++)
                    input_data[i] = 0;
            }
        }

        /// <summary>
        /// 상태를 설정합니다.
        /// </summary>
        /// <param name="button">버튼</param>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <returns></returns>
        public virtual unsafe bool SetState(InputButtons button, int x, int y) {
            input_data[0] = x;
            input_data[1] = y;
            input_data[2] = (int)button;

            return State?.Invoke(this, button, x, y) ?? true;
        }

        /// <summary>
        /// 상태를 가져옵니다.
        /// </summary>
        public virtual unsafe InputButtons GetState() =>
            (InputButtons)input_data[2];

        /// <summary>
        /// 위치를 가져옵니다.
        /// </summary>
        public virtual unsafe Point GetPosition() =>
            new(input_data[0], input_data[1]);

        /// <summary>
        /// 위치를 가져옵니다.
        /// </summary>
        public virtual unsafe void GetPosition(out int x, out int y) {
            x = input_data[0];
            y = input_data[1];
        }

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {

                }

                unsafe {
                    // 인풋 데이터 반환
                    Marshal.FreeHGlobal((IntPtr)input_data);
                }
                disposedValue = true;
            }
        }

        ~MouseModel() {
            Dispose(disposing: false);
        }

        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

    public delegate bool MouseState(object sender, InputButtons button, int x, int y);
}
