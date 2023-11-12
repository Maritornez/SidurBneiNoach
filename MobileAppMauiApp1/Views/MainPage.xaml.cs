namespace MobileAppMauiApp1.Views
{
    public partial class MainPage //ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            //count++;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void ButtonClickedMorningAwakening(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MorningAwakening());
        }

        private async void ButtonClickedShacharit(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new TargetShacharit());
        }

        private async void ButtonClickedMinha(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Minha()); 
        }
    }
}