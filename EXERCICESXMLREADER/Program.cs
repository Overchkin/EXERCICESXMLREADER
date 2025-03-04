using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EXERCICESXMLREADER
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = XmlReader.Create("fichier.xml");
            var personne = new Personne();

            reader.MoveToContent();
            reader.ReadStartElement("Personne");

            reader.ReadStartElement("Nom");
            personne.Nom = reader.ReadContentAsString();
            reader.ReadEndElement();

            reader.ReadStartElement("Prenom");
            personne.Prenom = reader.ReadContentAsString();
            reader.ReadEndElement();

            reader.ReadStartElement("DateDeNaissance");
            personne.DateDeNaissance = reader.ReadContentAsDateTime();
            reader.ReadEndElement();

            reader.ReadStartElement("Taille");
            personne.Taille = reader.ReadContentAsInt();
            reader.ReadEndElement();

            reader.ReadEndElement();

            System.Console.WriteLine($"{personne.Prenom} {personne.Nom} " +
                $"né le {personne.DateDeNaissance:dd/MM/yyyy} mesure {personne.Taille}cm");

            var writerSettings = new XmlWriterSettings
            {
                Indent = true
            };
            var writer = XmlWriter.Create(@"C:\Users\Israël TODOME\source\repos\EXERCICESXMLREADER\EXERCICESXMLREADER", writerSettings);

            writer.WriteStartElement("Personne");
            writer.WriteElementString("Nom", personne.Nom);
            writer.WriteElementString("Prenom", personne.Prenom);
            writer.WriteElementString("DateDeNaissance", personne.DateDeNaissance.ToString());
            writer.WriteElementString("Taille", personne.Taille.ToString());
            writer.WriteEndElement();

            writer.Flush();
        }
    }
}
