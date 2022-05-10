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

        public string GetToken(string id)
        {
            foreach (Login token in _context.Logins)
            {
                if (token.GoogleId == id)
                    return token.GoogleId;
            }

            return null;
        }

        public bool CreateToken(Login login)
        {
            if (GetToken(login.GoogleId) == null)
            {
                _context.Logins.Add(login);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteLogin(string id)
        {
            _context.Logins.Remove(_context.Logins.Find(id));
            _context.SaveChanges();
            return true;
        }
    }
}
