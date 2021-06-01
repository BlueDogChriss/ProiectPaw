using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PAW_Munteanu_Cristian
{
    public partial class Users : ICloneable , IComparable
    {
        private string userName;
        private string userFullName;
        private string userPassword;
        private string userTelefon;
        private string userEmail;
        private string userAdress;
       


        public Users()
        {
            userName = "n/a";
            userFullName = "n/a";
            userPassword = "n/a";
            userTelefon = "+40....";
            userEmail = "email@email.com";
            userAdress = "adresa...";
        }
        public Users(string n, string fn, string p, string t, string e, string a)
        {
            userName = n;
            userFullName = fn;
            userPassword = p;
            userTelefon = t;
            userEmail = e;
            userAdress = a;
        }

        public string Username
        {
            get { return userName; }
            set
            {
                if (value != null)
                    userName = value;
            }
        }
        public string FullName
        {
            get { return userFullName; }
            set
            {
                if (value != null)
                    userFullName = value;
            }
        }
        public string Password
        {
            get { return userPassword; }
            set
            {
                if (value != null)
                    userPassword = value;
            }
        }
        public string Telefon
        {
            get { return userTelefon; }
            set
            {
                if (value != null)
                    userTelefon = value;
            }
        }
        public string Email
        {
            get { return userEmail; }
            set
            {
                if (value != null)
                    userEmail = value;
            }
        }
        public string Adress
        {
            get { return userAdress; }
            set
            {
                if (value != null)
                    userAdress = value;
            }
        }


        public Users getUsers()
        {
            return new Users(userName, userFullName, userPassword, userTelefon, userEmail, userAdress);
        }

        public Object Clone()
        {
            return this.MemberwiseClone();
        }
        public int CompareTo(Object obj)
        {
            Users u = (Users)obj;
            return String.Compare(this.userName, u.userName);
            return String.Compare(this.userTelefon, u.userTelefon);
        }
        public override string ToString()
        {
            return "User Name: " + userName + "\nFull Name: " + userFullName + "\nPassword: " + userPassword + 
                "\nTelefon: " + userTelefon + "\nEmail: " + userEmail + "\nAdresa: " + userAdress + "\n";
        }


    }
    


}
