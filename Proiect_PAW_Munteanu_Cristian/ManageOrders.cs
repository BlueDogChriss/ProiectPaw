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
    public partial class ManageOrders : Form
    {
        public ManageOrders()
        {
            InitializeComponent();
        }

        SqlConnection Conex = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Cristi\Documents\HardwareShop.mdf;Integrated Security=True;Connect Timeout=30");

        void populare()
        {
            try
            {
                Conex.Open();
                string querry = "select * from UserTable";
                SqlDataAdapter adapter = new SqlDataAdapter(querry, Conex);
                SqlCommandBuilder bld = new SqlCommandBuilder(adapter);
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataGridViewUserList.DataSource = dataSet.Tables[0];
                Conex.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void populareProd()
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
                //comboBoxCategProd.ValueMember = "NumeCateg";
                //comboBoxCategProd.DataSource = dataTable;
                comboBoxFilter.ValueMember = "NumeCateg";
                comboBoxFilter.DataSource = dataTable;
                Conex.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int num = 0;
        int qty;
        float uprice,totprice;
        string produs;
        int flag =0;
        int stock;
        private void ManageOrders_Load(object sender, EventArgs e)
        {
            populare();
            populareProd();
            getCateg();
          
        }

        private void dataGridViewUserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgViewRow = dataGridViewUserList.Rows[e.RowIndex];
            guna2TextBoxNumeUser.Text = dgViewRow.Cells[1].Value.ToString();
            guna2TextBoxUserPhone.Text = dgViewRow.Cells[3].Value.ToString();
          

        }
        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgViewRow = dataGridViewProd.Rows[e.RowIndex];
            produs = dgViewRow.Cells[1].Value.ToString();
            stock = Convert.ToInt32(dgViewRow.Cells[2].Value.ToString());
            //qty = Convert.ToInt32(guna2TextBoxCantitate.Text);
            uprice = Convert.ToInt32(dgViewRow.Cells[3].Value.ToString());
            //totprice = qty * uprice;
            flag = 1;
          
        }
        
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            float suma = 0;
         
            DataTable table;
            if (dataGridViewComanda.Rows.Count > 0)
            {
                table = (DataTable)dataGridViewComanda.DataSource;
            }
            else
            {
                table = new DataTable();
                table.Columns.Add("Product_Num");
                table.Columns.Add("Product_Name");
                table.Columns.Add("Product_Cant");
                table.Columns.Add("Product_UPrice");
                table.Columns.Add("Product_TotPrice");
            }

          

            if (guna2TextBoxCantitate.Text == "")
            {
                MessageBox.Show("Va rog introduceti o cantitate");
            }
            else if(flag == 0){
                MessageBox.Show("Alegeti produs");
            }
            else if(Convert.ToInt32(guna2TextBoxCantitate.Text) > stock){
                MessageBox.Show("Stoc insuficient");
            }
            else
            {
                num = num + 1;
                qty = Convert.ToInt32(guna2TextBoxCantitate.Text);
                totprice = qty * uprice;
                table.Rows.Add(num, produs, qty, uprice, totprice);
                dataGridViewComanda.DataSource = table;
                flag = 0;
            }
                suma = suma + totprice;
                labelRezultat.Text = suma.ToString();
                updateProduct();
        }

        private void comboBoxFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Conex.Open();
                string querry = "select * from ProductsTable where CategProd='" + comboBoxFilter.SelectedValue.ToString() + "'";
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

        private void buttonSendComanda_Click(object sender, EventArgs e)
        {
            if (guna2TextBoxIDOrder.Text == "" || guna2TextBoxUserPhone.Text == "" || guna2TextBoxNumeUser.Text == "" || labelRezultat.Text == "" )
            {
                MessageBox.Show("Introduceti datele comenzii");
            }
            else
            {
                try
                {
                    Conex.Open();
                    SqlCommand cmd = new SqlCommand("insert into OrderTable values('" + guna2TextBoxIDOrder.Text + "','" + guna2TextBoxUserPhone.Text + "','" + guna2TextBoxNumeUser.Text + "','" + dateTimePickerDataComanda.Text + "','" + labelRezultat.Text +  "')", Conex);
                    //MessageBox.Show(cmd.CommandText);
                    cmd.ExecuteNonQuery();
                    const string mesaj = "Comanda adaugata in baza de date!";
                    MessageBox.Show(mesaj);
                    /*,MessageBoxButtons.OK,MessageBoxIcon.Information);*/
                    Conex.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void buttonVeziComenzi_Click(object sender, EventArgs e)
        {
            ViewOrders view = new ViewOrders();
            view.Show();

        }

        private void guna2CircleButtonHome_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Hide();
        }

        void updateProduct()
        {
            
            
            int id =Convert.ToInt32( dataGridViewProd.Rows[0].Cells[0].Value.ToString());
            int newCant = stock - Convert.ToInt32(guna2TextBoxCantitate.Text);
            if (newCant < 0)
            {
                MessageBox.Show("Operatie esuata!");
            }
            else {
                Conex.Open();
                string querry = "update ProductsTable set CantitateProd=" + newCant + " where IdProdus="+ id + ";";
                SqlCommand cmd = new SqlCommand(querry, Conex);
                cmd.ExecuteNonQuery();
                Conex.Close();
                populareProd();
            }
            
        }


    }
}
