﻿using MoneyFox.Application;
using MoneyFox.Presentation;
using MoneyFox.Presentation.Interfaces;

namespace MoneyFox.Droid
{
    public class ThemeSelectorAdapter : IThemeSelectorAdapter
    {
        public string Theme => ThemeManager.CurrentTheme().ToString();

        public void SetTheme(string theme)
        {
            ThemeManager.ChangeTheme(theme == "Light" ? AppTheme.Light : AppTheme.Dark);
        }
    }
}
