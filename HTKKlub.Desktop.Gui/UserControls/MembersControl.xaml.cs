using HTKKlub.Desktop.Gui.ViewModels;
using HTKKlub.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HTKKlub.Desktop.Gui.UserControls
{
    /// <summary>
    /// Interaction logic for MembersControl.xaml
    /// </summary>
    public partial class MembersControl: UserControl
    {
        private readonly MemberViewModel viewModel;
        private bool isLoaded = false;

        public MembersControl()
        {
            InitializeComponent();
            viewModel = DataContext as MemberViewModel;
        }

        /// <summary>
        /// Initializes the viewModel when the view has been loaded, and prevents reinitialization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!isLoaded)
                {
                    isLoaded = true;
                    await viewModel.InitializeAsync();
                }
            }
            //Writes a message to the logger if an exception is caught while loading
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Der opstod en fejl.", MessageBoxButton.OK, MessageBoxImage.Error);
                await Logger.LogAsync(ex);
            }
        }
    }
}