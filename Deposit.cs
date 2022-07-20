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
    public partial class Deposit : Form
    {
        public Deposit()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JMO7UOM\\SQLNAME;Initial Catalog=AtmDB;Integrated Security=True");
        string Acc = Login.Accnumber;

        private void Addtransaction()
        {
            String trType = "ໄດ້ຮັບເງີນເຂົ້າບັນຊີ";
            try
            {
                con.Open();
                string query = "insert into Transactiontbl   values('" + Acc + "',N'" + trType+ "'," + depositAmtb.Text + ",'" +DateTime.Today.Date.ToString()+ "')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

              //  MessageBox.Show("ຂໍ້ມູນຖືກເພີ້ມສຳເລັດແລ້ວ");

                con.Close();

                Login log = new Login();
                log.Show();
                this.Hide();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (depositAmtb.Text == "" || Convert.ToInt32(depositAmtb.Text) <=0)
            {
                MessageBox.Show("Enter the Amount to Deposit");
            }

            else
            {
              
                newbalance = oldbalance + Convert.ToInt32(depositAmtb.Text);
                try
                {
                    con.Open();
                    string query = "update Accountbtl set Balance =" + newbalance + "where AccNum = '" + Acc + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("ເງີນຂອງທ່ານໄດ້ຮັບການຮັບຝາກສຳເລັດເເລ້ວ");

                    con.Close();
                    Addtransaction();

                    Home home = new Home();
                    home.Show();
                    this.Hide();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void label5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        int oldbalance ,newbalance;

        private void getbalance()
        {
            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter("select Balance from Accountbtl where Accnum ='" + Acc + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

           oldbalance = Convert.ToInt32( dt.Rows[0][0].ToString());

            con.Close();
        }  

        private void Deposit_Load(object sender, EventArgs e)
        {
            getbalance();
        }
    }
}
