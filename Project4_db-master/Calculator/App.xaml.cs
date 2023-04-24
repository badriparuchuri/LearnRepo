using Calculator.ViewModels;

namespace Calculator;

public partial class App : Application
{
	public static HistoryViewModel historyViewModel;
	public App(DatabaseService database)
	{
		InitializeComponent();
        MainPage = new AppShell();
        historyViewModel = new HistoryViewModel(database);

	}
}
