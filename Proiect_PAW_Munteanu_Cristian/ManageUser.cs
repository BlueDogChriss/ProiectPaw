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
    public partial class ManageUser : Form
    {
        public ManageUser()
        {
            InitializeComponent();
        }

        void populare()
        {
            try
            {
                Conex.Open();
                string querry = "select * from UserTable";
                SqlDataAdapter adapter = new SqlDataAdapter(querry,Conex);
                SqlCommandBuilder bld = new SqlCommandBuilder(adapter);
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataGridViewUsers.DataSource = dataSet.Tables[0];
                Conex.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        SqlConnection Conex = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Cristi\Documents\HardwareShop.mdf;Integrated Security=True;Connect Timeout=30");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
           
            try
            {
                Conex.Open();
                SqlCommand cmd = new SqlCommand("insert into UserTable values('" + guna2TextBoxUserName.Text + "','" + guna2TextBoxFullName.Text + "','" +  guna2TextBoxPassword.Text + "','" + guna2TextBoxTelefon.Text + "','" + guna2TextBoxEmail.Text + "','" + guna2TextBoxAdresa.Text + "')", Conex);
                cmd.ExecuteNonQuery();
                const string mesaj = "User adaugat in baza de date!";
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

        private void ManageUser_Load(object sender, EventArgs e)
        {
            populare();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            const string msgApprove = "Enter User Phone Number";
            const string msgDelete = "User sters cu succes!";
            if (guna2TextBoxTelefon.Text == "")
            {
                
                MessageBox.Show(msgApprove);
            }
            else
            {
                Conex.Open();
                string querry = "delete from UserTable where UTelefone='" + guna2TextBoxTelefon.Text + "';";
                SqlCommand cmd = new SqlCommand(querry,Conex);
                cmd.ExecuteNonQuery();
                MessageBox.Show(msgDelete);
                Conex.Close();
                populare();
            }
        }

        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1) { 
            DataGridViewRow dgViewRow = dataGridViewUsers.Rows[e.RowIndex];  

            guna2TextBoxUserName.Text = dgViewRow.Cells[0].Value.ToString();
            guna2TextBoxPassword.Text = dgViewRow.Cells[1].Value.ToString();
            guna2TextBoxFullName.Text = dgViewRow.Cells[2].Value.ToString();
            guna2TextBoxTelefon.Text = dgViewRow.Cells[3].Value.ToString();
            guna2TextBoxEmail.Text = dgViewRow.Cells[4].Value.ToString();
            guna2TextBoxAdresa.Text = dgViewRow.Cells[5].Value.ToString();
            }
            Conex.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from OrdersTable where TelefonUser = " + guna2TextBoxTelefon.Text + "", Conex);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            labelCount.Text = dt.Rows[0][0].ToString();

            SqlDataAdapter sda1 = new SqlDataAdapter("select Sum(CostTotal) from OrdersTable where TelefonUser = " + guna2TextBoxTelefon.Text + "", Conex);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            labelAmount.Text = dt1.Rows[0][0].ToString();

            SqlDataAdapter sda2 = new SqlDataAdapter("select OrderDate from OrdersTable where TelefonUser = " + guna2TextBoxTelefon.Text + "", Conex);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            labelDate.Text = dt2.Rows[0][0].ToString();

            Conex.Close();


        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Conex.Open();
                SqlCommand cmd = new SqlCommand("update UserTable set Uname='"+ guna2TextBoxUserName.Text + "',UFullname='" + guna2TextBoxPassword.Text + "',Upassword='"+ guna2TextBoxPassword.Text + "',UTelefone='" + guna2TextBoxTelefon.Text +"',UEmail='"+ guna2TextBoxEmail.Text + "',UAdress='"+ guna2TextBoxAdresa.Text + "' where UTelefone='"+ guna2TextBoxTelefon.Text + "'", Conex);
                cmd.ExecuteNonQuery();
                const string mesaj = "User actualizat in baza de date!"; 
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButtonHome_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Hide();
        }
    }
}
