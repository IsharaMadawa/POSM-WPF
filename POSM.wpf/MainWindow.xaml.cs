using System.Windows;

namespace POSM.wpf
{
	public partial class MainWindow : Window
	{
		public MainWindow(object dataContext)
		{
			InitializeComponent();
			DataContext = dataContext;
		}
	}
}
