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
	public partial class LoginPostulante : ContentPage
    {

        private HttpClient _Client = new HttpClient();

        public LoginPostulante ()
		{
			InitializeComponent ();
		}

 
        

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string usuario = usernameEntry.Text.ToString();
            string password = passwordEntry.Text.ToString();

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
                string url = Servicio.IP + "loginPostulante/" + usuario + "/" + password;
                var content = await _Client.GetStringAsync(url);
                var post = JsonConvert.DeserializeObject<Postulante>(content);
                string nombre = post.nombre;

                if (nombre.Substring(0, 5).Equals("Error"))
                {
                    await DisplayAlert("Login", "Postulante", "Ingreso Mal");
                }
                else
                {
                    int idRequerimiento = post.idRequerimiento;
                    int idPostulante = post.idPostulante;

                    /*
                     120 = sin iniciar
                     121 = iniciado
                     122 = finalizado
                     */
                    //if (post.flagEstadoRespuestas == 120 || post.flagEstadoRespuestas == 121)
                    //{

                    List<ListPreguntaDet> lista = new List<ListPreguntaDet>();

                    if (post.flagEstadoRespuestas == 120 || post.flagEstadoRespuestas == 121)
                    {                    
                        NavigationPage MainPage = new NavigationPage(new PreguntasPostuPage(idRequerimiento: idRequerimiento, idPostulante: idPostulante, nombre: nombre, flagEstadoRespuestas: post.flagEstadoRespuestas, ListaPreguntaDet : lista));
                        App.Current.MainPage = MainPage;
                    }
                    if (post.flagEstadoRespuestas == 122)
                    {
                        await DisplayAlert("Login", "Administrador", "Ya respondio toda la entrevista");
                    }
                } 
            }
            else {
                await DisplayAlert("Login", "Administrador", "Ingrese su Usuario o Password");
            }

          
        }



    }
}