using De.HsFlensburg.ClientApp093.Logic.Ui.Wrapper;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using System.Windows;

namespace De.HsFlensburg.ClientApp093.Logic.Ui.ViewModels
{
    public class PdfExportWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public RelayCommand ExportAsPDF { get; set; }

        private bool withAnswers;
        public bool IsWithAnswers
        {
            get
            {
                return withAnswers;
            }
            set
            {
                withAnswers = value;
                OnPropertyChanged("IsWithAnswers");
            }
        }
        private bool withoutAnswers;
        public bool IsWithoutAnswers
        {
            get
            {
                return withoutAnswers;
            }
            set
            {
                withoutAnswers = value;
                OnPropertyChanged("IsWithoutAnswers");
            }
        }
        public BoxViewModel SelectedCardsList { get; set; }

        public PdfExportWindowViewModel(BoxViewModel boxVM)
        {
            SelectedCardsList = boxVM;
            ExportAsPDF = new RelayCommand(() => ExportAsPDFMethod());
        }

        private void ExportAsPDFMethod()
        {
            if (IsWithAnswers || IsWithoutAnswers)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                saveFile.Filter = "pdf files (*.pdf)|*.pdf";
                var listCards = SelectedCardsList.Where(x => x.IsSelected == true)?.ToList();

                if (listCards.Count > 0 && saveFile.ShowDialog() == true)
                {
                    FileStream fs = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                    Rectangle backGround = new Rectangle(PageSize.A4);
                    backGround.BackgroundColor = new Color(244, 244, 244);
                    var doc1 = new Document(backGround);

                    PdfWriter writer = PdfWriter.GetInstance(doc1, fs);
                    BaseFont bf1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                    Font times = new Font(bf1, 12, Font.BOLD, new Color(22, 96, 136));

                    doc1.Open();
                    Rectangle rec = new Rectangle(0f, 720f, 600f, 900f);
                    rec.BackgroundColor = new Color(110, 156, 181);
                    doc1.Add(rec);

                    int count = 0;
                    int size = listCards.Count;
                    if (size == 1)
                    {
                        Rectangle reccc = new Rectangle(60f, 670f, 525f, 210f);
                        reccc.BackgroundColor = new Color(255, 255, 255);
                        doc1.Add(reccc);

                        string str = listCards[count].Name;
                        Paragraph Titel = new Paragraph(str, times);
                        Titel.Font.Size = 50;
                        Titel.SetAlignment("Center");
                        Titel.SpacingBefore = 160f;

                        Paragraph paragraph = new Paragraph();
                        paragraph.Font.Size = 25;
                        paragraph.SpacingBefore = 40f;
                        paragraph.IndentationLeft = 40f;
                        paragraph.IndentationRight = 40f;
                        paragraph.Leading = 35f;
                        paragraph.SetAlignment("Center");

                        Chunk chunkQ = new Chunk("Q: ");
                        Chunk chunkA = new Chunk("A: ");
                        paragraph.Add(chunkQ + listCards[count].Title + "\n \n");

                        if (IsWithAnswers)
                        {
                            paragraph.Add(chunkA + listCards[count].Content);
                        }
                        doc1.Add(Titel);
                        doc1.Add(paragraph);
                    }
                    else
                    {
                        float BgCard = 0f;
                        foreach (var card in listCards)
                        {
                            if (count > 0 && count % 2 == 0)
                            {
                                doc1.NewPage();
                                BgCard = 0f;
                            }
                            Rectangle recF = new Rectangle(60f, 670f - BgCard, 525f, 450f - BgCard);
                            recF.BackgroundColor = new Color(255, 255, 255);
                            doc1.Add(recF);
                            string strF = listCards[count].Name;
                            Paragraph TitelF = new Paragraph(strF, times);
                            TitelF.Font.Size = 30;
                            TitelF.SetAlignment("Center");
                            TitelF.SpacingBefore = 160f;

                            Paragraph paragraphF = new Paragraph();
                            paragraphF.SpacingBefore = 30f;
                            paragraphF.IndentationLeft = 40f;
                            paragraphF.IndentationRight = 40f;
                            paragraphF.Leading = 18f;
                            paragraphF.SetAlignment("Center");

                            Chunk chunk1 = new Chunk("Q: ");
                            Chunk chunk2 = new Chunk("A: ");

                            paragraphF.Add(chunk1 + listCards[count].Title + "\n \n");
                            if (IsWithAnswers)
                            {
                                paragraphF.Add(chunk2 + listCards[count].Content);
                                BgCard = 290f;
                            }
                            else
                            {
                                BgCard = 270f;
                            }
                            doc1.Add(TitelF);
                            doc1.Add(paragraphF);
                            count++;
                        }
                    }
                    doc1.Close();
                }
                else
                {
                    MessageBox.Show("Please choose the card or cards that you want to export!");
                }
            } 
            else
            {
                MessageBox.Show("Please choose if you want the cards with or without answers!");
            }
        }
    }
}
