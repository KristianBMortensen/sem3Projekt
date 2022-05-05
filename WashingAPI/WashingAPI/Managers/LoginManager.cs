using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WashingAPI.Managers
{
    public class LoginManager
    {
        private List<string> Tokens;

        public LoginManager()
        {
            Tokens = new();
            Tokens.Add("102474468596296399731");
        }

        public List<string> GetAllTokens()
        {
            return Tokens;
        }

        public string GetToken(string id)
        {
            return Tokens.Find(t => t == id);
        }

        public bool CreateToken(string id)
        {
            if (GetToken(id) == null)
            {
                Tokens.Add(id);
                return true;
            }

            return false;
        }
    }
}
