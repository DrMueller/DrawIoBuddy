using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.DrawIoBuddy.WpfUI.Areas.Uml.ClassFromMetaData.ViewModels
{
    /// <summary>
    /// Interaction logic for ClassFromMetaDataView.xaml
    /// </summary>
    public partial class ClassFromMetaDataView : UserControl, IViewMap<ClassFromMetaDataViewModel>
    {
        public ClassFromMetaDataView()
        {
            InitializeComponent();
        }
    }
}