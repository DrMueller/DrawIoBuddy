using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.DrawIoBuddy.WpfUI.Areas.Decoding.ViewModels
{
    /// <summary>
    /// Interaction logic for DecodingView.xaml
    /// </summary>
    public partial class DecodingView : UserControl, IViewMap<DecodingViewModel>
    {
        public DecodingView()
        {
            InitializeComponent();
        }
    }
}