using AppEntrevista.CS;
using AppEntrevista.Model;
using AppEntrevista.Views;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml; 

namespace AppEntrevista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPreguntaRequer : ContentPage
	{
        private   string url = Servicio.IP + "api/ListaPregunta";
        private HttpClient _Client = new HttpClient();
        private List<ListPreguntaCab> preguntas; 
        public int idReq = 0;
        Requerimiento modelo;

        public AddPreguntaRequer (Requerimiento requerimiento)
		{
			InitializeComponent ();
            ListaPreguntas();
            idReq = requerimiento.idRequerimiento;

            modelo = requerimiento;
        }

        public async void ListaPreguntas()
        {
            waitInidicator.IsRunning = true;
            try
            {
                var content = await _Client.GetStringAsync(url);
                var post = JsonConvert.DeserializeObject<List<ListPreguntaCab>>(content);
                preguntas = new List<ListPreguntaCab>(post);
                Preguntas_List.ItemsSource = preguntas;
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

        
        private async void Preguntas_List_ItemTapped(object sender, ItemTappedEventArgs e)
        { 
            var result = await this.DisplayAlert("Alert!", "Desea Agragar Este Examen", "Si", "No");
            if (result)
            {
                try
                {
                    ListPreguntaCab lista = (ListPreguntaCab)e.Item;
                    RequerimientoPreguntaModel model = new RequerimientoPreguntaModel();
                    model.idListPregunta = lista.idListPregunta;
                    model.idRequerimiento = idReq;
                    HttpClient cliente = new HttpClient();
                    string url2 = Servicio.IP + "pregunta/updateAddListPregCabAndIdReq/" + lista.idListPregunta + "/" + idReq;
                    String jsonAdd = JsonConvert.SerializeObject(model);
                    var resultado = await cliente.PutAsync(url2, new StringContent(jsonAdd));
                    var json = resultado.Content.ReadAsStringAsync().Result;
                    if (json.Equals("1"))
                    {
                        await DisplayAlert("Agregado", "Se agrego correctamente ", "Ok");
                        await Navigation.PushAsync(new PostulantesRequerPage(modelo));

                    }
                    if (json.Equals("0"))
                    {
                        await DisplayAlert("Error", "ya tiene esta lista en su examen", "Ok");
                    }
                }
                catch (Exception  )
                {
                    await DisplayAlert("Error", "no Se agrego correctamente ", "Ok");
                }
            }
            else
            {
                 
            } 
                // PostulantesRequerPage pos = new PostulantesRequerPage(modelo); 
                //  pos.ListaPreguntasReq();

        }

         



    }
}
 


     
 