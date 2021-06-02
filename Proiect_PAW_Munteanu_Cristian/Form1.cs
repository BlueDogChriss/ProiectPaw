using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proiect_PAW_Munteanu_Cristian
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection Conex = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Cristi\Documents\HardwareShop.mdf;Integrated Security=True;Connect Timeout=30");

        private void labelNumeFirma_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void guna2TextBoxPassword_TextChanged(object sender, EventArgs e)
        {
            guna2TextBoxPassword.UseSystemPasswordChar = true;
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

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (comboBoxRol.SelectedItem.ToString() == "ADMIN")
            {
                try { 
                Conex.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from AdminsTable where AdminUN='" + guna2TextBoxUsername.Text + "' and AdminPass='" + guna2TextBoxPassword.Text + "'", Conex);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    this.Hide();
                    HomePage home = new HomePage();
                    home.Show();
                    
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                }
                Conex.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBoxRol.SelectedItem.ToString() == "USER")
            {
                try
                {
                    Conex.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from UserTable where UName='" + guna2TextBoxUsername.Text + "' and Upassword='" + guna2TextBoxPassword.Text + "'", Conex);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        HomePageUser homePage = new HomePageUser();
                        homePage.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Username or Password");
                    }
                    Conex.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selectati Rolul!");
            }
        }
    }
}
