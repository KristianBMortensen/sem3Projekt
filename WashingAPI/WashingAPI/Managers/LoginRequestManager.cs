using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashingAPI.DBModels;
using WashingAPI.Models;

namespace WashingAPI.Managers
{
    public class LoginRequestManager
    {
        /*private static Dictionary<string, LoginOprettelsesRequest> OprettelseRequests = new()
        {
            {"23232323", new LoginOprettelsesRequest("Magnus", "Jensen", "28A")}
        };*/
        private readonly LoginManager _manager;
        private readonly Sem3Context _context;

        public LoginRequestManager()
        {
            _manager = new();
            _context = new();
        }
        public IEnumerable<LoginRequest> GetAllRequests()
        {
            return _context.LoginRequests;
        }

        public LoginRequest GetRequest(int id)
        {

            foreach (LoginRequest pair in _context.LoginRequests)
            {
                if (pair.GoogleId == id)
                {
                    return pair;
                }
            }

            return null;

        }

        public bool CreateSignupRequest(LoginRequest login)
        {
            _context.LoginRequests.Add(login);
            if (_context.LoginRequests.ToList().Find(l => l.GoogleId == login.GoogleId) != null)
            {
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool CreateLogin(Login login)
        {
            if (!_manager.CreateToken(login)) return false;
            _context.LoginRequests.ToList().Remove(_context.LoginRequests.ToList().Find(l => l.GoogleId == login.GoogleId));
            return true;
        }

        public bool DeleteRequest(int id)
        {
            _context.LoginRequests.ToList().Remove(_context.LoginRequests.ToList().Find(l => l.GoogleId == id));
            return true;
        }
    }
}
