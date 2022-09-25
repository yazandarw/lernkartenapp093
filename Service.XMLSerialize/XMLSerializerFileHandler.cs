using De.HsFlensburg.ClientApp093.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace De.HsFlensburg.ClientApp093.Service.XMLSerialize
{
    public class XMLSerializerFileHandler
    {
        public static void SaveFile(BoxCollection myBoxCollection, string path)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XElement root = new XElement("BoxCollection");
                foreach (var item in myBoxCollection)
                {
                    XElement newBox = new XElement("Box", new XAttribute("Name", item.Name), new XAttribute("Category", item.Category));

                    foreach (var box in item)
                    {
                        XElement card = new XElement("Card",
                        new XAttribute("Name", box.Name),
                        new XElement("Title", box.Title),
                        new XElement("Content", box.Content),
                        new XElement("Learned", box.Learned));
                        newBox.Add(card);
                    }
                    root.Add(newBox);
                }
                root.Save(path);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static BoxCollection LoadFile(string path)
        {
            BoxCollection items = new BoxCollection();
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(path);
                XmlNode root = doc.DocumentElement;
                foreach (XmlNode item in root.ChildNodes)
                {
                    Box box = new Box();
                    box.Name = item.Attributes[0].InnerText;
                    box.Category = item.Attributes[1].InnerText;
                    foreach (XmlNode card in item.ChildNodes)
                    {
                        Card newCard = new Card();
                        newCard.Name = card.Attributes[0].InnerText;
                        newCard.Title = card.ChildNodes[0].InnerText;
                        newCard.Content = card.ChildNodes[1].InnerText;
                        newCard.Learned = card.ChildNodes[2].InnerText == "true";
                        box.Add(newCard);
                    }
                    items.Add(box);
                }
                MessageBox.Show("Die Datei wurde erfolgreich importiert");
            }
            catch (Exception error)
            {
                MessageBox.Show("Die Datei wurde nicht importiert " +
                    "\n" +
                    "Stellen Sie sicher, dass die Datei struktur korrekt ist\n" + error);
            }
            return items;
        }
    }
}
