using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;


namespace C_Sharp_PoLiS
{
    public class Сitizen : Entities
    {
        public string ? NameCitizen { get; set; } // Імя
        public string ? SecondNameСitizen { get; set; } // Прізвище
        public string ? NiddleNameСitizen { get; set; } // побатькові
        public string ? StatusСitizen { get; set; } // Статус
        public string ? AddressСitizen { get; set; } //Адрес
        public string ? IdentificationСitizen { get; set; } // Індифікайійний код 
        public string ? MailСitizen { get; set; }
        public string ? PhoneNumber { get; set; }
        public DateTime birthday;
        public int Age { get => DateTime.Today.Year - birthday.Year; set => age = value; }
        private int age;

        public Сitizen()
        {
            NameCitizen = null;
            SecondNameСitizen = null;
            NiddleNameСitizen = null;
            StatusСitizen = null;
            AddressСitizen = null;
            IdentificationСitizen = null;
            MailСitizen = null;
            PhoneNumber = null;
            Age = 0;

        }

        public override string ToString()
        {
            return string.Format($"\t |{Inum}| Імя: {NameCitizen}|  Прізвище: {SecondNameСitizen}|  По батькові: {NiddleNameСitizen}| " +
     $"Статус:  {StatusСitizen}|  Адрес: {AddressСitizen}|  \n |Індифікайійний код: {IdentificationСitizen}|  Електроний адрес: {MailСitizen}| Телфоний номер {PhoneNumber }| Вік {Age}|.\n");

        }

        public Сitizen(string? NameCitizen, string? SecondNameСitizen, string? NiddleNameСitizen, string? StatusСitizen,
            string? AddressСitizen, string ? IdentificationСitizen , string? MailСitizen , string ? PhoneNumber , int Age)
        {
            this.NameCitizen = NameCitizen;
            this.SecondNameСitizen = SecondNameСitizen;
            this.NiddleNameСitizen = NiddleNameСitizen;
            this.StatusСitizen = StatusСitizen;
            this.AddressСitizen = AddressСitizen;
            this.IdentificationСitizen = IdentificationСitizen;
            this.MailСitizen = MailСitizen;
            this.PhoneNumber = PhoneNumber;
            this.Age = Age;

        }




    }
}
