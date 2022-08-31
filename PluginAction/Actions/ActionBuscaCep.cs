using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PluginAction.Actions
{
    public class ActionBuscaCep : PluginImplementation
    {
      
       public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            var cep = this.Context.InputParameters["cep"].ToString();
            var buscaCep = RequisicaoViaCep.buscaCep(cep).Result;
            this.Context.OutputParameters["dadosCep"] = buscaCep;

       }
    }
}
