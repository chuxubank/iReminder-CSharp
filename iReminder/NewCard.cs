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
    public partial class NewCard : Form
    {
        private string deck_name;
        DBConnection ir = new DBConnection();
        public NewCard(string deck_name)
        {
            this.deck_name = deck_name;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                MessageBox.Show("请先选择卡组！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (richTextBox1.Text == "" || richTextBox2.Text == "")
                MessageBox.Show("请先输入内容！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                ir.open();
                string time = DateTime.Now.ToString("yyyy-MM-dd");
                string sql = "insert into card (FRONT,BACK,CREATTIME,STATE,DECKNUM,TAG) values(?,?,?,?,?,?)";
                OleDbParameter[] parameters = new OleDbParameter[]
                {
                    new OleDbParameter("FRONT",richTextBox1.Rtf),
                    new OleDbParameter("BACK",richTextBox2.Rtf),
                    new OleDbParameter("CREATTIME",time),
                    new OleDbParameter("STATE","0"),
                    new OleDbParameter("DECKNUM",comboBox1.SelectedValue),
                    new OleDbParameter("TAG",textBox1.Text),
                };
                ir.ExecuteSql(sql, parameters);
                ir.close();
            }
            richTextBox1.Text = "";
            richTextBox2.Text = "";
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

        private void NewCard_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“iReminderDataSet_deck.deck”中。您可以根据需要移动或删除它。
            this.deckTableAdapter.Fill(this.iReminderDataSet_deck.deck);
            comboBox1.Text = deck_name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

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
    }
}
