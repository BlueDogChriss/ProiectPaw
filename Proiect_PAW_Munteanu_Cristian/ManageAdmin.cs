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
    public partial class ManageAdmin : Form
    {
        public ManageAdmin()
        {
            InitializeComponent();
        }

        void populare()
        {
            try
            {
                Conex.Open();
                string querry = "select * from AdminsTable";
                SqlDataAdapter adapter = new SqlDataAdapter(querry, Conex);
                SqlCommandBuilder bld = new SqlCommandBuilder(adapter);
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataGridViewAdmins.DataSource = dataSet.Tables[0];
                Conex.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        SqlConnection Conex = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Cristi\Documents\HardwareShop.mdf;Integrated Security=True;Connect Timeout=30");

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Conex.Open();
                SqlCommand cmd = new SqlCommand("insert into AdminsTable values('" + guna2TextBoxIDAdmin.Text + "','" + guna2TextBoxAdminUN.Text + "','" + guna2TextBoxAdminPassword.Text + "','" + guna2TextBoxAdminFullName.Text + "','" + guna2TextBoxSalariu.Text + "')", Conex);
                cmd.ExecuteNonQuery();
                const string mesaj = "Admin adaugat in baza de date!";
                MessageBox.Show(mesaj);
                /*,MessageBoxButtons.OK,MessageBoxIcon.Information);*/
                Conex.Close();
                populare();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewAdmins_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgViewRow = dataGridViewAdmins.Rows[e.RowIndex];

                guna2TextBoxIDAdmin.Text = dgViewRow.Cells[0].Value.ToString();
                guna2TextBoxAdminUN.Text = dgViewRow.Cells[1].Value.ToString();
                guna2TextBoxAdminPassword.Text = dgViewRow.Cells[2].Value.ToString();
                guna2TextBoxAdminFullName.Text = dgViewRow.Cells[3].Value.ToString();
                guna2TextBoxSalariu.Text = dgViewRow.Cells[4].Value.ToString();
                
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            const string msgApprove = "Enter Admin ID";
            const string msgDelete = "Admin sters cu succes!";
            if (guna2TextBoxIDAdmin.Text == "")
            {

                MessageBox.Show(msgApprove);
            }
            else
            {
                Conex.Open();
                string querry = "delete from AdminsTable where IdAdmin='" + guna2TextBoxIDAdmin.Text + "';";
                SqlCommand cmd = new SqlCommand(querry, Conex);
                cmd.ExecuteNonQuery();
                MessageBox.Show(msgDelete);
                Conex.Close();
                populare();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Conex.Open();
                SqlCommand cmd = new SqlCommand("update AdminsTable set IdAdmin='" + guna2TextBoxIDAdmin.Text + "',AdminUN='" + guna2TextBoxAdminUN.Text + "',AdminPass='" + guna2TextBoxAdminPassword.Text + "',AdminFN='" + guna2TextBoxAdminFullName.Text + "',AdminSal='" + guna2TextBoxSalariu.Text + "' where IdAdmin='" + guna2TextBoxIDAdmin.Text + "'", Conex);
                cmd.ExecuteNonQuery();
                const string mesaj = "Admin actualizat in baza de date!";
                MessageBox.Show(mesaj);
                /*,MessageBoxButtons.OK,MessageBoxIcon.Information);*/
                Conex.Close();
                populare();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ManageAdmin_Load(object sender, EventArgs e)
        {
            populare();
        }

        private void guna2CircleButtonHome_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Hide();
        }
    }
}
