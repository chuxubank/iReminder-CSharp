using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iReminder
{
    public partial class SieveDeck : Form
    {
        DBConnection ir = new DBConnection();
        public SieveDeck()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string add_name = textBox1.Text;
            if ((add_name == null) || (add_name.Length == 0))
                return;
            else
            {
                ir.open();
                int flag = 0;
                if ((int)ir.SelectToObject(String.Format("select count(dname) from deck where dname='{0}'", add_name)) != 0)
                    flag = 1;
                ir.close();
                if (flag == 0)
                {
                    ir.open();
                    ir.ExecuteSql("insert into deck(dname,sieve) values(?,?)", new OleDbParameter("dname", add_name),new OleDbParameter("sieve",textBox2.Text));
                    ir.close();
                }
                else
                {
                    MessageBox.Show("已存在此卡组！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            textBox1.Text = "筛选：";
            textBox2.Text = "";
        }
    }
}
