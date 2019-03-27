using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppEntrevista.ViewModel
{
    public class RestClient
    {
       /* public async Task<T> Get<T>(string URL)
        {
            try {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(URL);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
                    
                }
            }
            catch (Exception e)
            { }

        } */
    }
}
