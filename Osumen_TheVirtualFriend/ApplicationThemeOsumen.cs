using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osumen_TheVirtualFriend
{
    class ApplicationThemeOsumen
    {
        public enum AppTheme
        {
            Light,
            Dark
        }

        private AppTheme GetAppTheme()
        {
            String apptheme = Properties.Settings.Default.SelectedTheme;
            return ConvertFrom(apptheme);
        }

        private AppTheme ConvertFrom(String ThemeName)
        {
            if (ThemeName == "Dark")
            {
                return AppTheme.Dark;
            }
            else
            {
                return AppTheme.Light;
            }
        }


    }
}
