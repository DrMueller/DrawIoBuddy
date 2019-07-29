using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.DrawIoBuddy.WpfUI.Areas.Uml.Components.ViewModels
{
    public partial class ComponentsView : UserControl, IViewMap<ComponentsViewModel>
    {
        public ComponentsView()
        {
            InitializeComponent();
        }
    }
}