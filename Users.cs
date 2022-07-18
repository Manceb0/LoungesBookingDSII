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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            ShowUsers();
        }



        //CONEXION  --->     Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Yuli.YULIMANUEL\Documents\GuestHouse.mdf;Integrated Security=True;Connect Timeout=30


        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Yuli.YULIMANUEL\Documents\GuestHouse.mdf;Integrated Security=True;Connect Timeout=30");
        private void ShowUsers()
        {
            Con.Open();
            string Query = "Select * from UserTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UsersDGV.DataSource = ds.Tables[0];
            Con.Close();
        }


        ///GUARDAR
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || UphoneTb.Text == "" || UpasswordTb.Text == "")
            {
                MessageBox.Show("Falta informacion");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into UserTbl(Uname,Uphone,Upass)values(@UN,@UP,@UPA)", Con);
                    cmd.Parameters.AddWithValue("@UN", UnameTb.Text);
                    cmd.Parameters.AddWithValue("@UP", UphoneTb.Text);
                    cmd.Parameters.AddWithValue("@UPA", UpasswordTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario Guardado");
                    Con.Close();
                    ShowUsers();
                    Reset();
        
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        ///EDITAR

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || UphoneTb.Text == "" || UpasswordTb.Text == "")
            {
                MessageBox.Show("Falta informacion");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update UserTbl Set Uname=@UN,Uphone=@UP,Upass=@UPA where UId=@UKey", Con);
                    cmd.Parameters.AddWithValue("@UN", UnameTb.Text);
                    cmd.Parameters.AddWithValue("@UP", UphoneTb.Text);
                    cmd.Parameters.AddWithValue("@UPA", UpasswordTb.Text);
                    cmd.Parameters.AddWithValue("@UKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario editado");
                    Con.Close();
                    ShowUsers();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }


        /// RESET///
        private void Reset()
        {
            UnameTb.Text = "";
            UphoneTb.Text = "";
            UpasswordTb.Text = "";
            Key = 0;

        }
        

        ///DELETE///

        int Key = 0;
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
                    SqlCommand cmd = new SqlCommand("Delete from UserTbl where UId=@UKey", Con);
                    cmd.Parameters.AddWithValue("@UKey",Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario borrado");
                    Con.Close();
                    ShowUsers();
                    Reset();
                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void UsersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UnameTb.Text = UsersDGV.SelectedRows[0].Cells[1].Value.ToString();
            UphoneTb.Text = UsersDGV.SelectedRows[0].Cells[2].Value.ToString();
            UpasswordTb.Text = UsersDGV.SelectedRows[0].Cells[3].Value.ToString();
            if(UnameTb.Text == "")
            {
                Key = 0;
            }else
            {
                Key = Convert.ToInt32(UsersDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }
    }
}
