namespace Input.Platforms.Windows {
    internal static class WinApiUtility {
        public static bool IsExtendedKey(this WindowsKeys keyCode) =>
            keyCode switch {
                WindowsKeys.Menu or 
                WindowsKeys.LMenu or
                WindowsKeys.RMenu or 
                WindowsKeys.ControlKey or 
                WindowsKeys.RControlKey or
                WindowsKeys.Insert or 
                WindowsKeys.Delete or
                WindowsKeys.Home or
                WindowsKeys.End or 
                WindowsKeys.PageUp or
                WindowsKeys.PageDown or 
                WindowsKeys.Right or
                WindowsKeys.Up or 
                WindowsKeys.Left or
                WindowsKeys.Down or
                WindowsKeys.NumLock or 
                WindowsKeys.Cancel or
                WindowsKeys.PrintScreen or
                WindowsKeys.Divide => true,
                _ => false,
            };
    }
}
