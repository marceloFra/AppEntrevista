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
	public partial class RequerimientoPostPage : ContentPage
	{
        private string url ="";

        private HttpClient _Client = new HttpClient();
        private List<Requerimiento> requerimineto;
        Postulante postulante = new Postulante();
        int idPost = 0;
        public RequerimientoPostPage (Postulante modelo)
		{
			InitializeComponent ();
            idPost = modelo.idPostulante;
            postulante = modelo;
            ListaRequereimiento();
        }

        public async void ListaRequereimiento()
        {
            waitInidicator.IsRunning = true;
            try
            {
                url = Servicio.IP + "Requerimiento/listRequerimientoByIdPos/"+ postulante.idPostulante;
                var content = await _Client.GetStringAsync(url);
                var post = JsonConvert.DeserializeObject<List<Requerimiento>>(content);
                requerimineto = new List<Requerimiento>(post);
                Requerimiento_List.ItemsSource = requerimineto;
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
                // return;
            }
            waitInidicator.IsRunning = false;
        }

        private void Requerimiento_List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Requerimiento modelo = (Requerimiento)e.SelectedItem;  
                Navigation.PushAsync(new PostulantesPregPage(modelo, postulante));
            }
        }



    }
}