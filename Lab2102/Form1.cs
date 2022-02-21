using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2102
{
    public partial class Form1 : Form
    {
        string line ="";
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                XORCip x = new XORCip();
                var enc = x.Encrypt(line, textBox2.Text);
                StreamWriter sw = new StreamWriter(@"C:\Users\student\source\repos\Lab2102\Lab2102\pri.txt");
                sw.WriteLine(enc);
                sw.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            textBox1.Text = open.FileName;
            StreamReader sr = new StreamReader(open.FileName);
            line = sr.ReadToEnd();
            //while (line != null)
            //{
            //    line = sr.ReadLine();
            //}
            sr.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        
    }

    public class XORCip
    {
        private string GetRepeatKey(string s, int n)
        {
            var r = s;
            while (r.Length < n)
            {
                r += r;
            }
            return r.Substring(0, n);
        }

        private string Cipher(string text, string secretKey)
        {
            var currentKey = GetRepeatKey(secretKey, text.Length);
            var res = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                res += ((char)(text[i] ^ currentKey[i])).ToString();
            }
            return res;
        }

        public string Encrypt(string plainText, string password)
            => Cipher(plainText, password);
        public string Decrypt(string encryptedText, string password)
            => Cipher(encryptedText, password);
    }
}
