using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_PAW_Munteanu_Cristian
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void guna2CircleButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ButtonLogout_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void guna2CircleButtonProductsList_Click_1(object sender, EventArgs e)
        {
            ManageProducts prod = new ManageProducts();
            prod.Show();
            this.Hide();
        }

        private void guna2CircleButtonUsers_Click_1(object sender, EventArgs e)
        {
            ManageUser user = new ManageUser();
            user.Show();
            this.Hide();
        }

        private void guna2CircleButtonAdmins_Click_1(object sender, EventArgs e)
        {
            ManageAdmin admin = new ManageAdmin();
            admin.Show();
            this.Hide();
        }

        private void guna2CircleButtonCategories_Click_1(object sender, EventArgs e)
        {
            ManageCategories categ = new ManageCategories();
            categ.Show();
            this.Hide();
        }

        private void guna2CircleButtonOrders_Click_1(object sender, EventArgs e)
        {
            ManageOrders comenzi = new ManageOrders();
            comenzi.Show();
            this.Hide();
        }

        private void guna2CircleButtonClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
