using System.Runtime.InteropServices;

namespace Input {
    /// <summary>
    /// 플렛폼
    /// </summary>
    public static class Platform {
        /// <summary>
        /// 리눅스 여부
        /// </summary>
        public static bool IsLinux => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        /// <summary>
        /// 윈도우 여부
        /// </summary>
        public static bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        /// <summary>
        /// osx 여부
        /// </summary>
        public static bool IsOSX => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        /// <summary>
        /// os 아키텍처
        /// </summary>
        public static Architecture OSArchitecture => RuntimeInformation.OSArchitecture;
        /// <summary>
        /// 프로세서 아키텍처
        /// </summary>
        public static Architecture ProcessArchitecture => RuntimeInformation.ProcessArchitecture;

        /// <summary>
        /// 프레임워크 설명
        /// </summary>
        public static string FrameworkDescription => RuntimeInformation.FrameworkDescription;

        /// <summary>
        /// os 설명
        /// </summary>
        public static string OSDescription => RuntimeInformation.OSDescription;

        /// <summary>
        /// 진단 설명
        /// </summary>
        public static string DiagnosticDetails => $"OS: {(IsLinux ? "Linux" : IsWindows ? "Windows" : IsOSX ? "OSX" : "Other")} {OSArchitecture} {RuntimeInformation.OSDescription}\nFramework: {FrameworkDescription}\nProcess: {ProcessArchitecture}";
    }
}
