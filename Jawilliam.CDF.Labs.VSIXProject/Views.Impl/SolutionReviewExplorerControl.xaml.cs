namespace Jawilliam.CDF.Labs.VSIXProject.Views.Impl
{
    using Jawilliam.CDF.Labs.VSIXProject.ViewModels;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for SolutionReviewExplorerControl.
    /// </summary>
    public partial class SolutionReviewExplorerControl : UserControl, ISolutionReviewExplorerPassiveView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionReviewExplorerControl"/> class.
        /// </summary>
        public SolutionReviewExplorerControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
                "SolutionReviewExplorer");
        }

        private void DockPanel_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue is SolutionReviewExplorerViewModel)
                ((SolutionReviewExplorerViewModel)e.OldValue).PassiveView = null;

            if (e.NewValue is SolutionReviewExplorerViewModel)
                ((SolutionReviewExplorerViewModel)e.NewValue).PassiveView = this;
        }

        /// <summary>
        /// Requests that the given object must be shown in the properties window.
        /// </summary>
        /// <param name="source">object to show in the properties windows.</param>
        public virtual void ShowProperties(object source)
        {
            throw new System.NotImplementedException();
        }
    }
}