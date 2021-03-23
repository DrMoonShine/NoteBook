using System;
using System.Collections.Generic;
namespace NoteBook
{
    class Program
    {
        public static Dictionary<int, Note> allNotes = new Dictionary<int, Note>(); //коллекция всех записей 
        public class Note
        {
            public string Surname { get; set; }
            public string Name { get; set; }
            public string PatName { get; set; } //Отчество
            public string PhoneNumber { get; set; }
            public string Country { get; set; }
            public string Company { get; set; }
            public string Post { get; set; } //Должность
            public string Text { get; set; }
            public DateTime Date { get; set; }
            /*public DateTime Date
            {
                get { return Date; }
                set { Date = new DateTime(); }
            }*/
            public Note(string surname,string name,string patName,string phoneNumber,string country,string company,string post,string text,DateTime date)
            {
                Surname = surname;
                Name = name;
                PatName = patName;
                PhoneNumber = phoneNumber;
                Country = country;
                Company = company;
                Post = post;
                Text = text;
                Date = date;
            }
            
        }
        //Создание новой записи
        public static void Create()
        {
            Console.Clear();
            string name = "Иван";
            string surname = "Иванов";
            string patName;
            string phoneNumber = "123123";
            string country = "Россия";
            string company;
            string post;
            string text;
            Console.WriteLine("Добавление новой записи");
            Console.WriteLine("Введите имя(обязательное поле): ");
            bool check = false;
            while (check == false)
            {
                //Самое длинное имя Барнаби Мармадюк Алоизий Бенджи Кобвеб Дартаньян Эгберт Феликс Гаспар Гумберт Игнатий Джейден...
                //...Каспер Лерой Максимилиан Недди Объяхулу Пепин Кьюллиам Розенкранц Секстон Тедди Апвуд Виватма Уэйленд Ксилон Ярдли Закари Усански(это все 1 имя -_-)
                //Поэтому ограничения на длину b cvbdjks ytn(не забываем про X Æ А-12) 
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Поле не может быть пустым. Введите имя еще раз.");
                }
                else
                {
                    check = true;
                }
            }
            check = false;
            Console.WriteLine("Введите фамилию(обязательное поле): ");
            while (check == false)
            {
                surname = Console.ReadLine();
                if (string.IsNullOrEmpty(surname))
                {
                    Console.WriteLine("Поле не может быть пустым. Введите фамилию еще раз.");
                }
                else
                {
                    check = true;
                }
            }
            check = false;
            Console.WriteLine("Введите страну(обязательное поле): ");
            while (check == false)
            {
                country = Console.ReadLine();
                if (string.IsNullOrEmpty(country))
                {
                    Console.WriteLine("Поле не может быть пустым. Введите название страны еще раз.");
                }
                else
                {
                    check = true;
                }
            }
            check = false;
            Console.WriteLine("Введите номер без пробелов(обязательное поле): ");
            while (check == false)
            {
                phoneNumber = Console.ReadLine();
                long ck;
                if (long.TryParse(phoneNumber, out ck) == false)
                {
                    Console.WriteLine("Номер может состоять только из цифр");
                }
                else if (phoneNumber.Length > 14 || phoneNumber.Length < 3)
                {
                    Console.WriteLine("Номер должне быть длиннее 2х знаков и короче 14 знаков");//Самый длинные номера в Нигерии и Северной Корее там в номере 13 знаков. Самые короткие номера 02,03 и тп
                }
                else
                {
                    check = true;
                }
            }
            Console.WriteLine("Следующие поля необязательные");
            int year = 1;
            int month = 1;
            int day = 1;
            Console.WriteLine("Для ввода даты введите команду 'yes'");
            string checkyear = Console.ReadLine();
            if(checkyear == "yes")
            {
                check = false;
            }
            while (check == false)
            {
                Console.WriteLine("Введите дату рождения в формате год.месяц.день или год месяц день");
                string d = Console.ReadLine();
                string[] temp = d.Split('.', ' ');             
                while(temp.Length != 3)
                {
                    Console.WriteLine("Неверный формат! Попробуйте еще раз");
                    d = Console.ReadLine();
                    temp = d.Split('.', ' ');
                }
                if (int.TryParse(temp[0], out year) == false)
                {
                    Console.WriteLine("Год введен не верно");
                }
                else if (int.TryParse(temp[1], out month) == false)
                {
                    Console.WriteLine("Месяц введен не верно");
                }
                else if (int.TryParse(temp[2], out day) == false)
                {
                    Console.WriteLine("День введен не верно");
                }
                else if (year < 0 || year > 9999)
                {
                    Console.WriteLine("Год долже попасть в интервал от 0 до 9999");
                }
                else if (month < 1 || month > 12)
                {
                    Console.WriteLine($"Месяц под номером {month} не существует, попробуйте еще раз");
                }
                else if (day < 1 || day > 31)
                {
                    Console.WriteLine($"В месяце нет {day}го дня");
                }
                
                else
                {
                    check = true;
                }
            }
            DateTime date = new DateTime(year, month, day);
            Console.WriteLine("Введите отчество");
            patName = Console.ReadLine();
            Console.WriteLine("Введите организацию");
            company = Console.ReadLine();
            Console.WriteLine("Введите должность");
            post = Console.ReadLine();
            Console.WriteLine("Оставьте заметку");
            text = Console.ReadLine();
            int id = 0;
            while (allNotes.ContainsKey(id))
            {
                id++;
            }          
            allNotes.Add(id, new Note(surname, name, patName, phoneNumber, country, company, post, text, date));
            ChooseComand();
        }
        //Вывод информации о всех значения
        public static void ReadAllNote()
        {
            Console.Clear();
            if(allNotes.Count == 0)
            {
                Console.WriteLine("Записей пока нет !");
            }
            else
            {
                foreach (var informationNote in allNotes)
                {
                    Console.WriteLine("-------------------------------------------------------------------------------");
                    Console.WriteLine($"Номер записи(id)#{ informationNote.Key}");
                    Console.WriteLine($"Фамилия: { informationNote.Value.Surname}");
                    Console.WriteLine($"Имя: {informationNote.Value.Name}");
                    Console.WriteLine($"Номер телефона: { informationNote.Value.PhoneNumber}");
                    Console.WriteLine("-------------------------------------------------------------------------------");
                }
            }
            Console.WriteLine("Введите команду back для возвращения к списку команд");
            string back = Console.ReadLine();
            while(back != "back")
            {
                Console.WriteLine("Неверная команда, пропробуйте еще раз");
                back = Console.ReadLine();
            }
            if(back == "back") ChooseComand();
        }
        //Удаление записи
        public static void RemoveNote()
        {
            Console.Clear();
            Console.WriteLine("Введите id");
            string sId = Console.ReadLine();
            int id;
            while(int.TryParse(sId, out id) == false)
            {
                Console.WriteLine("ID может быть только числом !");
                sId = Console.ReadLine();
            }
            if (allNotes.ContainsKey(id))
            {
                allNotes.Remove(id);
            }
            else
            {
                Console.WriteLine($"Id {id} не существует");
            }
            ChooseComand();
        }
        //Получить информацию о конкретной записи
        public static void GetOneNote()
        {
            Console.Clear();
            Console.WriteLine("Введите id");
            string sId = Console.ReadLine();
            int id;
            while (int.TryParse(sId, out id) == false)
            {
                Console.WriteLine("ID может быть только числом !");
                sId = Console.ReadLine();
            }
            if (allNotes.ContainsKey(id))
            {
                Console.WriteLine($"Номер записи#{id}");
                Console.WriteLine($"Фамилия: { allNotes[id].Surname}");
                Console.WriteLine($"Имя: {allNotes[id].Name}");
                if (string.IsNullOrEmpty(allNotes[id].PatName) == false) { Console.WriteLine($"Отчество: { allNotes[id].PatName}"); }
                Console.WriteLine($"Номер телефона: {allNotes[id].PhoneNumber}");
                Console.WriteLine($"Страна: {allNotes[id].Country}");
                if (allNotes[id].Date != new DateTime(0001,01,01))
                {
                    Console.Write("Дата рождения: ");
                    Console.WriteLine(allNotes[id].Date.ToString("dd.MM.yyyy"));
                }
                if (string.IsNullOrEmpty(allNotes[id].Company) == false) { Console.WriteLine($"Организация: {allNotes[id].Company}"); }
                if (string.IsNullOrEmpty(allNotes[id].Post) == false) { Console.WriteLine($"Должность: {allNotes[id].Post}"); }
                if (string.IsNullOrEmpty(allNotes[id].Text) == false) { Console.WriteLine($"Заметка: {allNotes[id].Text}"); }
            }
            else
            {
                Console.WriteLine($"Id {id} не существует, вернитесь к списку команд");
            }
            Console.WriteLine("Введите команду back для возвращения к списку команд");
            string back = Console.ReadLine();
            while (back != "back")
            {
                Console.WriteLine("Неверная команда, пропробуйте еще раз");
                back = Console.ReadLine();
            }
            if (back == "back") ChooseComand();

        }
        //Редактировать запись
        public static void UpgrateNote()
        {
            Console.Clear();
            Console.WriteLine("Введите id");
            string sId = Console.ReadLine();
            int id;
            while (int.TryParse(sId, out id) == false)
            {
                Console.WriteLine("ID может быть только числом !");
                sId = Console.ReadLine();
            }
            if (allNotes.ContainsKey(id))
            {
                Console.WriteLine("Выберете поле для редактирования.\nДля выбора нужно ввести название поля(name(имя),surname(фамилия),patname(отчество),phonenumber(номер телефона)\ncountry(страна),company(организация),post(должность),text(заметки),date(дата),end(закончить редоктирование)");
                bool checkExit = false;
                while(checkExit == false)
                {
                    string field = Console.ReadLine();
                    switch (field)
                    {
                        case "name":
                            {
                                Console.WriteLine("Введите новое имя");
                                string s = Console.ReadLine();
                                while (string.IsNullOrEmpty(s))
                                {
                                    Console.WriteLine("Поле не может быть пустым. Введите имя еще раз.");
                                    s = Console.ReadLine();
                                }
                                allNotes[id].Name = s;
                                Console.WriteLine("Изменения внесены!");
                                break;
                            }
                        case "surname":
                            {
                                Console.WriteLine("Введите новую фамилию");
                                string s = Console.ReadLine();
                                while (string.IsNullOrEmpty(s))
                                {
                                    Console.WriteLine("Поле не может быть пустым. Введите фамилию еще раз.");
                                    s = Console.ReadLine();
                                }
                                allNotes[id].Surname = s;
                                Console.WriteLine("Изменения внесены!");
                                break;
                            }
                        case "patname":
                            {
                                Console.WriteLine("Введите новое отчество");
                                allNotes[id].PatName = Console.ReadLine();
                                Console.WriteLine("Изменения внесены!");
                                break;
                            }
                        case "phonenumber":
                            {
                                Console.WriteLine("Введите новый номер");
                                string s = Console.ReadLine();
                                long ck;
                                while (long.TryParse(s, out ck) == false)
                                {
                                    Console.WriteLine("Номер может состоять только из цифр");
                                    s = Console.ReadLine();
                                }
                                while (s.Length > 14 || s.Length < 3)
                                {
                                    Console.WriteLine("Номер должне быть длиннее 2х знаков и короче 14 знаков");
                                    s = Console.ReadLine();
                                }
                                allNotes[id].PatName = s;
                                Console.WriteLine("Изменения внесены!");
                                break;
                            }
                        case "country":
                            {
                                Console.WriteLine("Введите новую страну");
                                string s = Console.ReadLine();
                                while (string.IsNullOrEmpty(s))
                                {
                                    Console.WriteLine("Поле не может быть пустым. Введите название страны еще раз.");
                                    s = Console.ReadLine();
                                }
                                allNotes[id].Country = s;
                                Console.WriteLine("Изменения внесены!");
                                break;
                            }
                        case "company":
                            {
                                Console.WriteLine("Введите новое название компании");
                                allNotes[id].Company = Console.ReadLine();
                                Console.WriteLine("Изменения внесены!");
                                break;
                            }
                        case "post":
                            {
                                Console.WriteLine("Введите новую должность");
                                allNotes[id].Post = Console.ReadLine();
                                Console.WriteLine("Изменения внесены!");
                                break;
                            }
                        case "text":
                            {
                                Console.WriteLine("Введите новую заметку");
                                allNotes[id].Text = Console.ReadLine();
                                Console.WriteLine("Изменения внесены!");
                                break;
                            }

                        case "date":
                            {
                                bool check = false;
                                int year = 1;
                                int month = 1;
                                int day = 1;
                                while (check == false)
                                {
                                    Console.WriteLine("Введите новую дату рождения в формате год.месяц.день год месяц день");
                                    string d = Console.ReadLine();
                                    string[] temp = d.Split('.');
                                    while (temp.Length != 3)
                                    {
                                        Console.WriteLine("Неверный формат! Попробуйте еще раз");
                                        d = Console.ReadLine();
                                        temp = d.Split('.', ' ');
                                    }
                                    if (int.TryParse(temp[0], out year) == false)
                                    {
                                        Console.WriteLine("Год введен не верно");
                                    }
                                    else if (int.TryParse(temp[1], out month) == false)
                                    {
                                        Console.WriteLine("Месяц введен не верно");
                                    }
                                    else if (int.TryParse(temp[2], out day) == false)
                                    {
                                        Console.WriteLine("День введен не верно");
                                    }
                                    else if (year < 0 || year > 9999)
                                    {
                                        Console.WriteLine("Год долже попасть в интервал от 0 до 9999");
                                    }
                                    else if (month < 1 || month > 12)
                                    {
                                        Console.WriteLine($"Месяц {month} не существует, попробуйте еще раз");
                                    }
                                    else if (day < 1 || day > 31)
                                    {
                                        Console.WriteLine($"В месяце нет {day}го дня");
                                    }
                                    else if (string.IsNullOrEmpty(temp[0]) || string.IsNullOrEmpty(temp[1]) || string.IsNullOrEmpty(temp[2]))
                                    {
                                        Console.WriteLine("Все поля должны быть заполнены");
                                    }
                                    else
                                    {
                                        check = true;
                                    }
                                }
                                DateTime t = new DateTime(year, month, day);
                                allNotes[id].Date = t;
                                Console.WriteLine("Изменения внесены!");
                                break;
                            }
                        case "end":
                            {
                                checkExit = true;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Команды не существует");
                                break;
                            }
                    }
                }
                
            }
            else
            {
                Console.WriteLine($"Id {id} не существует");
            }
            ChooseComand();
        }
        public static void ChooseComand()
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать!");
            Console.WriteLine("Это записная книжка");
            Console.WriteLine("Доступные команды: ");
            Console.WriteLine("create(добавить новую запись)");
            Console.WriteLine("readall(посмотреть все записи) - тут можно посмотреть id нужной записи");
            Console.WriteLine("getone(получить подробную информацию о записи по id)");
            Console.WriteLine("remove(удалить запись по id)");
            Console.WriteLine("upgrate(изменить поля записи по id)");
            Console.WriteLine("exit(выйти)");

            bool checkExit = false;

            while(checkExit == false)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "create": Create(); break; 
                    case "readall": ReadAllNote(); break;
                    case "getone": GetOneNote(); break;
                    case "remove": RemoveNote(); break;
                    case "upgrate": UpgrateNote(); break;
                    case "exit": checkExit = true; break;
                    default: Console.WriteLine("Такой команды не существует"); break;
             
                }
            }
        }
        static void Main(string[] args)
        { 
            ChooseComand();
        }
    }
}
