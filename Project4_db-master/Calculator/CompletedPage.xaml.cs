namespace Calculator;

public partial class CompletedPage : ContentPage
{
	public CompletedPage()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new MainPage());
	}
}