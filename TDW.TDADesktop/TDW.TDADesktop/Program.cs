using System;
using System.Collections.Generic;
using System.Windows.Forms;

// https://channel9.msdn.com/Blogs/TheChannel9Team/Joe-Stegman-Building-Outlook-UI-in-100-lines-of-code-with-Winforms
// https://docs.microsoft.com/en-us/dotnet/desktop/winforms/migration/?view=netdesktop-5.0&preserve-view=true
// https://docs.microsoft.com/en-us/dotnet/standard/analyzers/portability-analyzer
// https://marketplace.visualstudio.com/items?itemName=ConnieYau.NETPortabilityAnalyzer
// https://docs.microsoft.com/en-us/dotnet/core/porting/upgrade-assistant-winforms-framework
// https://github.com/dotnet/upgrade-assistant#installation
// https://www.outsystems.com/blog/posts/migrating-from-net-framework-to-net-core/
//

namespace System.Windows.Forms.Samples
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}