using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;

namespace C_Sharp_PoLiS
{



    public class Policeman : Entities
    {
        public string? NamePoliceman { get; set;} // Імя
        public string? SecondNamePoliceman { get; set; } // Прізвище
        public string? NiddleNamePoliceman { get; set; } // побатькові
        public string? Department { get; set; } //Відділок
        public string? Partner { get; set; } // Напарник 
        public string? DateEmployment { get; set; } // Дата прийнятя на роботу 
        public DateTime birthday;
        public int Age { get => DateTime.Today.Year - birthday.Year; set => age = value; }
        private int age;
        //public Penalty? penalty;
        public Policeman()
        {
            NamePoliceman = null;
            SecondNamePoliceman = null;
            NiddleNamePoliceman = null;
            Department = null;
            Partner = null;
            DateEmployment = null;
            //penalty = null;
            Age = 0;
        }

        public override string ToString()
        {
            return string.Format($"\t |{Inum}| Імя: {NamePoliceman}|  Прізвище: {SecondNamePoliceman}|  Побатькові: {NiddleNamePoliceman}| " +
     $"Відділок:  {Department}|  Напарник: {Partner}|  \n |Дата прийнятя на роботу: {DateEmployment}|  Повних років: {Age}|.\n");
        }

        public Policeman( string ? NamePoliceman , string? SecondNamePoliceman , string? NiddleNamePoliceman, string? Department , string? Partner , string? DateEmployment , int Age )
        {
            this.NamePoliceman = NamePoliceman;
            this.SecondNamePoliceman = SecondNamePoliceman;
            this.NiddleNamePoliceman = NiddleNamePoliceman;
            this.Department = Department;
            this.Partner = Partner;
            this.DateEmployment = DateEmployment;
            this.Age = Age;



        }




    }

}
