using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Arr
    {
        int[] mass1;
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
        Owner person = new Owner(228332, "Владимир", "БГТУ");
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
            
        }
    }
}
