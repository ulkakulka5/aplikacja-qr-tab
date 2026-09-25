using System.Collections.ObjectModel;

namespace lista_zakupow;

public partial class AddTaskPage : ContentPage
{
    private readonly DatabaseService _databaseService;
    public ObservableCollection<Item> Products { get; }

    public AddTaskPage(ObservableCollection<Item> products, DatabaseService databaseService)
    {
        InitializeComponent();
        Products = products;
        _databaseService = databaseService;
        BindingContext = this;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Imie.Text) ||
       string.IsNullOrWhiteSpace(Nazwisko.Text) ||
       string.IsNullOrWhiteSpace(Klasa.Text))
        {
            await DisplayAlert("B³¹d", "Uzupe³nij wszystkie pola.", "OK");
            return;
        }

        if (Products.Count > 0)
        {
            var item = Products[^1];
            item.ImieNazwiskoKLasa = $"{Imie.Text} {Nazwisko.Text} {Klasa.Text}".Trim();
            await _databaseService.DodajFilmAsync(item);
        }

        await Navigation.PopToRootAsync();
    }
}
