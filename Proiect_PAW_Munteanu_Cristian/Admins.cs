using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PAW_Munteanu_Cristian
{
    public partial class Admins : ICloneable, IComparable
    {
        private int idAdmin;
        private string adminUsername;
        private string adminPassword;
        private string adminFullname;
        private float adminSalariu;
        public static int contor = 0;

        public Admins()
        {
            idAdmin=contor++;
            adminUsername="null";
            adminPassword = "null";
            adminFullname="null";
            adminSalariu=0;
        }

        public Admins(string aun, string ap, string afn, float asal)
        {
            adminUsername = aun;
            adminPassword = ap;
            adminFullname = afn;
            adminSalariu = asal;
            idAdmin = contor++;
        }
        public string AdminUsername
        {
            get { return adminUsername; }
            set
            {
                if (value != null)
                    adminUsername = value;
            }
        }
        public string AdminPassword
        {
            get { return adminPassword; }
            set
            {
                if (value != null)
                    adminPassword = value;
            }
        }
        public string AdminFullname
        {
            get { return adminFullname; }
            set
            {
                if (value != null)
                    adminFullname = value;
            }
        }
        public float AdminSalariu
        {
            get { return adminSalariu; }
            set
            {
                if (value != null)
                    adminSalariu = value;
            }
        }

        public Admins getAdmins()
        {
            return new Admins(adminUsername, adminPassword, adminFullname, adminSalariu);
        }
        public Object Clone()
        {
            return this.MemberwiseClone();
        }
        public int CompareTo(Object obj)
        {
            Admins a = (Admins)obj;
            return String.Compare(this.adminUsername, a.adminUsername);
        }

        public override string ToString()
        {
            return "Admin Username: " + adminUsername + "\nPassword: " + adminPassword + 
                "\nFullname: " + adminFullname + "\nSalariu:" + adminSalariu + "\n";
        }


    }
}
