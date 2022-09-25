using System;
using System.Windows;
using De.HsFlensburg.ClientApp093.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp093.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp093.Services.MessageBus;

namespace De.HsFlensburg.ClientApp093.Logic.Ui.ViewModels
{
    public class MainWindowViewModel
    {
        public string CardName { get; set; }
        public string CardTitel { get; set; }
        public string CardContent { get; set; }
        public RelayCommand AddCard { get; }
        public RelayCommand DelCard { get; }
        public RelayCommand ResetCards { get; }
        public CardViewModel SelectedCard { get; set; }
        public string BoxName { get; set; }
        public string BoxCategory { get; set; }
        public RelayCommand AddBox { get; }
        public RelayCommand DelBox { get; }
        public RelayCommand ResetBoxes { get; }
        public BoxViewModel SelectedBox { get; set; }
        public BoxViewModel AllCards { get; set; }
        public BoxCollectionViewModel MyCollectionOfBoxes { get; set; }
        public RelayCommand OpenPDFExportWindowMessage { get; }
        public RelayCommand OpenXMLWindowMessage { get; }

        public MainWindowViewModel()
        {
            AddCard = new RelayCommand(() => AddCardMethod());
            DelCard = new RelayCommand(() => DeleteCard(SelectedCard));
            ResetCards = new RelayCommand(() => ClearCardsInBox());
            AddBox = new RelayCommand(() => AddBoxMethod());
            DelBox = new RelayCommand(() => DeleteBox(SelectedBox));
            ResetBoxes = new RelayCommand(() => ClearBoxes());
            OpenPDFExportWindowMessage = new RelayCommand(() => OpenPDFExportWindowMessageMethod());

            MyCollectionOfBoxes = new BoxCollectionViewModel();
            AllCards = new BoxViewModel();
            SelectedBox = new BoxViewModel();
            SelectedBox.Name = "";
            BoxName = "";
            BoxCategory = "";
            CardName = "";
            CardTitel = "";
            CardContent = "";

            BoxViewModel myBox1 = new BoxViewModel();
            myBox1.Name = "Box 1";
            myBox1.Category = "Geography";
            CardViewModel card1 = new CardViewModel();
            card1.Name = "Card 1";
            card1.Title = " What is the capital of Chile?";
            card1.Content = "Santiago";
            myBox1.Add(card1);
            AllCards.Add(card1);
            CardViewModel card2 = new CardViewModel();
            card2.Name = "Card 2";
            card2.Title = "What is the smallest country in the world?";
            card2.Content = "Vatican City";
            myBox1.Add(card2);
            AllCards.Add(card2);
            BoxViewModel myBox2 = new BoxViewModel();
            myBox2.Name = "Box 2";
            myBox2.Category = "Economy";
            CardViewModel card3 = new CardViewModel();
            card3.Name = "Card 3";
            card3.Title = "What is the currency of Brazil?";
            card3.Content = "Brazilian Real";
            myBox2.Add(card3);
            AllCards.Add(card3);
            MyCollectionOfBoxes.Add(myBox1);
            MyCollectionOfBoxes.Add(myBox2);
        }
        private void AddCardMethod()
        {
            if (SelectedBox.Name == "")
            {
                MessageBox.Show("Select a box to be able to create the card in it, please");
            }
            else if (CardName != "" && CardTitel != "" && CardContent != "")
            {
                CardViewModel newCard = new CardViewModel();
                newCard.Name = CardName;
                newCard.Title = CardTitel;
                newCard.Content = CardContent;
                SelectedBox.Add(newCard);
                AllCards.Add(newCard);
            }
            else
            {
                MessageBox.Show("Please choose a name for the card and add a question and answer");
            }
        }
        private void AddBoxMethod()
        {
            if (BoxName != "" && BoxCategory != "")
            {
                BoxViewModel boxVM = new BoxViewModel();
                boxVM.Name = BoxName;
                boxVM.Category = BoxCategory;
                MyCollectionOfBoxes.Add(boxVM);
            }
            else
            {
                MessageBox.Show("Please choose a name and category for the box");
            }
        }
        private void DeleteCard(CardViewModel card)
        {
            try
            {
                AllCards.Remove(card);
                SelectedBox.Remove(card);
            }
            catch (Exception e)
            {
                MessageBox.Show("The card is not deleted\n" + e);
            }
        }
        private void ClearBoxes()
        {
            try
            {
                MyCollectionOfBoxes.Clear();
                AllCards.Clear();
            }
            catch (Exception e)
            {
                MessageBox.Show("The boxes are not reset\n" + e);
            }
        }
        private void ClearCardsInBox()
        {
            try
            {
                for (var index1 = AllCards.Count - 1; index1 >= 0; index1--)
                {
                    for (var index2 = 0; index2 < SelectedBox.Count; index2++)
                    {
                        if (AllCards[index1].Name == SelectedBox[index2].Name)
                        {
                            AllCards.RemoveAt(index1);
                            SelectedBox.RemoveAt(index2);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("The cards are not reset\n" + e);
            }
        }
        private void DeleteBox(BoxViewModel selected)
        {
            try
            {
                for (var index1 = AllCards.Count - 1; index1 >= 0; index1--)
                {
                    for (var index2 = 0; index2 < selected.Count; index2++)
                    {
                        if (AllCards[index1].Name == selected[index2].Name)
                        {
                            AllCards.RemoveAt(index1);
                            selected.RemoveAt(index2);
                        }
                    }
                }
                MyCollectionOfBoxes.Remove(selected);
            }
            catch (Exception e)
            {
                MessageBox.Show("The box is not deleted\n" + e);
            }
        }
        internal BoxCollectionViewModel GetCollection()
        {
            return MyCollectionOfBoxes;
        }
        internal BoxViewModel GetAllCards()
        {
            return AllCards;
        }
        private void OpenPDFExportWindowMessageMethod()
        {
            ServiceBus.Instance.Send(new OpenPdfExportWindowMessage());
        }
    }
}
