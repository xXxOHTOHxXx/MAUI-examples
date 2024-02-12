using Lab1.Services;
using NbrbAPI.Models;

namespace Lab1;

public partial class lab4page : ContentPage
{
	private IEnumerable<Rate>? rates;
	public lab4page()
	{
		InitializeComponent();
        var serviceProvider = MauiProgram.services.BuildServiceProvider();
        MauiProgram.rateService = serviceProvider.GetService<RateService>();
    }

	public void Picker1SelectedIndexChanged(object sender, EventArgs e)
	{
		if (rates == null)
		{
			return;
		}

	}

    public void Picker2SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rates == null)
        {
            return;
        }
    }

	public void DateSelected(object sender, EventArgs e)
	{
		rates = MauiProgram.rateService.GetRates(this.DatePicker.Date).Result;
	}
}

//public class WholeNumberValidationBehavior : Behavior<Entry>
//{
//    protected override void OnAttachedTo(Entry bindable)
//    {
//        bindable.TextChanged += Bindable_TextChanged;
//        base.OnAttachedTo(bindable);
//    }

//    protected override void OnDetachingFrom(Entry bindable)
//    {
//        bindable.TextChanged -= Bindable_TextChanged;
//        base.OnDetachingFrom(bindable);
//    }

//    private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
//    {
//        if (!string.IsNullOrEmpty(e.NewTextValue))
//        {
//            bool isWholeNumber = int.TryParse(e.NewTextValue, out int value) && value > 0;
//            if (!isWholeNumber)
//            {
//                ((Entry)sender).Text = e.OldTextValue;
//            }
//        }
//        else
//        {
//            ((Entry)sender).Text = null;
//        }
//    }
//}