using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TccPlugin.Models
{
    public class PluginDynacoopTcc : PluginImplementation
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            Entity product = (Entity)this.Context.InputParameters["Target"];
            product["tcc2_integracao"] = true;

            IOrganizationService service = ConnectionFactory.GetService();
            service.Create(product);

        }

    }
}
