using System.Globalization;

namespace MobileAppMauiApp1.Views
{
    public partial class MainPage //ContentPage
    {
        //int count = 0;

        //private void OnCounterClicked(object sender, EventArgs e)
        //{
        //count++;

        //if (count == 1)
        //    CounterBtn.Text = $"Clicked {count} time";
        //else
        //    CounterBtn.Text = $"Clicked {count} times";

        //SemanticScreenReader.Announce(CounterBtn.Text);
        //}


        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            // Установка текущей григорианской даты при загрузке страницы
            currentGregorianDateLabel.Text = $"{DateTime.Now.ToShortDateString()}";

            currentHebrevDateLabel.Text = GetHebrewJewishDateString(DateTime.Now, true);
        }


        private static string GetHebrewJewishDateString(DateTime anyDate, bool addDayOfWeek)
        {
            System.Text.StringBuilder hebrewFormatedString = new System.Text.StringBuilder();

            // Create the hebrew culture to use hebrew (Jewish) calendar 
            CultureInfo jewishCulture = CultureInfo.CreateSpecificCulture("he-IL");
            jewishCulture.DateTimeFormat.Calendar = new HebrewCalendar();

            #region Format the date into a Jewish format 

            if (addDayOfWeek)
            {
                // Day of the week in the format " " 
                hebrewFormatedString.Append(anyDate.ToString("dddd", jewishCulture) + " ");
            }

            // Day of the month in the format "'" 
            hebrewFormatedString.Append(anyDate.ToString("dd", jewishCulture) + " ");

            // Month and year in the format " " 
            hebrewFormatedString.Append("" + anyDate.ToString("y", jewishCulture));
            #endregion

            return hebrewFormatedString.ToString();
        }


        private async void ButtonMorningAwakening_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MorningAwakening());
        }

        private async void ButtonShacharit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Shacharit());
        }

        private async void ButtonMinha_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Minha());
        }

        private async void ButtonAvrit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Avrit());
        }

        private async void ButtonShma_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Shma());
        }


        private async void ButtonCompas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CompassPage());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}