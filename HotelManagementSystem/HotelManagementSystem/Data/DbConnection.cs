﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem.Data
{
    public class DbConnection
    {
        protected SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-CT2J624\\SQLEXPRESS;database=myHotel;integrated security =True;";
            return con;
        }

        public DataSet getData(String query) // Get data from database
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void setData(String query, String message) // Insertion, Deletion and Updation
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("'" + message + "'", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public SqlDataReader getForCombo(String query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }


    }
}
