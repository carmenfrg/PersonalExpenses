using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using Microsoft.WindowsAzure.MobileServices;
using PersonalExpenses.Resources;
using PersonalExpenses.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace PersonalExpenses
{
	public partial class App : Application
	{

		public static string DatabasePath;

		public static MobileServiceClient mobileServiceClient = new MobileServiceClient("https://personalexp.azurewebsites.net");

		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MainPage());

		}

		public App (string databasePath)
		{
			InitializeComponent();

            string test = "commit test";
			AppResources.Culture = new System.Globalization.CultureInfo("");

			MainPage = new NavigationPage(new MainPage());

			DatabasePath = databasePath;
		}

		protected override void OnStart ()
		{
			AppCenter.Start("ios=7af2e8d6-f77c-4881-b059-bd5650730345;android=9565e75c-906d-4d88-9fe9-e2844c1f51b7", typeof(Analytics), typeof(Push), typeof(Crashes));
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
