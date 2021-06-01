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
    public partial class ManageCategories : Form
    {
        public ManageCategories()
        {
            InitializeComponent();
        }
        void populare()
        {
            try
            {
                Conex.Open();
                string querry = "select * from CategTable";
                SqlDataAdapter adapter = new SqlDataAdapter(querry, Conex);
                SqlCommandBuilder bld = new SqlCommandBuilder(adapter);
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataGridViewCateg.DataSource = dataSet.Tables[0];
                Conex.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        SqlConnection Conex = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Cristi\Documents\HardwareShop.mdf;Integrated Security=True;Connect Timeout=30");


        private void ManageCategories_Load(object sender, EventArgs e)
        {
            populare();
        }

        private void dataGridViewCateg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgViewRow = dataGridViewCateg.Rows[e.RowIndex];

                guna2TextBoxIDCateg.Text = dgViewRow.Cells[0].Value.ToString();
                guna2TextBoxNumeCateg.Text = dgViewRow.Cells[1].Value.ToString();
             
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Conex.Open();
                SqlCommand cmd = new SqlCommand("insert into CategTable values('" + guna2TextBoxIDCateg.Text + "','" + guna2TextBoxNumeCateg.Text + "')", Conex);
                cmd.ExecuteNonQuery();
                const string mesaj = "Categorie adaugata in baza de date!";
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            const string msgApprove = "Enter Category ID";
            const string msgDelete = "Categorie stearsa cu succes!";
            if (guna2TextBoxIDCateg.Text == "")
            {

                MessageBox.Show(msgApprove);
            }
            else
            {
                Conex.Open();
                string querry = "delete from CategTable where IdCateg='" + guna2TextBoxIDCateg.Text + "';";
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
                SqlCommand cmd = new SqlCommand("update CategTable set IdCateg='" + guna2TextBoxIDCateg.Text + "',NumeCateg='" + guna2TextBoxNumeCateg.Text + "' where IdCateg='" + guna2TextBoxIDCateg.Text + "'", Conex);
                cmd.ExecuteNonQuery();
                const string mesaj = "Categorie actualizat in baza de date!";
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

        private void guna2CircleButtonHome_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Hide();
        }
    }
}
