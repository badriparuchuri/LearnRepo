using System.Text.Json;
using Uri = System.Uri;

namespace Calculator;

internal class CustomStore
{
    private static int pageNumber = 0;

    public static int pageNum { get; set; }

}

internal class QuestionModel
{
    public string questionText { get; set; }
    public int questionNumber { get; set; }
    public string optionOne { get; set; }
    public string optionTwo { get; set; }
    public string optionThree { get; set; }
    public string correctOptionValue { get; set; }
}
internal class RestService
{
    HttpClient _client;
    JsonSerializerOptions _serializerOptions;
    static string apiUrl = "http://3.6.127.17:8080/ques/";
    public QuestionModel question { get; private set; }

    public RestService()
    {
        _client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<QuestionModel> getCurrentQuestionData(int questionNumber)
    {
        question = new QuestionModel();

        Uri uri = new Uri(string.Format($"{apiUrl}{questionNumber}", string.Empty));
        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                question = JsonSerializer.Deserialize<QuestionModel>(content, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return question;
    }
}
        public partial class PractisePage : ContentPage
{

    public int currentQuestionNumber = 0;
    public string correctOptionValue;
    public PractisePage()
    {
        InitializeComponent();
        getQuestionNumberFromStorage();
        getQuestionData();
    }

    public void getQuestionNumberFromStorage()
    {
        currentQuestionNumber = CustomStore.pageNum;
    }

    public async void navigationToNextQuestion()
    {
        ++currentQuestionNumber;
        if (currentQuestionNumber >= 10)
        {
            await Navigation.PushAsync(new CongratsPage());
            return;
        }
        CustomStore.pageNum = currentQuestionNumber;
        getQuestionData();
    }
        public async void getQuestionData()
    {
        this.messageText.Text = "";
        RestService apiService = new RestService();
        var questionData = await apiService.getCurrentQuestionData(currentQuestionNumber);
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
            await Navigation.PushAsync(new ErrorPage());
            return;
        }
        this.messageText.Text = "Correct Answer moving to next question !";
        await Task.Delay(3000);
        navigationToNextQuestion();
        return;
    }
 }
