namespace Calculator;

public partial class App : Application
{
    public static HistoryViewModel historyViewModel;
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
        historyViewModel = new HistoryViewModel();
    }
}
