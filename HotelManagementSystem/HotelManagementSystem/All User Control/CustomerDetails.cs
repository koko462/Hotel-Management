using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagementSystem.Data;
using DbConnection = HotelManagementSystem.Data.DbConnection;

namespace HotelManagementSystem.All_User_Control
{
    public partial class CustomerDetails : UserControl
    {
        DbConnection db = new DbConnection();
        String query;
        public CustomerDetails()
        {
            InitializeComponent();
        }

        private void txtSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtSearchBy.SelectedIndex == 0)
            {
                query = "select customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof," +
                    "customer.email,customer.checkin,customer.checkout,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price from customer " +
                    "inner join rooms on customer.roomid = rooms.roomid";
                getRecord(query);
            }
            else if (txtSearchBy.SelectedIndex == 1)
            {
                query = "select customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof," +
                    "customer.email,customer.checkin,customer.checkout,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price from customer " +
                    "inner join rooms on customer.roomid = rooms.roomid where checkout is null";
                getRecord(query);
            }
            else if(txtSearchBy.SelectedIndex == 2)
            {
                query = "select customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof," +
                    "customer.email,customer.checkin,customer.checkout,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price from customer " +
                    "inner join rooms on customer.roomid = rooms.roomid where checkout is not null";
                getRecord(query);
            }
        }

        private void getRecord(String query)
        {
            DataSet ds = db.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
