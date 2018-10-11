using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entity
{
    class Member
    {
        private string _name;
        private string _phone;
        private string _email;

        public string name { get => _name; set => _name = value; }
        public string phone { get => _phone; set => _phone = value; }
        public string email { get => _email; set => _email = value; }
    }
}
