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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void guna2GradientButtonSendRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            
        }

        private void guna2CircleButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2TextBoxRegisterPassword_TextChanged(object sender, EventArgs e)
        {
            guna2TextBoxRegisterPassword.UseSystemPasswordChar = true;
        }
    }
}
