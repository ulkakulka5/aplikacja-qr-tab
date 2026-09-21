using System.Collections.ObjectModel;

namespace lista_zakupow;

public partial class EditTaskPage : ContentPage
{
    private readonly DatabaseService _databaseService;
    private Item _pobranyTablet;
    private int _TabletId;
    public EdytujFilm(DatabaseService databaseService, int filmId)
    {
        InitializeComponent();
        _databaseService = databaseService;
        _TabletId = filmId;

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        _pobranyTablet = await _databaseService.PobierzFilmPoID(_TabletId);

        if (_pobranyTablet == null)
            return;

        TytulEntry.Text = _pobranyTablet.NumerUrzadzenia;
        RezyserEntry.Text = _pobranyTablet.ImieNazwiskoKLasa;
        RokProdukcjiEntry.Text = _pobranyTablet.Data.ToString();

    }

    private async void OnEdytujFilmClicked(object sender, EventArgs e)
    {
        var tablet = new Item
        {
            Id = _TabletId,
            NumerUrzadzenia = TytulEntry.Text,
            ImieNazwiskoKLasa = RezyserEntry.Text,
            Data = DateTime.Parse(RokProdukcjiEntry.Text)
        };
        await _databaseService.AktualizujFilmAsync(tablet);

    }
}