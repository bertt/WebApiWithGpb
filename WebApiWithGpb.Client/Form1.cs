using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

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
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-protobuf"));
            var result = await client.GetStringAsync("http://localhost:53833/api/persons");
            


            // try to deserialize
            MessageBox.Show(result);
        }
    }
}
