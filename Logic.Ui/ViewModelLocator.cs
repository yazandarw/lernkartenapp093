using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.ClientApp093.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp093.Logic.Ui.Wrapper;

namespace De.HsFlensburg.ClientApp093.Logic.Ui
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowVM { get; }
        public PdfExportWindowViewModel PDFExportVM { get; }
        public BoxViewModel MyBoxVM { get; set; }
        public BoxCollectionViewModel MyCollectionVM { get; set; }

        public ViewModelLocator()
        {
            MainWindowVM = new MainWindowViewModel();
            MyBoxVM = new BoxViewModel();
            MyBoxVM = MainWindowVM.GetAllCards();
            PDFExportVM = new PdfExportWindowViewModel(MyBoxVM);
            MyCollectionVM = new BoxCollectionViewModel();
            MyCollectionVM = MainWindowVM.GetCollection();
        }
    }
}
