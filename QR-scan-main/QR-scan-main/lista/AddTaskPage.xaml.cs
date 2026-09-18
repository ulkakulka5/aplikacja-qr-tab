using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace lista_zakupow;

public partial class AddTaskPage : ContentPage
{
    public ObservableCollection<Item> _products;

    public AddTaskPage(ObservableCollection<Item> products)
    {
        InitializeComponent();
        _products = products;
    }

    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        
        if (!string.IsNullOrWhiteSpace(addItem.Text))
        {
            _products.Add(new Item { Name = addItem.Text, Number = 1 });

            await Navigation.PopAsync();
        }
    }
}

