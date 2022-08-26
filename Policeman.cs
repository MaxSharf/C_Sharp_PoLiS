using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp_PoLiS
{
    public class Policeman
    {
        public string? NamePoliceman { get; set;} // Імя
        public string? SecondNamePoliceman { get; set; } // Прізвище
        public string? NiddleNamePoliceman { get; set; } // побатькові
        public string? Department { get; set; } //Відділок
        public string? Partner { get; set; } // Напарник 
        public string? DateEmployment { get; set; } // Дата прийнятя на роботу 

        Policeman()
        {
            NamePoliceman = null;
            SecondNamePoliceman = null;
            NiddleNamePoliceman = null;
            Department = null;
            Partner = null;
            DateEmployment = null;
        }

        




    }

}
