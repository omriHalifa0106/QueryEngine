using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Engine
{
    public class User
    {
        private string email;
        private string fullName;
        private int age;

        public User(string email, string fullName, int age)
        {
            this.email = email;
            this.fullName = fullName;
            this.age = age;
        }

        public string Email { get => email; set => email = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public int Age { get => age; set => age = value; }

        public void toString()
        {
            Console.WriteLine("User-> email:'{0}',full name: '{1}', age: {2} ", this.email, this.fullName, this.age);
        }
    }
}
