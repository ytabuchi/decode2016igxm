using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace XF_SalesDashboard.ViewModels
{
    public class StartPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public StartPageViewModel()
        {

            // TODO: 
            // https://forums.xamarin.com/discussion/60937/how-to-bind-a-command-to-listview-itemtapped
            // これを参考にタップしたListItemでAreaをサマライズした情報をAreaPageViewModelに渡したい
            this.GoToCommand = new Command(() =>
            {
                System.Diagnostics.Debug.WriteLine("GoToCommand Fired");

                // TODO: 
                // https://developer.xamarin.com/guides/cross-platform/xamarin-forms/messaging-center/
                // を参考にMessage CenterでViewModelからPageの移動を行う。
                // 
                // MessagingCenter.Send<StartPageViewModel, string>(this, "GoToAreaPage", "CommandParameterなどで取得");
            });
        }

        public ICommand GoToCommand { protected set; get; }
    }
}
