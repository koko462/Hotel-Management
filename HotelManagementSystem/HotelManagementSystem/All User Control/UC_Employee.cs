using System;
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
    public partial class UC_Employee : UserControl
    {
        DbConnection db = new DbConnection();
        String query;
        public UC_Employee()
        {
            InitializeComponent();
        }

        private void UC_Employee_Load(object sender, EventArgs e)
        {
            getMaxID();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtWorkTime.Text != "" && txtPosition.Text != "" && txtEmail.Text != "" && txtUsername.Text != "" && txtPassword.Text != "")
            {
                String name = txtName.Text;
                String workTime = txtWorkTime.Text;
                String position = txtPosition.Text;
                String email = txtEmail.Text;
                String username = txtUsername.Text;
                String password = txtPassword.Text;

                query = "insert into employee (ename,worktime,position,emailid,username,pass) values('"+name+"','"+workTime+"','"+position+"','"+email+"','"+username+"','"+password+"')";
                db.setData(query, "Employee Registered.");

                clearAll();
                getMaxID();
            }
            else 
            {
                MessageBox.Show("Fill all Fields.", "Warning...!",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //========================================================REQUIRED METHOD=====================================================
        public void getMaxID()
        {
            query = "select max(eid) from employee";
            DataSet ds = db.getData(query);

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                labelToSET.Text = (num + 1).ToString();
            }
        } 
        
        public void clearAll()
        {
            txtName.Clear();
            txtWorkTime.Clear();
            txtPosition.SelectedIndex = -1;
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
        }

        public void setEmployee(DataGridView dgv)
        {
            query = "select * from employee";
            DataSet ds = db.getData(query);
            dgv.DataSource = ds.Tables[0];
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1) 
            {
                setEmployee(dataGridView1);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                setEmployee(dataGridView2);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                if (MessageBox.Show("Are You Sure?", "Confirmation...!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "delete from employee where eid =" + txtID.Text + "";
                    db.setData(query, "Record Deleted.");
                    tabControl1_SelectedIndexChanged(this, null);
                }
            }
            else 
            {
                MessageBox.Show("Fill field for ID", "Information !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void UC_Employee_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
