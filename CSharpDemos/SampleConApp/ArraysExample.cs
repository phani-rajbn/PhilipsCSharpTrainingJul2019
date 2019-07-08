using System;
/*
 * Arrays are reference types which are instances of a class called System.Array. The class contains properties and methods to get info about the array and perform operations like Copy, Clone, GetDimensions and so forth...
 * Arrays are fixed in size, U cannot modify the size retaining the elements. For that we use collection classes...
 */
namespace SampleConApp
{
    class ArraysExample
    {
        static void Main(string[] args)
        {
            //singleDimensionalArray();
            //multiDimensionalArray();
            //jaggedArray();
            arrayUsingArrayClass();
        }

        private static void arrayUsingArrayClass()
        {
            Console.WriteLine("Enter the size");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the CTS Type to create");
            Type type = Type.GetType(Console.ReadLine());
            Array array = Array.CreateInstance(type, size);
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter the value for the data type " + type.Name);
                object value = Convert.ChangeType(Console.ReadLine(), type);
                array.SetValue(value, i);
            }
            foreach(object value in array)
                Console.WriteLine(value);
        }

        private static void jaggedArray()
        {
            //Array with fixed no of rows and  no columns in each row...
            //A school having an array of classrooms where each room has variable no of students in it. 
            int[][] school = new int[3][];//Rows of the Array....
            school[0] = new int[] { 45, 66, 55, 66, 77 };
            school[1] = new int[] { 66, 55, 56, 77 };
            school[2] = new int[] { 76, 55, 77, 88, 77, 87, 67, 77 };

            //foreach(int [] students in school)
            //{
            //    foreach(int value in students)
            //        Console.Write(value + " ");
            //    Console.WriteLine();
            //}

            for (int i = 0; i < school.Length; i++)
            {
                for (int j = 0; j < school[i].Length; j++)
                {
                    Console.Write(school[i][j] +" ");
                }
                Console.WriteLine();
            }

        }

        private static void multiDimensionalArray()
        {
            int[,] scores = new int[2, 4];
            Console.WriteLine("The No of Dimensions " + scores.Rank);
            for (int i = 0; i < scores.GetLength(0); i++)
            {
                Console.WriteLine("Enter the marks for {0}th Participant", (i + 1));
                for (int j = 0; j < scores.GetLength(1); j++)
                {
                    Console.WriteLine("Enter the score:");
                    scores[i, j] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Marks entered for the student " + (i+1));
            }
            Console.WriteLine("Scores displayed in matrix format...");
            for (int i = 0; i < scores.GetLength(0); i++)
            {
                for (int j = 0; j < scores.GetLength(1); j++)
                {
                    Console.Write(scores[i,j] + " ");
                }
                Console.WriteLine();
            }

        }

        private static void singleDimensionalArray()
        {
            int[] elements = { 123, 234, 234, 234, 234, 234 };
            int[] scores = new int[5];
            for (int i = 0; i < scores.Length; i++)//Length is a property to get the no of elements within the array. 
            {
                scores[i] = i + 1;
            }

            string[] fruits = new string[] { "Apple", "Mango", "Orange" };

            foreach (string fruit in fruits) Console.WriteLine(fruit);
            //foreach is forward only and readonly. It is applicable only on collections, Array is basic collection. 
        }
    }
}
