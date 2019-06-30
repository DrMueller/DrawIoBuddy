using System.Threading.Tasks;
using Mmu.DrawIoBuddy.DomainServices.Areas.SqlMetaData.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;

namespace Mmu.DrawIoBuddy.WpfUI.Areas.Uml.ClassFromMetaData.ViewModels
{
    public class CommandContainer : IViewModelCommandContainer<ClassFromMetaDataViewModel>
    {
        private readonly ISqlMetaDataTransformer _transformer;
        private ClassFromMetaDataViewModel _context;
        public CommandsViewData Commands { get; private set; }
        public string Text { get; private set; }

        private ViewModelCommand Create
        {
            get
            {
                return new ViewModelCommand(
                    "Create",
                    new RelayCommand(() =>
                    {
                        _context.DrawIoOutput = _transformer.Transform(_context.MetaData);
                    }));
            }
        }

        public CommandContainer(ISqlMetaDataTransformer transformer)
        {
            _transformer = transformer;
        }

        public Task InitializeAsync(ClassFromMetaDataViewModel context)
        {
            _context = context;
            Commands = new CommandsViewData(Create);

            return Task.CompletedTask;
        }
    }
}