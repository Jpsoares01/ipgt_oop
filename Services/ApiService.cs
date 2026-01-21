using ipgt_oop.MVVM.Models;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;

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

        public async Task<bool> TransactionAsync(TransactionRequest transacao)
        {
            try
            {
                // Envia os dados usando PUT
                var resposta = await _client.PutAsJsonAsync("multibanco/transaction", transacao);

                return resposta.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Erro na transação: {ex.Message}");
                return false;
            }
        }


        public async Task<List<Card>> GetCardsAsync()
        {
            try
            {
                
                var lista = await _client.GetFromJsonAsync<List<Card>>("listAccountCards");

                return lista ?? new List<Card>();
            }
            catch (Exception ex)
            {
                return new List<Card>();
            }
        }




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

        public async Task<bool> LoginAsync(string username, string password)
        {
            try
            {
                var auth = new Auth
                {
                    username = username,
                    password = password
                };

                //Envia para api
                var response = await _client.PostAsJsonAsync("multibanco/auth/login", auth);

                // token

                if (response.IsSuccessStatusCode)
                {
                    var dadosResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();


                    if (dadosResponse != null && !string.IsNullOrEmpty(dadosResponse.token))
                    {
                        _client.DefaultRequestHeaders.Authorization = 
                            new AuthenticationHeaderValue("Bearer", dadosResponse.token);

                        return true;
                    }
                }
                return false;

            }
            catch (Exception)
            {
                return false;
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
                    // Aqui fazer o que der certo --  daqui vai pro ViewModel
                
                }
                else
                {
                    Console.WriteLine(response.StatusCode);
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
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
