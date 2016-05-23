using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XF_SalesDashboard.Views
{
    public partial class AreaPage : ContentPage
    {
        ViewModels.AreaPageViewModel vm;

        public AreaPage()
        {
            InitializeComponent();
            vm = new ViewModels.AreaPageViewModel();


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //var testSalesData = vm.SalesData;
            //foreach (var x in testSalesData)
            //{
            //    System.Diagnostics.Debug.WriteLine($"Item:{x.Item}, Value:{x.Value}");
            //}
            //var testCategoryData = vm.CategoryData;
            //foreach (var x in testCategoryData)
            //{
            //    System.Diagnostics.Debug.WriteLine($"Item:{x.Item}, Value:{x.Value}");
            //}
            //var testSegmentData = vm.SegmentData;
            //foreach (var x in testSegmentData)
            //{
            //    System.Diagnostics.Debug.WriteLine($"Item:{x.Item}, Value:{x.Value}");
            //}

            var salesData = new List<Models.SummaryModel>()
            {
                new Models.SummaryModel { Item = "A", Value = 1000d },
                new Models.SummaryModel { Item = "B", Value = 1500d },
                new Models.SummaryModel { Item = "C", Value = 1200d },
            };

            var categoryData = new List<Models.SummaryModel>()
            {
                new Models.SummaryModel { Item = "A", Value = 1000d },
                new Models.SummaryModel { Item = "B", Value = 1500d },
                new Models.SummaryModel { Item = "C", Value = 1200d },
            };

            var segmentData = new List<Models.SummaryModel>()
            {
                new Models.SummaryModel { Item = "男性", Value = 45d },
                new Models.SummaryModel { Item = "女性", Value = 55d }
            };

            listView.BindingContext = /*salesData;*/  vm.SalesData;
            dataChart.BindingContext = categoryData;  // vm.CategoryData;
            //pieChart.BindingContext = segmentData;  // vm.SegmentData;
        }
    }
}
