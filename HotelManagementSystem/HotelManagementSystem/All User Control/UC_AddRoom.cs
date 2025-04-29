﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagementSystem.Data;

namespace HotelManagementSystem.All_User_Control
{
    public partial class UC_AddRoom : UserControl
    {
        DbConnection db = new DbConnection();
        String query;
        
        public UC_AddRoom()
        {
            InitializeComponent();
        }

        private void UC_AddRoom_Load(object sender, EventArgs e)
        {
            query = "select * from rooms";
            DataSet ds = db.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "" && txtType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                String roomNo = txtRoomNo.Text;
                String type = txtType.Text;
                String bed = txtBed.Text;
                decimal price = decimal.Parse(txtPrice.Text);

                query = "insert into rooms (roomNo,roomType,bed,price) values ('" + roomNo + "','" + type + "','" + bed + "'," + price + ")";
                db.setData(query, "Room Added.");

                UC_AddRoom_Load(this, null);
                clearAll();
            }
            else 
            { 
                MessageBox.Show("Fill All Fields.", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            txtRoomNo.Clear();
            txtType.SelectedIndex = -1;
            txtBed.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private void UC_AddRoom_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_AddRoom_Enter(object sender, EventArgs e)
        {
            UC_AddRoom_Load(this, null);
        }
    }
}
