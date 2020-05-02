using System;
using System.Linq;
using Jawilliam.CDF.Labs.VSIXProject.Models;
using Jawilliam.CDF.Labs.VSIXProject.Models.Impl;
using Jawilliam.CDF.Labs.VSIXProject.Services.Impl;
using Jawilliam.CDF.Labs.VSIXProject.ViewModels;
using Jawilliam.CDF.Labs.VSIXProject.Views.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Jawilliam.CDF.Labs.VSIXProject
{
    [TestClass]
    public class TestSolutionReviewExplorerViewModel
    {
        //public virtual SolutionReviewExplorerViewModel ViewModel { get; set; }

        //[TestInitialize]
        //public virtual void Initialize()
        //{
        //    CreateViewModel();
        //}

        protected virtual SolutionReviewExplorerViewModel CreateViewModel()
        {
            var model = new SolutionReviewExplorerModel();
            var service = new MockSolutionReviewExplorerService();
            var passiveView = new MockSolutionReviewExplorerPassiveView();
            return new SolutionReviewExplorerViewModel(model, service)
            {
                PassiveView = passiveView
            };
        }

        [TestMethod]
        public void IfSelectedDisagreedDeltaChanges_ClearLoadedDisagreedDelta_OK()
        {
            var vm = this.CreateViewModel();
            Assert.IsNull(vm.Model.SelectedDisagreedDelta);
            Assert.IsNull(vm.Model.LoadedDisagreedDelta);

            vm.Model.LoadedDisagreedDelta = new DisagreedDeltaContent();
            Assert.IsNull(vm.Model.SelectedDisagreedDelta);
            Assert.IsNotNull(vm.Model.LoadedDisagreedDelta);

            vm.Model.SelectedDisagreedDelta = new DisagreedDeltaDescriptor();
            Assert.IsNotNull(vm.Model.SelectedDisagreedDelta);
            Assert.IsNull(vm.Model.LoadedDisagreedDelta);
        }

        [TestMethod]
        public void IfNonCurrentDisagreedDelta_CannotStartReview()
        {
            var vm = this.CreateViewModel();
            Assert.IsFalse(vm.CanExecuteSubmitReviewCommand());
            Assert.IsFalse(vm.OnReview);
            Assert.IsFalse(vm.CanExecuteEndReviewCommand());

            vm.ExecuteListDisagreedDeltasCommand();
            Assert.IsTrue(vm.CanExecuteSubmitReviewCommand());
            Assert.IsFalse(vm.OnReview);
            Assert.IsFalse(vm.CanExecuteEndReviewCommand());

            //vm.Model =  vm.Model.DisagreedDeltas.Last();
            //vm.ExecuteListDisagreedDeltasCommand();
            //Assert.IsTrue(vm.CanExecuteStartReviewCommand());
            //Assert.IsFalse(vm.OnReview);
            //Assert.IsFalse(vm.CanExecuteEndReviewCommand());
        }
    }
}
