using System.Collections.ObjectModel;
using ZXing.Net.Maui;

namespace lista_zakupow;

public partial class SkanerQR : ContentPage
{
    public ObservableCollection<Item> _products;
    public SkanerQR(ObservableCollection<Item> products)
	{
		InitializeComponent();
        _products = products;
    }

    protected override void OnAppearing() // nadpisanie domyœlnej metody OnAppearing która jest wywo³ywana gdy strona staje siê widoczna
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
        var result = e?.Results?.FirstOrDefault(); // Jeœli e nie jest null pobierz wynik(kolekcje wyników) i weŸ pierwszy element(FirstOrDefault)
        if (result is null)
            return;
        // Wywo³anie na w¹tku UI i przypisanie do labela, kamera dzia³a na w¹tku t³a i pobranie wyniku z kamery nie mo¿e byæ przypisane do labela, poniewa¿ label dzia³a na w¹tku UI,
        // w¹tek t³a mo¿e nadal dzia³aæ i wykrywaæ kolejne kody
        // Podstawowe w¹tki: MainThead - w¹tek UI, Background Thread - w¹tek t³a, w którym dzia³a kamera, 
        MainThread.BeginInvokeOnMainThread(async() =>
        {
            codeValue.Text = result.Value;
            if (!string.IsNullOrWhiteSpace(codeValue.Text))
            {
                _products.Add(new Item { Name = codeValue.Text, Number = 1 });

                await Navigation.PopAsync();
            }
        });
    }
}