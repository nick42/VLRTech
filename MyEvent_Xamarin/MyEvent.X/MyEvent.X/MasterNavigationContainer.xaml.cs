using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyEvent.X
{
    public partial class MasterNavigationContainer : MasterDetailPage
    {
        //MasterNavigationContentPage oPage_MasterNaviationContent;

        public MasterNavigationContainer()
        {
            InitializeComponent();

            //oPage_MasterNaviationContent = new MasterNavigationContentPage();
            //Master = oPage_MasterNaviationContent;

            MasterBehavior = MasterBehavior.Popover;
        }
    }
}
