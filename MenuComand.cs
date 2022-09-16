using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.ConsoleIO;


namespace C_Sharp_PoLiS
{
    public partial class Menu
    {
        private void OutData()
        {
            OutPenaltyesData();
            OutPolicemansData();
            OutСitizensData();
        }

        private void OutСitizensData()
        {
            int i = 0;
            Console.WriteLine("  Список Жителів :");
            foreach (var obj in sortingСitizens)
            {
                i++;

                Console.WriteLine($"\t |{obj.Inum}| Імя: {obj.NameCitizen}|  Прізвище: {obj.SecondNameСitizen}|  По батькові: {obj.NiddleNameСitizen}| " +
     $"Статус:  {obj.StatusСitizen}|  Адрес: {obj.AddressСitizen}|  \n |Індифікайійний код: {obj.IdentificationСitizen}|  Електроний адрес: {obj.MailСitizen}| Телфоний номер {obj.PhoneNumber }| Вік {obj.Age}|.\n");

            }
        }


        private void OutPenaltyesData()
        {
            int i = 0;
            Console.WriteLine("  Список штрафів :");
            foreach (var obj in sortingPenaltyes)
            {
                i++;
                Console.WriteLine($"\t |{obj.Inum}| Назва штрафу: {obj.NamePenalty}|  Категорія: {obj.СategoryPenalty}|  Дата видачі: {obj.DataPenalty}| " +
               $"Ким виданий:  {obj.WhoIssued}|  Кому виданий: {obj.WhoMIssued}|  \n |Розмір штрафу (грн): {obj.PrisePenalty}|.\n");


            }
        }

        private void OutPolicemansData()
        {
            int i = 0;
            Console.WriteLine("\n  Список Поліцейських:");
            foreach (var obj in sortingPolicemans)
            {
                i++;
                Console.WriteLine($"\t |{obj.Inum}| Імя: {obj.NamePoliceman}|  Прізвище: {obj.SecondNamePoliceman}|  Побатькові: {obj.NiddleNamePoliceman}| " +
     $"Відділок:  {obj.Department}|  Напарник: {obj.Partner}|  \n |Дата прийнятя на роботу: {obj.DateEmployment}|  Повних років: {obj.Age}|.\n");

            }
        }

        public void AddPoliceman()
        {
            Policeman inst = new Policeman();
           // inst.Inum = Enteringstring.EnterString("Введіть ІПН особи", @"\A\d{10}\z", "Потрібно ввести 10 цифр");
            inst.NamePoliceman = Enteringstring.EnterString("Введіть імя поліцейського", 20, 2);
            inst.SecondNamePoliceman = Enteringstring.EnterString("Введіть Прізвище поліцейського", 20, 2);
            inst.NiddleNamePoliceman = Enteringstring.EnterString("\n\tВведіть Побатькові :");
            inst.Department = Enteringstring.EnterString("\n\tВведіть віділок  :");
            inst.Partner = Enteringstring.EnterString("Введіть IПБ напарника");
            inst.DateEmployment = Enteringstring.EnterString("Введіть дату прийнятя на роботу ");
            inst.Age = Entering.EnterInt32("Введіть вік");
            dataContext.Policemans.Add(inst);
        }

        public void AddСitizen()
        {
            Сitizen inst = new Сitizen();
           // inst.Inum = Enteringstring.EnterString("Введіть ІПН особи", @"\A\d{10}\z", "Потрібно ввести 10 цифр");
            inst.NameCitizen = Enteringstring.EnterString("Введіть Імя");
            inst.SecondNameСitizen = Enteringstring.EnterString("Введіть прізвище ");
            inst.NiddleNameСitizen = Enteringstring.EnterString("Введіть побатькові");
            inst.StatusСitizen = Enteringstring.EnterString("\n\tВведіть Статус :");
            inst.AddressСitizen = Enteringstring.EnterString("\n\tВведіть адрес:");
            inst.IdentificationСitizen = Enteringstring.EnterString("Введіть індефікаційний код ");
            inst.MailСitizen = Enteringstring.EnterString("Введіть Елкетрону почту ");
            inst.PhoneNumber = Enteringstring.EnterString("Введіть номер телефону");
            dataContext.Сitizens.Add(inst);
        }
        public void AddPenalty()
        {
            Penalty inst = new Penalty();
          //  inst.Inum = Enteringstring.EnterString("Введіть ІПН особи", @"\A\d{10}\z", "Потрібно ввести 10 цифр");
            inst.NamePenalty = Enteringstring.EnterString("Введіть назву штрафу");
            inst.СategoryPenalty = Enteringstring.EnterString("Введіть категорію");
            inst.DataPenalty = Enteringstring.EnterString("Введіть дату видачі штрафу");
            inst.WhoIssued = Enteringstring.EnterString("Введіть кому видан штраф");
            inst.WhoMIssued = Enteringstring.EnterString("Введіть ким видан штраф");
            inst.PrisePenalty = Entering.EnterDecimal("Введіть розмір штрафу");
            dataContext.Penaltyes.Add(inst);
        }



        //private EducationType SelectEducationType()
        //{
        //    while (true)
        //    {
        //        string education = Enteringstring.EnterString("Назва освіти");
        //        education = Enteringstring.FirstUpper(education);
        //        try
        //        {
        //            var educationType = dataContext.EducationTypes.First(e => e.name == education);
        //            return educationType;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //}


        public void RemoveСitizen()
        {
            int id = Entering.EnterInt32("Введіть числовий ідентифікатор номеру освіти");
            Сitizen inst = inst = dataContext.Сitizens.ElementAt(id - 1);
            dataContext.Сitizens.Remove(inst);
        }

        public void RemovePoliceman()
        {
            int id = Entering.EnterInt32("Введіть числовий ідентифікатор особи");
            Policeman inst = dataContext.Policemans.ElementAt(id - 1);
            dataContext.Policemans.Remove(inst);
        }

        private void SortPolicemanByName()
        {
            sortingPolicemans = sortingPolicemans.OrderBy(e => e.NamePoliceman);
        }

        private void SortPolicemanBySname()
        {
            sortingPolicemans = sortingPolicemans.OrderBy(e => e.SecondNamePoliceman);
        }

        private void SortСitizensBySname()
        {
            sortingСitizens = sortingСitizens.OrderBy(e => e.SecondNameСitizen);


        }

        public void LoginAcaunt()
        {

            int tmp;
            tmp = Entering.EnterInt32("\n\tВверіть за кого ви хочете увійти :  \n\t1 - поліцейський \n\t2 -  житель");

            switch (tmp)
            {
                case 1:
                    if (LoginPolis())
                    {
                        Run();
                    }

                    break;
                case 2:
                     
                    if (LoginCitizen() == true)
                    {
                        Run();
                    }
                    else
                    {
                      Console.WriteLine("ТИ ХТО????");
                    }

                    break;

            }



        }

    }
}
