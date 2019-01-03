namespace AppIm.Models
{
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string isRemembered = "IsRemembered";
        private const string usuario = "Usuario";
        private static readonly bool booleanDefault = false;
        private static readonly string stringDefault = string.Empty;

        #endregion
        
        public static bool IsRemembered
        {
            get
            {
                return AppSettings.GetValueOrDefault(isRemembered, booleanDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(isRemembered, value);
            }
        }
        public static string Usuario
        {
            get
            {
                return AppSettings.GetValueOrDefault(usuario, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(usuario, value);
            }
        }
    }
}
