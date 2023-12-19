using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Application = Microsoft.Maui.Controls.Application;

namespace TabPage_GenerateItems
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			MainPage = new MainPage();
		}
	}
}
