using AppEntrevista.CS;
using AppEntrevista.Views;
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
	public partial class PreguntasPostuPage : ContentPage
	{
        public int idReque = 0;
        public int idPostula = 0;
        public int flagEstadoRespt = 0;
        private string Url = "";
        private HttpClient _Client = new HttpClient();
        private List<ListPreguntaDet> listaPreguntas;
        string nom = "";
 

            public PreguntasPostuPage(int idRequerimiento, int idPostulante, string nombre, int flagEstadoRespuestas, List<ListPreguntaDet> ListaPreguntaDet)
        {
            InitializeComponent();
            idPostula = idPostulante;
            idReque = idRequerimiento;
            flagEstadoRespt = 121;
            DisplayAlert("Welcome", nombre, "Aceptar");
            nom = nombre;

            if (flagEstadoRespuestas == 122)
            {
                Navigation.PushAsync(new LoginPostulante());
            }
            if (flagEstadoRespuestas == 120) {
                int flagEstadoRespt = 121;
                string resp = CambioEstadoExamen(idReque, idPostula, flagEstadoRespt).ToString(); 
                AgregarPreguntasDet(idPostula, idReque); 
            }
            if (flagEstadoRespuestas == 121)
            {
                if (ListaPreguntaDet != null &&  ListaPreguntaDet.Count != 0)
                {
                    ListaPregPostulantesByReq(ListaPreguntaDet);
                }
                else {
                    ListaPregPostulantesByReq();
                }
                
            }
            

        }

        public async void ListaPregPostulantesByReq(List<ListPreguntaDet> listaPreguntas)
        {
            waitInidicator.IsRunning = true;
            try
            {
                //Url = Servicio.IP + "postulante/ListPregAvailableByPostReq/" + idPostula + "/" + idReque;
                //var content = await _Client.GetStringAsync(Url);
                //var post = JsonConvert.DeserializeObject<List<ListPreguntaDet>>(content);
                //listaPreguntas = new List<ListPreguntaDet>(post);
                PrePost_List.ItemsSource = listaPreguntas;
                //  base.OnAppearing();
                waitInidicator.IsRunning = false;
                waitInidicator.IsVisible = false;
                opacidad.IsVisible = false;
            }
            catch (Exception e)
            {
                e.ToString();
                await DisplayAlert("Error", "No hay conexion Intente mas Tarde ¡LISTADO!", "Aceptar");
                waitInidicator.IsRunning = false;
                // return;
            }
            waitInidicator.IsRunning = false;
        }


        /*cambia de estado a la tabla*/
        public async Task<string> CambioEstadoExamen(int idReque, int idPostula, int flagEstadoRespt)
        {
            string rsp = "";
            try {
                //Postulante model = new Postulante();
                //model.idRequerimiento = idReque;
                //model.idPostulante = idPostula;
                //model.flagEstadoRespuestas = flagEstadoRespt;
                HttpClient cliente = new HttpClient();
                var url = Servicio.IP + "postulante/updatePostulantePregOfReqFinished/" + idPostula + "/" + idReque + "/" + flagEstadoRespt;
                var content = await _Client.GetStringAsync(url);


                //String jsonAdd = JsonConvert.SerializeObject(model);
                //var resultado = await cliente.PutAsync(url, new StringContent(jsonAdd));
                //var json =   resultado.Content.ReadAsStringAsync().Result;
                //if (json.Equals("1"))
                //{
                //    await DisplayAlert("Agregado", "Se agrego correctamente ", "Ok");
                //}
                //if (json.Equals("0"))
                //{
                //    await DisplayAlert("Error", "ya tiene esta lista en su examen", "Ok");
                //}
                rsp = content;

            }
            catch (Exception e) {

                e.ToString();
                rsp = e.ToString();
            }
            return rsp;
        }


        /*Rellena las tabla con el id  de preguntas*/
        /* y debuelve una  lista de todas las preguntas asignadas*/
        public async void AgregarPreguntasDet(int idPostula, int idReque )
        {
            waitInidicator.IsRunning = true;
            try
            {
              
            var url = Servicio.IP + "postulante/updateFillPregInArrayDePregByPostReq/" + idPostula + "/" + idReque;
                var content = await _Client.GetStringAsync(url);
                var post = JsonConvert.DeserializeObject<List<ListPreguntaDet>>(content);
                listaPreguntas = new List<ListPreguntaDet>(post);
                PrePost_List.ItemsSource = listaPreguntas;
                //  base.OnAppearing();
                waitInidicator.IsRunning = false;
                waitInidicator.IsVisible = false;
                opacidad.IsVisible = false;


            }
            catch (Exception e)
            {
                e.ToString();
                await DisplayAlert("Error", "No hay conexion Intente mas Tarde FILL", "Aceptar");
                waitInidicator.IsRunning = false;
                // return;
            }
            waitInidicator.IsRunning = false;
        }

        /*
        public async void ListaPregPostulantes()
        {
            waitInidicator.IsRunning = true;
            try
            {
                Url = Servicio.IP + "pregunta/listPregDetByPost/"+ idPostula;
                var content = await _Client.GetStringAsync(Url);
                var post = JsonConvert.DeserializeObject<List<ListPreguntaDet>>(content);
                listaPreguntas = new List<ListPreguntaDet>(post); 
                PrePost_List.ItemsSource = listaPreguntas;
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
        */

        /* lista los datos  */
         
        public async void ListaPregPostulantesByReq()
        {
            waitInidicator.IsRunning = true;
            try
            {
                Url = Servicio.IP + "postulante/ListPregAvailableByPostReq/" + idPostula+"/"+idReque;
                var content = await _Client.GetStringAsync(Url);
                var post = JsonConvert.DeserializeObject<List<ListPreguntaDet>>(content);
                listaPreguntas = new List<ListPreguntaDet>(post);
                PrePost_List.ItemsSource = listaPreguntas;
                //  base.OnAppearing();
                waitInidicator.IsRunning = false;
                waitInidicator.IsVisible = false;
                opacidad.IsVisible = false;
            }
            catch (Exception e)
            {
                e.ToString();
                await DisplayAlert("Error", "No hay conexion Intente mas Tarde ¡LISTADO!", "Aceptar");
                waitInidicator.IsRunning = false;
                // return;
            }
            waitInidicator.IsRunning = false;
        }
         
        /* tap para enviar a grabar la pregunta*/

        private   void PrePost_List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ListPreguntaDet modelo = (ListPreguntaDet)e.SelectedItem;
                //Navigation.PushAsync(new NavigationPage(new RespondePreguntaPage(modelo)));
                //  new NavigationPage(new RespondePreguntaPage(modelo));
                //  DisplayAlert("Error", modelo.pregunta, "Aceptar"); 
                // Navigation.PushAsync(new RespondePreguntaPage(modelo));


                /* NavigationPage MainPage = new NavigationPage(new  RespondePreguntaPage(idPostula, idReque, modelo)); 
                Navigation.PushAsync(MainPage); */

                //NavigationPage navPage = new NavigationPage(new RespondePreguntaPage (idPostula, idReque, modelo));
                //App.Current.MainPage = navPage;


                //  NavigationPage MainPage = new NavigationPage(new RespondePreguntaPage(idPostula, idReque, modelo));

                // NavigationPage MainPage = new NavigationPage(new PreguntasPostuPage(idRequerimiento: idRequerimiento, idPostulante: idPostulante, nombre: nombre, flagEstadoRespuestas: post.flagEstadoRespuestas));
                // App.Current.MainPage = MainPage;

                //Navigation.PushAsync(new RespondePreguntaPage(idPostula, idReque, modelo)); 

                NavigationPage MainPage = new NavigationPage(new RespondePreguntaPage(idPostula, idReque,  modelo, nom, flagEstadoRespt));
                App.Current.MainPage = MainPage;

            }
        }



    }
}