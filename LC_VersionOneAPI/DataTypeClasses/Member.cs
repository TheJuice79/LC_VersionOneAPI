using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace LC_VersionOne.DataTypeClasses
{
    public class Member
    {
        public string? Email { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Nickname { get; set; }
        public string? Username { get; set; }

        private string? url;
        public string? Url
        {
            get { return url; }
            set => url = $"https://www5.v1host.com{value}";
        }
    }
}
