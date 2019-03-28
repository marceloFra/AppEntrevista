using AppEntrevista;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
 

namespace Entrevista.CS
{
    

    public class SplashPage: ContentPage
    {
        Image splashImage; 

        public SplashPage() {
            NavigationPage.SetHasNavigationBar(this, false);
            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "ITDATA.png",
                WidthRequest = 250,
                HeightRequest = 200
            };

            AbsoluteLayout.SetLayoutFlags(splashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.FromHex("#1a1a1a");
            this.Content = sub;
             
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await splashImage.ScaleTo(1, 500);// tiempo
            await splashImage.ScaleTo(1.4, 1200, Easing.Linear);
            await splashImage.ScaleTo(1.4, 1000, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }

    }
}
