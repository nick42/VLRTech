using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyEvent.X
{
    public partial class MasterNavigationContentPage : ContentPage
    {
        // from XAML...
        //public ListView oListView_NagivationElements { get; } = new ListView();

        public MasterNavigationContentPage()
        {
            InitializeComponent();

            var oMasterPageItems = new List<MasterNavigationContentPageItem>();

            oMasterPageItems.Add(new MasterNavigationContentPageItem
            {
                Title = "Current Event",
                IconSource = "event.png",
                TargetType = typeof(MainPage),
            });

            oListView_NagivationElements.ItemsSource = oMasterPageItems;
        }
    }
}
