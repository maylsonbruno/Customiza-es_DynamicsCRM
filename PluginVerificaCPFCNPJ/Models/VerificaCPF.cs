using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginVerificaCPFCNPJ
{
    public class VerificaCPF : PluginImplementation
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            Entity contact = (Entity)this.Context.InputParameters["Target"];

            string cpf = (string)contact.Attributes["tcc_cpf"];

            QueryExpression recuperarContaComCpf = new QueryExpression("contact");
            recuperarContaComCpf.Criteria.AddCondition("tcc_cpf", ConditionOperator.Equal, cpf);
            EntityCollection contas = this.Service.RetrieveMultiple(recuperarContaComCpf);

            if (contas.Entities.Count() > 0)
            {


                throw new InvalidPluginExecutionException("CPF  já Existe no Sistema");


            }

           
        }
    }
}
