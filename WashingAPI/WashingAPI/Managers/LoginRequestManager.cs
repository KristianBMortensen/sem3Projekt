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

        public KeyValuePair<string, LoginOprettelsesRequest> GetRequest(string id)
        {

            foreach (KeyValuePair<string, LoginOprettelsesRequest> pair in OprettelseRequests)
            {
                if (pair.Key == id)
                {
                    return new KeyValuePair<string, LoginOprettelsesRequest>(pair.Key, pair.Value);
                    break;
                }
            }

            return new KeyValuePair<string, LoginOprettelsesRequest> (null, null);

        }

        public bool CreateSignupRequest(string id, string fornavn, string efternavn, string lejlighedsnummer)
        {
            OprettelseRequests.Add(id, new LoginOprettelsesRequest(fornavn, efternavn, lejlighedsnummer));
                if (OprettelseRequests[id] != null)
                    return true;

                return false;
        }

        public bool CreateLogin(string id, string room)
        {
            if (!_manager.CreateToken(id, room)) return false;
            OprettelseRequests.Remove(id);
            return true;
        }

        public bool DeleteRequest(string id)
        {
            OprettelseRequests.Remove(id);
            return true;
        }
    }
}
