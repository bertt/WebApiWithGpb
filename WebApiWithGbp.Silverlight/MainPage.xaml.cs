using System;
using System.Windows;
using WebApiWithGpb.Core;

namespace WebApiWithGbp.Silverlight
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void buttonProtobuf(object sender, RoutedEventArgs e)
        {
            var url = new Uri("http://localhost:53833/api/");
            var client = new SuperClient(url, "username", "password");
            var persons = await client.GetPersons();
            var p = persons.Count;
            MessageBox.Show("number of persons: " + p);
        }
    }
}
