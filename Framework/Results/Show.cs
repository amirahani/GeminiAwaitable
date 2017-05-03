using Caliburn.Micro;
using Gemini.Framework.Services;
using Microsoft.Win32;
using System.Threading.Tasks;

namespace Gemini.Framework.Results
{
	public static class Show
	{
		public static async Task CommonDialog(CommonDialog commonDialog)
		{
			await new ShowCommonDialogResult(commonDialog).ExecuteAsync();
		}

		public static async Task<TTool> Tool<TTool>()
			where TTool : ITool
		{
            return await new ShowToolResult<TTool>().ExecuteAsync<TTool>();
		}

        public static Task<TTool> Tool<TTool>(TTool tool)
			where TTool : ITool
		{
            return new ShowToolResult<TTool>(tool).ExecuteAsync<TTool>();
		}

		public static async Task Document(IDocument document)
		{
			await new OpenDocumentResult(document).ExecuteAsync();
		}

        public static async Task Document(string path)
		{
            await new OpenDocumentResult(path).ExecuteAsync();
		}

        public static Task Document<T>()
				where T : IDocument
		{
            return new OpenDocumentResult(typeof(T)).ExecuteAsync();
		}

        public static Task<TWindow> Window<TWindow>()
                where TWindow : IWindow
        {
            return new ShowWindowResult<TWindow>().ExecuteAsync<TWindow>();
        }

        public static Task<TWindow> Window<TWindow>(TWindow window)
            where TWindow : IWindow
        {
            return new ShowWindowResult<TWindow>(window).ExecuteAsync<TWindow>();
        }

        public static Task<TWindow> Dialog<TWindow>()
                where TWindow : IWindow
        {
            return new ShowDialogResult<TWindow>().ExecuteAsync<TWindow>();
        }

        public static Task<TWindow> Dialog<TWindow>(TWindow window)
            where TWindow : IWindow
        {
            return new ShowDialogResult<TWindow>(window).ExecuteAsync<TWindow>();
        }
    }
}