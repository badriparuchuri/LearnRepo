namespace Calculator;

public partial class ErrorPage : ContentPage
{
	public ErrorPage()
	{
		InitializeComponent();
	}

    public async void navigateToNextQuestion(object sender, EventArgs e)
    {
        var int_num = CustomStore.pageNum + 1;
        CustomStore.pageNum = int_num;
        if (CustomStore.pageNum >= 10)
        {
            await Navigation.PushAsync(new CongratsPage());
            return;
        }
        await Navigation.PushAsync(new PractisePage());
    }

    public async void trySameQuestionAgain(object sender, EventArgs e)
    {
        var int_num = CustomStore.pageNum;
        CustomStore.pageNum = int_num;
        await Navigation.PushAsync(new PractisePage());
    }
}