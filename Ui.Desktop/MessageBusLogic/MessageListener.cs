using De.HsFlensburg.ClientApp093.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp093.Services.MessageBus;

namespace De.HsFlensburg.ClientApp093.Ui.Desktop.MessageBusLogic
{
    public class MessageListener
    {
        public bool BindableProperty => true;
        public MessageListener()
        {
            InitMessenger();
        }
        private void InitMessenger()
        {
            ServiceBus.Instance.Register<OpenPdfExportWindowMessage>(this, delegate ()
            {
                PdfExportWindow myPdfExportWindow = new PdfExportWindow();
                myPdfExportWindow.ShowDialog();
            });
        }
    }
}
