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
    public partial class dashb : Form
    {
        public dashb()
        {
            InitializeComponent();
            CountBooked();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Yuli.YULIMANUEL\Documents\GuestHouse.mdf;Integrated Security=True;Connect Timeout=30");
        int free, Booked;
        int Bper, FreePer;
        private void CountBooked()
        {

            string Status = "Booked";
            


            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from RoomTbl where RStatus='"+ Status + "'",Con);
            DataTable dt = new DataTable();
            Con.Close();
            sda.Fill(dt);

            free = 20 - Convert.ToInt32(dt.Rows[0][0].ToString());
            Booked = Convert.ToInt32(dt.Rows[0][0].ToString());
            Bper = Booked / 20;
            FreePer = free / 20;
            BLbl.Text = dt.Rows[0][0].ToString() + "Salones reservados";
            AVLbl.Text = free + "Salones libres";
            BProgress.Value = Bper;
            AVProgress.Value =
            Con.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
