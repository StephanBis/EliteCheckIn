using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    public class SystemsController : ApiController
    {
        private EliteCheckInDB _db;

        public SystemsController()
        {
            _db = new EliteCheckInDB();
        }

        public IEnumerable<Systems> Get()
        {
            return _db.Systems;
        }

        public Systems Get(int id)
        {
            return GetSystemById(id);
        }

        private Systems GetSystemById(int id)
        { 
            try
            {
                return _db.Systems.Where(c => c.SystemId == id).First();
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
                Systems system = value.ToObject<Systems>();
                _db.Systems.Add(system);
                _db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("api/systems/put/")]
        public HttpResponseMessage Put([FromBody]JObject value)
        {
            try
            {
                Systems newSystem = value.ToObject<Systems>();
                Systems oldSystem = GetSystemById(newSystem.SystemId);
                oldSystem.Name = newSystem.Name;
                oldSystem.Faction = newSystem.Faction;
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
