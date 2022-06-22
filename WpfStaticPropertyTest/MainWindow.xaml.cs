using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfStaticPropertyTest
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			var binding = new Binding("StaticName") { Mode = BindingMode.OneWay }; // Setting Source is not required.
			this.TargetName.SetBinding(TextBlock.TextProperty, binding);
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (this.DataContext is MainWindowViewModel vm)
				vm.Name = "Changed Instance Name !!!";

			MainWindowViewModel.StaticName = "Changed Static Name !!!";
		}
	}
}