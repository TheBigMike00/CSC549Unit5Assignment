using System;
using System.Collections.Generic;
using System.Collections;

namespace Unit5Assignment
{
    class Driver
    {
        #region Exercise 2.17
        public static int GetLastPair(List<int> lst) //using a cdr-like method rather than using c# build in tools
        {
            if (lst.Count > 1) //assumes lst contains at least one element
            {
                lst.RemoveAt(0); //cdr
                return GetLastPair(lst);
            }
            return lst[0];
        }
        #endregion


        #region Exercise 2.18
        public static string Reverse(List<int> lst)
        {
            String output = "";
            List<int> reversedList = ReverseIter(lst, new List<int>());
            foreach (var element in reversedList)
                output += element.ToString() + " ";
            return output;
        }

        public static List<int> ReverseIter(List<int> lst, List<int> reversed) //again using car/cdr method avoiding built in c# reverse
        {
            if (lst.Count == 0)
                return reversed;
            reversed.Insert(0, lst[0]);
            lst.RemoveAt(0);
            return ReverseIter(lst, reversed);
        }
        #endregion


        #region Exercise 2.20
        public static string SameParity(int first, List<int> otherNums)
        {
            string output = "";
            if(first % 2 == 0)
            {
                foreach (var element in otherNums)
                {
                    if(element % 2 == 0)
                        output += element.ToString() + " ";
                }
            }
            else
            {
                foreach (var element in otherNums)
                {
                    if (element % 2 != 0)
                        output += element.ToString() + " ";
                }
            }
            return output;
        }
        #endregion


        #region Exercise 2.23
        public static void CustomForEach(Func<int, int> func, List<int> lst)
        {
            foreach (var element in lst)
                func(element);
        }
        #endregion


        #region Exercise 2.30
        public static ArrayList SquareTree(ArrayList arr)
        {
            ArrayList toReturn = new ArrayList();
            foreach(var element in arr)
            {
                if(element.GetType() == typeof(ArrayList))
                    toReturn.Add(SquareTree((ArrayList)element));
                else
                    toReturn.Add((int)element * (int)element);
            }
            return toReturn;
        }

        public static string DisplayList(ArrayList arr)
        {
            string output = "( ";
            foreach(var element in arr)
            {
                if(element.GetType() == typeof(ArrayList))
                {
                    output += DisplayList((ArrayList)element);
                }
                else
                {
                    output += element + " ";
                }
            }
            return output + ")";
        }
        #endregion

        static void Main(string[] args)
        {
            //Exercise 2.17
            List<int> testList = new List<int> { 23, 72, 149, 34 };
            Console.WriteLine("Last Pair: " + GetLastPair(testList));

            //Exercise 2.18
            List<int> reverseTest = new List<int> { 1, 4, 9, 16, 25 };
            Console.WriteLine("\n\nReversed List: " + Reverse(reverseTest));

            //Exercise 2.20
            List<int> parity = new List<int> { 3, 4, 5, 6, 7 };
            Console.WriteLine("\n\nOdd Parity: " + SameParity(1, parity));
            Console.WriteLine("Even Parity: " + SameParity(2, parity));

            //Exercise 2.23
            List<int> toDisplay = new List<int> { 57, 321, 88 };
            Console.WriteLine("\n");
            CustomForEach(x =>
            {
                Console.WriteLine(x + " ");
                return x;
            }, toDisplay);

            //Exercise 2.30
            ArrayList arrList = new ArrayList();
            arrList.Add(1);
            arrList.Add(new ArrayList(){ 4, new ArrayList(){ 9, 16 }, 25});
            arrList.Add(new ArrayList() { 36, 49 });
            Console.WriteLine("\n\nOriginal List: " + DisplayList(arrList));
            Console.WriteLine("Squared List: " + DisplayList(SquareTree(arrList)));
        }
    }
}
