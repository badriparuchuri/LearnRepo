//using Java.Sql;

namespace Calculator;

public partial class MainPage : ContentPage
{
    int currentState = 1;
    String operatorMath;
    double firstNum, secondNum;
    String currentEntry = "";


    public MainPage()
    {
        InitializeComponent();
        OnClearEvent(this, null);
    }
    //string currentEntry = "";
    //int currentState = 1;
    //string mathOperator;
    //double firstNumber, secondNumber;
    string decimalFormat = "N0";


    private void OnClearEvent(object sender, EventArgs e)
    {
        firstNum = 0;
        secondNum = 0;
        currentState = 1;
        this.result.Text = "0";
        currentEntry = String.Empty;

    }

    private void squareRoot(object sender, EventArgs e)
    {
        if (firstNum == 0)
        {
            return;
        }
        firstNum = firstNum * firstNum;
        this.result.Text = firstNum.ToString();
    }

    private void OnSelectNumber(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        String btnPressed = button.Text;

        if (this.result.Text == "0" || currentState < 0)
        {
            this.result.Text = String.Empty;
            if (currentState < 0)
            {
                currentState *= -1;

            }

        }

        this.result.Text += btnPressed;

        double number;

        if (double.TryParse(this.result.Text, out number))
        {
            this.result.Text = number.ToString("N0");
            if (currentState == 1)
            {
                firstNum = number;

            }
            else
            {
                secondNum = number;
            }
        }


    }

    private void OnPercentage(object sender, EventArgs e)
    {
        
    }

    private void OnSelectOperator(object sender, EventArgs e)
    {
        currentState = -2;
        Button button = (Button)sender;
        String btnPressed = button.Text;
        operatorMath = btnPressed;


    }

    private void OnNegative(object sender, EventArgs e)
    {
        if(currentState == 1)
        {
            secondNum = -1;
            operatorMath = "×";
            currentState = 2;
            OnCalculate(this, null);
        }
    }

    private void OnCalculate(object sender, EventArgs e)
    {
        if (currentState == 2)
        {
            
            double result = Calculate.calculate(firstNum, secondNum, operatorMath);

            this.CurrentCalculation.Text = $"{firstNum} {operatorMath} {secondNum}";

            this.result.Text = result.ToString();
            App.historyViewModel.sample = $"{result.ToString()}";
            App.historyViewModel.saveToHistory($"{firstNum} {operatorMath} {secondNum} = {result.ToTrimmedString(decimalFormat)}");

            firstNum = result;
            currentState = -1;
            currentEntry = string.Empty;





        }
    }
    private void LockNumberValue(string text)
    {
        double number;
        if (double.TryParse(text, out number))
        {
            if (currentState == 1)
            {
                firstNum = number;
            }
            else
            {
                secondNum = number;
            }

            currentEntry = string.Empty;
        }
    }
}