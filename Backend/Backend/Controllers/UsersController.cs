using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    public class UsersController : ApiController
    {
        private EliteCheckInDB _db;

        public UsersController()
        {
            _db = new EliteCheckInDB();
        }

        public IEnumerable<Users> Get()
        {
            return _db.Users;
        }

        public Users Get(int id)
        {
            return GetUserById(id);
        }

        [Route("api/users/username/{username}")]
        public Users Get(string username)
        {
            return GetUserByUsername(username);
        }

        [Route("api/users/close/{systemId}/{filter}")]
        public List<Users> Get(int systemId, int filter)
        {
            return GetUsersCloseToSystem(systemId, filter);
        }

        private Users GetUserById(int id)
        { 
            try
            {
                return _db.Users.Where(c => c.UserId == id).First();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private Users GetUserByUsername(string username)
        {
            try
            {
                return _db.Users.Where(c => c.Username == username).First();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<Users> GetUsersCloseToSystem(int systemId, int filter)
        {
            try
            {
                Systems system = _db.Systems.Where(c => c.Id == systemId).First();
                List<Users> users = _db.Users.ToList();
                List<Users> usersToSend = new List<Users>();

                foreach(Users user in users)
                {
                    Systems systemClose = _db.Systems.Where(c => c.Id == user.SystemId).First();

                    if (((systemClose.X >= system.X - filter) && (systemClose.X <= system.X + filter)) && ((systemClose.Y >= system.Y - filter) && (systemClose.Y <= system.Y + filter)) && ((systemClose.Z >= system.Z - filter) && (systemClose.Z <= system.Z + filter)))
                    {
                        usersToSend.Add(user);
                    }
                }

                return usersToSend;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public HttpResponseMessage Post([FromBody] JObject value)
        {
            try
            {
                Users user = value.ToObject<Users>();

                if (_db.Users.Where(c => c.Username == user.Username).Count() == 0)
                {
                    _db.Users.Add(user);
                    _db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("api/users/put/")]
        public HttpResponseMessage Put([FromBody]JObject value) //string email, even weggehaald om te testen
        {
            try
            {
                Users newUser = value.ToObject<Users>();
                Users oldUser = GetUserByUsername(newUser.Username);
                oldUser.Email = newUser.Email;
                oldUser.Password = newUser.Password;
                oldUser.SystemId = newUser.SystemId;
                _db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
