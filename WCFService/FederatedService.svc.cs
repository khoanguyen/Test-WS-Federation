using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FederatedService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FederatedService.svc or FederatedService.svc.cs at the Solution Explorer and start debugging.
    public class FederatedService : IFederatedService
    {
        public string Ping(string echo)
        {
            return "Echo " + echo + " AND you are " + OperationContext.Current.ClaimsPrincipal.Identity.Name.ToUpper();
        }
    }
}
