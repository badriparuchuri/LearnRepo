using System.Data;

namespace Calculator;

public partial class AdvancedPage : ContentPage
{
    string currentEntry = "";
    int currentState = 1;
    string mathOperator;
    double firstNumber, secondNumber;
    string input = "";
   //string decimalFormat = "N0";


    public AdvancedPage()
    {
        InitializeComponent();
        OnClearEvent(this, null);
        BindingContext = App.historyViewModel;
    }

    void OnSelectNumber(object sender, EventArgs e)
    {

        Button button = (Button)sender;
        String btnpressed = button.Text;
        if (btnpressed == "mod")
        {
            input += "%";
        }
        else if (btnpressed == "×")
        {
            input += "*";
        }
        else if (btnpressed == "÷")
        {
            input += "/";
        }
        else if (btnpressed == "%")
        {
            input += "/100";
        }
        else
        {
            input += btnpressed;
        }

        result.Text = input;
        CurrentCalculation.Text = input;
    }

    void OnSelectOperator(object sender, EventArgs e)
    {
        LockNumberValue(result.Text);

        currentState = -2;
        Button button = (Button)sender;
        string pressed = button.Text;
        if (pressed == "mod")
        {
            mathOperator = "%";
        }
        else
        {
            mathOperator = pressed;
        }
    }

    private void LockNumberValue(string text)
    {
        double number;
        if (double.TryParse(text, out number))
        {
            if (currentState == 1)
            {
                firstNumber = number;
            }
            else
            {
                secondNumber = number;
            }


            currentEntry = string.Empty;
        }
    }

    void OnClearEvent(object sender, EventArgs e)
    {
        input = String.Empty;
        this.result.Text = "0";
        CurrentCalculation.Text = "0";
        currentEntry = string.Empty;
    }

    void OnCalculateEvent(object sender, EventArgs ev)
    {
        var dt = new DataTable();
        this.result.Text = dt.Compute(input, "").ToString();
        App.historyViewModel.sample = $"{this.result.Text}";
        App.historyViewModel.saveToHistory($"{CurrentCalculation.Text} = {this.result.Text}");
        currentState = -1;
        input = this.result.Text;
    }

    void OnNegativeEvent(object sender, EventArgs e)
    {
        var neg = float.Parse(input) * -1;
        this.result.Text = neg.ToString();
        input = this.result.Text;
    }

    void OnSquarerootEvent(object sender, EventArgs e)
    {
        var num = int.Parse(input);
        var res = Math.Sqrt(num);
        this.result.Text = res.ToString();
        input = res.ToString();

    }
}