using Lab1.Services;
using NbrbAPI.Models;

namespace Lab1;

public partial class lab4page : ContentPage
{
	private IEnumerable<Rate>? rates;
    private Rate CurrRate;/*e= new rates.FirstOrDefault(curr => curr.Cur_Name == "Российский рубль");;*/
    private bool SkipTextChanged = false;
	public lab4page()
	{
		InitializeComponent();
        var serviceProvider = MauiProgram.services.BuildServiceProvider();
        MauiProgram.rateService = serviceProvider.GetService<IRateService>();
        this.Entry1.IsEnabled = false;
        this.Entry2.IsEnabled = false;
        this.Currency2.IsEnabled = false;
        this.ConvertButton.IsEnabled = false;
        this.DatePicker.MaximumDate = DateTime.Today;
        rates = new List<Rate>();

    }


    public void Picker2SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Entry2.IsEnabled = true;
        this.Entry1.IsEnabled = true;
        SkipTextChanged = true;
        //this.Entry1.TextChanged -= this.OnEntry1TextChanged;
        //this.Entry1.Text = "1";
        //this.Entry1.TextChanged += this.OnEntry1TextChanged;

        if (rates == null)
        {
            throw new NullReferenceException(nameof(rates));
        }

        CurrRate = rates.FirstOrDefault(curr => curr.Cur_Name == this.Currency2.SelectedItem.ToString());
        if (CurrRate == null)
        {
            throw new NullReferenceException(nameof(CurrRate));
        }
        //this.Entry2.TextChanged-= this.OnEntry2TextChanged;
        //this.Entry2.Text = (Convert.ToDecimal(this.Entry1.Text) / CurrRate.Cur_OfficialRate * CurrRate.Cur_Scale).ToString();
        //this.Entry2.TextChanged += this.OnEntry2TextChanged;
        //SkipTextChanged = false;
    }

    public void OnEntry1TextChanged(object sender, EventArgs e)
    {
        //if (SkipTextChanged) return;
        //if (rates == null)
        //{
        //    throw new NullReferenceException(nameof(rates));
        //}
        //if (this.Entry1.Text.Length == 0)
        //{
        //    this.Entry1.TextChanged -= this.OnEntry1TextChanged;
        //    this.Entry1.Text = "0";
        //    this.Entry1.TextChanged += this.OnEntry1TextChanged;
        //    return;
        //}
        //if (this.Entry1.Text[0] == '0')
        //{
        //    this.Entry1.TextChanged -= this.OnEntry1TextChanged;
        //    this.Entry1.Text.Remove(0, 1);
        //    this.Entry1.TextChanged += this.OnEntry1TextChanged;
        //}

        //this.Entry1.TextChanged -= this.OnEntry1TextChanged;
        //this.Entry2.TextChanged -= this.OnEntry2TextChanged;
        //SkipTextChanged = true;
        //this.Entry2.Text = ((Convert.ToDecimal(this.Entry1.Text)) / CurrRate.Cur_OfficialRate * CurrRate.Cur_Scale).ToString();
        //SkipTextChanged = false;
        //this.Entry2.TextChanged += this.OnEntry2TextChanged;
        //this.Entry1.TextChanged += this.OnEntry1TextChanged;

    }

    public void OnEntry2TextChanged(object sender, EventArgs e)
    {
        //if (SkipTextChanged) return;
        //if (rates == null)
        //{
        //    throw new NullReferenceException(nameof(rates));
        //}
        //if (this.Entry2.Text.Length == 0)
        //{
        //    this.Entry2.TextChanged -= this.OnEntry2TextChanged;
        //    this.Entry2.Text = "0";
        //    this.Entry2.TextChanged += this.OnEntry2TextChanged;
        //    return;
        //}
        //if (this.Entry2.Text[0] == '0')
        //{
        //    this.Entry2.TextChanged -= this.OnEntry2TextChanged;
        //    this.Entry2.Text.Remove(0, 1);
        //    this.Entry2.TextChanged += this.OnEntry2TextChanged;
        //}

        //this.Entry1.TextChanged -= this.OnEntry1TextChanged;
        //this.Entry2.TextChanged -= this.OnEntry2TextChanged;
        //SkipTextChanged = true;
        //this.Entry1.Text = ((Convert.ToDecimal(this.Entry2.Text)) * CurrRate.Cur_OfficialRate / CurrRate.Cur_Scale).ToString();
        //SkipTextChanged = false;
        //this.Entry1.TextChanged += this.OnEntry1TextChanged;
        //this.Entry2.TextChanged += this.OnEntry2TextChanged;

    }

    public void OnConvertClicked(object sender, EventArgs e)
    {
        this.Entry2.Text= ((Convert.ToDecimal(this.Entry1.Text)) * CurrRate.Cur_OfficialRate / CurrRate.Cur_Scale).ToString();
    }
    public async void DateSelected(object sender, EventArgs e)
	{
        SkipTextChanged = true;
        if (MauiProgram.rateService == null)
        {
            throw new NullReferenceException("Rates on date are null");
        }

        
        rates = await MauiProgram.rateService.GetRates(this.DatePicker.Date);
        this.Currency2.IsEnabled = true;
        this.ConvertButton.IsEnabled = true;
        //if(this.Currency2.SelectedIndex!=-1)
        //{
        //    this.Entry2.IsEnabled = true;
        //    this.Entry1.IsEnabled = true;
        //    this.Entry1.TextChanged -= this.OnEntry1TextChanged;
        //    this.Entry1.Text = "1";
        //    this.Entry1.TextChanged += this.OnEntry1TextChanged;

        //    if (rates == null)
        //    {
        //        throw new NullReferenceException(nameof(rates));
        //    }

        //    CurrRate = rates.FirstOrDefault(curr => curr.Cur_Name == this.Currency2.SelectedItem.ToString());
        //    this.Entry2.TextChanged -= this.OnEntry2TextChanged;
        //    this.Entry2.Text = (Convert.ToDecimal(this.Entry1.Text) / CurrRate.Cur_OfficialRate * CurrRate.Cur_Scale).ToString();
        //    this.Entry2.TextChanged += this.OnEntry2TextChanged;
        //}
        SkipTextChanged = false;
    }
}