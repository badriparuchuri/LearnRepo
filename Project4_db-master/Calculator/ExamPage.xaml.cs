namespace Calculator;

public partial class ExamPage : ContentPage
{
    public int currentQuestionNumber = 0;
    public string correctOptionValue;
    public ExamPage()
    {
        InitializeComponent();
        getQuestionNumberFromStorage();
        getQuestionData();
    }

    public void getQuestionNumberFromStorage()
    {
        currentQuestionNumber = Store.pageNum;
    }

    public async void goToNextQuestion()
    {
        ++currentQuestionNumber;
        if(currentQuestionNumber >= 9)
        {
            await Navigation.PushAsync(new CompletedPage());
            return;
        }
        Store.setPage(currentQuestionNumber);
        getQuestionData();
    }

    public async void getQuestionData()
    {
        
        ApiService apiService = new ApiService();
        var questionData = await apiService.getExamQuestion(currentQuestionNumber);
        questionText.Text = questionData.questionText;
        optionOneBtn.Text = questionData.optionOne;
        optionTwoBtn.Text = questionData.optionTwo;
        optionThreeBtn.Text = questionData.optionThree;
        correctOptionValue = questionData.correctOptionValue;
    }

    private async void optionBtn_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string buttonValue = button.Text;
        if (buttonValue != correctOptionValue)
        {
            await Navigation.PushAsync(new WrongAnswerPage());
            return;
        }
        await Navigation.PushAsync(new CorrectAnswerPage());
        return;
    }

}