using System;
using System.Collections.Generic;
using Caliburn.Micro;
using System.Threading.Tasks;

namespace Gemini.Modules.ToolBars.Models
{
	public class ToolBarItem : StandardToolBarItem
	{
		private readonly Func<Task> _execute;

		#region Constructors

		public ToolBarItem(string text)
			: base(text)
		{
			
		}

		public ToolBarItem(string text, Func<Task> execute)
			: base(text)
		{
			_execute = execute;
		}

        public ToolBarItem(string text, Func<Task> execute, Func<bool> canExecute)
			: base(text, canExecute)
		{
			_execute = execute;
		}

		#endregion

		public async Task Execute()
		{
			if(_execute != null) await _execute();
		}
	}
}