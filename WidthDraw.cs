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
    public partial class WidthDraw : Form
    {
        public WidthDraw()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JMO7UOM\\SQLNAME;Initial Catalog=AtmDB;Integrated Security=True");
        string Acc = Login.Accnumber;
        int bal;
        private void getbalance()
        {
            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter("select Balance from Accountbtl where Accnum ='" + Acc + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            balancelbl.Text = "ຍອດເງີນໃນບັນຊີຂອງທ່ານ:" + dt.Rows[0][0].ToString() +" ກີບ";
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            con.Close();
        }
        //active in our app
        private void Addtransaction()
        {
            String trType = "ຖອນເງີນອອກຈາກບັນຊີ";
            try
            {
                con.Open();
                string query = "insert into Transactiontbl   values('" + Acc + "',N'" + trType + "'," + WDAmoutTb.Text + ",'" + DateTime.Today.Date.ToString() + "')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

              //  MessageBox.Show("ຂໍ້ມູນຖືກເພີ້ມສຳເລັດແລ້ວ");

                con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        private void WidthDraw_Load(object sender, EventArgs e)
        {
            getbalance();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int  newbalance;
        private void widthdrawBtn_Click(object sender, EventArgs e)
        {
            if (WDAmoutTb.Text=="")
            {
                MessageBox.Show("ບໍ່ມີຂໍ້ມູນ ກະລຸນາປ້ອມ ເເລ້ວ ລອງອີກຄັ້ງ");
            }
            else if (Convert.ToInt32(WDAmoutTb.Text) < 0)
            {
                MessageBox.Show("ກະລຸນາປ້ອມໃຫມ່ ເເລ້ວ ລອງອີກຄັ້ງ");
            }
            else if(Convert.ToInt32(WDAmoutTb.Text) > bal)
            {
                MessageBox.Show("ຈຳນວນຍອດເງີນໃນບັນຊີບໍ່ພຽງພໍ");
            }
            else
            {

                newbalance = bal- Convert.ToInt32(WDAmoutTb.Text);
                try
                {
                    con.Open();
                    string query = "update Accountbtl set Balance =" + newbalance + "where AccNum = '" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("ຖອນສຳເລັດ !");

                    Home home = new Home();
                    home.Show();
                    this.Hide();

                    con.Close();
                    Addtransaction();
                 
                }
                catch (Exception ex)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
