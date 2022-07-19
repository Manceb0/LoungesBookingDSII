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
            CountCustomers();
            CountBooked();
            CountBookings();
            GetCustomers();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Yuli.YULIMANUEL\Documents\GuestHouse.mdf;Integrated Security=True;Connect Timeout=30");
        int free, Booked;
        int Bper, FreePer;
        int RoomNumber = 0;


        //BOTON 


        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(CusNameTb.Text)
        }



        private void CountBooked()
        {

            string Status = "Booked";



            
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count (*) from RoomTbl where RStatus='" + Status + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            free = 20 - Convert.ToInt32(dt.Rows[0][0].ToString());
            Booked = Convert.ToInt32(dt.Rows[0][0].ToString());
            Bper = (Booked / 20) * 100;
            FreePer = (free / 20) * 100;
            Blbl.Text = dt.Rows[0][0].ToString() + " Salones Reservados";
            AVLbl.Text = free + " Salones disponibles";
            AVLbl1.Text = free + "";
            BProgress.Value = Bper;
            AVProgress.Value = FreePer;
            FreeRoomsProgress.Value = FreePer;
            Con.Close();
        }

        private void CountCustomers()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from BookingTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CustNumLbl.Text = dt.Rows[0][0].ToString() + "Bookings";
            Con.Close();
        }

        private void CountBookings()
        {


            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from CustomerTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            BookedLbl.Text = dt.Rows[0][0].ToString() + "Reservados";
            Con.Close();
        }

        private void GetCustomers()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select CusId from CustomerTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CusId", typeof(int));
            dt.Load(rdr);
            CusIdCb.ValueMember = "CusId";
            CusIdCb.DataSource = dt;
            Con.Close();
        }
        
        private void CusIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCusName();
        }

        private void R1_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 1;
        }

        private void R2_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 2;
        }

        private void R3_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 3;
        }

        private void R4_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 4;
        }

        private void R5_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 4;
        }
        private void R6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void R7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void R8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void R9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void R10_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 10;

        }

        private void R11_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 11;
        }

        private void R12_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 12;
        }

        private void R13_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 13;
        }

        private void R14_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 14;
        }

        private void R15_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 15;
        }

        private void R16_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 16;
        }

        private void R17_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 17;
        }

        private void R18_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 18;
        }

        private void R19_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 19;
        }

        private void R20_Paint(object sender, PaintEventArgs e)
        {
            RoomNumber = 20;
        }

        private void GetCusName()
        {

            string Query = "Select * from CustomerTbl where CusId=" + CusIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CusNameTb.Text = dr["CusName"].ToString();
            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
