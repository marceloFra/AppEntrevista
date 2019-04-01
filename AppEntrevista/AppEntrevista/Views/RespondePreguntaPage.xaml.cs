using AppEntrevista.CS;
using AppEntrevista.Model;
using Model;
using Newtonsoft.Json;
using Plugin.AudioRecorder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks; 
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Media.Abstractions;

namespace AppEntrevista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RespondePreguntaPage : ContentPage
    {
        MediaFile _mediaFile;
        AudioRecorderService recorder;
        AudioPlayer player;
         
        public int IDpostulante = 0;
        ListPreguntaDet detalleParam = new ListPreguntaDet();
        private ListPreguntaDet ListPreguntaDet;

        string nomb = "";
        int flagEstado = 0;
        int idReq = 1;
        int idPost = 1;
        int idPregunta = 0;

        public RespondePreguntaPage(int idPostula, int idReque, ListPreguntaDet modelo, string nom, int flagEstadoRespt )
        {
            nomb = nom;
            flagEstado = flagEstadoRespt;
            idReq = idReque;
            idPost = idPostula;
            idPregunta = modelo.idPregunta;

            string nombre = Servicio.GenerarNombre(idPostula, idReque, modelo.idListPregunta, modelo.idPregunta); 
          //  var mediaTestPath = "/storage/emulated/0/Android/data/com.companyname.AppEntrevista/files/"+ nombre + ".wav";
           
            #region Development Code
            /*
            nombre = nombre + ".wav";
            
            string rutaArchivoDeRutaPaAudio = "/storage/emulated/0/Android/data/com.companyname.AppEntrevista/files/";
                        
            var mediaTestPath = Path.Combine(rutaArchivoDeRutaPaAudio, nombre);
            */
            #endregion

            #region Production Code
            nombre = nombre + ".wav";

            string rutaArchivoDeRutaPaAudio = "/data/user/0/com.companyname.AppEntrevista/cache/";

            var mediaTestPath = Path.Combine(rutaArchivoDeRutaPaAudio, nombre);
            #endregion


            InitializeComponent();
            
            //BindingContext = modelo;
            ListPreguntaDet = modelo;
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(RespondePreguntaPage)).Assembly;
            IDpostulante = idPostula;

            var mainDir = FileSystem.AppDataDirectory;// directorio raiz

            recorder = new AudioRecorderService
            {
                StopRecordingAfterTimeout = true, // detendrá la grabación después de un tiempo de espera máximo (definido a continuación) 
                TotalAudioTimeout = TimeSpan.FromSeconds(60), // el audio dejará de grabar después de 15 segundos 
                AudioSilenceTimeout = TimeSpan.FromSeconds(5), // Tiempo de espera de silencio de audio
                FilePath = mediaTestPath
            };          
            player = new AudioPlayer();
            player.FinishedPlaying += Player_FinishedPlaying;             
        }



        
        private async void RecordButton_Clicked(object sender, EventArgs e)
        {
            pregunta.Text = ListPreguntaDet.pregunta;
            pregunta.TextColor = Color.Red;
            await RecordAudio();
            IrLista.IsEnabled = true;
            RecordButton.IsEnabled = false;
        }
         

        async Task RecordAudio()
        {
            try
            {
                if (!recorder.IsRecording) //Record button clicked
                {
                    recorder.StopRecordingOnSilence = TimeoutSwitch.IsToggled;

                    RecordButton.IsEnabled = false;
                   // PlayButton.IsEnabled = true;

                    //start recording audio
                    var audioRecordTask = await recorder.StartRecording();

                    RecordButton.Text = "Stop Recording";
                    RecordButton.IsEnabled = true;

                    await audioRecordTask;

                    //RecordButton.Text = "Record";
                   // PlayButton.IsEnabled = true;
                }
                else //Stop button clicked
                {
                    RecordButton.IsEnabled = false;
                    
                    recorder.StopRecording();

                    RecordButton.IsEnabled = true;
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }

            
            var  filePath = recorder.GetAudioFilePath();
            var length = filePath.Length.ToString();

            //ArchivoAudioModel model = new ArchivoAudioModel();
            //model.audio = filePath;
            //model.Idpostulante = 2;
            //model.idRequerimiento = 1;
            //model.idListPregunta = ListPreguntaDet.idListPregunta;
            //model.idPregunta = ListPreguntaDet.idPregunta;


            //    HttpContent fileStreamContent = new StreamContent(filePath.);
             
            var content = new MultipartFormDataContent();

          
            FileStream fs = File.OpenRead(filePath);
            StreamContent streamContent = new StreamContent(fs);
            streamContent.Headers.Add("Content-Type", "audio/wav"); 
            streamContent.Headers.Add("Content-Disposition", "form-data; name=\"file\"; filename=\"" + Path.GetFileName(filePath) + "\"");
             
            content.Add(streamContent, "file", Path.GetFileName(filePath)); 
            HttpClient cliente = new HttpClient();
            var uploadServiceBaseAddress = Servicio.IP + "Upload/Sonidos"; 
            var httpResponseMessage = await cliente.PostAsync(uploadServiceBaseAddress, content);

           

            var result = await httpResponseMessage.Content.ReadAsStringAsync();
            
            fs.Close();

            /*METODO PARA GUARDAR EL NOMBRE AUDIO EN LA BASE DE DATOS Y
             * REGISTRAR QUE SE GRABO EL AUDIO CON ESTE POST */


            await DisplayAlert("Aviso", "Guardado" , "Aceptar");

        }

        /*------------------------------------  -----------------------------*/
        private void PlayButton_Clicked(object sender, EventArgs e)
        {
            PlayAudio();
            RecordButton.IsEnabled = true;
        }

        void PlayAudio()
        {
            try
            {
                var filePath = recorder.GetAudioFilePath();

                if (filePath != null)
                {
                   // PlayButton.IsEnabled = false; 
                    player.Play(filePath);
                }
            }
            catch (Exception ex)
            {
                //blow up the app!
                throw ex;
            }
        }

        public List<ListPreguntaDet> listaPreguntas;
        private async void IrLista_Clicked(object sender, EventArgs e)
        {
            HttpClient _Client = new HttpClient();
            string Url = Servicio.IP + "postulante/updateDelPregOfArrayDePregByPostReqPreg/" + idPost + "/" + idReq + "/" + idPregunta;
            var content = await _Client.GetStringAsync(Url);
            var post = JsonConvert.DeserializeObject<List<ListPreguntaDet>>(content);
            listaPreguntas = new List<ListPreguntaDet>(post);

            if (listaPreguntas.Count != 0) {
                NavigationPage MainPage = new NavigationPage(new PreguntasPostuPage(idRequerimiento: idReq, idPostulante: idPost, nombre: nomb, flagEstadoRespuestas: flagEstado, ListaPreguntaDet: listaPreguntas));
                App.Current.MainPage = MainPage;
            }
            if (listaPreguntas.Count == 0) {
                int flagEstadoRespt = 122;
                await CambioEstadoExamen(idReq, idPost, flagEstadoRespt);
                await DisplayAlert("Felicidades", "Usted a terminado el examen! Pronto estaremos comunicaremos con usted", "Aceptar");
                NavigationPage MainPage = new NavigationPage(new PreguntasPostuPage(idRequerimiento: idReq, idPostulante: idPost, nombre: nomb, flagEstadoRespuestas: flagEstadoRespt, ListaPreguntaDet: listaPreguntas));
                App.Current.MainPage = MainPage;
            }

          

        }


        /*--------------------------------------------------------------------*/

        void Player_FinishedPlaying(object sender, EventArgs e)
        {
           // PlayButton.IsEnabled = true;
            RecordButton.IsEnabled = true;
        }

        public byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }


        public async Task<string> CambioEstadoExamen(int idReque, int idPostula, int flagEstadoRespt)
        {
            string rsp = "";
            try
            {
                
                HttpClient cliente = new HttpClient();
                var url = Servicio.IP + "postulante/updatePostulantePregOfReqFinished/" + idPostula + "/" + idReque + "/" + flagEstadoRespt;
                var content = await cliente.GetStringAsync(url); 
                rsp = content;

            }
            catch (Exception e)
            {

                e.ToString();
                rsp = e.ToString();
            }
            return rsp;
        }



        // <!---- <Button x:Name="PlayButton" Text="Reproducir" FontSize="24" HorizontalOptions="FillAndExpand" Clicked="PlayButton_Clicked" IsEnabled="False" />  -->

    }
}