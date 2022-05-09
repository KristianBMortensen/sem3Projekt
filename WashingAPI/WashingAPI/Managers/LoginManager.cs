using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashingAPI.Models;

namespace WashingAPI.Managers
{
    public class LoginManager
    {
        private Dictionary<string, string> Tokens;
        private Dictionary<string, LoginOprettelsesRequest> OprettelseRequests;

        public LoginManager()
        {
            Tokens = new();
            OprettelseRequests = new();
            Tokens.Add("102474468596296399731", "27A");
        }

        public Dictionary<string,string> GetAllTokens()
        {
            return Tokens;
        }

        public Dictionary<string, LoginOprettelsesRequest> GetAllRequests()
        {
            return OprettelseRequests;
        }

        public string GetToken(string id)
        {
            foreach (string token in Tokens.Keys)
            {
                if (token == id)
                    return token;
            }

            return null;
        }

        public bool CreateSignupRequest(string id, string fornavn, string efternavn, string lejlighedsnummer)
        {
            if (GetToken(id) == null)
            {
                OprettelseRequests.Add(id, new LoginOprettelsesRequest(fornavn,efternavn,lejlighedsnummer));
                return true;
            }

            return false;
        }

        public bool CreateToken(string id, string lejlighedsNummer)
        {
            if (GetToken(id) == null)
            {
                Tokens.Add(id,lejlighedsNummer);
                return true;
            }

            return false;
        }
    }
}
