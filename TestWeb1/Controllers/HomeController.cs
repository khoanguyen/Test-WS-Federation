using System;
using System.Collections.Generic;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using TestWeb1.Services;

namespace TestWeb1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var client = CreateClient();          
            //client.ClientCredentials
            ViewBag.Ping = client.Ping("1000");
            return View();
        }

        private SecurityToken GetIssuedToken()
        {
            var identity = (User as ClaimsPrincipal).Identity as ClaimsIdentity;
            var token = (identity.BootstrapContext as BootstrapContext).SecurityToken;
            return token;            
        }

        private IFederatedService CreateClient()
        {
            //var serviceEndpoint = "https://localhost:44300/FederatedService.svc";

            //var binding = new WS2007FederationHttpBinding(WSFederationHttpSecurityMode.TransportWithMessageCredential);
            //binding.Security.Message.EstablishSecurityContext = false;
            //binding.Security.Message.IssuedKeyType = SecurityKeyType.BearerKey;
          
            //var factory = new ChannelFactory<IFederatedService>(
            //    binding,
            //    new EndpointAddress(serviceEndpoint));

            //factory.Credentials.UseIdentityConfiguration = true;
            //factory.Credentials.SupportInteractive = false;
            var factory = new ChannelFactory<IFederatedService>("WS2007FederationHttpBinding_IFederatedService");
            var token = GetIssuedToken();
            var channel = factory.CreateChannelWithIssuedToken(token);
            return channel;
            
        }
    }
}
