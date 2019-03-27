using AppEntrevista.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppEntrevista
{
    public partial class MainPage : CarouselPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_ClickedAdministrador(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginAdmin()); 
        }
        private void Button_ClickedPostulante(object sender, EventArgs e) 
        {
            // Navigation.PushModalAsync(new LoginPostulante());
            Navigation.PushAsync(new LoginPostulante());
        }
    }
}
