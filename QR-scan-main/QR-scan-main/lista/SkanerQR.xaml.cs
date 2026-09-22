using System.Collections.ObjectModel;
using ZXing.Net.Maui;

namespace lista_zakupow;

public partial class SkanerQR : ContentPage
{
    private readonly ObservableCollection<Item> _products;
    private readonly DatabaseService _databaseService;

    public SkanerQR(ObservableCollection<Item> products, DatabaseService databaseService)
	{
		InitializeComponent();
        _products = products;
        _databaseService = databaseService;
    }

    protected override void OnAppearing() // nadpisanie domyślnej metody OnAppearing która jest wywoływana gdy strona staje się widoczna
    {
        base.OnAppearing();

        // Konfiguracja formatów
        cameraView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.OneDimensional | BarcodeFormats.TwoDimensional,
            AutoRotate = true,
            Multiple = true,
            TryHarder = true
        };
    }

    private void CameraView_BarcodeDetected(object sender, BarcodeDetectionEventArgs e)
    {
        var result = e?.Results?.FirstOrDefault(); // Jeśli e nie jest null pobierz wynik(kolekcje wyników) i weź pierwszy element(FirstOrDefault)
        if (result is null)
            return;
        // Wywołanie na wątku UI i przypisanie do labela, kamera działa na wątku tła i pobranie wyniku z kamery nie może być przypisane do labela, ponieważ label działa na wątku UI,
        // wątek tła może nadal działać i wykrywać kolejne kody
        // Podstawowe wątki: MainThead - wątek UI, Background Thread - wątek tła, w którym działa kamera, 
        MainThread.BeginInvokeOnMainThread(async() =>
        {
           
          if (!string.IsNullOrWhiteSpace(result.Value))
            {
               _products.Add(new Item { NumerUrzadzenia = result.Value, Data = DateTime.Now});

                await Navigation.PushAsync(new AddTaskPage(_products, _databaseService));
            }
        });
    }
    

    async private void Powrot_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
