using System.Collections.ObjectModel;
using System.Text.Json;

namespace lista_zakupow
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Item> Tablety { get; set; }
        private readonly DatabaseService _databaseService;
        private Item _wybranyTablet;
        public MainPage(DatabaseService databaseService)
        {
            InitializeComponent();
            Tablety = new ObservableCollection<Item>();
            _databaseService = databaseService;
            Tablety = new ObservableCollection<Item>();
            BindingContext = this;

        }


        private async void AddButton_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new AddTaskPage(Tablety));
        }

        private async void AddQR_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SkanerQR(Tablety));
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            Tablety.Remove((Item)list.SelectedItem);
        }

       

        


        private async void EditButton_Clicked(object sender, EventArgs e)
        {

            /*if (list.SelectedItem is Item selectedItem)
            {

                await Navigation.PushAsync(new EditTaskPage(selectedItem, Tablety));
            }*/
        }


    }
}
