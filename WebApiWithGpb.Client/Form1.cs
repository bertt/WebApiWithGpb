using System;
using System.Windows.Forms;
using WebApiWithGpb.Core;

namespace WebApiWithGpb.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var url = new Uri("http://localhost:53833/api/");
            var client = new SuperClient(url, "username", "password");
            var persons = await client.GetPersons();
            var p = persons.Count;
            MessageBox.Show("number of persons: " + p);
        }
    }
}
