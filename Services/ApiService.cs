using ipgt_oop.MVVM.Models;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace ipgt_oop.Services
{
    class ApiService
    {
        private static readonly HttpClient _client = new HttpClient();
        private const string BaseUrl = "http://localhost:8080/";

        public ApiService()
        {

            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = new Uri(BaseUrl);
            }
        }

        // metodos api

        public async Task<List<Bank>> GetBanksAsync()
        {
            try 
            {
                var lista = await _client.GetFromJsonAsync<List<Bank>>("api/Bank");

                return lista ?? new List<Bank>();
            }

            catch (Exception ex)
            {
                return new List<Bank>();
            }

        }

        public async Task CreateClient(string username, string password, int bankId, string cardNumber)
        {
            string url = BaseUrl + "multibanco/client";

            var payload = new
            {
                username =  username,
                password = password,
                bankId =  bankId,
                cardNumber = cardNumber
            };

            try
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync(url, payload);
                
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("LEGAL");
                    // Aqui fazer o que der certo --  daqui vai pro ViewModel
                
                }
                else
                {
                    Console.WriteLine(response.StatusCode);
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                    Console.WriteLine("NOT LEGAL");
                    //Aqui fazer o que se der errado
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }
        
    }
}
