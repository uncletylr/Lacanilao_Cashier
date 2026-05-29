using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lacanilao_Cashier
{
        public abstract class UserAccount
        {
            protected string full_name;
            protected string username;
            protected string password;


            public UserAccount(string uName, string pass)
            {
                this.username = uName;


                this.full_name = "Lamarski T.";
                this.password = "password123";
            }


            public abstract bool validateLogin(string uName, string pass);


            public string FullName => full_name;
        }

        public class Cashier : UserAccount
        {

            public Cashier(string uName, string pass) : base(uName, pass)
            {
            }


            public override bool validateLogin(string uName, string pass)
            {
                return this.username.Equals(uName) && this.password.Equals(pass);
            }
        }
    }