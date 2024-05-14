﻿
using System.Diagnostics;
using System.Numerics;

namespace Projekt3
{
    internal class Program
    {
        static sorts sort  = new sorts();
        static int[] t = new int[50000];
        const int NIter = 1;
        const int Consta = 5;
        static Random rnd = new Random(Guid.NewGuid().GetHashCode());
        static void GenerateAscendingArray(int[] t)
        {
            for (int i = 0; i < t.Length; ++i) t[i] = i;
            //return t;
        }
        static void GenerateDescendingArray(int[] t)
        {
            for (int i = 0; i < t.Length; ++i) t[i] = t.Length - i - 1;
            //return t;
        }
        static void GenerateVShape(int[] t)
        {
            int n = t.Length;
            int middle = n / 2;
            for (int i = 0; i < middle; i++)
            {
                t[i] = n - 1 - (i * 2);
            }
            for (int i = middle; i < n; i ++)
            {
                t[i] = (i - middle) * 2;
            }
            //return t;
        }
        static void GenerateRandomArray(int[] t, Random rnd, int maxValue = int.MaxValue)
        {
            for (int i = 0; i < t.Length; ++i)
                t[i] = rnd.Next(maxValue);
        }

        static void GenerateConst(int[] t)
        {
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = Consta;
            }
        }

        static string TimerGetTime(sorts[] sort, int[] t) 
        {
            return "xd";
        }
        static string SortTime(int c,int[] t)
        {
            double ElapsedSeconds;
            long ElapsedTime = 0, MinTime = long.MaxValue, MaxTime = long.MinValue, IterationElapsedTime;

            for (int i = 0; i < (NIter + 2); ++i)
            {

                long start = Stopwatch.GetTimestamp();
                SortChoose(c,t); //METODA DO WYBIERANIA SORTOWANIA ZAMIAST JEDNEJ KONKRETNEJ
                long end = Stopwatch.GetTimestamp();
                IterationElapsedTime = end - start;
                ElapsedTime += IterationElapsedTime;
                if (IterationElapsedTime > MaxTime) MaxTime = IterationElapsedTime;
                if (IterationElapsedTime < MinTime) MinTime = IterationElapsedTime;
            }
            ElapsedTime -= MaxTime + MinTime;
            ElapsedSeconds = ElapsedTime * (1.0 / (NIter * Stopwatch.Frequency));
            Console.Write("\t" + ElapsedSeconds.ToString("F10"));
            return ElapsedSeconds.ToString("F10");
        }
        static void SortChoose(int c, int[] t)
        {
            switch (c)
            {
                case 0:
                    //Console.WriteLine("HeapSort");
                    sort.HeapSort(t);
                    break;
                case 1:
                   // Console.WriteLine("CocktaSort");
                    sort.CocktailSort(t);
                    break;
                case 2:
                    //Console.WriteLine("InsertionSort");
                    sort.InsertionSort(t);
                    break;
                case 3:
                    //Console.WriteLine("SelectionSort");
                    sort.SelectionSort(t);
                    break;
                default:
                    break;
            }
        }
        static string TableChoose(int c)
        {
            switch (c)
            {
                case 0:
                    return "Desc";  
                case 1:
                    return "Ascd";
                case 2:
                    return "Rand";
                case 3:
                    return "V-sh";                 
                case 4:
                    return "Const";
                default:
                    return "";
            }
        }
        static void GenChoose(int c, int[] t)
        {
            switch (c)
            {
                case 0:
                    GenerateDescendingArray(t);
                    break;
                case 1:
                    GenerateAscendingArray(t);
                    break;
                case 2:
                    GenerateRandomArray(t, rnd);
                    break;
                case 3:
                    GenerateVShape(t);
                    break;
                case 4:
                    GenerateConst(t);
                    break;
                default:
                    break;
            }
        }
        static void Tester()
        {
            GenerateDescendingArray(t);
            sort.qsort(t, 0, t.Length - 1);
            //foreach (int item in t) Console.Write(item + " ");
        }
        static void Main(string[] args)
        {
            /*
              for (int i = 50000; i < 1000001; i += 10000) CZY DLA RÓŻNYCH TABLIC CZY JEDNEJ ROZMIAR TABLICY?
            {
                int[] t = new int[i];
                GenerateDescendingArray(t);
            } */
            /*
            Console.WriteLine("\t\tTIME ANALYSIS 4 DIFFRENT SORT ALGORITHMS");
            Console.WriteLine("for table of {0} elements", t.Length);
            Console.WriteLine("Table\tHeapSort\t CoctailSort\t InsertionSort \t SelectionSort");
            using (StreamWriter writer = new StreamWriter("C:\\Users\\jakob\\OneDrive\\Pulpit\\c#\\Algorytmy\\Projekt3\\results.txt"))
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("\n" + TableChoose(j));
                    writer.Write("\n" + TableChoose(j) + ";");
                    for (int i = 0; i < 4; i++)
                    {
                        GenChoose(j, t);
                        //foreach (int item in t) Console.Write(" " + item);
                        writer.Write(SortTime(i, t) + ";");
                    }                    
                }
            } 
            */
            /////////////////////////////// QUICK SORT //////////////////////////////////////
            
            Thread TesterThread = new Thread(Program.Tester, 8 * 1024 * 1024); // utworzenie wątku
            TesterThread.Start(); // uruchomienie wątku
            TesterThread.Join(); // oczekiwanie na zakończenie wątku
            
            //////// METODA NA WYBIERANIE PARAMETRU t[p] - mediany, do quicksorta i to na tyle narazie
        }
    }
}