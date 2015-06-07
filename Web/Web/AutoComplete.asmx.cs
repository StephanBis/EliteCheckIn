using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;

namespace Web
{
    /// <summary>
    /// Summary description for AutoComplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AutoComplete : System.Web.Services.WebService
    {
        [WebMethod]
        public List<string> SearchSystems(string prefixText, int count)
        {
            List<Systems> systems = Database.GetSystemsByFilter(prefixText).Result;
            List<string> systemNames = new List<string>();

            foreach (Systems system in systems)
            {
                systemNames.Add(system.Name);
            }

            return systemNames;
        }
    }
}
