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
using System.IO;

namespace Proiect_PAW_Munteanu_Cristian
{
    public partial class FormRegister : Form
    {
        List<Users> UsersList = new List<Users>();
        public static Users u = new Users();
        public FormRegister()
        {
            InitializeComponent();
        }

        private void guna2GradientButtonSendRegister_Click(object sender, EventArgs e)
        {
            string UName = guna2TextBoxRegisterUsername.Text;
            string FullName= guna2TextBoxRegisterFullName.Text;
            string UPassword= guna2TextBoxRegisterPassword.Text;
            string UTelefone= guna2TextBoxRegisterTelefon.Text;
            string UEmail= guna2TextBoxRegisterEmail.Text;
            string UAdress= guna2TextBoxRegisterAdresa.Text;

            if (guna2TextBoxRegisterUsername.Text == "" || guna2TextBoxRegisterFullName.Text == "" || guna2TextBoxRegisterPassword.Text == "" || guna2TextBoxRegisterTelefon.Text == "" || guna2TextBoxRegisterEmail.Text == "" || guna2TextBoxRegisterAdresa.Text == "")
            {
                MessageBox.Show("Unul sau mai multe campuri ale formularului sunt goale!");
            }
            else { 
                UsersList.Add(new Users(UName, FullName, UPassword, UTelefone, UEmail, UAdress));
                foreach (var user in UsersList)
                {
                    MessageBox.Show(user.ToString() + "\n");
                }
            }

            try
            {
                u.Username = UName;
                u.FullName = FullName;
                u.Password = UPassword;
                u.Telefon = UTelefone;
                u.Email = UEmail;
                u.Adress = UAdress;
                TextWriter tw = new StreamWriter("UserList.txt");
                foreach (var u in UsersList)
                {
                    tw.WriteLine(u);
                }
                tw.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SqlConnection Conex2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Cristi\Documents\HardwareShop.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                if (string.IsNullOrEmpty(guna2TextBoxRegisterFullName.Text))
                {
                    errorProviderRegister.SetError(guna2TextBoxRegisterFullName, "Introduceti un nume!");
                }
                else
                     if (string.IsNullOrEmpty(guna2TextBoxRegisterUsername.Text))
                {
                    errorProviderRegister.SetError(guna2TextBoxRegisterUsername, "Introduceti un Username!");
                }
                else
                     if (string.IsNullOrEmpty(guna2TextBoxRegisterPassword.Text))
                {
                    errorProviderRegister.SetError(guna2TextBoxRegisterPassword, "Introduceti o parola!");
                }
                else
                     if (string.IsNullOrEmpty(guna2ComboBoxGen.Text))
                {
                    errorProviderRegister.SetError(guna2ComboBoxGen, "Introduceti genul dumneavoastra!");
                }
                else
                     if (string.IsNullOrEmpty(guna2TextBoxRegisterEmail.Text))
                {
                    errorProviderRegister.SetError(guna2TextBoxRegisterEmail, "Introduceti o adresa de email!");
                }
                else
                     if (string.IsNullOrEmpty(guna2TextBoxRegisterTelefon.Text))
                {
                    errorProviderRegister.SetError(guna2TextBoxRegisterTelefon, "Introduceti un numar de telefon!");
                }
                else
                     if (string.IsNullOrEmpty(guna2TextBoxRegisterAdresa.Text))
                {
                    errorProviderRegister.SetError(guna2TextBoxRegisterAdresa, "Introduceti o adresa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
                { 
                Conex2.Open();
                SqlCommand cmd = new SqlCommand("insert into UserTable values('" + guna2TextBoxRegisterUsername.Text + "','" + guna2TextBoxRegisterFullName.Text + "','" +  guna2TextBoxRegisterPassword.Text + "','" + guna2TextBoxRegisterTelefon.Text + "','" + guna2TextBoxRegisterEmail.Text + "','" + guna2TextBoxRegisterAdresa.Text + "')", Conex2);
                cmd.ExecuteNonQuery();
                const string mesaj = "V-ati inregistrat cu succes!";
                MessageBox.Show(mesaj);
                Conex2.Close();
                }
                finally
                {
                    this.Hide();
                    Form1 f1 = new Form1();
                    f1.ShowDialog();
                }

        }

        private void guna2CircleButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void guna2TextBoxRegisterPassword_TextChanged(object sender, EventArgs e)
        {
            guna2TextBoxRegisterPassword.UseSystemPasswordChar = true;
        }
    }
}
