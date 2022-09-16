using System;
using System.Collections.Generic;
using System.Text;
using Common.ConsoleUI;
using Common.ConsoleIO;

namespace C_Sharp_PoLiS
{
    public partial class Menu
    {
        public DataContext dataContext;
        readonly DataSet dataSet = new DataSet();

        IEnumerable<Policeman> sortingPolicemans;
        IEnumerable<Penalty> sortingPenaltyes;
        IEnumerable<Сitizen> sortingСitizens;


        public Menu(DataContext dataContext)
        {
            this.dataContext = dataContext;
            sortingPolicemans = dataContext.Policemans;
            sortingPenaltyes = dataContext.Penaltyes;
            sortingСitizens = dataContext.Сitizens;
            IniCommandsInfo();
        }

        public static CommandInfo[] commandsInfo;

        public virtual void IniCommandsInfo()
        {
            
            commandsInfo = new CommandInfo[] {
                new CommandInfo("Вийти", null),
                new CommandInfo("Створити тестові дані",  dataContext.CreateTestingData),
                new CommandInfo("Показати як текст",ShowAsText),
                new CommandInfo("Редагувати дані про Поліцейського ►", RunPoliceman),
                new CommandInfo("Редагувати дані про Жителів ►", RunСitizen),
                new CommandInfo("Видалити усі записи...", dataContext.Clear),
           };
        }

        public void AcayntGO()
        {
            commandsInfo = new CommandInfo[]
            {
                new CommandInfo("Вийти", null),
                new CommandInfo("Створити акаут поліцейського" ,RunPolicemanAcc),
                new CommandInfo("Створити акаут жителя" ,RunСitizenAcc),
                new CommandInfo("Авторизуватися" ,LoginAcaunt)
            };
        }
        public void IniCommandsPolis()
        {
            commandsInfo = new CommandInfo[] {
                new CommandInfo("←---",Run),
                new CommandInfo("додати запис про поліцейського...", AddPoliceman),
                new CommandInfo("видалити запис про поліцейського...", RemovePoliceman),
                new CommandInfo("сортувати поліцейських за прізвищем", SortPolicemanBySname),
                new CommandInfo("сортувати поліцейських за Іменем", SortPolicemanByName),
                new CommandInfo("відібрати поліцейських: прізвище починається з ...", FilterPolicemanByStartSname),
                new CommandInfo("відібрати поліцейських: за напарнинком", FilterPolicemanByStartDepartment),
                new CommandInfo("видалити усі записи про поліцейських", dataContext.Policemans.Clear),
            };
        }

        public void IniCommandsСitizen()
        {

            commandsInfo = new CommandInfo[] {
                new CommandInfo("←---",Run),
                new CommandInfo("додати запис про жителя...", AddСitizen),
                new CommandInfo("видалити запис про жителя...", RemoveСitizen),
                new CommandInfo("видалити усі записи про типи жителів", dataContext.Сitizens.Clear),
                new CommandInfo("Відібрати  жителів за прізвищем", FilterСitizensByStartSname),
            };
        }
        private void ShowAsText()
        {
            Console.WriteLine();
            Console.Write(dataContext);
            KeyPressWaiting();
        }
        private void OutStatistics()
        {

            Console.WriteLine("\n  Представлено:\n"
                + "{0,7} Поліцейських\n"
                + "{1,7} Жителів\n",
                dataContext.Policemans.Count,
                dataContext.Сitizens.Count
                );
        }
        public void Run()
        {
                      
        
             while (true)                              
            {
                Console.Clear();
                OutStatistics();
                Console.WriteLine();              
                IniCommandsInfo();
                ShowCommandsMenu();
                Command command = EnterCommand();
                if (command == null)
                {
                    Environment.Exit(0); ;
                }
                command();
            }
        }

        public void Run3()
        {
            int tmp ;
            tmp = Entering.EnterInt32("\t 1 - почати роботу \n\t 2 -режим бога ");

            switch (tmp)
            {
                case 1:
                    Run2();
                    break;
                case 2:
                    Run();
                    break;             

            }

        }

        public void Run2()
        {
            dataContext.CreateTestingData();
                Console.Clear();
                Console.WriteLine();
                AcayntGO();
                ShowCommandsMenu();
                Command command = EnterCommand();
                if (command == null)
                {
                    Environment.Exit(0); ;
                }
                command();
                Console.Clear();
            
        }

        public void RunPoliceman()
        {
            while (true)
            {
                Console.Clear();
                OutPolicemansData();
                Console.WriteLine();
                IniCommandsPolis();
                ShowCommandsMenu();
                Command command = EnterCommand();
                command();
            }
        }
        public void RunPolicemanAcc()
        {
                Console.Clear();
                AddPoliceman();
                Console.WriteLine();
            while (true)
            {
                Console.Clear();
                OutStatistics();
                IniCommandsInfo();
                ShowCommandsMenu();
                Command command = EnterCommand();
                if (command == null)
                {
                    Environment.Exit(0); ;
                }

                command();
            }
        }
        public void RunСitizenAcc()
        {
            while (true)
            {
                Console.Clear();
                AddСitizen();
                while (true)
                {
                    Console.Clear();
                    OutStatistics();
                    IniCommandsInfo();
                    ShowCommandsMenu();
                    Command command = EnterCommand();
                    if (command == null)
                    {
                        Environment.Exit(0); ;
                    }

                    command();
                }
            }
        }


        public void RunСitizen()
        {
            while (true)
            {
                Console.Clear();
                OutСitizensData();
                Console.WriteLine();
                IniCommandsСitizen();
                ShowCommandsMenu();
                Command command = EnterCommand();

                command();
            }
        }
        private void ShowCommandsMenu()
        {
            Console.WriteLine("  Список команд меню:");
            for (int i = 0; i < commandsInfo.Length; i++)
            {
                Console.WriteLine($"\t{i,2} - {commandsInfo[i].name}");
            }
        }

        static Command EnterCommand()
        {
            while (true)
            {
                int number = Entering.EnterInt32(" Введіть номер команди меню");
                if (number < commandsInfo.Length)
                {
                    return commandsInfo[number].command;
                }
                Console.WriteLine("Помилка  введення  команди");
            }

        }

        protected virtual void KeyPressWaiting()
        {
            Console.Write("\nДля продовження роботи програми "
                + "натисніть довільну клавішу...");
            Console.ReadKey(true);
        }

    }
}
