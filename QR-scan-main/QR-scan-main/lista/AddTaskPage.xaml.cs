using System.Collections.ObjectModel;

namespace lista_zakupow;

public partial class AddTaskPage : ContentPage
{
    private readonly DatabaseService _databaseService;

    public AddTaskPage(DatabaseService databaseService)
    {
        InitializeComponent();

        _databaseService = databaseService;
    }

    private async void OnDodajFilmClicked(object sender, EventArgs e)
    {
        var film = new Item
        {
            NumerUrzadzenia = TytulEntr.Text,
            Rezyser = RezyserEntry.Text,
            RokProdukcji = int.Parse(RokProdukcjiEntry.Text),
            Ocena = int.Parse(OcenaEntry.Text)
        };
        await _databaseService.DodajFilmAsync(film);
    }
}
