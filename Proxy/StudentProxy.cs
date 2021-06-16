using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;

namespace Lab12MVCAJAX.Proxy
{
    public class StudentProxy
    {

        public async Task<ResponseProxy<Models.StudentModel>> GetStudentAsync()
        {
            var client = new HttpClient();
            var urlBase = "https://localhost:44304";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/Api", "/Student", "/GetAllStudents");
            var response = client.GetAsync(url).Result;
            if( response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var students = JsonConvert.DeserializeObject<List<Models.StudentModel>>(result);
                return new ResponseProxy<Models.StudentModel>
                {
                    Codigo = (int)HttpStatusCode.OK,
                    Mensaje = "Exito",
                    objeto = new Models.StudentModel(),
                    listado = students
                };
            } else
            {
                return new ResponseProxy<Models.StudentModel>
                {
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }
        
        }

    }
}