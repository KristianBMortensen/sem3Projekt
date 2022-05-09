using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashingAPI.Models;

namespace WashingAPI.Managers
{
    public class LoginManager
    {
        private static Dictionary<string, string> Tokens = new()
        {
            { "102474468596296399731", "27A" }
        };

        public LoginManager()
        {
            
        }

        public Dictionary<string,string> GetAllTokens()
        {
            return Tokens;
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
