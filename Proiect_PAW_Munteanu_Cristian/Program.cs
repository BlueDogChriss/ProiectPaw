using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_PAW_Munteanu_Cristian
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Application.Run(new ManageUser());
            //Application.Run(new ManageAdmin());
            //Application.Run(new ManageCategories());
            //Application.Run(new ManageProducts());
            //Application.Run(new FormRegister());
            //Application.Run(new ManageOrders());
            //Application.Run(new ViewOrders());
            //Application.Run(new AddCart());
            
        }
    }
}
