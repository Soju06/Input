using System.Diagnostics;

namespace Input.Platforms.Windows {
    /// <summary>
    /// 스캔 코드를 캐시합니다.
    /// </summary>
    internal class ScanCodeMap {
        Dictionary<WindowsKeys, uint> cached_scancodes = new();

        ScanCodeMap() {
            cached_scancodes = GetCachedScancodes();
            Inputs.cache_clear_event += CacheClear;
        }

        bool disposed = false;

        ~ScanCodeMap() {
            if (!disposed) {
                disposed = true;
                CacheClear(false);
            }
        }

        void CacheClear() =>
            CacheClear(true);

        void CacheClear(bool f) {
            try {
                if (f && disposed) {
                    Inputs.cache_clear_event -= CacheClear;
                    return;
                }

                var scancodes = GetCachedScancodes();
                cached_scancodes = scancodes;
            } catch (Exception ex) {
                Debug.WriteLine($"ScancodeMap cache clear exception:\n{ex}");
            }
        }

        Dictionary<WindowsKeys, uint> GetCachedScancodes() {
            Dictionary<WindowsKeys, uint> scancodes = new();
            foreach (var key in (WindowsKeys[])Enum.GetValues(typeof(WindowsKeys)))
                scancodes.Add(key, WinAPI.MapVirtualKey((uint)key, 0));
            return scancodes;
        }

        /// <summary>
        /// 스캔코드를 가저옵니다.
        /// </summary>
        /// <param name="vKey">VKEY</param>
        /// <param name="defaultValue">default Value</param>
        public ushort GetScanCode(WindowsKeys vKey, ushort defaultValue = 0) {
            if (cached_scancodes.TryGetValue(vKey, out var sc))
                return (ushort)(sc & 0xFFU);
            else return defaultValue;
        }

        /// <summary>
        /// 맵을 만듭니다.
        /// </summary>
        public static ScanCodeMap Create() => new();
    }
}
