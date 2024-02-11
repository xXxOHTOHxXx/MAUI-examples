using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Diagnostics;

namespace Lab1;

public partial class lab2page : ContentPage
{
    public lab2page()
    {
        InitializeComponent();
    }

    CancellationTokenSource cancelTokenSource = new CancellationTokenSource();


    //public async void StartClicked(object sender, EventArgs e)
    //{
    //    CancellationToken token = cancelTokenSource.Token;
    //    this.pgLabel.Text = "Calculating...";

    //    while (xcoord1 < xcoord2)
    //    {
    //        await Task.Run(() => CalculateInt());
    //        this.progBar.Progress = (int)(xcoord1 / xcoord2 * 100);
    //    }

    //    if (token.IsCancellationRequested)
    //    {
    //        return;
    //    }
    //    this.pgLabel.Text = ResDefInt.ToString();
    //}

    //async private Task CalculateInt()
    //{
    //    ResDefInt += (Math.Sin(xcoord1) * 0.0001);
    //    xcoord1 += 0.0000001;//0.00000001

    //    for (int i = 0; i < 10; i++) { int a = 123 * i; }//delay
    //}

    public void CancelClicked(object sender, EventArgs e)
    {
        cancelTokenSource.Cancel();
    }

    private async void StartClicked(object sender, EventArgs e)
    {
        cancelTokenSource = new CancellationTokenSource();
        CancellationToken token = cancelTokenSource.Token;
        double step = 0.001;
        double start = 0;
        double end = 1;
        double result = 0;


        await Task.Run(async () =>
        {
            for (double i = start; i < end; i += step)
            {
                if (token.IsCancellationRequested)
                {
                    await MainThread.InvokeOnMainThreadAsync(() =>
                    {
                        this.progBar.Progress = 0;
                        this.pgLabel.Text = "Cancelled";
                    });
                    return;
                }
                await Task.Delay(1);
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    this.progBar.Progress = i / end;
                    this.ProgNum.Text = (i / end * 100).ToString() + "%";
                });
                result += Math.Sin(i) * step;

                // Задержка для увеличения времени выполнения вычисления

            }
        });

        if (token.IsCancellationRequested)
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                this.progBar.Progress = 0;
                this.ProgNum.Text = "0%";
                this.pgLabel.Text = "Cancelled";
            });
            cancelTokenSource.Dispose();
            return;
        }
        this.ProgNum.Text = "100%";
        this.pgLabel.Text = result.ToString();

    }
}