using AppEntrevista.CS;
using AppEntrevista.Model;
using Newtonsoft.Json;
using Plugin.AudioRecorder;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEntrevista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EvaluaPreguntaPage : ContentPage
	{
        private string url = "";
        private HttpClient _Client = new HttpClient();
        //CargaAudio carga;
        //AudioPlayer player;
        //public object SaveFileDialog { get; private set; }
        string nombre = "";
        public EvaluaPreguntaPage (int idPostulantes, int idReque, int idListPregunta, int  idPregunta)
		{
			InitializeComponent ();
            // player = new AudioPlayer();
            nombre = Servicio.GenerarNombre(idPostulantes, idReque, idListPregunta,  idPregunta);
            string url = Servicio.IP + "Download/Sonidos/" + nombre;
            Audio.Source = UriVideoSource.FromUri(url);
             
        }

        //public async Task CargaVideoAsync() {
        //    string url = Servicio.IP + "Download/Sonidos/" + nombre;
        //    video.Source = url;
        //}






















        //public async void ListaPreguntas()
        //{

        //    try
        //    {
        //        var docPath = "/storage/emulated/0/Android/data/com.companyname.AppEntrevista/files/";
        //        /* var post = JsonConvert.DeserializeObject<List<ListPreguntaDet>>(content);
        //         requerimineto = new List<ListPreguntaDet>(post);
        //         PostulantePre_List.ItemsSource = requerimineto;
        //         waitInidicator.IsRunning = false;
        //         waitInidicator.IsVisible = false;
        //         opacidad.IsVisible = false;*/

        //      //  HttpPostedFileBase fileUpload = new HttpPostedFileBase();
        //        var content = await _Client.GetStringAsync(url);

        //       // FileSavePicker(content)

        //        //string localPath= Path.Combine(docPath, filePath);
        //        player.Play(content); 

        //        //if (file != null && File.Exists(file))
        //        //{
        //        //    player.Play(file); 
        //        //}


        //    }
        //    catch (Exception e)
        //    {
        //        e.ToString();
        //        await DisplayAlert("Error", "No hay conexion Intente mas Tarde", "Aceptar"); 
        //    }


        //}



    }
}