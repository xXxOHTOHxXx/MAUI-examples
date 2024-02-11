using System.Numerics;

namespace Lab1;

public partial class MainPage : ContentPage
{
    int numflag = 2; // 3- new number1 // 2 - num1 being typed // 1 - num2 being typed // 0 - new number2 //-1 -err
    string opClicled;
    double num1 = 0;
    double num2 = 0;
    double memory = 0;

    void OnMfuncClicked(object sender, EventArgs e)
    {
        Button buttonClicked = (Button)sender;

        switch (buttonClicked.Text)
        {
            case "MC":
                memory=0;
                break;
            case "MR":
                this.display.Text = memory.ToString();
                if (numflag == 2 || numflag == 3)
                {
                    double.TryParse(this.display.Text, out num1);
                }
                else
                {
                    double.TryParse(this.display.Text, out num2);
                }
                break;
            case "M+":
                {
                    double rec = 0; double.TryParse(this.display.Text, out rec);
                    memory = memory + rec;
                }
                break;
            case "M-":
                {
                    double rec = 0; double.TryParse(this.display.Text, out rec);
                    memory = memory - rec;
                }
                break;
            case "MS":
                double.TryParse(this.display.Text, out memory);
                break;
            default:
                break;
        }
    }
    public MainPage()
	{
		InitializeComponent();
	}


   void DigitClicked(object sender, EventArgs e)
    {
        if (numflag == -1) return;

        Button buttonClicked = (Button)sender;
        string digit = buttonClicked.Text;

        if (this.display.Text == "0" || numflag==0 || numflag==3 )
            this.display.Text = string.Empty;

        this.display.Text += digit;

        double bitNumber;
        if (double.TryParse(this.display.Text, out bitNumber))
        {
            this.display.Text = bitNumber.ToString();
            if (numflag == 2 || numflag==3)
            {
                num1 = bitNumber;
                numflag = 2;
            }
            else
            {
                num2 = bitNumber;
                numflag = 1;
            }
        }
    }


    void cClicked(object sender, EventArgs e)
    {
        num1 = 0;
        num2 = 0;
        numflag = 2;
        opClicled = "";
        this.display.Text = "0";
    }

    void ceClicked(object sender, EventArgs e)
    {
        if (numflag == 2 || numflag == 3)
        {
            num1 = 0;
            this.display.Text = num1.ToString();
        }
        else
        {
            num2 = 0;
            this.display.Text = num2.ToString();
        }
    }

    void eraseClicked(object sender, EventArgs e)
    {
        if(this.display.Text.Length > 1)
        {
            this.display.Text = this.display.Text.Remove(display.Text.Length-1,1);
        }
        else if(this.display.Text.Length == 1)
        {
            this.display.Text = "0";
        }

        if (numflag == 2 || numflag == 3)
        {
            double.TryParse(this.display.Text, out num1);
        }
        else
        {
            double.TryParse(this.display.Text, out num2);
        }
    }
    
    void dotClicked(object sender, EventArgs e)
    {
        if(this.display.Text.Contains(','))
        {
            return;
        }
        else
        {
            this.display.Text += ",";
        }
    }

    void SqrtClicked(object sender, EventArgs e)
    {
        if (numflag == -1) return;
        //if (num1 == 0)
        //    return;
        num1 = Math.Sqrt(num1);
        this.display.Text = num1.ToString();
    }

    void powneg1Clicked(object sender, EventArgs e)
    {
        if (numflag == -1) return;
        if (num1 == 0)
        {
            this.display.Text = "err";
            numflag = -1;
            return;
        }
        if (numflag == 2 || numflag == 3)
        {
            num1 = 1.0 / num1;
            this.display.Text = num1.ToString();
        }
        else
        {
            num2 = 1.0/num2;
            this.display.Text = num2.ToString();
        }
    }

    void pow2Clicked(object sender, EventArgs e)
    {
        if (numflag == -1) return;
        if (numflag == 2 || numflag == 3)
        {
            num1 = Math.Pow(num1, 2);
            this.display.Text = num1.ToString();
        }
        else
        {
            num2 = Math.Pow(num2, 2);
            this.display.Text = num2.ToString();
        }
    }

    void circleAreaClicked(object sender, EventArgs e)
    {
        if (numflag == -1) return;
        if (numflag == 2 || numflag == 3)
        {
            num1 = Math.PI * Math.Pow(num1, 2);
            this.display.Text = num1.ToString();
        }
        else
        {
            num2 = Math.PI * Math.Pow(num2, 2);
            this.display.Text = num2.ToString();
        }
    }

    void signSwap(object sender, EventArgs e)
    {
        if (this.display.Text[0] != '-')
        {
            this.display.Text = "-" + this.display.Text;
        }
        else if (this.display.Text == "0") return;
        else
        {
            this.display.Text = this.display.Text.Remove(0, 1);
        }

        if (numflag == 2 || numflag == 3)
        {
            double.TryParse(this.display.Text, out num1);
        }
        else
        {
            double.TryParse(this.display.Text, out num2);
        }
    }


    void BinaryOperations(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        opClicled = button.Text;
        numflag = 0;
    }

    void equalClicked(object sender, EventArgs e)
    {
        double result = 0;
        switch (opClicled)
        {
            case "/":
                if (num2 == 0)
                {
                    this.display.Text = "err";
                    numflag = -1;
                    return;
                }
                result = num1 / num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "+":
                result = num1 + num2;
                break;
            case "%":
                result = num1 % num2;
                break;
            default:
                result = num1;
                break;
        }
        num1 = result;
        this.display.Text = num1.ToString();
        numflag = 3;
    }


}


