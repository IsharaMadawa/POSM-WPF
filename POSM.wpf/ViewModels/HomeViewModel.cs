using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSM.wpf.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        //public AssetSummaryViewModel AssetSummaryViewModel { get; }
        //public MajorIndexListingViewModel MajorIndexListingViewModel { get; }

        public HomeViewModel()
        {
            //AssetSummaryViewModel = assetSummaryViewModel;
            //MajorIndexListingViewModel = majorIndexListingViewModel;
        }

        public override void Dispose()
        {
            //AssetSummaryViewModel.Dispose();
            //MajorIndexListingViewModel.Dispose();

            base.Dispose();
        }
    }
}
