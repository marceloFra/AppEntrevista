using AppEntrevista.CS;
using AppEntrevista.Model;
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
	public partial class PostulantesRequerPage : ContentPage
	{
        private string url = "";
        private string urlR = "";
        private HttpClient _Client = new HttpClient();
        private List<Postulante> postulantes;
        private List<ListPreguntaCab> PreguntaCab;
        private int IdRequerimiento;


        Requerimiento requerimiento;
        public PostulantesRequerPage (Requerimiento modelo)
		{
			InitializeComponent ();
            requerimiento = modelo;
            url = Servicio.IP + "postulante/listPostulanteByIdReq/" + modelo.idRequerimiento;
          
            IdRequerimiento = modelo.idRequerimiento;
            ListaPostulantesReq();
            ListaPreguntasReq();
        }

         

        public async void ListaPostulantesReq()
        {
            waitInidicator.IsRunning = true;
            try
            {
                var content = await _Client.GetStringAsync(url);
                var post = JsonConvert.DeserializeObject<List<Postulante>>(content);
                postulantes = new List<Postulante>(post);
                PostulantesReq_List.ItemsSource = postulantes;
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


        public async void ListaPreguntasReq()
        {
        //    waitInidicator.IsRunning = true;
            try
            {
                urlR = Servicio.IP + "pregunta/listPregCabByReq/" + IdRequerimiento; 
                var content = await _Client.GetStringAsync(urlR);
                var post = JsonConvert.DeserializeObject<List<ListPreguntaCab>>(content);
                PreguntaCab = new List<ListPreguntaCab>(post);
                if (PreguntasReq_List.ItemsSource != null) { PreguntasReq_List.ItemsSource = null; }
                PreguntasReq_List.ItemsSource = PreguntaCab;
                //  base.OnAppearing();
                waitInidicator.IsRunning = false;
                waitInidicator.IsVisible = false;
                opacidad.IsVisible = false;
                 
            }
            catch (Exception e)
            {
                e.ToString();
                await DisplayAlert("Error", "No hay conexion Intente mas Tarde", "Aceptar");
               // waitInidicator.IsRunning = false;
            //    opacidad.IsVisible = false;
                // return;
            }
          //  waitInidicator.IsRunning = false;
        }
         
        private void Agregar_Clicked(object sender, EventArgs e)
        {
            // App.Current.MainPage = new NavigationPage(new MainPage());
            //  Navigation.PushAsync(new AddPreguntaRequer(IdRequerimiento));
            // App.Current.MainPage = new NavigationPage(new AddPreguntaRequer(IdRequerimiento));
           // Navigation.PopToRootAsync();  --> para volver atras   
            Navigation.PushAsync(new AddPreguntaRequer(requerimiento));
        }


        private async void PreguntasReq_List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var result = await this.DisplayAlert("Alert!", "Desea Eliminar Este Examen", "Si", "No");
            if (result)
            {
                try
                {
                    ListPreguntaCab lista = (ListPreguntaCab)e.Item;
                    RequerimientoPreguntaModel model = new RequerimientoPreguntaModel();
                    model.idListPregunta = lista.idListPregunta;
                    model.idRequerimiento = IdRequerimiento;
                    HttpClient cliente = new HttpClient();
                    string url2 = Servicio.IP + "pregunta/updateDelListPregCabAndIdReq/" + lista.idListPregunta + "/" + IdRequerimiento;
                    String jsonAdd = JsonConvert.SerializeObject(model);
                    var resultado = await cliente.PutAsync(url2, new StringContent(jsonAdd));
                    var json = resultado.Content.ReadAsStringAsync().Result;
                    if (json.Equals("1"))
                    {
                        await DisplayAlert("Agregado", "Se Elimino correctamente ", "Ok");

                    }
                    if (json.Equals("0"))
                    {
                        await DisplayAlert("Error", "ya tiene esta lista en su examen", "Ok");
                    }
                    ListaPreguntasReq();
                }
                catch (Exception)
                {
                    await DisplayAlert("Error", "no Se agrego correctamente ", "Ok");
                }
            }
            else
            {

            }
        }
    }
}