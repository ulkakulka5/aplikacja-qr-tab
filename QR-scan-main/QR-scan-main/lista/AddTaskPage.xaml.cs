using System.Collections.ObjectModel;

namespace lista_zakupow;

public partial class AddTaskPage : ContentPage
{
    private readonly DatabaseService _databaseService;

    public DodajFilm(DatabaseService databaseService)
    {
        InitializeComponent();

        _databaseService = databaseService;
    }

    private async void OnDodajFilmClicked(object sender, EventArgs e)
    {
        var film = new Film
        {
            Tytul = TytulEntry.Text,
            Rezyser = RezyserEntry.Text,
            RokProdukcji = int.Parse(RokProdukcjiEntry.Text),
            Ocena = int.Parse(OcenaEntry.Text)
        };
        await _databaseService.DodajFilmAsync(film);
    }
}
