using Input.Platforms;
using System.Reflection;

namespace Input {
    /// <summary>
    /// 인풋 후커
    /// </summary>
    public static class InputHook {
        static readonly Type[] supportPlatformsMethodReturnTypes = new Type[] { typeof(int), typeof(platform) };

        static readonly Dictionary<Type, Type[]> cached_types = new();

        /// <summary>
        /// 인풋 후커를 만듭니다.
        /// </summary>
        /// <typeparam name="TInputHook">후커</typeparam>
        /// <exception cref="NotSupportedException"></exception>
        public static TInputHook Use<TInputHook>() where TInputHook : IInputHook =>
            (TInputHook)Use(typeof(TInputHook));

        /// <summary>
        /// 인풋 후커를 만듭니다.
        /// </summary>
        /// <typeparam name="TInputHook">후커</typeparam>
        /// <param name="assembly">참조 어셈블리</param>
        /// <exception cref="NotSupportedException"></exception>
        public static TInputHook Use<TInputHook>(Assembly? assembly) where TInputHook : IInputHook =>
            (TInputHook)Use(typeof(TInputHook), assembly);

        /// <summary>
        /// 인풋 후커를 만듭니다.
        /// </summary>
        /// <param name="inputHookType">후커 타입</param>
        /// <exception cref="NotSupportedException"></exception>
        public static object Use(Type inputHookType) =>
            Use(inputHookType, null);

        /// <summary>
        /// 인풋 후커를 만듭니다.
        /// </summary>
        /// <param name="inputHookType">후커 타입</param>
        /// <param name="assembly">참조 어셈블리</param>
        /// <exception cref="NotSupportedException"></exception>
        public static object Use(Type inputHookType, Assembly? assembly) {
            var module_type = GetSupportedModule(inputHookType, assembly);
            if (module_type == null) throw new NotSupportedException($"{inputHookType.Name}을 지원하는 모듈이 없습니다.");
            return module_type.CreateInstance();
        }

        /// <summary>
        /// 캐시된 어셈블리의 지원 인터페이스 타입을 지웁니다.
        /// </summary>
        public static void CacheClear() {
            lock (cached_types)
                cached_types.Clear();
        }

        static Type? GetSupportedModule(Type hookType, Assembly? assembly = null) {
            if (!typeof(IInputHook).IsAssignableFrom(hookType)) 
                throw new NotSupportedException("IInputHook 인터페이스 형식이 아닙니다.");

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
    }
}