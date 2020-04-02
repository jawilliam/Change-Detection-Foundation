using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Jawilliam.CDF.Labs.VSIXProject.Models;
using Jawilliam.CDF.Labs.VSIXProject.Models.Impl;
using Jawilliam.CDF.Labs.VSIXProject.Services;
using Jawilliam.CDF.Labs.VSIXProject.Services.Impl;
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

            SimpleIoc.Default.Register<SolutionReviewExplorerViewModel>();

            //SimpleIoc.Default.Register(NewSolutionReviewExplorerModel);
            //SimpleIoc.Default.Register(NewSolutionReviewExplorerService);

            SimpleIoc.Default.Register<ISolutionReviewExplorerModel, MockSolutionReviewExplorerModel>();
            SimpleIoc.Default.Register<ISolutionReviewExplorerService, MockSolutionReviewExplorerService>();

            //SimpleIoc.Default.Register<IDialogService, DialogService>();
            //SimpleIoc.Default.Register<INavigationService, NavigationService>();
            //SimpleIoc.Default.Register(NewSolutionReviewExplorerService);
        }

        /// <summary>
        /// Creates a new <see cref="ISolutionReviewExplorerModel"/> instance.
        /// </summary>
        /// <returns>returns a fresh <see cref="ISolutionReviewExplorerModel"/> instance.</returns>
        protected virtual ISolutionReviewExplorerModel NewSolutionReviewExplorerModel()
        {
            return new SolutionReviewExplorerModel();
        }

        /// <summary>
        /// Creates a new <see cref="ISolutionReviewExplorerService"/> instance.
        /// </summary>
        /// <returns>returns a fresh <see cref="ISolutionReviewExplorerService"/> instance.</returns>
        protected virtual ISolutionReviewExplorerService NewSolutionReviewExplorerService()
        {
            return new SolutionReviewExplorerService();
        }
    }
}
