using System.Threading.Tasks;
using System.Xml.Linq;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.Strings.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;

namespace Mmu.DrawIoBuddy.WpfUI.Areas.Decoding.ViewModels
{
    public class CommandContainer : IViewModelCommandContainer<DecodingViewModel>
    {
        private DecodingViewModel _context;
        public CommandsViewData Commands { get; private set; }
        public string Text { get; private set; }

        private ViewModelCommand Decode
        {
            get
            {
                return new ViewModelCommand(
                    "Decode",
                    new RelayCommand(() => _context.DecodedText = new DrawIoString(_context.EncodedText).DecodeString()));
            }
        }

        private ViewModelCommand Encode
        {
            get
            {
                return new ViewModelCommand(
                    "Encode",
                    new RelayCommand(() => _context.EncodedText = new DrawIoString(_context.DecodedText).EncodeString()));
            }
        }

        private ViewModelCommand SaveAsXml
        {
            get
            {
                return new ViewModelCommand(
                    "Save as XML",
                    new RelayCommand(() =>
                    {
                        var doc = XDocument.Parse(_context.DecodedText);
                        doc.Save(@"C:\Users\Matthias\Desktop\Work\Tra.xml");
                    }));
            }
        }

        public Task InitializeAsync(DecodingViewModel context)
        {
            _context = context;

            Commands = new CommandsViewData(
                Decode,
                Encode,
                SaveAsXml);

            return Task.CompletedTask;
        }
    }
}