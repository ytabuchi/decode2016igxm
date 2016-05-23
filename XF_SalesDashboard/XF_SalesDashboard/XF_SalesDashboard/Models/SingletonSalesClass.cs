using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XF_SalesDashboard.Models
{
    public class SingletonSalesClass
    {
        static readonly string EndPoint = @"http://jxug.org/SalesData.json";

        /// <summary>
        /// たった一つのインスタンス
        /// </summary>
        public static SingletonSalesClass Instance { get; } = new SingletonSalesClass();

        private List<SalesModel> _salesData = new List<SalesModel>();

        /// <summary>
        /// インスタンスが一つきりであることを保証するためコンストラクタは隠ぺいする
        /// </summary>
        private SingletonSalesClass()
        {

        }

        /// <summary>
        /// 初期化メソッド
        /// </summary>
        public Task Initialize()
        {
            System.Diagnostics.Debug.WriteLine("【SingletonSalesClass.Instance.Initialize()】");
            return Task.Run(async () =>
            {
                using (var client = new HttpClient())
                {
                    using (var reader = new StreamReader(await client.GetStreamAsync(EndPoint)))
                    {
                        var json = await reader.ReadToEndAsync();
                        this._salesData = JsonConvert.DeserializeObject<List<SalesModel>>(json);
                    }
                }
            });
        }

        public Task<List<SummaryModel>> GetSalesAsync()
        {
            return Task.Run(() =>
            {
                return this._salesData
                    .GroupBy(x => x.StoreName)
                    .Select(x => new SummaryModel
                    {
                        Item = x.Key,
                        Value = x.Sum(y => y.Sales)
                    }).ToList();

            });
        }

        public Task<List<SummaryModel>> GetSalesbyCategoriesAsync()
        {
            return Task.Run(() =>
            {
                return this._salesData
                    .GroupBy(x => x.Category)
                    .Select(x => new SummaryModel
                    {
                        Item = x.Key,
                        Value = x.Sum(y => y.Sales)
                    }).ToList();

            });
        }

        public Task<List<SummaryModel>> GetSalesbySegmentsAsync()
        {
            return Task.Run(() =>
            {
                return this._salesData
                    .GroupBy(x => x.Segment.Contains("M") ? "男性" : "女性")
                    .Select(x => new SummaryModel
                    {
                        Item = x.Key,
                        Value = x.Sum(y => y.Sales)
                    }).ToList();

            });
        }
    }
}
