using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    public class Users
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public int SystemId { get; set; }
        public int Score { get; set; }

        public string Rank()
        {
            if (Score <= 50)
            {
                return "Harmless";
            }
            else if (Score <= 100)
            {
                return "Mostly harmless";
            }
            else if (Score <= 150)
            {
                return "Novice";
            }
            else if (Score <= 200)
            {
                return "Competent";
            }
            else if (Score <= 250)
            {
                return "Expert";
            }
            else if (Score <= 300)
            {
                return "Master";
            }
            else if (Score <= 350)
            {
                return "Dangerous";
            }
            else if (Score <= 400)
            {
                return "Deadly";
            }
            else
            {
                return "Elite";
            }
        }
    }
}