using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TccPlugin.Models
{
    public class ConnectionFactory
    {
        public static IOrganizationService GetService()
        {
            string connectionString =
                   "AuthType=OAuth;" +
                   "Username=TccGrupo4@Dynacoop2.onmicrosoft.com;" +
                   "Password=teste4444#;" +
                   "Url=https://dynamicstwo.crm2.dynamics.com/;" +
                   "AppId=f7aea30d-3bee-4157-b059-fb588701872b;" +
                   "RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97;";

            CrmServiceClient crmServiceClient = new CrmServiceClient(connectionString);
            return crmServiceClient.OrganizationWebProxyClient;
        }

    }
}
