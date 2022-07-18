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
    public partial class Bookings : Form
    {
        public Bookings()
        {
            InitializeComponent();
            showBooking();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Yuli.YULIMANUEL\Documents\GuestHouse.mdf;Integrated Security=True;Connect Timeout=30");

        private void showBooking()
        {
            Con.Open();
            string Query = "Select * from BookingTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookingDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void filterBooking()
        {
            Con.Open();
            string Query = "Select * from BookingTbl where RType = '"+RTypeCb.SelectedItem.ToString()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookingDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            showBooking();
        }

        private void RTypeCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filterBooking();
        }
    }
}
