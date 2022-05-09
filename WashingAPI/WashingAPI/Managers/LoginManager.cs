using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WashingAPI.Managers
{
    public class LoginManager
    {
        private Dictionary<string, string> Tokens;

        public LoginManager()
        {
            Tokens = new();
            Tokens.Add("102474468596296399731", "27A");
        }

        public Dictionary<string,string> GetAllTokens()
        {
            return Tokens;
        }

        public string GetToken(string id)
        {
            return Tokens[id];
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
