using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XF_SalesDashboard.Models;

namespace XF_SalesDashboard.ViewModels
{
    public class AreaPageViewModel // : INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;


        public List<SummaryModel> SalesData { get; set; }

        public List<SummaryModel> CategoryData { get; set; }

        public List<SummaryModel> SegmentData { get; set; }



        public AreaPageViewModel()
        {
            Init();
            System.Diagnostics.Debug.WriteLine("【Constructor】AreaPageViewModel");
        }

        public async void Init()
        {
            //await Models.SingletonSalesClass.Instance.Initialize();
           
            this.SalesData = await SingletonSalesClass.Instance.GetSalesAsync();
            this.CategoryData = await SingletonSalesClass.Instance.GetSalesbyCategoriesAsync();
            this.SegmentData = await SingletonSalesClass.Instance.GetSalesbySegmentsAsync();
        }


        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
    }
}
