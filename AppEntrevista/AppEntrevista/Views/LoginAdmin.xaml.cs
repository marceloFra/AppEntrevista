

using AppEntrevista.CS;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEntrevista.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginAdmin : ContentPage
	{
      //  LoginViewModel model = new LoginViewModel();
		public LoginAdmin ()
		{
			InitializeComponent();
          //  BindingContext = model;

        }


        private HttpClient _Client = new HttpClient();

   
        private async void Button_Clicked(object sender, EventArgs e)
        {
            string usuario = usernameEntry.Text.ToString();
            string password = passwordEntry.Text.ToString();
            string nombre = "";

            try {
                if (usuario.Equals(""))
                {
                    await DisplayAlert("Login", "Administrador", "Ingrese su Usuario");
                    return;
                }
                if (password.Equals(""))
                {
                    await DisplayAlert("Login", "Administrador", "Ingrese su Pasword");
                    return;
                }
                if (!usuario.Equals("") || !password.Equals(""))
                {

                    var slider = new Slider();

                    string url = Servicio.IP + "loginAdministrador/" + usuario + "/" + password;
                    var content = await _Client.GetStringAsync(url);
                    var post = JsonConvert.DeserializeObject<string>(content);
                    nombre = post;

                    if (!nombre.Equals("No existe usuario"))
                    {
                        await Navigation.PushModalAsync(new Inicio(nombre: nombre));
                    }
                    else
                    {
                        await DisplayAlert("Login", "Administrador", "Ingresó Mal su Usuario o Password");
                    }
                }
                else
                {
                    await DisplayAlert("Login", "Administrador", "Ingrese su Usuario o Password");
                }
            }
            catch (Exception msj) {
                string mensaje = msj.Message;
                await  DisplayAlert("Login", mensaje, "Aceptar");
            }
             
        }



        /*  private async Task Button_IniciarAdminAsync(object sender, EventArgs e)
          { 

              // falta mas para hace todo el login 
              string usuario = usernameEntry.Text.ToString();
              string password = passwordEntry.Text.ToString();

              /*    if (usuario == "admin" && password == "123")
                  {
                      // DisplayAlert("Login", "Administrador", "Ingreso Bien");
                      // Navigation.PushAsync(new Menu());
                      Navigation.PushAsync(new Inicio());
                  }
                  else
                  {
                      DisplayAlert("Login", "Administrador", "Ingreso Mal");
                  } */

        /*  if (string.IsNullOrEmpty(usuario))
          {
              DisplayAlert("Error", "Debe Ingresar el Usuairo", "Aceptar");
              usernameEntry.Focus();
              return;
          }
          if (string.IsNullOrEmpty(password))
          {
              DisplayAlert("Error", "Debe Ingresar el Password", "Aceptar");
              passwordEntry.Focus();
              return;
          }


          waitInidicator.IsRunning = true;
          //   Button_IniciarAdmin.IsEnabled = false;
          HttpClient client  = new HttpClient();
          // direcion base 
          client.BaseAddress = new Uri("192.168.1.100:85");
          string url = string.Format("login/{0}/{1}", usernameEntry.Text, passwordEntry.Text);
          // metodo asincrinico para hacer la conexio
          var response = await client.GetAsync(url);
          // la respuesta lo debuelve como un estring (ose el mensaje que debuelve)
          var result = response.Content.ReadAsStringAsync().Result;
          //   Button_IniciarAdmin.IsEnabled = true;
          waitInidicator.IsRunning = false; 
      }  */
    }
}