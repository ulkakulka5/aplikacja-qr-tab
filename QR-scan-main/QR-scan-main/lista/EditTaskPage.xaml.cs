using System.Collections.ObjectModel;

namespace lista_zakupow;

public partial class EditTaskPage : ContentPage
{
    private readonly DatabaseService _databaseService;
    private readonly Item _item;
    public ObservableCollection<Item> Products { get; }

    public EditTaskPage(Item item, ObservableCollection<Item> products, DatabaseService databaseService)
    {
        InitializeComponent();
        _item = item;
        Products = products;
        _databaseService = databaseService;
        BindingContext = this;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var parts = (_item.ImieNazwiskoKLasa ?? string.Empty)
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Imie.Text = parts.Length > 0 ? parts[0] : string.Empty;
        Nazwisko.Text = parts.Length > 1 ? parts[1] : string.Empty;
        Klasa.Text = parts.Length > 2 ? parts[2] : string.Empty;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        _item.ImieNazwiskoKLasa = $"{Imie.Text} {Nazwisko.Text} {Klasa.Text}".Trim();
        await _databaseService.AktualizujFilmAsync(_item);
        await Navigation.PopAsync();
    }
}
