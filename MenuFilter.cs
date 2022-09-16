using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Collections.Generic;

namespace C_Sharp_PoLiS
{
     partial class Menu
    {
        //private void FilterCountriesByMistoUnknown()
        //{
        //    var collection = sortingPersons
        //        .Where(e => string.IsNullOrEmpty(e.misto));
        //    Console.Write(collection.ToLineList(
        //        "\nСписок країн, для яких не вказано місто"));
        //    KeyPressWaiting();
        //}

        //private void FilterPersonsByAgeHasValue()
        //{
        //    var collection = sortingPersons.Where(e => e.age.HasValue);
        //    Console.Write(collection.ToLineList(
        //        "\nСписок осіб, для яких вказано значення віку"));
        //    KeyPressWaiting();
        //}

        private void FilterPolicemanByStartDepartment()
        {
            Console.Write("\n\tПочаток назви: ");
            string nameStart = Console.ReadLine();
            var collection = sortingPolicemans
                .Where(e => e.Department.StartsWith(nameStart,
                StringComparison.InvariantCultureIgnoreCase));
            Console.Write(collection.ToLineList(string.Format(
                "\nСписок осіб, які находяться в одному віділку \"{0}\"",
                nameStart)));
            KeyPressWaiting();
        }

        private void FilterPolicemanByStartSname()
        {
            Console.Write("\n\tФрагмент назви: ");
            string nameSubstring = Console.ReadLine();
            var collection = sortingPolicemans
                .Where(e => e.SecondNamePoliceman.IndexOf(nameSubstring,
                StringComparison.InvariantCultureIgnoreCase) >= 0);
            Console.Write(collection.ToLineList(string.Format(
                "\nСписок поліцейськиз, Прізвище яких містить \"{0}\"",
                nameSubstring)));
            KeyPressWaiting();
        }

        private void FilterСitizensByStartSname()
        {
            Console.Write("\n\tФрагмент назви: ");
            string nameSubstring = Console.ReadLine();
            var collection = sortingСitizens
                .Where(e => e.SecondNameСitizen.IndexOf(nameSubstring,
                StringComparison.InvariantCultureIgnoreCase) >= 0);
            Console.Write(collection.ToLineList(string.Format(
                "\nСписок Жителів, Прізвище яких містить \"{0}\"",
                nameSubstring)));
            KeyPressWaiting();
        }



        public bool LoginCitizen()
        {
            Console.Write("\n\tВведіть номер телефону : ");
            string Parol = Console.ReadLine();
            var collection = sortingСitizens.Where(e => e.PhoneNumber.IndexOf(Parol, StringComparison.InvariantCultureIgnoreCase) >= 0);

            // провірити що я тут зробив коли добавив колекцію в foreach
            foreach (var item in collection)
            {
                if (Parol == item.PhoneNumber)
                {
                    return true;
                }
            }
            return false;
        }

        public bool LoginPolis()
        {
            Console.Write("\n\tВведіть ваше прізвище  : ");
            string Parol = Console.ReadLine();
            var collection = sortingPolicemans.Where(e => e.SecondNamePoliceman.IndexOf(Parol, StringComparison.InvariantCultureIgnoreCase) >= 0);
            foreach (var item in sortingPolicemans)
            {
                if (Parol == item.SecondNamePoliceman)
                {
                    return true;
                }

            }
            return false;

        }


    }
}
