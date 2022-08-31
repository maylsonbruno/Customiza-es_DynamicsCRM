using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginVerificaCPFCNPJ
{
    public class PluginCodigoIdentificador : PluginImplementation
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            Entity opportunity = (Entity)this.Context.InputParameters["Target"];
            string identificador = geradorNumerico();
            EntityCollection validaidentificador = validaIdentificador(identificador);
            if (validaidentificador.Entities.Count() > 0)
            {
                identificador = geradorNumerico();
                
            }
            opportunity["tcc_identificador"] = identificador;
        }

        public string geradorNumerico()
        {
            string identificador = "OPP-" + numerioAleatorio(5) + "-" + letraAleatorio(1) + numerioAleatorio(1) + letraAleatorio(1) + numerioAleatorio(1);
            
            return identificador;
        }
        public EntityCollection validaIdentificador(string identificador)
        {
            QueryExpression validIdenticador = new QueryExpression("opportunity");
            validIdenticador.ColumnSet.AddColumn("opportunityid");
            validIdenticador.Criteria.AddCondition("tcc_identificador", ConditionOperator.Equal, identificador);
            EntityCollection retornoQuery = this.Service.RetrieveMultiple(validIdenticador);

            if (retornoQuery.Entities.Count() > 0)
            {


                return null;


            }
            return retornoQuery;
        }

        public string numerioAleatorio(int tamanho)
        {
            var chars = "0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        public string letraAleatorio(int tamanho)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}
