using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginVerificaCPFCNPJ
{
    public class VerificaCNPJ : PluginImplementation
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            Entity account = (Entity)this.Context.InputParameters["Target"];

            string cnpj = (string)account.Attributes["tcc_cnpj"];

            QueryExpression recuperarContaComCnpj = new QueryExpression("account");
            recuperarContaComCnpj.Criteria.AddCondition("tcc_cnpj", ConditionOperator.Equal, cnpj);
            EntityCollection conta = this.Service.RetrieveMultiple(recuperarContaComCnpj);

            if (conta.Entities.Count() > 0)
            {


                throw new InvalidPluginExecutionException("CNPJ  já Existe no Sistema");


            }
        }
    }
}
