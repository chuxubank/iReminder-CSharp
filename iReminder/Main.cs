using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.OleDb;
using System.IO;
using Microsoft.Office.Interop.Access.Dao;
using System.Collections.Generic;

namespace iReminder
{
    public partial class Main : Form
    {
        DBConnection ir = new DBConnection();
        private int deck_id;
        public Main()
        {
            InitializeComponent();
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsb_newcard_Click(object sender, EventArgs e)
        {
            string deck_name = dataGridView1.SelectedRows[0].Cells["名称"].Value.ToString();
            if (dataGridView1.Rows.Count==0)
                MessageBox.Show("请先创建一个卡组！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                NewCard nc = new NewCard(deck_name);
                nc.Show();
            }
            
        }

        private void tsb_browse_Click(object sender, EventArgs e)
        {
            ir.open();
            int count = (int)ir.SelectToObject("select count(*) from card");
            ir.close();
            if (count == 0)
                MessageBox.Show("请先创建一张卡！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Browse bs = new Browse();
                bs.Show();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            refresh_dgv();
            SetBtnStyle(btn_newdeck);
            SetBtnStyle(btn_editdeck);
            SetBtnStyle(btn_deletdeck);
            SetBtnStyle(btn_learndeck);

        }

        /// <summary>  
        /// 设置透明按钮样式  
        /// </summary>  
        private void SetBtnStyle(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;//样式  
            btn.ForeColor = Color.Transparent;//前景  
            btn.BackColor = Color.Transparent;//去背景  
            btn.FlatAppearance.BorderColor = Color.CornflowerBlue;
            btn.FlatAppearance.BorderSize = 0;//去边线  
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;//鼠标经过  
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;//鼠标按下  
        }
        private void btn_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatAppearance.BorderSize = 1;
        }
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatAppearance.BorderSize = 0;
        }


