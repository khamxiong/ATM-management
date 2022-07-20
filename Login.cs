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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
      //  SqlConnection con = new SqlConnection("Data Source=DESKTOP-JMO7UOM\\SQLNAME;Initial Catalog=AtmDB;Integrated Security=True");


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Account acc = new Account();
            acc.Show();
            this.Hide();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JMO7UOM\\SQLNAME;Initial Catalog=AtmDB;Integrated Security=True");
        public static string Accnumber;

        private void loginBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Accountbtl where AccNum ='" + AccNumtb.Text+"' and PIN = "+Pintb.Text+" ",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (AccNumtb.Text == "" || Pintb.Text == "") 
            {
                MessageBox.Show("ຫວ່າງເປົ່າບໍ່ໄດ້");
            }
            
           else  if (dt.Rows[0][0].ToString() == "1")
            {
                Accnumber = AccNumtb.Text;
                Home home = new Home();

                this.Hide();
                home.Show();
                
                con.Close();
            }
            else
            {
                MessageBox.Show("ເລກບັນຊີ ຫຼື ລະຫັດ PIN ບໍ່ຖືກຕ້ອງ ກະລຸນາລອງອືກຄັ້ງ");
            }
            con.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
