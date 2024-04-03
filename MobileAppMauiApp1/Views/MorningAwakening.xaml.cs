using Firebase.Storage;
using Firebase.Database;
using Firebase.Database.Query;


namespace MobileAppMauiApp1.Views;

public partial class MorningAwakening : ContentPage
{

    public MorningAwakening()
	{
		InitializeComponent();
        //DownloadImage();
        //ReadText();
    }

    //private async void ReadText()
    //{
    //    MorningAwakeningLabelModa.Text = await ReadTextFromFirebase("https://realtimedatabase-77a8a-default-rtdb.europe-west1.firebasedatabase.app/", "text");
    //    MorningAwakeningLabelThanks.Text = await ReadTextFromFirebase("https://realtimedatabase-77a8a-default-rtdb.europe-west1.firebasedatabase.app/", "thanks");
    //    MorningAwakeningSleep.Text = await ReadTextFromFirebase("https://realtimedatabase-77a8a-default-rtdb.europe-west1.firebasedatabase.app/", "sleep");
    //    MorningAwakeningSleepThanks1.Text = await ReadTextFromFirebase("https://realtimedatabase-77a8a-default-rtdb.europe-west1.firebasedatabase.app/", "thanks1");
    //    MorningAwakeningSleepMorning.Text = await ReadTextFromFirebase("https://realtimedatabase-77a8a-default-rtdb.europe-west1.firebasedatabase.app/", "morning");
    //}

    //private async void DownloadImage()
    //{
    //    try 
    //    {
    //        image.Source = await GetImage();
    //    }
    //    catch { }
    //}

    //public async Task<string> GetImage()
    //{
    //    FirebaseStorage firebaseStorage = new FirebaseStorage("realtimedatabase-77a8a.appspot.com");
    //    return await firebaseStorage.Child("image.png").GetDownloadUrlAsync();
    //}


    static async Task<string> ReadTextFromFirebase(string firebaseBaseUrl, string nodePath)
    {
        try
        {
            var firebaseClient = new FirebaseClient(firebaseBaseUrl);

            // Чтение текста из узла в Realtime Database
            var dataSnapshot = await firebaseClient.Child(nodePath).OnceSingleAsync<string>();

            return dataSnapshot;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading from Firebase: {ex.Message}");
            return null;
        }
    }
}