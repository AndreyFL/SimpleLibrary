using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrary
{
    class Book
    {
        public string Name { get; set; }

        int count = 0;
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                if (value < 0)
                    count = 0;
                else
                    count = value;
            }
        }


        public override string ToString()
        {
            return String.Format("Книга \"{0}\" в наличии {1} штук.", this.Name, this.Count);
        }


    }

    class Library
    {
        static Book[] booksArray = new Book[5];
        public string Name { get; set; }

        public Library()
        {
            Random r = new Random();
            for (int i = 0; i < booksArray.Length; i++)
                // создание книг которые находятся в хранилище
                booksArray[i] = new Book() { Name = "Книга" + i * 5, Count = r.Next(1, 6) };
        }

        public void GetBookList()
        {
            int i = 0;
            Console.WriteLine("\nБиблиотека: {0}", this.Name);
            foreach (Book b in booksArray)
                Console.WriteLine(i++ + "-" + b);
        }

        public string GetCurrentName(int index)
        {
            if (booksArray.Length > index)
                return booksArray[index].Name.ToString();
            else return "";
        }

        public bool GiveBook(int index)
        {
            if (booksArray.Length > index && booksArray[index].Count > 0)
            {
                booksArray[index].Count--;
                return true;
            }
            else
                return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            char key; // переменная для хранения кнопки нажатой пользователем
            Library illichaLib = new Library() { Name = "Ленинская" }; // экземпляр библиотека Иллича.
            Library shechenkoLib = new Library() { Name = "Шевченко" }; // экземпляр библиотека Шевченко
            List<Library> librarysList = new List<Library>(); // список содержащий созданные библиотеки
            librarysList.Add(illichaLib);
            librarysList.Add(shechenkoLib);

            int libIndex; // переменная в которой хранится индекс выбранной библиотеки

            do
            {
                // выбор библиотеки
                do
                {
                    for (int i = 0; i < librarysList.Count; i++)
                    {
                        Console.WriteLine("{0} - {1}", i, librarysList[i].Name);

                    }
                    Console.Write("\nВыберите индекс библионетки,'q' для выхода:");
                    try
                    {
                        key = Convert.ToChar(Console.ReadLine());
                    }
                    catch
                    {
                        key = 'q';
                    }
                    libIndex = Convert.ToInt32(key.ToString());
                    if (libIndex >= 0 && libIndex < librarysList.Count())
                        key = 'b';
                } while (key != 'b' && key != 'q');

                // Выбор книги в библиотеке
                while (key != 'l' && key != 'q')
                {
                    librarysList[libIndex].GetBookList();
                    Console.WriteLine("\nВыберите индекс книги которую выдаете,'q' для выхода, 'l' для возврата к выбору библиотеки:");
                    try
                    {
                        key = Convert.ToChar(Console.ReadLine());
                    }
                    catch
                    {
                        key = 'q';
                    }
                    if (Convert.ToInt32(key) >= 48 && Convert.ToInt32(key) <= 57)
                    {
                        int index = Convert.ToInt32(key.ToString());
                        if (librarysList[libIndex].GiveBook(index))
                            Console.WriteLine("{0} есть в наличии, выдать можем :)", librarysList[libIndex].GetCurrentName(index));
                        else
                            Console.WriteLine("{0} отсутствует в хранилище, выдать не можем!!!", librarysList[libIndex].GetCurrentName(index));
                    }
                    else if (key != 'l')
                        key = 'q';
                }
            } while (key != 'q');
        }
    }
}