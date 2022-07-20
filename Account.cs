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
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JMO7UOM\\SQLNAME;Initial Catalog=AtmDB;Integrated Security=True");


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Account_Load(object sender, EventArgs e)
        {

        }

        private void loginBTN_Click(object sender, EventArgs e)
        {
            int bal = 0;
            if (AccNumtb.Text==""||Nametb.Text==""||faNametb.Text==""||phonetb.Text==""||pintb.Text=="")
            {
                MessageBox.Show("ກະລຸນາປ້ອມຂໍ້ມູນໃຫ້ຄົບ");

            }
            else
            {
                 try
                 {
                     con.Open();
                    string query = "insert into Accountbtl values('"+AccNumtb.Text+"',N'"+Nametb.Text+"',N'"+faNametb.Text+"','" + Bdate.Value.Date + "','" + phonetb.Text + "',N'" +addresstb.Text+ "',"+ pinid.Text +",N'"+ Educombo.SelectedItem.ToString() +"',N'" +Occutb.Text+ "',"+bal+")";

                     SqlCommand cmd = new SqlCommand(query, con);
                     cmd.ExecuteNonQuery();

                     MessageBox.Show("ຂໍ້ມູນຖື້ມເພີ້ມສຳເລັດແລ້ວ");

                     con.Close();

                    Login log = new Login();
                    log.Show();
                    this.Hide();
                 }
                 catch(Exception Ex)
                 {
                     MessageBox.Show(Ex.Message);
                 }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
