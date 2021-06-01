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
    public partial class ManageProducts : Form
    {
        public ManageProducts()
        {
            InitializeComponent();
        }

        SqlConnection Conex = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Cristi\Documents\HardwareShop.mdf;Integrated Security=True;Connect Timeout=30");

        void populare()
        {
            try
            {
                Conex.Open();
                string querry = "select * from ProductsTable";
                SqlDataAdapter adapter = new SqlDataAdapter(querry, Conex);
                SqlCommandBuilder bld = new SqlCommandBuilder(adapter);
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataGridViewProd.DataSource = dataSet.Tables[0];
                Conex.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void getCateg()
        {
            string querry = "select * from CategTable";
            SqlCommand cmd = new SqlCommand(querry, Conex);
            SqlDataReader r;
            try
            {
                Conex.Open();
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("NumeCateg", typeof(string));
                r = cmd.ExecuteReader();
                dataTable.Load(r);
                comboBoxCategProd.ValueMember = "NumeCateg";
                comboBoxCategProd.DataSource = dataTable;
                comboBoxFilter.ValueMember = "NumeCateg";
                comboBoxFilter.DataSource = dataTable;
                Conex.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void filterCateg()
        {
            try
            {
                Conex.Open();
                string querry = "select * from ProductsTable where CategProd='"+comboBoxFilter.SelectedValue.ToString()+ "'";
                SqlDataAdapter adapter = new SqlDataAdapter(querry, Conex);
                SqlCommandBuilder bld = new SqlCommandBuilder(adapter);
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataGridViewProd.DataSource = dataSet.Tables[0];
                Conex.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ManageProducts_Load(object sender, EventArgs e)
        {
            getCateg();
            populare();
        }

        private void buttonAddProdus_Click(object sender, EventArgs e)
        {
            try
            {
                Conex.Open();
                SqlCommand cmd = new SqlCommand("insert into ProductsTable values('" + guna2TextBoxIDProd.Text + "','" + guna2TextBoxNumeProd.Text + "','" + guna2TextBoxProdCant.Text + "','" + guna2TextBoxProdPrice.Text + "','" + guna2TextBoxProdDescription.Text + "','" + comboBoxCategProd.SelectedValue.ToString() + "')", Conex);
                cmd.ExecuteNonQuery();
                const string mesaj = "Produs adaugata in baza de date!";
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

        private void buttonDeleteProdus_Click(object sender, EventArgs e)
        {
            const string msgApprove = "Introdu ID Produs";
            const string msgDelete = "Produs stears cu succes!";
            if (guna2TextBoxIDProd.Text == "")
            {

                MessageBox.Show(msgApprove);
            }
            else
            {
                Conex.Open();
                string querry = "delete from ProductsTable where IdProdus='" + guna2TextBoxIDProd.Text + "';";
                SqlCommand cmd = new SqlCommand(querry, Conex);
                cmd.ExecuteNonQuery();
                MessageBox.Show(msgDelete);
                Conex.Close();
                populare();
            }
        }

        private void buttonUpdateProdus_Click(object sender, EventArgs e)
        {
            try
            {
                Conex.Open();
                SqlCommand cmd = new SqlCommand("update ProductsTable set IdProdus='" + guna2TextBoxIDProd.Text + "',NumeProd='" + guna2TextBoxNumeProd.Text + "',CantitateProd='" + guna2TextBoxProdCant.Text + "',PretProd='" + guna2TextBoxProdPrice.Text + "',DescProd='" + guna2TextBoxProdDescription.Text + "' where IdCateg='" + guna2TextBoxIDProd.Text + "'", Conex);
                cmd.ExecuteNonQuery();
                const string mesaj = "Produs actualizat in baza de date!";
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

        private void dataGridViewProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgViewRow = dataGridViewProd.Rows[e.RowIndex];

                guna2TextBoxIDProd.Text = dgViewRow.Cells[0].Value.ToString();
                guna2TextBoxNumeProd.Text = dgViewRow.Cells[1].Value.ToString();
                guna2TextBoxProdCant.Text = dgViewRow.Cells[2].Value.ToString();
                guna2TextBoxProdPrice.Text = dgViewRow.Cells[3].Value.ToString();
                guna2TextBoxProdDescription.Text = dgViewRow.Cells[4].Value.ToString();
                comboBoxCategProd.SelectedValue= dgViewRow.Cells[5].Value.ToString();

            }
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            filterCateg();
        }

        private void button1_Click(object sender, EventArgs e)
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
