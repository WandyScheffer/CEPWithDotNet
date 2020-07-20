using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace ConsoleAppUmblerTest
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Digite o CEP a ser consultado: ");
            string cepClient = Console.ReadLine();
            
            static async System.Threading.Tasks.Task search(string cep){

                HttpClient cliente = new HttpClient();
                HttpResponseMessage res = await cliente.GetAsync("https://viacep.com.br/ws/" + cep + "/json");

                var data = await res.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<FormatJson>(data);

                Console.WriteLine("\nUF: " + obj.uf);
                Console.WriteLine("Cidade: " + obj.localidade);
                Console.WriteLine("Bairro: " + obj.bairro);
                Console.WriteLine("Logradouro: " + obj.logradouro);
                if (obj.complemento != ""){
                    Console.WriteLine("Complemento: " + obj.complemento);
                }
            }


            try{
                await search(cepClient);
            }
            catch (Exception error){
                Console.WriteLine("Erro na busca: \n" + error);
            }
        }
    }
}
