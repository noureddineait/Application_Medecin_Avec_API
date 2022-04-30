using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Application_pour_medecin
{
    internal class RestApiQueries
    {
        private HttpClient _client;

        public RestApiQueries()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5000/api/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private async Task<Models.LoginResponse> LoginAsync(Models.Login in_login, string path)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(in_login), Encoding.UTF8, "application/json");
            //string contentString = JsonConvert.SerializeObject(in_login);
            HttpResponseMessage response = await _client.PostAsync(path, content);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                Models.LoginResponse out_login = JsonConvert.DeserializeObject<Models.LoginResponse>(data);
                return out_login;
            }
            else
            {
                return null;
            }
        }
        public Models.LoginResponse Login(Models.Login in_login, string path)
        {
            try
            {
                Task<Models.LoginResponse> task = Task.Run(async () => await LoginAsync(in_login, path));
                task.Wait();
                return task.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        private async Task<Models.StatusCode> RegisterAsync(Models.Register in_register, string path)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(in_register), Encoding.UTF8, "application/json");
            //string contentString = JsonConvert.SerializeObject(in_register);
            HttpResponseMessage response = await _client.PostAsync(path, content);

            
                string data = await response.Content.ReadAsStringAsync();
                Models.StatusCode out_register = JsonConvert.DeserializeObject<Models.StatusCode>(data);
                return out_register;
            
        }
        public Models.StatusCode Register(Models.Register in_register, string path)
        {
            try
            {
                Task<Models.StatusCode> task = Task.Run(async () => await RegisterAsync(in_register, path));
                task.Wait();
                return task.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        private async Task<Models.Medecin> GetInfoAsync(string path)
        {
            HttpResponseMessage response = await _client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                Models.Medecin out_medecin = JsonConvert.DeserializeObject<Models.Medecin>(data);
                return out_medecin;
            }
            else
            {
                return null;
            }
        }
        public Models.Medecin GetInfo(string token, string path)
        {
            try
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                Task<Models.Medecin> task = Task.Run(async () => await GetInfoAsync(path));
                task.Wait();
                return task.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
        public async Task<bool> EditInfoAsync(Models.Medecin medecin,string path)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(medecin), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync(path, content);
            if(response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
        public bool EditInfo(Models.Medecin medecin, string token, string path)
        {
            try
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                Task<bool> task = Task.Run(async () => await EditInfoAsync(medecin,path));
                task.Wait();
                return task.Result;
            }
            catch (Exception)
            {}
            return false;
        }
        private async Task<List<Models.Patient>> GetPatientsAsync(string path)
        {
            HttpResponseMessage response = await _client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                List<Models.Patient> patients = JsonConvert.DeserializeObject<List<Models.Patient>>(data);
                return patients;
            }
            else
            {
                return null;
            }
        }
        public List<Models.Patient> GetPatients(string token, string path)
        {
            try
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                Task<List<Models.Patient>> task = Task.Run(async () => await GetPatientsAsync(path));
                task.Wait();
                return task.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        private async Task<Models.Patient> AddPatientAsync(Models.Patient in_patient, string path)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(in_patient), Encoding.UTF8, "application/json");
            //string contentString = JsonConvert.SerializeObject(in_patient);
            HttpResponseMessage response = await _client.PostAsync(path, content);


            string data = await response.Content.ReadAsStringAsync();
            Models.Patient out_register = JsonConvert.DeserializeObject<Models.Patient>(data);
            return out_register;

        }
        public Models.Patient AddPatient(Models.Patient in_patient,string token, string path)
        {
            try
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                Task<Models.Patient> task = Task.Run(async () => await AddPatientAsync(in_patient, path));
                task.Wait();
                return task.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
        private async Task<Models.Diagnostic> DiagnoseAsync(Models.Diagnostic in_diag, string path)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(in_diag), Encoding.UTF8, "application/json");
            //string contentString = JsonConvert.SerializeObject(in_patient);
            HttpResponseMessage response = await _client.PostAsync(path, content);


            string data = await response.Content.ReadAsStringAsync();
            Models.Diagnostic out_diag = JsonConvert.DeserializeObject<Models.Diagnostic>(data);
            return out_diag;

        }
        public Models.Diagnostic Diagnose(Models.Diagnostic in_diag, string token, string path)
        {
            try
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                Task<Models.Diagnostic> task = Task.Run(async () => await DiagnoseAsync(in_diag, path));
                task.Wait();
                return task.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
