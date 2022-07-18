using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomBookingDSII
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            ShowCustomers();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Yuli.YULIMANUEL\Documents\GuestHouse.mdf;Integrated Security=True;Connect Timeout=30");
        private void ShowCustomers()
        {
            Con.Open();
            string Query = "Select * from CustomerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CustomersDGV.DataSource = ds.Tables[0];
            Con.Close();
        }


        int Key = 0;
        private void Reset()
        {
            CusNameTb.Text = "";
            CusPhoneTb.Text = "";
            CusGenCb.SelectedIndex = -1;
            Key = 0;

        }



        //GUARDAR

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CusNameTb.Text == "" || CusPhoneTb.Text == "" || CusGenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Falta informacion");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into CustomerTbl(CusName,CusPhone,CusGen,CusDOB)values(@CN,@CP,@CG,@CD)", Con);
                    cmd.Parameters.AddWithValue("@CN", CusNameTb.Text);
                    cmd.Parameters.AddWithValue("@CP", CusPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@CG", CusGenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CD", CusDOB.Value.Date);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente Guardado");
                    Con.Close();
                    ShowCustomers();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }





        //EDITAR
        private void EditBtn_Click(object sender, EventArgs e)
        {

        }






        //BORRAR
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("seleccionar usuario");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from CustomerTbl where CusId=@CKey", Con);
                    cmd.Parameters.AddWithValue("@CKey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente borrado");
                    Con.Close();
                    ShowCustomers();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }


            }

        }




        //DATA GRID VIEW PARA SELECCIONAR
        private void CustomersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CusNameTb.Text = CustomersDGV.SelectedRows[0].Cells[1].Value.ToString();
            CusPhoneTb.Text = CustomersDGV.SelectedRows[0].Cells[2].Value.ToString();
            CusGenCb.Text = CustomersDGV.SelectedRows[0].Cells[3].Value.ToString();
            CusDOB.Text = CustomersDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (CusNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CustomersDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
