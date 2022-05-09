using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashingAPI.Models;

namespace WashingAPI.Managers
{
    public class LoginRequestManager
    {
        private static Dictionary<string, LoginOprettelsesRequest> OprettelseRequests = new()
        {
            {"23232323", new LoginOprettelsesRequest("Magnus", "Jensen", "28A")}
        };
        private readonly LoginManager _manager;

        public LoginRequestManager()
        {
            _manager = new();
        }
        public Dictionary<string, LoginOprettelsesRequest> GetAllRequests()
        {
            return OprettelseRequests;
        }

        public int CreateSignupRequest(string id, string fornavn, string efternavn, string lejlighedsnummer)
        {
            OprettelseRequests.Add(id, new LoginOprettelsesRequest(fornavn, efternavn, lejlighedsnummer));
                if (OprettelseRequests[id] != null)
                    return OprettelseRequests.Count();

                return 0;
        }
    }
}
