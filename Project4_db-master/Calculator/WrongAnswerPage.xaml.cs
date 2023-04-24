namespace Calculator;

public partial class WrongAnswerPage : ContentPage
{
	public WrongAnswerPage()
	{
		InitializeComponent();
	}

    public async void navigateToNextQuestion(object sender, EventArgs e)
    {
        var int_num = Store.pageNum + 1;
        Store.setPage(int_num);
        if (Store.pageNum >= 9)
        {
            await Navigation.PushAsync(new CompletedPage());
            return;
        }
        await Navigation.PushAsync(new ExamPage());
    }

    public async void trySameQuestionAgain(object sender, EventArgs e)
    {
        var int_num = Store.pageNum;
        Store.setPage(int_num);
        await Navigation.PushAsync(new ExamPage());
    }
}