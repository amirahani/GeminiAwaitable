using System;
using System.Collections.Generic;
using Caliburn.Micro;
using System.Threading.Tasks;

namespace Gemini.Modules.MainMenu.Models
{
	public class MenuItem : StandardMenuItem
	{
        private readonly Func<Task> _execute;

		#region Constructors

		public MenuItem(string text)
			: base(text)
		{
			
		}

        public MenuItem(string name, string text)
            : this(name, text, null, null) { }

        public MenuItem(string text, Func<Task> execute)
			: base(text)
		{
			_execute = execute;
		}

        public MenuItem(string name, string text, Func<Task> execute) 
            : this(name, text, execute, null) { }

        public MenuItem(string text, Func<Task> execute, Func<bool> canExecute)
			: base(text, canExecute)
		{
			_execute = execute;
		}

        public MenuItem(string name, string text, Func<Task> execute, Func<bool> canExecute)
            : base(name, text, canExecute)
        {
            this._execute = execute;
        }

		#endregion

		public async Task Execute()
		{
			if(_execute != null) await _execute();
		}
	}
}