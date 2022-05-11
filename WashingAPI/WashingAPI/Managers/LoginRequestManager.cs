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

        public LoginRequest? GetRequest(string id)
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
            _context.SaveChanges();
            return true;
        }

        public bool CreateLogin(string id)
        {
            LoginRequest request = _context.LoginRequests.Find(id);
            Login login = new Login()
            {
                GoogleId = request.GoogleId,
                Fornavn = request.Fornavn,
                Efternavn = request.Efternavn,
                Room = request.Room
            };
            if (!_manager.CreateToken(login)) return false;
            if (!DeleteRequest(id)) return false;
            return true;
        }

        public bool DeleteRequest(string id)
        {
            _context.LoginRequests.Remove(_context.LoginRequests.ToList().Find(l => l.GoogleId == id));
            _context.SaveChanges();
            if (_context.LoginRequests.Find(id) != null) return false;
            return true;
        }
    }
}
