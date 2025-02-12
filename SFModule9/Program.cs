using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.IO;
using System.Runtime;


namespace SFLesonsAndTasksPart8FilleSystem
{
    // Задание 9.1.3, Задание 9.1.4
    class Program
    {
        static void Main(string[] args)
        {
            Exception myexception = new Exception("Произошло исключение в проекте Модуля 9");
            myexception.Data.Add("Дата создания исключения: ", DateTime.Now);
            myexception.HelpLink = "https://yandex.ru";
            //TryCatchDemonstration();
            //AuOfRaEx();
            int[] a = { 5, 4, 3, 2, 1 };
            RankEx(a);
            int[] b = { 3, 2, 1 };
            RankEx(b);
        }

        // Задание 9.2.2
        static void AuOfRaEx()
        {
            byte max = 128;
            try
            {
                Console.WriteLine("Тестовое задание 9.2.2 выполняется");
                byte b = 0;
                do
                {
                    if (b > max)
                    {
                        throw new ArgumentOutOfRangeException($"Значения b = {b} и это выше установленного максимального значения, равного {max}");
                    }
                    b += 32;
                    Console.WriteLine($"Текущее значение переменой b(byte) = {b}, добавляем 32");
                } while (b < 256);
    
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine($"Ошибка: {exception.Message}");
            }
            
            catch (Exception ex)
            {
                Console.WriteLine("Сработало еще какое-то исключение, включем трассировку");
                Console.WriteLine(ex.StackTrace.ToString());
            }
            finally
            {
                Console.WriteLine("Блок Finally - сработал, делаем что-то дальше");
            }
        }

        // Задание 9.2.3
        static void RankEx(int[] arr)
        {
            int[] newarr = [1, 2, 3];
            try
            {
                Console.WriteLine("Тестовое задание 9.2.3 выполняется");
                if (arr.Length != 3)
                {
                    throw new RankException();
                }
                else 
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        newarr[i] = arr[i];
                        Console.WriteLine($"В массив добавлено значение {arr[i]}");
                    }
                }
                
            }
            catch (RankException exception)
            {
                Console.WriteLine($"Ошибка: {exception.GetType()}, получен массив с размерностью {arr.Length}, корректное значение размерности = {newarr.Length}");
            }

            finally
            {
                Console.WriteLine("Блок Finally - сработал, делаем что-то дальше");
                
            }
        }

        // Код из скринкаста
        static void TryCatchDemonstration()
        {
            try
            {
                Console.WriteLine("Демонстрация блока Try - начал свою работу");
                //throw new Exception("Ошибка в Модуле 9");
                //throw new FileNotFoundException();
                Method2();
            }
            catch (Exception ex) when (ex.Message == "Ошибка в Модуле 9")
            {
                Console.WriteLine("Произлшло исключение в Модуле 9");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) when (ex is ArgumentNullException)
            {
                Console.WriteLine("Аргумент пустой");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) when (ex is FileNotFoundException)
            {
                Console.WriteLine("Файл не найден");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
            finally
            {
                Console.WriteLine("Блок Finally - сработал");
            }
        }

        static void Method1()
        {
            try 
            {
                throw new Exception("Внутреннее исключение");
            }
            catch (Exception)
            {
                throw;
            }
        }
        static void Method2()
        {
            try
            {
                Method1();
            }
            catch (Exception)
            {
                throw;
            }
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

    }
}

