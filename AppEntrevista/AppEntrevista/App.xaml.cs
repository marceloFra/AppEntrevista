using Entrevista.CS;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppEntrevista
{
    public partial class App : Application
    {
        public App()
        {
            
            NavigationPage navPage = new NavigationPage(new SplashPage())
            {
                BarBackgroundColor = Color.FromHex("#0081f9"),
                BarTextColor = Color.White,
            };
            // App.Current.Ma NavigationPage navPage = new NavigationPage(new MainPage());inPage = new NavigationPage(new MainPage());
            MainPage = navPage;
        }
  
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