        private void btn_newdeck_Click(object sender, EventArgs e)
        {
            string add_name = Interaction.InputBox("请输入卡组名称:", "提示");
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
                    ir.ExecuteSql("insert into deck(dname) values(?)", new OleDbParameter("dname", add_name));
                    ir.close();
                    refresh_dgv();
                }
                else
                {
                    MessageBox.Show("已存在此卡组！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void refresh_dgv()
        {
            DataTable dt = new DataTable();
            ir.open();
            dt = ir.SelectToDataTable("select id as 编号,dname as 名称 from deck");
            dt.Columns.Add(new DataColumn("已完成"));
            dt.Columns.Add(new DataColumn("卡片总数"));
            for(int i=0;i<dt.Rows.Count;i++)
            {
                int issieve;
                issieve = (int)ir.SelectToObject(String.Format("select count(sieve) from deck where id={0}", dt.Rows[i]["编号"]));
                if(issieve==1)
                {
                    string sieve_str= (string)ir.SelectToObject(String.Format("select sieve from deck where id={0}", dt.Rows[i]["编号"]));
                    //处理标签
                    HashSet<string> tagset = new HashSet<string>();
                    string tagstr=sieve_str;
                    string[] tagarray = tagstr.Split(' ');
                    foreach (string tag in tagarray)
                    {
                        tagset.Add(tag);
                    }
                    string sqltegsieve="";
                    foreach(string tag in tagset)
                    {
                        sqltegsieve += " and tag like '%" + tag + "%'";
                    }
                    dt.Rows[i]["已完成"] = ir.SelectToObject(String.Format("select count(donetime) from card where 1=1" + sqltegsieve, dt.Rows[i]["编号"]));
                    dt.Rows[i]["卡片总数"] = ir.SelectToObject(String.Format("select count(*) from card where 1=1" + sqltegsieve, dt.Rows[i]["编号"]));

                }
                else
                {
                    dt.Rows[i]["已完成"] = ir.SelectToObject(String.Format("select count(donetime) from card where decknum={0}", dt.Rows[i]["编号"]));
                    dt.Rows[i]["卡片总数"] = ir.SelectToObject(String.Format("select count(*) from card where decknum={0}", dt.Rows[i]["编号"]));

                }
            }
            ir.close();
            dataGridView1.DataSource = dt;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btn_editdeck_Click(object sender, EventArgs e)
        {
            int id = deck_id;
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择一个卡组", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string edit_name = Interaction.InputBox("请输入新卡组名称:", "提示", dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                if ((edit_name == null) || (edit_name.Length == 0))
                    return;
                else
                {
                    ir.open();
                    int flag = 0;
                    if ((int)ir.SelectToObject(String.Format("select count(dname) from deck where dname='{0}'",edit_name))!=0)
                            flag = 1;
                    ir.close();
                    if (flag==0)
                    {
                        ir.open();
                        ir.ExecuteSql("update deck set dname=? where id=?", new OleDbParameter("dname", edit_name), new OleDbParameter("id", id));
                        ir.close();
                        refresh_dgv();
                    }
                    else
                    {
                        MessageBox.Show("已存在此卡组！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }  
        }

        private void btn_deletdeck_Click(object sender, EventArgs e)
        {
            int id = deck_id;
            int issieve;
            if (dataGridView1.SelectedRows.Count==0)
            {
                MessageBox.Show("请先选择一个卡组", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                ir.open();
                issieve = (int)ir.SelectToObject(String.Format("select count(sieve) from deck where id={0}", id));
                ir.close();
                if (issieve == 1)
                {
                    if (MessageBox.Show("删除此卡组?\n删除筛选卡组不会删除其中所有卡片", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        ir.open();
                        ir.ExecuteSql("delete from deck where id=?", new OleDbParameter("id", id));
                        ir.close();
                        refresh_dgv();
                    }
                }
                else if (MessageBox.Show("删除此卡组?\n删除此卡组将会删除其中所有卡片!", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    ir.open();
                    ir.ExecuteSql("delete from card where decknum=?", new OleDbParameter("decknum", id));
                    ir.ExecuteSql("delete from deck where id=?", new OleDbParameter("id", id));
                    ir.close();
                    refresh_dgv();
                }
            }
        }

        private void btn_learndeck_Click(object sender, EventArgs e)
        {
            int id = deck_id;
            if (dataGridView1.SelectedRows.Count == 0)
                MessageBox.Show("请先选择一个卡组", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else if(dataGridView1.SelectedRows[0].Cells["已完成"].Value.ToString() == dataGridView1.SelectedRows[0].Cells["卡片总数"].Value.ToString())
                MessageBox.Show("该卡组已背完", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
            {
                ReviewCard rc = new ReviewCard(id);
                rc.Show(this);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count != 0)
                deck_id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["编号"].Value);
        }

        private void Main_Activated(object sender, EventArgs e)
        {
            refresh_dgv();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("iReminder v1.0.0", "版本信息");
        }

        private void 重记选择卡组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ir.open();
            ir.ExecuteNonQuery(String.Format("update card set state=0 ,donetime=null where decknum={0}", deck_id));
            ir.close();
            MessageBox.Show("已重置卡组！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void 清除空卡片CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ir.open();
            ir.ExecuteNonQuery("delete from card where front is null");
            ir.close();
            MessageBox.Show("已清除所有空卡片！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void 重建数据库RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("此举将清除全部内容，是否继续？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2)==DialogResult.OK)
            {
                ir.open();
                ir.ExecuteNonQuery("delete from card");
                ir.ExecuteNonQuery("delete from deck");
                ir.close();
                MessageBox.Show("已清除数据库！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// 导出到excel
        /// </summary>
        /// <param name="dt"></param>
        protected void ExportExcel(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0) return;
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("您的电脑可能没有安装Excel","提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                return;
            }
            System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range;
            long totalCount = dt.Rows.Count;
            long rowRead = 0;
            float percent = 0;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, i + 1];
                range.Interior.ColorIndex = 15;
                range.Font.Bold = true;
            }
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = dt.Rows[r][i].ToString();
                }
                rowRead++;
                percent = ((float)(100 * rowRead)) / totalCount;
            }
            xlApp.Visible = true;
        }

        private void 导出所有生卡片到ExcelEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            ir.open();
            dt = ir.SelectToDataTable("select c.id as 编号,front as 正面,back as 反面, creattime as 创建时间,donetime as 完成时间,state as 状态,tag as 标签, dname as 所在卡组 from card c ,deck d where donetime is null and c.decknum=d.id");
            ir.close();
            RichTextBox rtb = new RichTextBox();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    rtb.Rtf = dt.Rows[i]["正面"].ToString();
                    dt.Rows[i]["正面"] = rtb.Text;
                    rtb.Rtf = dt.Rows[i]["反面"].ToString();
                    dt.Rows[i]["反面"] = rtb.Text;
                }
                catch
                { }
            }
            ExportExcel(dt);
        }

        
        private void 压缩数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string accessFile = "iReminder.mdb";
            string tempFile = Path.Combine(Path.GetDirectoryName(accessFile),
                              Path.GetRandomFileName() + Path.GetExtension(accessFile));
            var dbe = new DBEngine();
            try
            {
                dbe.CompactDatabase(accessFile, tempFile);
                FileInfo temp = new FileInfo(tempFile);
                temp.CopyTo(accessFile, true);
                temp.Delete();
            }
            catch (Exception e1)
            {
                Console.WriteLine("Error: " + e1.Message);
            }
            MessageBox.Show("完成压缩！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void 创建筛选卡组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SieveDeck sd = new SieveDeck();
            sd.Show();
        }

        private void btn_newdeck_MouseEnter(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.btn_newdeck, "新建卡组");
            p.SetToolTip(this.btn_deletdeck, "删除卡组");
            p.SetToolTip(this.btn_editdeck, "编辑卡组");
            p.SetToolTip(this.btn_learndeck, "学习卡组");
        }
    }
}
