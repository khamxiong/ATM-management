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

namespace ATM_Management
{
    public partial class MiniStament : Form
    {
        public MiniStament()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JMO7UOM\\SQLNAME;Initial Catalog=AtmDB;Integrated Security=True");
        String Acc = Login.Accnumber;

        private void populate()
        {
            con.Open();
            String query = "select*from Transactiontbl where AccNum ='" + Acc + "'";

            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MinistamentDVG.DataSource = ds.Tables[0];

            con.Close();
        }
        private void MiniStament_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
