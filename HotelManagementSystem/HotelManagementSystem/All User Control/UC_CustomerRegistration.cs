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
using HotelManagementSystem.Data;

namespace HotelManagementSystem.All_User_Control
{
    public partial class UC_CustomerRegistration : UserControl
    {
        DbConnection db = new DbConnection();
        String query;

        public UC_CustomerRegistration()
        {
            InitializeComponent();
        }

        public void setComboBox(String query, ComboBox combo)
        {
            SqlDataReader sdr = db.getForCombo(query);
            while (sdr.Read()) 
            { 
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    combo.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
        }

        private void UC_CustomerRegistration_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomNo.Items.Clear();
            query = "select roomNo from rooms where bed = '"+txtBed.Text+"' and roomType='"+txtType.Text+"' and booked= 'NO' ";
            setComboBox(query, txtRoomNo);
        }

        private void txtBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtType.SelectedIndex = -1;
            txtRoomNo.Items.Clear();
        }

        int rid;
        private void txtRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select price,roomid from rooms where roomNo = '"+txtRoomNo.Text+"'";
            DataSet ds = db.getData(query);
            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            rid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
        }

        private void btnAlloteRoom_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtMobile.Text != "" && txtNationality.Text != "" && txtGender.Text != "" && txtDob.Text != "" && txtIdProof.Text != "" && txtEmail.Text != "" && txtCheckIn.Text != "" && txtPrice.Text != "")
            {
                String name = txtName.Text;
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String nationality = txtNationality.Text;
                String gender = txtGender.Text;
                String dob = txtDob.Text;
                String idProof = txtIdProof.Text;
                String email = txtEmail.Text;
                String checkIn = txtCheckIn.Text;

                query = "insert into customer (cname,mobile,nationality,gender,dob,idproof,email,checkin,roomid) values ('"+name+"',"+mobile+",'"+nationality+"','"+gender+"','"+dob+"','"+idProof+"','"+email+"','"+checkIn+"',"+rid+") update rooms set booked = 'YES' where roomNo = '"+txtRoomNo.Text+"'";
                db.setData(query, "Room No " + txtRoomNo.Text + " Allocation Successful.");
            }
            else 
            { 
                MessageBox.Show("All fields are mandatory.", "Information !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            txtName.Clear();
            txtMobile.Clear();
            txtNationality.Clear();
            txtGender.SelectedIndex = -1;
            txtDob.ResetText();
            txtIdProof.Clear();
            txtEmail.Clear();
            txtCheckIn.ResetText();
            txtBed.SelectedIndex = -1;
            txtType.SelectedIndex = -1;
            txtRoomNo.Items.Clear();
            txtPrice.Clear();
        }

        private void UC_CustomerRegistration_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
