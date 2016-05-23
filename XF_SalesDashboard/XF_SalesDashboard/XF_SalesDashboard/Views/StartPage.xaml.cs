using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XF_SalesDashboard.Views
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            var data = new List<Models.SummaryModel>()
            {
                new Models.SummaryModel { Item = "東地区", Value = 6d },
                new Models.SummaryModel { Item = "西地区", Value = 6d },
                new Models.SummaryModel { Item = "南地区", Value = 6d },
                new Models.SummaryModel { Item = "北地区", Value = 6d },
            };

            this.BindingContext = data;
        }

        async void listItemTapped(object sender, ItemTappedEventArgs e)
        {
            listView.SelectedItem = null;
            await Navigation.PushAsync(new AreaPage());
        }

    }
}
