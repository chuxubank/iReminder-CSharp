using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iReminder
{
    public partial class ReviewCard : Form
    {
        DBConnection ir = new DBConnection();
        public int learntimes = 2;
        private DataTable dt = new DataTable();
        private int deck_id,i,max;
        public ReviewCard(int id)
        {
            deck_id = id;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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

        private void richTextBox2_Click(object sender, EventArgs e)
        {
            richTextBox2.Rtf = dt.Rows[i]["back"].ToString();
            richTextBox2.SelectAll();
            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
            int flag = 0;
            string str = dt.Rows[i]["tag"].ToString();
            string[] strs = { "编程", "算法", "代码" };
            foreach (string item in strs)
            {
                if (str.Contains(item))
                    flag = 1;
            }
            if (flag == 1)
            {
                richTextBox2.SelectionAlignment = HorizontalAlignment.Left;
            }
            richTextBox2.Select(0, 0);
        }

        /// <summary>  
        /// 从谷歌官方api获取发音并下载到本地，返回音频文件相对路径  
        /// </summary>  
        /// <param name="word">单词全拼</param>  
        /// <returns>返回音频文件相对路径</returns>  
        private static string makeMp3(string word)
        {
            try
            {
                string url = "http://translate.google.com/translate_tts?tl=en&q=" + word;
                string k = word.Substring(0, 1);
                string path = Directory.CreateDirectory("wordVolice/") + "\\" + k;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);//在根目录下建立文件夹   
                }
                string filename = path + "\\" + word + ".mp3";


                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                System.IO.Stream st = myrp.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    so.Write(by, 0, osize);
                    osize = st.Read(by, 0, (int)by.Length);
                }
                so.Close();
                st.Close();
                return "/wordVolice/" + k + "/" + word + ".mp3";
            }
            catch
            {
                return null;
            }
        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            ir.open();
            if ((int)dt.Rows[i]["state"] + 1 == learntimes)
                //Access 数据库的Date格式字段值必须由一对 # 符号标识，更新的时间前后都加#号
                ir.ExecuteNonQuery(String.Format("update card set state={0},donetime=#{1}# where id={2}", (int)dt.Rows[i]["state"] + 1, DateTime.Now.ToString("yyyy-MM-dd"), (int)dt.Rows[i]["id"]));
            else
                ir.ExecuteNonQuery(String.Format("update card set state={0} where id={1}", (int)dt.Rows[i]["state"]+1, (int)dt.Rows[i]["id"]));
            ir.close();
            show_next();
        }

        private void show_next()
        {
            if (i+1==max)
            {
                progressBar1.Value = i + 1;
                MessageBox.Show("背完了!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else
            {
                i++;
                progressBar1.Value = i;
                //makeMp3(richTextBox1.Text);
                richTextBox1.Rtf = dt.Rows[i]["front"].ToString();
                richTextBox2.Rtf = "";
                richTextBox2.Text = "单击以显示反面";
                richTextBox1.SelectAll();
                richTextBox2.SelectAll();
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
                richTextBox1.Select(0, 0);
                richTextBox2.Select(0, 0);
            }

        }

        private void btn_wrong_Click(object sender, EventArgs e)
        {
            show_next();
        }

        private void btn_right_MouseHover(object sender, EventArgs e)
        {
            btn_right.Image = global::iReminder.Properties.Resources.ok_hover;
        }

        private void btn_right_MouseLeave(object sender, EventArgs e)
        {
            btn_right.Image = global::iReminder.Properties.Resources.ok_normal;
        }

        private void btn_wrong_MouseHover(object sender, EventArgs e)
        {
            this.btn_wrong.Image = global::iReminder.Properties.Resources.cancel_hover;
        }

        private void btn_wrong_MouseLeave(object sender, EventArgs e)
        {
            this.btn_wrong.Image = global::iReminder.Properties.Resources.cancel_normal;
        }

        private void richTextBox2_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText); // call default browser  
        }

        private void btn_right_MouseEnter(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.btn_right, "会背了");
            p.SetToolTip(this.btn_wrong, "忘记了");
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatAppearance.BorderSize = 0;
        }

        private void ReviewCard_Load(object sender, EventArgs e)
        {
            i = 0;
            SetBtnStyle(button1);
            SetBtnStyle(btn_right);
            SetBtnStyle(btn_wrong);
            ir.open();
            int issieve = (int)ir.SelectToObject(String.Format("select count(sieve) from deck where id={0}", deck_id));
            if (issieve == 1)
            {
                string sieve_str = (string)ir.SelectToObject(String.Format("select sieve from deck where id={0}", deck_id));
                //处理标签
                HashSet<string> tagset = new HashSet<string>();
                string tagstr = sieve_str;
                string[] tagarray = tagstr.Split(' ');
                foreach (string tag in tagarray)
                {
                    tagset.Add(tag);
                }
                string sqltegsieve = "";
                foreach (string tag in tagset)
                {
                    sqltegsieve += " and tag like '%" + tag + "%'";
                }
                dt = ir.SelectToDataTable("select * from card where donetime is null" + sqltegsieve);
            }
            else
                dt = ir.SelectToDataTable(String.Format("select * from card where decknum={0} and donetime is null", deck_id));
            ir.close();
            max = dt.Rows.Count;
            progressBar1.Maximum = max;
            progressBar1.Value = 0;

            richTextBox1.Rtf = dt.Rows[0]["front"].ToString();
            richTextBox2.Rtf = "";
            richTextBox2.Text = "单击以显示反面";
            richTextBox1.SelectAll();
            richTextBox2.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.Select(0, 0);
            richTextBox2.Select(0, 0);
        }
    }
}
