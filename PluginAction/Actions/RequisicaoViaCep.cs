using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PluginAction.Actions
{
    public class RequisicaoViaCep
    {
        public static async Task<string> buscaCep(string cep)
        {
            try
            {
                HttpClient client = new HttpClient();
                var resultado = await client.GetStringAsync($"https://viacep.com.br/ws/{cep}/json/");
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
