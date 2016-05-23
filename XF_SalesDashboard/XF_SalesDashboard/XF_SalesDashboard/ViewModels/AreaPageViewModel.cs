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
    public class AreaPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private List<SummaryModel> _salesData;
        public List<SummaryModel> SalesData
        {
            get { return _salesData; }
            set
            {
                if (_salesData != value)
                {
                    _salesData = value;
                    OnPropertyChanged();
                }
            }
        }

        private List<SummaryModel> _categoryData;
        public List<SummaryModel> CategoryData
        {
            get { return _categoryData; }
            set
            {
                if (_categoryData != value)
                {
                    _categoryData = value;
                    OnPropertyChanged();
                }
            }
        }

        private List<SummaryModel> _segmentData;
        public List<SummaryModel> SegmentData
        {
            get { return _segmentData; }
            set
            {
                if (_segmentData != value)
                {
                    _segmentData = value;
                    OnPropertyChanged();
                }
            }
        }



        public AreaPageViewModel()
        {
            Init();
            System.Diagnostics.Debug.WriteLine("【Constructor】AreaPageViewModel");
        }

        public void Init()
        {
            SingletonSalesClass.Instance.PropertyChanged += Instance_PropertyChanged;

            this.SalesData = SingletonSalesClass.Instance.GetSales();
            this.CategoryData = SingletonSalesClass.Instance.GetSalesbyCategories();
            this.SegmentData = SingletonSalesClass.Instance.GetSalesbySegments();
        }

        private void Instance_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SingletonSalesClass.SalesData))
            {
                this.SalesData = SingletonSalesClass.Instance.GetSales();
                this.CategoryData = SingletonSalesClass.Instance.GetSalesbyCategories();
                this.SegmentData = SingletonSalesClass.Instance.GetSalesbySegments();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
