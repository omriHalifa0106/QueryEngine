using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Engine
{
    public class Data
    {
        public List<User> users;
        public List<Order> orders;

        /*
         * the function create the lists and add items of users and orders.
         */
        public void CreateDataBase()
        {
            this.users = new List<User>();
            this.orders = new List<Order>();

            this.users.Add(new User("halifa76i@gmail.com", "Omri Halifa", 19));
            this.users.Add(new User("selected.databases@ravendb.net", "John Doe", 37));
            this.users.Add(new User("jobs@ravendb.net", "hibernatin grhinos", 19));
            this.users.Add(new User("bar@gmail.com", "bar", 23));
            this.users.Add(new User("foo@walla.com", "foo", 26));
            this.users.Add(new User("google@gmail.com", "google", 67));
            this.users.Add(new User("david@webcam.com", "David hen", 18));
            this.users.Add(new User("ohad@gmail.com", "Ohad Mizrahi", 29));
            this.users.Add(new User("Ilay@gmail.com", "Ilay Azulay", 34));
            this.users.Add(new User("raz@gmail.com", "Raz toledano", 56));


            this.orders.Add(new Order(1, 1345.50));
            this.orders.Add(new Order(201, 2500.0));
            this.orders.Add(new Order(902, 1450.0));
            this.orders.Add(new Order(103, 650.0));
            this.orders.Add(new Order(781, 998.0));
            this.orders.Add(new Order(91, 1000.0));
            this.orders.Add(new Order(11, 123.45));
            this.orders.Add(new Order(12, 200.99));
            this.orders.Add(new Order(23, 445.80));
            this.orders.Add(new Order(56, 1500.5));
        }

        /*
         * the function print the lists (the database) of users and orders.
         */
        public void printDataBase()
        {
            Console.WriteLine("Print the lists as the database:");
            Console.WriteLine("list Users:");
            foreach(var user in this.users)
            {
                user.toString();
            }
            Console.WriteLine("\nlist Orders:");
            foreach (var order in this.orders)
            {
                order.toString();
            }
            Console.WriteLine();
        }
    }
}
