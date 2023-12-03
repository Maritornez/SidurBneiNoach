namespace MobileAppMauiApp1.Views;

public partial class AboutNoah : ContentPage
{
	public AboutNoah()
	{
		InitializeComponent();
	}

	private async void OnLinkTapped_BritOlam(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://britolam.net");
    }
}