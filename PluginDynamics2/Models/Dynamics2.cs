using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginDynamics2.Models
{
    public class Dynamics2 : PluginImplementation
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            Entity product = (Entity)this.Context.InputParameters["Target"];
            bool integracao = (bool)product.Attributes["tcc2_integracao"];

            if (integracao == false)
            {

                throw new InvalidPluginExecutionException("Criação de Produto somente atráves do Dynamics1");

            }
        }
    }
}
