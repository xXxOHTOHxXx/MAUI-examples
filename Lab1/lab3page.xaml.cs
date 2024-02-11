using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Lab3.Services;
using Lab1;
using Microsoft.Extensions.DependencyInjection;

namespace Lab1;
public partial class lab3page : ContentPage
{
    public lab3page()
    {
        //Loaded += OnPageLoaded;
        InitializeComponent();
        var serviceProvider = MauiProgram.services.BuildServiceProvider();
        MauiProgram.dbService = serviceProvider.GetService<IDbService>();
        MauiProgram.dbService.Init();
        foreach (var item in MauiProgram.dbService.GetAllAuthors())
        {
            this.DBPicker.Items.Add(item.Name);
        }

    }

    //private void OnPageLoaded(object sender, EventArgs e) 
    //{
    //    var serviceProvider = MauiProgram.services.BuildServiceProvider();
    //    MauiProgram.dbService = serviceProvider.GetService<IDbService>();
    //    MauiProgram.dbService.Init();

    //}
    void PickerSelectedIndexChanged(object sender, EventArgs e)
    {
        ContentStackLayout.Clear();
        var item = MauiProgram.dbService.GetAllAuthors().FirstOrDefault(author => author.Name == DBPicker.Items[DBPicker.SelectedIndex]);
        var books = MauiProgram.dbService.GetAuthorsBooks(item.ID);
        string allBooks = "";
        foreach (var book in books)
        {
            allBooks += book.Title + "\n";
        }
        Border AgeBorder = new Border
        {
            Stroke = Colors.Gray,
            Content = new Label
            {
                Text = "Age: " + item.Age.ToString(),
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            },
            BackgroundColor = Color.FromArgb("#e1e1e1")
        };
        Border CountryBorder = new Border
        {
            Stroke = Colors.Gray,
            Content = new Label
            {
                Text = "Country: " + item.Country,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            },
            BackgroundColor = Color.FromArgb("#e1e1e1")
        };
        Border BooksBorder = new Border
        {
            Stroke = Colors.Gray,
            Content = new Label
            {
                Text = "Books: " + allBooks,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            },
            BackgroundColor = Color.FromArgb("#e1e1e1")
        };

        ContentStackLayout.Add(AgeBorder);
        ContentStackLayout.Add(CountryBorder);
        ContentStackLayout.Add(BooksBorder);


    }

}