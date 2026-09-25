using System.Collections.ObjectModel;

namespace lista_zakupow
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Item> Products { get; set; } = new();
        private readonly DatabaseService _databaseService;

        public MainPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Products.Clear();
            foreach (var item in await _databaseService.PobierzFilmyAsync())
                Products.Add(item);
        }

        private async void AddQR_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SkanerQR(Products, _databaseService));
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            if (list.SelectedItem is Item selected)
            {
                await _databaseService.UsunFilmAsync(selected);
                Products.Remove(selected);
                list.SelectedItem = null; 
            }
        }

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            if (list.SelectedItem is Item selectedItem)
            {
                await Navigation.PushAsync(new EditTaskPage(selectedItem, Products, _databaseService));
            }
            
        }
    }
}
