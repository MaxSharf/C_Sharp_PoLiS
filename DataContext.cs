using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Collections.Generic;

namespace C_Sharp_PoLiS
{
   public class DataContext
    {
        public readonly DataSet dataSet = new DataSet();

        public ICollection<Policeman> Policemans 
            { get { return dataSet.Policemans; } }

        public ICollection<Penalty>
            Penaltyes { get { return dataSet.Penaltyes; } }

        public ICollection<Сitizen>
            Сitizens { get { return dataSet.Сitizens; } }

        XmlFileIoController xmlFileIoController = new XmlFileIoController();

        public static string fileName = "Polis.xml";

        public void Save()
        {
            xmlFileIoController.Save(dataSet, fileName);
        }

        public void Load()
        {
            xmlFileIoController.Load(dataSet, fileName);
        }

        public override string ToString()
        {
            return string.Concat("Інформація про Облік штрафів , Поліцейських  та людей\n", Policemans.ToLineList("Поліцейські"), Penaltyes.ToLineList("Штрафи") , Сitizens.ToLineList("Жителі"));
        }
        public void Clear()
        {
            Policemans.Clear();
            Penaltyes.Clear();
            Сitizens.Clear();
        }
        public void CreateTestingData()
        {
            CreatePolicemans();
            CreatePenaltys();
            CreateCitizens();
        }

        private void CreatePenaltys()
        {
            Penaltyes.Add(new Penalty("Ст.121(1) ч.1", "ПДР" , "12.05.2021" , "Стрельченко Ілля Сергійович" , "Марінечеву Артему Констянтиновичу" , 255 ) { Inum = "1" });
            Penaltyes.Add(new Penalty("Ст.121(1) ч.1", "ПДР", "12.05.2021", "Стрельченко Ілля Сергійович", "Марінечеву Артему Констянтиновичу", 255) { Inum = "2" });
            Penaltyes.Add(new Penalty("Ст.121(1) ч.1", "ПДР", "12.05.2021", "Стрельченко Ілля Сергійович", "Марінечеву Артему Констянтиновичу", 255) { Inum = "3" });
            Penaltyes.Add(new Penalty("Ст.121(1) ч.1", "ПДР", "12.05.2021", "Стрельченко Ілля Сергійович", "Марінечеву Артему Констянтиновичу", 255) { Inum = "4" });
            Penaltyes.Add(new Penalty("Ст.121(1) ч.1", "ПДР", "12.05.2021", "Стрельченко Ілля Сергійович", "Марінечеву Артему Констянтиновичу", 255) { Inum = "5" });
        }

        public void CreatePolicemans()
        {
            //Policemans.Add(new Policeman("Вітенко", "Іван", "Олегович", "1 віділок місто жмеринка", "Івонов Іван Іванович ", "18.04.2000", 45, new Penalty("cnedrfef", " rf", "rf", "rf", "rf", 1213)) { Inum = "1" });
            Policemans.Add(new Policeman("Вітенко", "Іван", "Олегович", "1 віділок місто жмеринка", "Івонов Іван Іванович ", "18.04.2000" , 43) { Inum = "1" });
            Policemans.Add(new Policeman("Вітенко", "Іван", "Олегович", "1 віділок місто жмеринка", "Івонов Іван Іванович ", "18.04.2000", 45) { Inum = "2" });
            Policemans.Add(new Policeman("Вітенко", "Іван", "Олегович", "1 віділок місто жмеринка", "Івонов Іван Іванович ", "18.04.2000", 45) { Inum = "3" });
            Policemans.Add(new Policeman("Вітенко", "Іван", "Олегович", "1 віділок місто жмеринка", "Івонов Іван Іванович ", "18.04.2000", 45) { Inum = "4" });
            Policemans.Add(new Policeman("Вітенко", "Іван", "Олегович", "1 віділок місто жмеринка", "Івонов Іван Іванович ", "18.04.2000", 45) { Inum = "5" });
            Policemans.Add(new Policeman("Вітенко", "Іван", "Олегович", "1 віділок місто жмеринка", "Івонов Іван Іванович ", "18.04.2000", 45) { Inum = "6" });
            Policemans.Add(new Policeman("Вітенко", "Іван", "Олегович", "1 віділок місто жмеринка", "Івонов Іван Іванович ", "18.04.2000", 45) { Inum = "7" });

        }
        public void CreateCitizens()
        {
            Сitizens.Add(new Сitizen("Марінічев", "Атрем", "Констянтинович","LOX", "Вул.8 березня квартина 67","1234452424","Marina228@gmail.com" ,"0974353423"  , 17) { Inum = "1" });
            Сitizens.Add(new Сitizen("Марінічев", "Атрем", "Констянтинович", "LOX", "Вул.8 березня квартина 67", "1234452424", "Marina228@gmail.com", "0974353423", 17) { Inum = "2234567890" });
            Сitizens.Add(new Сitizen("Марінічев", "Атрем", "Констянтинович", "LOX", "Вул.8 березня квартина 67", "1234452424", "Marina228@gmail.com", "0974353423", 17) { Inum = "3234567890" });
            Сitizens.Add(new Сitizen("Марінічев", "Атрем", "Констянтинович", "LOX", "Вул.8 березня квартина 67", "1234452424", "Marina228@gmail.com", "0974353423", 17) { Inum = "4234567890" });
            Сitizens.Add(new Сitizen("Марінічев", "Атрем", "Констянтинович", "LOX", "Вул.8 березня квартина 67", "1234452424", "Marina228@gmail.com", "0974353423", 17) { Inum = "5234567890" });
            Сitizens.Add(new Сitizen("Марінічев", "Атрем", "Констянтинович", "LOX", "Вул.8 березня квартина 67", "1234452424", "Marina228@gmail.com", "0974353423", 17) { Inum = "6234567890" });
            Сitizens.Add(new Сitizen("Марінічев", "Атрем", "Констянтинович", "LOX", "Вул.8 березня квартина 67", "1234452424", "Marina228@gmail.com", "0974353423", 17) { Inum = "7234567890" });

        }



    }
}
