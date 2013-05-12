using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using ProtoBuf;
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
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-protobuf"));
            var stream = await client.GetStreamAsync("http://localhost:53833/api/persons");
            
            // try to deserialize
            var result = Serializer.Deserialize<List<Person>>(stream);

            MessageBox.Show("number of persons: " +  result.Count().ToString());
        }
    }
}
