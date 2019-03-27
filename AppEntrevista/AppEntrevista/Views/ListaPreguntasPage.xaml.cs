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

namespace AppEntrevista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaPreguntasPage : ContentPage
	{
         
        public  string url = Servicio.IP + "pregunta/listPregDetByListPreg/";
        private HttpClient _Client = new HttpClient();
        private List<ListPreguntaDet> ListPreguntaDet;

        public ListaPreguntasPage(ListPreguntaCab modelo)
		{
			InitializeComponent ();
            BindingContext = modelo;
            url = Servicio.IP+"pregunta/listPregDetByListPreg/" +modelo.idListPregunta;
            Lista_List_Preguntas();

        }

        public async void Lista_List_Preguntas()
        {
            waitInidicator.IsRunning = true;
            try
            {
                var content = await _Client.GetStringAsync(url);
                var post = JsonConvert.DeserializeObject<List<ListPreguntaDet>>(content);
                ListPreguntaDet = new List<ListPreguntaDet>(post);
                List_Preguntas_List.ItemsSource = ListPreguntaDet;
                //  base.OnAppearing();
                waitInidicator.IsRunning = false;
                waitInidicator.IsVisible = false;
                opacidad.IsVisible = false;
            }
            catch (Exception e)
            {
                e.ToString();
                await DisplayAlert("Error", "No hay conexion Intente mas Tarde", "Aceptar");
                waitInidicator.IsRunning = false;
                opacidad.IsVisible = false;
                // return;
            }
            waitInidicator.IsRunning = false;
        }




    }
}