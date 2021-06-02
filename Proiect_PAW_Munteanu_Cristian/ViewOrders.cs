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
    public partial class ViewOrders : Form
    {
        public ViewOrders()
        {
            InitializeComponent();
        }
        SqlConnection Conex = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Cristi\Documents\HardwareShop.mdf;Integrated Security=True;Connect Timeout=30");

        void populareOrders()
        {
            try
            {
                Conex.Open();
                string querry = "select * from OrderTable";
                SqlDataAdapter adapter = new SqlDataAdapter(querry, Conex);
                SqlCommandBuilder bld = new SqlCommandBuilder(adapter);
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                guna2DataGridViewOrders.DataSource = dataSet.Tables[0];
                Conex.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ViewOrders_Load(object sender, EventArgs e)
        {
            populareOrders();
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void guna2DataGridViewOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Order Summary", new Font("Arial", 30, FontStyle.Bold),Brushes.Red,new Point(230));
            e.Graphics.DrawString("Order Id: "+ guna2DataGridViewOrders.SelectedRows[0].Cells[0].Value.ToString(), new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(80,100));
            e.Graphics.DrawString("Telefone User: " + guna2DataGridViewOrders.SelectedRows[0].Cells[1].Value.ToString(), new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(80, 130));
            e.Graphics.DrawString("Nume User: " + guna2DataGridViewOrders.SelectedRows[0].Cells[2].Value.ToString(), new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(80, 160));
            e.Graphics.DrawString("Data Comanda: " + guna2DataGridViewOrders.SelectedRows[0].Cells[3].Value.ToString(), new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(80, 190));
            e.Graphics.DrawString("Cost Total: " + guna2DataGridViewOrders.SelectedRows[0].Cells[4].Value.ToString(), new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(80, 220));


        }

        private void printToolStripMenuItem_Click(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
            
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void afisatiGraficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}
