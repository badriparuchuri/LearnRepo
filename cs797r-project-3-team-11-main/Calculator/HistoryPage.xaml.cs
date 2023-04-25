using System.Runtime.CompilerServices;

namespace Calculator;

public partial class HistoryPage : ContentPage
{
	public HistoryPage()
	{
		InitializeComponent();
		BindingContext = App.historyViewModel;
	}
 
}
