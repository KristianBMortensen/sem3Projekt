using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashingAPI.DBModels;
using WashingAPI.Models;

namespace WashingAPI.Managers
{
    public class LoginManager
    {
        /*private static Dictionary<string, string> Tokens = new()
        {
            { "102474468596296399731", "27A" }
        };*/

        private readonly Sem3Context _context;

        public LoginManager()
        {
            _context = new();
        }

        public IEnumerable<Login> GetAllTokens()
        {
            return _context.Logins;
        }

        public int GetToken(int id)
        {
            foreach (Login token in _context.Logins)
            {
                if (token.GoogleId == id)
                    return token.GoogleId;
            }

            return -1;
        }

        public bool CreateToken(Login login)
        {
            if (GetToken(login.GoogleId) == null)
            {
                _context.Logins.Add(login);
                return true;
            }

            return false;
        }
    }
}
