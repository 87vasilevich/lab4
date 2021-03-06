﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Arr
    {
        public int[] mass1;
        //int[] mass2;


        // КОНСТРУКТОРЫ
        //public Arr (int [] first, int [] second)
        //{
        //    mass1 = first;
        //    mass2 = second;
        //}

        public Arr (int [] first)
        {
            mass1 = first;
        }


        // ПЕРЕГРУЗКА ОПЕРАЦИЙ
        // разность со скалярным значением
        public static int [] operator -(Arr temp, int val)
        {
            int[] first = temp.mass1;
            for (int i =0; i<first.Length;i++)
            {
                first[i] -= val;
            }
            return first;
        }

        // проверка на вхождение элемента
        public static bool operator >(Arr temp, int elem)
        {
            bool flag = false;
            for (int i = 0; i < temp.mass1.Length; i++)
            {
                if(temp.mass1[i]==elem)
                {
                    flag = true;
                }
            }
            if (flag ==true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <(Arr temp, int elem)
        {
            bool flag = false;
            return false;
        }

        // проверка на неравенство массивов
        public static bool operator !=(Arr temp, Arr temp2)
        {
            bool flag = temp.mass1.SequenceEqual(temp2.mass1);
            if (flag == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator ==(Arr temp, Arr temp2)
        {
            bool flag = false;
            return false;
        }

        // объединение массивов
        public static int[] operator +(Arr temp, Arr temp2)
        {
            int[] oral = new int[temp.mass1.Length + temp2.mass1.Length];
            for (int i = 0; i < temp.mass1.Length; i++)
            {
                oral[i] = temp.mass1[i];
            }
            for (int i = temp.mass1.Length, y = 0; i < temp.mass1.Length + temp2.mass1.Length; y++, i++)
            {
                oral[i] = temp2.mass1[y];
            }
            return oral;
        }


        // ЭКЗЕМПЛЯР КЛАССА OWNER
        public Owner person = new Owner(228332, "Владимир", "БГТУ");


        // ВЛОЖЕННЫЙ КЛАСС DATE
        public class Date
        {
            int day, month, year;

            public Date(int day, int month, int year)
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }

            public override string ToString()
            {
                return ($"День - {day}, месяц - {month}, год - {year}.\n");
            }

        }

        public Date xx = new Date(9, 1, 2002);
    }



    public class Owner
    {
        int id;
        string name, company;

        public Owner (int id, string name, string company)
        {
            this.id = id;
            this.name = name;
            this.company = company;
        }

        //public int Id
        //{
        //    get { return id; }
        //    set { id = value; }
        //}
        //public string Name
        //{
        //    get { return name; }
        //    set { name = value; }
        //}
        //public string Company
        //{
        //    get { return Company; }
        //    set { Company = value; }
        //}

        public override string ToString()
        {
            return ($"Id - {id}, Имя - {name}, организация - {company}.\n");
        }
    }



    // ЧЕТВЁРТОЕ ЗАДАНИЕ
    // сумма максимального и минимального эл-та массива
    public static class StatisticOperation
    {
        public static int SumMaxMin(Arr temp)
        {
            int min, max, val;
            min = max = temp.mass1[0];
            for (int i = 0; i < temp.mass1.Length; i++)
            {
                if (temp.mass1[i] > max)
                {
                    max = temp.mass1[i];
                }
                if (temp.mass1[i] < min)
                {
                    min = temp.mass1[i];
                }
            }
            val = max + min;
            return val;
        }


        // разница максимального и минимального эл-та массива
        public static int RazMaxMin(Arr temp)
        {
            int min, max, val;
            min = max = temp.mass1[0];
            for (int i = 0; i < temp.mass1.Length; i++)
            {
                if (temp.mass1[i] > max)
                {
                    max = temp.mass1[i];
                }
                if (temp.mass1[i] < min)
                {
                    min = temp.mass1[i];
                }
            }
            val = max - min;
            return val;
        }


        // подсчёт количества элементов
        public static int Kol(Arr temp)
        {
            int sum = temp.mass1.Length;
            return sum;
        }



        // ПЯТОЕ ЗАДАНИЕ
        // удаление гласных из строки
        public static string delete_vowels(this string temp)
        {
            string letter = "АаУуОоЫыИиЭэЯяЮюЁёЕе";
            for (int i = 0; i < temp.Length; i++)
            {
                for (int j = 0; j < letter.Length; j++)
                {
                    if (temp[i] == letter[j])
                    {
                       temp = temp.Remove(i, 1);
                    }
                }
            }
            return temp;
        }

        // удаление первых пяти элементов
        public static int[] del_five_elements (this int [] arr)
        {
            
                Array.Clear(arr, 0, 5); // удаление первых пяти элементов
            
            return arr;
        }
    }

    ///////////////////////////////////////

    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1
            int l;

            Console.WriteLine("Введите длину 1-го массива -> ");
            l = Convert.ToInt32(Console.ReadLine());
            int[] mass = new int[l];
            //Console.WriteLine("\n");
            for (int i =0; i <mass.Length; i++)
            {
                Console.WriteLine($"Введите значение {i+1} элемента 1-го массива -> ");
                mass[i]= Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine("\n");
            }

            Console.WriteLine("\nВведите длину 2-го массива -> ");
            l = Convert.ToInt32(Console.ReadLine());
            int[] mass2 = new int[l];
            //Console.WriteLine("\n");
            for (int i = 0; i < mass2.Length; i++)
            {
                Console.WriteLine($"Введите значение {i + 1} элемента 2-го массива -> ");
                mass2[i] = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine("\n");
            }


            Arr one = new Arr(mass);
            Arr two = new Arr(mass2);
            
            Console.WriteLine("\n1) Разность со скалярным значением. Введите значение, которое вы ходите отнять от первого массива -> ");
            int val = Convert.ToInt32(Console.ReadLine());
            int[] temporary = new int[mass.Length];
            temporary = one - val;
            Console.WriteLine("Результат: ");
            foreach(int i in temporary)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("\n2) Введите значение элемента, который вы хотите проверить на вхождение в массив №2 ->");
            val = Convert.ToInt32(Console.ReadLine());
            bool result = two > val;
            Console.WriteLine($"Результат (true - элемент входит, false - элемент не входит): {result}");


            Console.WriteLine("\n3) Проверка на неравеснтво массивов");
            result = (one != two);
            Console.WriteLine($"Результат (true - массивы равны, false - массивы не равны): {result}");


            Console.WriteLine("\n4) Объединение массивов №1 и №2");
            int[] temporary2 = new int[mass.Length+mass2.Length];
            temporary2 = one + two;
            Console.WriteLine("Результат:");
            foreach(int i in temporary2)
            {
                Console.WriteLine(i);
            }


            // Задание 2
            //Console.WriteLine("\n"+one.person); 


            // Задание 3
            //Console.WriteLine("\n"+one.xx);


            // Задание 4
            int number4;
            number4 = StatisticOperation.RazMaxMin(one);
            Console.WriteLine($"\nРазница между максимальным и минимальным элементом массива №1 = {number4}");

            number4 = StatisticOperation.SumMaxMin(one);
            Console.WriteLine($"\nСумма максимального и минимального элемента массива №1 = {number4}");

            number4 = StatisticOperation.Kol(one);
            Console.WriteLine($"\nКоличество элемнтов массива №1 = {number4}\n");


            // Задание 5
            string example = "Привет, меня зовут Владимир";
            Console.WriteLine(example.delete_vowels()+"\n\n");

            int[] examp = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            examp = examp.del_five_elements();
            for(int i = 5; i<examp.Length;i++)
            {
                Console.WriteLine(examp[i]);
            }

        }
    }
}
