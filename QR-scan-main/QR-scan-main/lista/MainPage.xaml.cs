using System.Collections.ObjectModel;
using System.Text.Json;

namespace lista_zakupow
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Item> Products { get; set; }
        private string filePath = Path.Combine(FileSystem.AppDataDirectory, "tasks.json");
        public MainPage()
        {
            InitializeComponent();
            Products = new ObservableCollection<Item>();
            BindingContext = this;

        }


        private async void AddButton_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new AddTaskPage(Products));
        }

        private async void AddQR_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SkanerQR(Products));
        }

        private void Delete_Button_Clicked(object sender, EventArgs e)
        {
            Products.Remove((Item)list.SelectedItem);
        }

        private void SaveButton_Clicked(Object sender, EventArgs e)
        {
            string json = JsonSerializer.Serialize(Products);
            File.WriteAllText(filePath, json);
        }

        private void LoadButton_Clicked(System.Object sender, EventArgs e)
        {
            string json = File.ReadAllText(filePath);
            var restored = JsonSerializer.Deserialize<List<Item>>(json);
            Products.Clear();
            foreach (var item in restored)
                Products.Add(item);
        }


        private async void EditButton_Clicked(object sender, EventArgs e)
        {

            if (list.SelectedItem is Item selectedItem)
            {

                await Navigation.PushAsync(new EditTaskPage(selectedItem, Products));
            }
        }

    }
}
