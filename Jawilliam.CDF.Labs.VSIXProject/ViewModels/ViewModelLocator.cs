using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs.VSIXProject.ViewModels
{
    public class ViewModelLocator
    {
        public SolutionReviewExplorerViewModel SolutionReviewExplorer
            => SimpleIoc.Default.GetInstance<SolutionReviewExplorerViewModel>();

        public ViewModelLocator()
        {
            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            //}
            //else
            //{
            //    SimpleIoc.Default.Register<IDataService, DataService>();
            //}

            //SimpleIoc.Default.Register<IDialogService, DialogService>();
            //SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<SolutionReviewExplorerViewModel>();
        }
    }
}
