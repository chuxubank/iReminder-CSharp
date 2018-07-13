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
    public partial class Browse : Form
    {
        DBConnection ir = new DBConnection();
        private DataTable dt_card = new DataTable();
        private DataTable dt_deck = new DataTable();
        private DataTable dt_tag = new DataTable();
        public Browse()
        {
            InitializeComponent();
        }
        private void Browse_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            // TODO: 这行代码将数据加载到表“iReminderDataSet_deck.deck”中。您可以根据需要移动或删除它。
            this.deckTableAdapter.Fill(this.iReminderDataSet_deck.deck);
            ir.open();
            dt_card = ir.SelectToDataTable("select c.id as 编号,front as 正面,creattime as 创建时间,donetime as 完成时间,state  as 完成状态,tag  as 标签,d.dname as 所在卡组 from deck d,card c where d.id = c.decknum and d.sieve is null");
            dt_deck = ir.SelectToDataTable("select * from deck where sieve is null");
            dt_tag = ir.SelectToDataTable("select DISTINCT tag from card where((tag is not null) and (tag <>''))");
            ir.close();
            //处理标签
            HashSet<string> tagset = new HashSet<string>();
            string tagstr;
            foreach (DataRow dr in dt_tag.Rows)
            {
                tagstr = dr["tag"].ToString();
                string[] tagarray = tagstr.Split(' ');
                foreach(string tag in tagarray)
                {
                    tagset.Add(tag);
                }
            }
            listView2.Items.Add("无标签");
            foreach (string tag in tagset)
            {
                listView2.Items.Add(tag);
            }
            dataGridView_card.DataSource = dt_card;
            for(int i=0;i<dataGridView_card.Columns.Count;i++)
            {
                dataGridView_card.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            for (int i=0;i<dt_deck.Rows.Count;i++)
            {
                listView1.Items.Add(dt_deck.Rows[i]["dname"].ToString());
            }
            refresh_dgv();
        }

        private void refresh_dgv()
        {
            RichTextBox rtb = new RichTextBox();
            for (int i = 0; i < dataGridView_card.RowCount; i++)
            {
                try
                {
                    rtb.Rtf = dataGridView_card.Rows[i].Cells[1].Value.ToString();
                    dataGridView_card.Rows[i].Cells[1].Value = rtb.Text;
                }
                catch
                { }
            }
            if(dataGridView_card.SelectedRows.Count==0)
            {
                richTextBox1.Text = "";
                richTextBox2.Text = "";
                textBox1.Text = "";
            }
            button1.Enabled = false;
        }

        private void dataGridView_card_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView_card.SelectedRows.Count!=0)
            {
                int id = int.Parse(dataGridView_card.SelectedRows[0].Cells[0].Value.ToString());
                ir.open();
                comboBox1.SelectedValue = int.Parse(ir.SelectToObject(String.Format("select decknum from card where id={0}", id)).ToString());
                richTextBox1.Rtf = ir.SelectToObject(String.Format("select front from card where id={0}", id)).ToString();
                richTextBox2.Rtf = ir.SelectToObject(String.Format("select back from card where id={0}", id)).ToString();
                textBox1.Text = ir.SelectToObject(String.Format("select tag from card where id={0}", id)).ToString();
                ir.close();
            }
            refresh_dgv();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ir.open();
            if(listView1.SelectedItems.Count!=0)
                dt_card = ir.SelectToDataTable(String.Format("select c.id as 编号,front as 正面,creattime as 创建时间,donetime as 完成时间,state  as 完成状态,tag  as 标签,d.dname as 所在卡组 from deck d,card c where d.id = c.decknum and d.dname='{0}' and d.sieve is null",listView1.SelectedItems[0].Text));
            else
                dt_card = ir.SelectToDataTable("select c.id as 编号,front as 正面,creattime as 创建时间,donetime as 完成时间,state  as 完成状态,tag  as 标签,d.dname as 所在卡组 from deck d,card c where d.id = c.decknum and d.sieve is null");
            ir.close();
            dataGridView_card.DataSource = dt_card;
            refresh_dgv();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ir.open();
            if (listView2.SelectedItems.Count == 0)
                dt_card = ir.SelectToDataTable("select c.id as 编号,front as 正面,creattime as 创建时间,donetime as 完成时间,state  as 完成状态,tag  as 标签,d.dname as 所在卡组 from deck d,card c where d.id = c.decknum and d.sieve is null");
            else if(listView2.SelectedItems[0].Text=="无标签")
            {
                dt_card = ir.SelectToDataTable(String.Format("select c.id as 编号,front as 正面,creattime as 创建时间,donetime as 完成时间,state  as 完成状态,tag  as 标签,d.dname as 所在卡组 from deck d,card c where d.id = c.decknum and (tag is null or tag ='' or tag=' ') and d.sieve is null", listView2.SelectedItems[0].Text));
            }
            else
            {
                //处理标签
                HashSet<string> tagset = new HashSet<string>();
                foreach (ListViewItem tag in listView2.SelectedItems)
                {
                    tagset.Add(tag.Text);
                }
                string sqltegsieve = "";
                foreach (string tag in tagset)
                {
                    sqltegsieve += " and tag like '%" + tag + "%'";
                }
                dt_card = ir.SelectToDataTable("select c.id as 编号,front as 正面,creattime as 创建时间,donetime as 完成时间,state  as 完成状态,tag  as 标签,d.dname as 所在卡组 from deck d,card c where d.id = c.decknum and d.sieve is null"+sqltegsieve);

            }
            ir.close();
            dataGridView_card.DataSource = dt_card;
            refresh_dgv();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView_card.SelectedRows[0].Cells[0].Value);
            ir.open();
            string sql = "update card set FRONT=?,BACK=?,DECKNUM=?,TAG=? where id=?";
            OleDbParameter[] parameters = new OleDbParameter[]
            {
                    new OleDbParameter("FRONT",richTextBox1.Rtf),
                    new OleDbParameter("BACK",richTextBox2.Rtf),
                    new OleDbParameter("DECKNUM",comboBox1.SelectedValue),
                    new OleDbParameter("TAG",textBox1.Text),
                    new OleDbParameter("ID",id),
            };
            ir.ExecuteSql(sql, parameters);
            ir.close();
            button1.Enabled = false;
            Browse_Load(sender, e);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            button1.Enabled = true;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Focused)
            {
                Font oldFont1, newFont1;
                try
                {
                    oldFont1 = richTextBox1.SelectionFont;
                    if (oldFont1.Bold)
                    {
                        newFont1 = new Font(oldFont1, oldFont1.Style ^ FontStyle.Bold);
                    }
                    else
                    {
                        newFont1 = new Font(oldFont1, oldFont1.Style | FontStyle.Bold);
                    }
                    richTextBox1.SelectionFont = newFont1;
                    richTextBox1.Focus();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            else if (richTextBox2.Focused)
            {
                Font oldFont2, newFont2;
                try
                {
                    oldFont2 = richTextBox2.SelectionFont;
                    if (oldFont2.Bold)
                    {
                        newFont2 = new Font(oldFont2, oldFont2.Style ^ FontStyle.Bold);
                    }
                    else
                    {
                        newFont2 = new Font(oldFont2, oldFont2.Style | FontStyle.Bold);
                    }
                    richTextBox2.SelectionFont = newFont2;
                    richTextBox2.Focus();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Focused)
            {
                Font oldFont1, newFont1;
                try
                {
                    oldFont1 = richTextBox1.SelectionFont;
                    if (oldFont1.Italic)
                    {
                        newFont1 = new Font(oldFont1, oldFont1.Style ^ FontStyle.Italic);
                    }
                    else
                    {
                        newFont1 = new Font(oldFont1, oldFont1.Style | FontStyle.Italic);
                    }
                    richTextBox1.SelectionFont = newFont1;
                    richTextBox1.Focus();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            else if (richTextBox2.Focused)
            {
                Font oldFont2, newFont2;
                try
                {
                    oldFont2 = richTextBox2.SelectionFont;
                    if (oldFont2.Italic)
                    {
                        newFont2 = new Font(oldFont2, oldFont2.Style ^ FontStyle.Italic);
                    }
                    else
                    {
                        newFont2 = new Font(oldFont2, oldFont2.Style | FontStyle.Italic);
                    }
                    richTextBox2.SelectionFont = newFont2;
                    richTextBox2.Focus();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Focused)
            {
                Font oldFont1, newFont1;
                try
                {
                    oldFont1 = richTextBox1.SelectionFont;
                    if (oldFont1.Underline)
                    {
                        newFont1 = new Font(oldFont1, oldFont1.Style ^ FontStyle.Underline);
                    }
                    else
                    {
                        newFont1 = new Font(oldFont1, oldFont1.Style | FontStyle.Underline);
                    }
                    richTextBox1.SelectionFont = newFont1;
                    richTextBox1.Focus();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            else if (richTextBox2.Focused)
            {
                Font oldFont2, newFont2;
                try
                {
                    oldFont2 = richTextBox2.SelectionFont;
                    if (oldFont2.Underline)
                    {
                        newFont2 = new Font(oldFont2, oldFont2.Style ^ FontStyle.Underline);
                    }
                    else
                    {
                        newFont2 = new Font(oldFont2, oldFont2.Style | FontStyle.Underline);
                    }
                    richTextBox2.SelectionFont = newFont2;
                    richTextBox2.Focus();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }

        }

        Font oldfont1, oldfont2;
        float fontsize1, fontsize2;

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Focused)
            {
                try
                {
                    oldfont1 = richTextBox1.SelectionFont;
                    fontsize1 = richTextBox1.SelectionFont.Size;
                    fontsize1 += 1;
                    richTextBox1.SelectionFont = new Font(oldfont1.Name, fontsize1, oldfont1.Style);
                    richTextBox1.Focus();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            else if (richTextBox2.Focused)
            {
                try
                {
                    oldfont2 = richTextBox2.SelectionFont;
                    fontsize2 = richTextBox2.SelectionFont.Size;
                    fontsize2 += 2;
                    richTextBox2.SelectionFont = new Font(oldfont2.Name, fontsize2, oldfont2.Style);
                    richTextBox2.Focus();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Focused)
            {
                try
                {
                    oldfont1 = richTextBox1.SelectionFont;
                    fontsize1 = richTextBox1.SelectionFont.Size;
                    fontsize1 -= 1;
                    richTextBox1.SelectionFont = new Font(oldfont1.Name, fontsize1, oldfont1.Style);
                    richTextBox1.Focus();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            else if (richTextBox2.Focused)
            {
                try
                {
                    oldfont2 = richTextBox2.SelectionFont;
                    fontsize2 = richTextBox2.SelectionFont.Size;
                    fontsize2 -= 2;
                    richTextBox2.SelectionFont = new Font(oldfont2.Name, fontsize2, oldfont2.Style);
                    richTextBox2.Focus();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private Color color1 = Color.Black, color2 = Color.Black;

        private void toolStripButton_colorselect_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Focused)
            {
                colorDialog1.ShowDialog();
                color1 = colorDialog1.Color;
            }
            else if (richTextBox2.Focused)
            {
                colorDialog1.ShowDialog();
                color2 = colorDialog1.Color;
            }
        }

        private void toolStripButton_setcolor_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Focused)
            {
                richTextBox1.SelectionColor = color1;
            }
            else if (richTextBox2.Focused)
            {
                richTextBox2.SelectionColor = color2;
            }
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText); // call default browser  
        }

        private void toolStripButton_clear_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Focused)
            {
                try
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Regular);
                    richTextBox1.SelectionColor = Color.Black;
                    fontsize1 = 16;
                    richTextBox1.Focus();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            else if (richTextBox2.Focused)
            {
                try
                {
                    richTextBox2.SelectionFont = new Font(richTextBox2.SelectionFont, FontStyle.Regular);
                    richTextBox2.SelectionColor = Color.Black;
                    fontsize2 = 16;
                    richTextBox2.Focus();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_delcard_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView_card.SelectedRows[0].Cells[0].Value);
            ir.open();
            ir.ExecuteNonQuery(String.Format("delete from card where id={0}", id));
            ir.close();
            button1.Enabled = false;
            Browse_Load(sender, e);
        }
    }
}
