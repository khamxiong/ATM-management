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
    public partial class Balance : Form
    {
        public Balance()
        {
            InitializeComponent();
        }
        // link to conect sql server 
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JMO7UOM\\SQLNAME;Initial Catalog=AtmDB;Integrated Security=True");
        private void getbalance()
        {
            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter("select Balance from Accountbtl where Accnum ='"+ AccnumLabel.Text+"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BalanceLabel.Text = dt.Rows[0][0].ToString() +" ກີບ";
            con.Close();
        }
        private void Balance_Load(object sender, EventArgs e)
        {
            AccnumLabel.Text = Home.Accnumber;

            getbalance();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }
    }
}
