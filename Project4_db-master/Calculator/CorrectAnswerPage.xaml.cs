namespace Calculator;

public partial class CorrectAnswerPage : ContentPage
{
	public CorrectAnswerPage()
	{
		InitializeComponent();
	}

    public async void navigateToNextQuestion(object sender, EventArgs e)
    {
        var int_num = Store.pageNum + 1;
        Store.setPage(int_num);
        await Navigation.PushAsync(new ExamPage());
    }
}