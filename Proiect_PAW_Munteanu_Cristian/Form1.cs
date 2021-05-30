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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void labelNumeFirma_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CheckBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(guna2CheckBoxShowPassword.Checked == false)
            {
                guna2TextBoxPassword.UseSystemPasswordChar = true;

            }else
            {
                guna2TextBoxPassword.UseSystemPasswordChar = false;
            }
        }

        private void labelClear_Click(object sender, EventArgs e)
        {
            guna2TextBoxUsername.Text = "";
            guna2TextBoxPassword.Text = "";
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister fr = new FormRegister();
            fr.ShowDialog();
            
        }
    }
}
