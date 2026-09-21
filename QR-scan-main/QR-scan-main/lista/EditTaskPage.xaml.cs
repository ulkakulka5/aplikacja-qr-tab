using System.Collections.ObjectModel;

namespace lista_zakupow;

public partial class EditTaskPage : ContentPage
{ 
    private Item _itemToEdit;
    private ObservableCollection<Item> _Tablety;

    /*public EditTaskPage(Item itemToEdit, ObservableCollection<Item> products)
    {
        InitializeComponent();
        _itemToEdit = itemToEdit;
        _products = products;

        NameEntry.Text = _itemToEdit.Name;
    }

    private async void SaveEdit_Clicked(object sender, EventArgs e)
    {
        int index = _products.IndexOf(_itemToEdit);

        if (index != -1)
        {
            _itemToEdit.Name = NameEntry.Text;
            _products[index] = _itemToEdit;
        }
        await Navigation.PopAsync();
    }*/
}