using Newtonsoft.Json;
using RestSharp;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace CRUD_Alumnos.Datos
{
    class ConexionApi
    {
    //    public void consultaDatos(DataGridView dgAlumnos)
    //    {
    //        try
    //        {
    //            using (var client = new HttpClient())
    //            {
    //                //GET
    //                string url = "http://localhost:8080/api/v1/alumnos";
    //                client.DefaultRequestHeaders.Clear();
    //                var response = client.GetAsync(url).Result;
    //                var res = response.Content.ReadAsStringAsync().Result;
    //                dynamic data = JsonConvert.DeserializeObject<dynamic>(res);
    //                dgAlumnos.DataSource = data.data;
    //            }
    //        }
    //        catch (Newtonsoft.Json.JsonException e)
    //        {
    //            MessageBox.Show("Error:" + e);
    //        }
    //    }
    //    public void consultaDatosID(DataGridView dgAlumnos, int id)
    //    {
    //        try
    //        {
    //            using (var client = new HttpClient())
    //            {
    //                //GET ID
    //                string url = "http://localhost:8080/api/v1/alumnos";
    //                client.DefaultRequestHeaders.Clear();
    //                var response = client.GetAsync(url).Result;
    //                var res = response.Content.ReadAsStringAsync().Result;
    //                dynamic data = JsonConvert.DeserializeObject<dynamic>(res);
    //                dgAlumnos.DataSource = data.data;
    //            }
    //        }
    //        catch (Newtonsoft.Json.JsonException e)
    //        {
    //            MessageBox.Show("Error:" + e);
    //        }
    //    }
    //    public void registrarDatos(string nombre, string apPaterno, string apMaterno, int edad, int grado, int grupo, string telefono)
    //    {
    //        try
    //        {
    //            using (var client = new HttpClient())
    //            {
    //                //POST
    //                string url = "http://localhost:8080/api/v1/alumnos";
    //                var parameters = "{\"nombre\": \"nombre\", \apellidoPaterno\": \"apPaterno\", \"apellidoMaterno\": \"apMaterno\", \"edad\": \"edad\", \"grado\": \"grado\", \"grupo\": \"grupo\", \"telefono\": \"telefono\"}";
    //                var objeto = JsonConvert.DeserializeObject(parameters);
    //                var jsonString = new JsonConvert.SerializeObject();
    //                var content = new StringContent(parameters, Encoding.UTF8, "application/json"); 
    //                var res = client.PostAsync(url, content);
    //            }
    //        }
    //        catch (Newtonsoft.Json.JsonException e)
    //        {
    //            MessageBox.Show("Error: " + e);
    //        }
    //    }
    
    //    public void eliminarDatos(int id)
    //    {
    //        try
    //        {
    //            using (var client = new HttpClient())
    //            {
    //                //DELETE
    //                string url = "http://localhost:8080/api/v1/alumnos/";

    //            }
    //        }
    //        catch (Newtonsoft.Json.JsonException e)
    //        {
    //            MessageBox.Show("Error:" + e);
    //        }
    //    }
    //    public void modificarDatos(int id, string nombre, string apPaterno, string apMaterno, int edad, int grado, int grupo, string telefono)
    //    {
    //        try
    //        {
    //            using (var client = new HttpClient())
    //            {
    //                //PUT
    //                string url = "http://localhost:8080/api/v1/alumnos/";

    //            }
    //        }
    //        catch (Newtonsoft.Json.JsonException e)
    //        {
    //            MessageBox.Show("Error:" + e);
    //        }
    //    }
    }
}
