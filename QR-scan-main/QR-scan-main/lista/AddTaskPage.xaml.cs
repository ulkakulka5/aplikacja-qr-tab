using System.Collections.ObjectModel;

namespace lista_zakupow;

public partial class AddTaskPage : ContentPage
{
    public ObservableCollection<Item> _Tablety;

    private string wybranaKlasa;
    private string wybranaGrupa;
    private string wybranyUczen;

    public AddTaskPage(ObservableCollection<Item> Tablety)
    {
        InitializeComponent();

        _Tablety = Tablety;
    }

    private void listaKlasa_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        wybranaKlasa = e.SelectedItem.ToString();

        
        ((ListView)sender).SelectedItem = null;
    }

    private void listaGrupa_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        wybranaGrupa = e.SelectedItem.ToString();

        
        ((ListView)sender).SelectedItem = null;
    }

    private void listaUczen_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        wybranyUczen = e.SelectedItem.ToString();

        
        ((ListView)sender).SelectedItem = null;
    }

    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(wybranyUczen) ||
            string.IsNullOrEmpty(wybranaKlasa))
        {
            await DisplayAlert(
                "B³¹d",
                "Wybierz ucznia oraz klasê.",
                "OK");

            return;
        }

        _Tablety.Add(new Item
        {
            ImieNazwiskoKLasa = wybranyUczen + ", " + wybranaKlasa
        });

        
    }
}
