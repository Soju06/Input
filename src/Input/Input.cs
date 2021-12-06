using Input.Platforms;
using System.Diagnostics;
using System.Reflection;

namespace Input {
    /// <summary>
    /// 인풋 후커
    /// </summary>
    public static class Inputs {
        static readonly Type[] supportPlatformsMethodReturnTypes = new Type[] { typeof(int), typeof(platform) };
        static readonly Dictionary<Type, Type[]> cached_types = new();
        internal static event CacheClearEvent? cache_clear_event;

        /// <summary>
        /// 인풋을 만듭니다.
        /// 
        /// 기본 호환 가능한 타입:
        ///     <c>TInputHook</c>
        ///     <c>TInputSimulation</c>
        /// </summary>
        /// <typeparam name="TInputModule"></typeparam>
        /// <exception cref="NotSupportedException"></exception>
        /// <returns></returns>
        public static TInputModule Use<TInputModule>() where TInputModule : IInputModule =>
            (TInputModule)Use(typeof(TInputModule));

        #region InputHook

        /// <summary>
        /// 인풋 후커를 만듭니다.
        /// </summary>
        /// <typeparam name="TInputHook">후커</typeparam>
        /// <exception cref="NotSupportedException"></exception>
        public static TInputHook UseHook<TInputHook>() where TInputHook : IInputHook =>
            (TInputHook)Use(typeof(TInputHook));

        /// <summary>
        /// 인풋 후커를 만듭니다.
        /// </summary>
        /// <typeparam name="TInputHook">후커</typeparam>
        /// <param name="assembly">참조 어셈블리</param>
        /// <exception cref="NotSupportedException"></exception>
        public static TInputHook UseHook<TInputHook>(Assembly? assembly) where TInputHook : IInputHook =>
            (TInputHook)Use(typeof(TInputHook), assembly);

        #endregion

        #region InputSimulation

        /// <summary>
        /// 인풋 시뮬레이션을 만듭니다.
        /// </summary>
        /// <typeparam name="TInputSimulation">입력기</typeparam>
        /// <exception cref="NotSupportedException"></exception>
        public static TInputSimulation UseSimulation<TInputSimulation>() where TInputSimulation : IInputSimulation =>
            (TInputSimulation)Use(typeof(TInputSimulation));

        /// <summary>
        /// 인풋을 만듭니다.
        /// </summary>
        /// <typeparam name="TInputSimulation">입력기</typeparam>
        /// <param name="assembly">참조 어셈블리</param>
        /// <exception cref="NotSupportedException"></exception>
        public static TInputSimulation UseSimulation<TInputSimulation>(Assembly? assembly) where TInputSimulation : IInputSimulation =>
            (TInputSimulation)Use(typeof(TInputSimulation), assembly);

        #endregion

        /// <summary>
        /// 인풋 후커를 만듭니다.
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        public static object Use(Type inputType) =>
            Use(inputType, null);

        /// <summary>
        /// 인풋을 만듭니다.
        /// </summary>
        /// <param name="inputType">타입</param>
        /// <param name="assembly">참조 어셈블리</param>
        /// <exception cref="NotSupportedException"></exception>
        public static object Use(Type inputType, Assembly? assembly) {
            var module_type = GetSupportedModule(inputType, assembly);
            if (module_type == null) throw new NotSupportedException($"{inputType.Name}을 지원하는 모듈이 없습니다.");
            return module_type.CreateInstance();
        }

        /// <summary>
        /// 캐시된 개체를 초기화 합니다.
        /// 
        /// level >= 0:
        ///     캐시된 어셈블리의 지원 인터페이스 타입을 지웁니다.
        ///     
        /// level >= 1:
        ///     (Windows only) 캐시된 스캔 코드를 다시 불러옵니다.
        /// </summary>
        public static void CacheClear(int level) {
            if(level >= 0) {
                lock (cached_types) {
                    cached_types.Clear();
                }
            }

            if (level >= 1 && cache_clear_event != null) {
                lock (cache_clear_event) {
                    try {
                        cache_clear_event?.Invoke();
                    } catch (Exception ex) {
                        Debug.WriteLine($"Input cache clear exception:\n{ex}");
                    }
                }
            }
        }

        /// <summary>
        /// 최대 캐시 래벨입니다.
        /// </summary>
        public static readonly uint MaxCacheLevel = 1;



        static Type? GetSupportedModule(Type hookType, Assembly? assembly = null) {
            if (!typeof(IInputModule).IsAssignableFrom(hookType)) 
                throw new NotSupportedException("IInputModule 인터페이스 형식이 아닙니다.");

            var platform = GetCurrentPlatform();
            var types = GetInterfaceTypes(hookType, assembly);
            var types_length = types.Length;

            for (int i = 0; i < types_length; i++) {
                var type = types[i];
                var _plat = GetSupportPlatforms(type);
                if (_plat == null) continue;

                if (_plat.Value.HasFlag(platform))
                    return type;
            }

            return null;
        }

        static platform GetCurrentPlatform() {
            platform platform = 0;
            if (Platform.IsWindows) platform |= platform.windows;
            else if (Platform.IsLinux) platform |= platform.linux;
            else if (Platform.IsOSX) platform |= platform.osx;
            return platform;
        }

        internal static object CreateInstance(this Type type) =>
            Activator.CreateInstance(type);

        static platform? GetSupportPlatforms(Type type) {
            var methodInfo = type?.GetMethod("GetSupportPlatforms", BindingFlags.Static | BindingFlags.Public);
            if (methodInfo == null || supportPlatformsMethodReturnTypes.Contains(methodInfo.ReturnType) && methodInfo.GetParameters().Length != 0) return null;

            return (platform)Enum.ToObject(typeof(platform), methodInfo.Invoke(null, null));
        }

        static Type[] GetInterfaceTypes(Type _interface, Assembly? assembly = null) {
            lock (cached_types) {
                if (cached_types.TryGetValue(_interface, out var types))
                    return types;
                var pn = typeof(_platforms_dummy).Namespace;

                types = (from type in (assembly ?? Assembly.GetExecutingAssembly()).GetTypes()
                where (type.Namespace ?? "").IndexOf(pn, 0) != -1 && _interface.IsAssignableFrom(type)
                select type).ToArray();

                cached_types.Add(_interface, types);
                return types;
            }
        }

        [Flags]
        internal enum platform {
            linux = 0x10,
            osx = 0x0A,
            windows = 0x8
        }

        internal delegate void CacheClearEvent();
    }
}