using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WpfStaticPropertyTest
{
	public class MainWindowViewModel : ObservableObject
	{
		public MainWindowViewModel()
		{
			Name = "Instance Name";
			StaticName = "Static Name";
		}

		public string? Name
		{
			get => _name;
			set => SetProperty(ref _name, value);
		}
		private string? _name;

		public static string? StaticName
		{
			get => _staticName;
			set
			{
				if (_staticName == value)
					return;

				_staticName = value;
				RaiseStaticPropertyChanged();
			}
		}
		private static string? _staticName;

		// A name of static event for data binding must meet the following rule:
		// https://docs.microsoft.com/en-us/dotnet/framework/wpf/getting-started/whats-new?#binding-to-static-properties

		public static event EventHandler<PropertyChangedEventArgs>? StaticPropertyChanged;

		private static void RaiseStaticPropertyChanged([CallerMemberName] string propertyName = "")
		{
			StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
		}
	}
}