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
    public partial class HomePageUser : Form
    {
        public HomePageUser()
        {
            InitializeComponent();
        }

        private void guna2ButtonLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void guna2CircleButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CircleButtonCumpara_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCart shop = new AddCart();
            shop.Show();
        }
    }
}
