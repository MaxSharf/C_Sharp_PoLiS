using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace C_Sharp_PoLiS
{
    public class XmlFileIoController
    {
        public void Save(DataSet dataSet, string fileName)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.Unicode;
            XmlWriter writer = null;
            try
            {
                writer = XmlWriter.Create(fileName, settings);
                WriteData(dataSet, writer);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }


        void WriteData(DataSet dataSet, XmlWriter writer)
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("PolicInfo");
            WritePolicemans(dataSet.Policemans, writer);
            WritePenaltyes(dataSet.Penaltyes, writer);
            WriteСitizens(dataSet.Сitizens, writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
        }

        void WritePolicemans(IEnumerable<Policeman> collection, XmlWriter writer)
        {
            writer.WriteStartElement("Policeman");
            foreach (var inst in collection)
            {
                writer.WriteStartElement("Policeman");
                writer.WriteElementString("Id", inst.Inum);
                writer.WriteElementString("Name ", inst.NamePoliceman);
                writer.WriteElementString("Second name ", inst.SecondNamePoliceman);
                writer.WriteElementString("Department", inst.Department);
                writer.WriteElementString("Partner", inst.Partner);
                writer.WriteElementString("Date of employment", inst.DateEmployment);
                writer.WriteElementString("Age", inst.Age.ToString());
                //string penaltyId = inst.penalty == null ? " " : inst.penalty.Inum;
                //writer.WriteElementString("penaltyId", penaltyId);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        void WritePenaltyes(IEnumerable<Penalty> collection, XmlWriter writer)
        {
            writer.WriteStartElement("Penalty");
            foreach (var inst in collection)
            {
                writer.WriteStartElement("Penalty");
                writer.WriteElementString("Id", inst.Inum);
                writer.WriteElementString("Name penalty", inst.NamePenalty);
                writer.WriteElementString("Сategory penalty  ", inst.СategoryPenalty);
                writer.WriteElementString("Data penalty", inst.DataPenalty);
                writer.WriteElementString("Who Issued", inst.WhoIssued);
                writer.WriteElementString("Whom Issued", inst.WhoMIssued);
                writer.WriteElementString("Prise", inst.PrisePenalty.ToString());               
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        void WriteСitizens(IEnumerable<Сitizen> collection, XmlWriter writer)
        {
            writer.WriteStartElement("Сitizen");
            foreach (var inst in collection)
            {
                writer.WriteStartElement("Сitizen");
                writer.WriteElementString("Id", inst.Inum);
                writer.WriteElementString("Name ", inst.NameCitizen);
                writer.WriteElementString("Second name ", inst.SecondNameСitizen);
                writer.WriteElementString("Niddle name", inst.NiddleNameСitizen);
                writer.WriteElementString("Status", inst.StatusСitizen);
                writer.WriteElementString("Address", inst.AddressСitizen);
                writer.WriteElementString("Age", inst.Age.ToString());
                writer.WriteElementString("Identification cod ", inst.IdentificationСitizen);
                writer.WriteElementString("Mail", inst.MailСitizen);
                writer.WriteElementString("PhoneNumber", inst.PhoneNumber);

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        public void Load(DataSet dataSet, string fileName)
        {
            if (!File.Exists(fileName)) return;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            using (XmlReader reader = XmlReader.Create(fileName, settings))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "Сitizen":
                                ReadCitizen(reader, dataSet);
                                break;
                            case "Policeman":
                                ReadPoliceman(reader, dataSet);
                                break;
                           case "Penalty":
                                ReadPenalty(reader, dataSet);
                                break;

                        }
                    }
                }
            }
        }


        void ReadPoliceman(XmlReader reader, DataSet dataSet)
        {
            Policeman inst = new Policeman();
            reader.ReadStartElement("Policeman");
            inst.Inum = reader.ReadElementContentAsString();
            inst.NamePoliceman = reader.ReadElementContentAsString();
            inst.SecondNamePoliceman = reader.ReadElementContentAsString();
            inst.Department = reader.ReadElementContentAsString();
            string tmp = reader.ReadElementContentAsString();
            if (!DateTime.TryParse(tmp, out inst.birthday))
            {
                Console.WriteLine($"Помилка!!!: {tmp}");
            }
            inst.Partner = reader.ReadElementContentAsString();
            inst.DateEmployment = reader.ReadElementContentAsString();
            inst.Age = reader.ReadElementContentAsInt();
           // string educationId = reader.ReadElementContentAsString();
           //inst.penalty = dataSet.Penaltyes
               // .FirstOrDefault(e => e.Inum == educationId);
            dataSet.Policemans.Add(inst);

        }

        void ReadPenalty(XmlReader reader, DataSet dataSet)
        {
            Penalty inst = new Penalty();
            reader.ReadStartElement("Penalty");
            inst.Inum = reader.ReadElementContentAsString();
            inst.NamePenalty = reader.ReadElementContentAsString();
            inst.СategoryPenalty = reader.ReadElementContentAsString();
            inst.DataPenalty = reader.ReadElementContentAsString();
            inst.WhoIssued = reader.ReadElementContentAsString();
            inst.WhoMIssued = reader.ReadElementContentAsString();
            inst.PrisePenalty = reader.ReadElementContentAsDecimal();
            dataSet.Penaltyes.Add(inst);
        }


        void ReadCitizen(XmlReader reader, DataSet dataSet)
        {
            Сitizen inst = new Сitizen();
            reader.ReadStartElement("Сitizen");
            inst.Inum = reader.ReadElementContentAsString();
            inst.NameCitizen = reader.ReadElementContentAsString();
            inst.SecondNameСitizen = reader.ReadElementContentAsString();
            inst.NiddleNameСitizen = reader.ReadElementContentAsString();
            string tmp = reader.ReadElementContentAsString();
            if (!DateTime.TryParse(tmp, out inst.birthday))
            {
                Console.WriteLine($"Помилка!!!: {tmp}");
            }
            inst.StatusСitizen = reader.ReadElementContentAsString();
            inst.AddressСitizen = reader.ReadElementContentAsString();
            inst.IdentificationСitizen = reader.ReadElementContentAsString();
            inst.MailСitizen = reader.ReadElementContentAsString();
            inst.PhoneNumber = reader.ReadElementContentAsString();
            inst.Age = reader.ReadElementContentAsInt();
            dataSet.Сitizens.Add(inst);
        }




    }
}
