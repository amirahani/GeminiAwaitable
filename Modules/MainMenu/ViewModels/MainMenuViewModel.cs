using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Gemini.Framework.Results;
using Gemini.Framework.Services;
using Gemini.Modules.MainMenu.Models;
using Microsoft.Win32;
using ExtensionMethods = Gemini.Framework.Services.ExtensionMethods;
using System.Threading.Tasks;

namespace Gemini.Modules.MainMenu.ViewModels
{
	[Export(typeof(IMenu))]
	public class MainMenuViewModel : MenuModel
	{
		[Import] 
		private IShell _shell;

	    private bool _autoHide;

	    private readonly SettingsPropertyChangedEventManager<Properties.Settings> _settingsEventManager =
	        new SettingsPropertyChangedEventManager<Properties.Settings>(Properties.Settings.Default);

	    public MainMenuViewModel()
		{
			Add(
				new MenuItem(KnownItemNames.File, Properties.Resources.MenuItemFile)
				{
					new MenuItem(KnownItemNames.Open, Properties.Resources.MenuItemOpen, OpenFile).WithIcon(),
					MenuItemBase.Separator,
					new MenuItem(KnownItemNames.Exit, Properties.Resources.MenuItemExit, Exit),
				},
				new MenuItem(KnownItemNames.View, Properties.Resources.MenuItemView));

	        _autoHide = Properties.Settings.Default.AutoHideMainMenu;
            _settingsEventManager.AddListener(s => s.AutoHideMainMenu, value => { AutoHide = value; });
		}

	    public bool AutoHide
	    {
	        get { return _autoHide; }
	        private set
	        {
	            if (_autoHide == value)
	            {
	                return;
	            }

	            _autoHide = value;

	            NotifyOfPropertyChange(ExtensionMethods.GetPropertyName(() => AutoHide));
	        }
	    }

        private async Task OpenFile()
		{
			var dialog = new OpenFileDialog();
            await Show.CommonDialog(dialog);
            await Show.Document(dialog.FileName);
		}

        private async Task Exit()
		{
			_shell.Close();
		}
	}
}