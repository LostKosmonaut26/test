using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TestJWT
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var data = new { username = textBox1.Text, password = textBox2.Text };
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var resp = await client.PostAsync("http://127.0.0.1:5000/login", content);

            var responseBody = await resp.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseBody);
            label1.Text = result.access_token;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            button3.Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            button3.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "1")
            {
                MessageBox.Show("1");
            }
            else if (comboBox1.SelectedItem.ToString() == "2")
            {
                MessageBox.Show("2");
            }
        }
    }
}
