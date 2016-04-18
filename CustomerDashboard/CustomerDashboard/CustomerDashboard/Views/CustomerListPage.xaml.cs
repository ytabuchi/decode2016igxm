using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;


namespace CustomerDashboard.Views
{
    public partial class CustomerListPage : ContentPage
    {
        Models.CustomerJson data = new Models.CustomerJson();

        public CustomerListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var assembly = typeof(CustomerListPage).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("CustomerDashboard.CustomerData.json");
            string text = "";

            using (var reader = new StreamReader(stream))
            {
                text = await reader.ReadToEndAsync();
                data = JsonConvert.DeserializeObject<Models.CustomerJson>(text);
            }

            this.BindingContext = data.Customers;

        }
    }
}
