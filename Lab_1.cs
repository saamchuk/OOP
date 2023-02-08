using System;

namespace C_sharp
{
    class Program
    {
        public class TArray
        {
            protected int[] arr;
            protected int number;

            public TArray()
            {
                number = 0;
                arr = new int[number];
            }
            public TArray (int element)
            {
                number = 1;
                arr = new int[number];
                arr[0]= element;
            }
            public TArray (TArray copyObject)
            {
                number = copyObject.number;
                arr = new int[number];
                for (int i = 0; i < number; i++) arr[i] = copyObject.arr[i];
            }
            public void input()
            {
                number++;
                Array.Resize(ref arr, number);
                Console.WriteLine("Enter the element:");
                arr[number - 1] = Convert.ToInt32(Console.ReadLine());
            }
            public void output()
            {
                foreach (int i in arr) Console.Write(i + "\t");
                Console.WriteLine();
            }
            public int maxElement()
            {
                int max = arr[0];
                for (int i = 1; i < number; i++)
                {
                    if (max < arr[i]) max = arr[i];
                }
                return max;
            }
            public int minElement()
            {
                int min = arr[0];
                for (int i = 1; i < number; i++)
                {
                    if (min > arr[i]) min = arr[i];
                }
                return min;
            }
            public void sortArray ()
            {
                for (int i = 0; i < number - 1; i++)
                {
                    for (int j = i + 1; j < number; j++)
                    {
                        if (arr[i] > arr[j])
                        {
                            int k = arr[j];
                            arr[j] = arr[i];
                            arr[i] = k;
                        }
                    }
                }
            }
            public int sumElements()
            {
                int sum = 0;
                foreach (int i in arr) sum += i;
                return sum;
            }
            public static TArray operator +(TArray object1, TArray object2)
            {
                TArray adding;
                if (object1.number > object2.number)
                {
                    adding = new TArray(object1);
                    for (int i = 0; i < object2.number; i++) adding.arr[i] = (object1.arr[i] + object2.arr[i]);
                }
                else
                {
                    adding = new TArray(object2);
                    for (int i = 0; i < object1.number; i++) adding.arr[i] = (object1.arr[i] + object2.arr[i]);
                }
                return adding;
            }
            public static TArray operator -(TArray small, TArray big)
            {
                TArray subtracting;
                if (small.number > big.number)
                {
                    subtracting = new TArray(small);
                    for (int i = 0; i < big.number; i++) subtracting.arr[i] = (small.arr[i] - big.arr[i]);
                }
                else
                {
                    subtracting = new TArray(big);
                    for (int i = 0; i < small.number; i++) subtracting.arr[i] = (small.arr[i] - big.arr[i]);
                    for (int i = small.number; i < subtracting.number; i++) subtracting.arr[i] = - big.arr[i];
                }
                return subtracting;
            }
            public static TArray operator *(TArray objec, int n)
            {
                TArray multiplying = new TArray(objec);
                for (int i = 0; i < multiplying.number; i++) multiplying.arr[i] *= n;
                return multiplying;
            }
        }
        public class TOderedArray : TArray
        {
            public TOderedArray () : base() { }
            public TOderedArray (int element) : base(element) { }
            public TOderedArray (TArray copyObject) : base(copyObject) 
            {
                sortArray();
            }
            public static TOderedArray operator +(TOderedArray objec, int element)
            {
                TOderedArray addElement = new TOderedArray(objec);
                addElement.number++;
                Array.Resize(ref addElement.arr, addElement.number);
                addElement.arr[addElement.number - 1] = element;
                addElement.sortArray();
                return addElement;
            }
            public static TOderedArray operator -(TOderedArray objec, int index)
            {
                TOderedArray deleteElement = new TOderedArray(objec);
                if (index == deleteElement.number - 1)
                {
                    deleteElement.number--;
                    Array.Resize(ref deleteElement.arr, deleteElement.number);
                }
                else if (index < deleteElement.number - 1) {
                    for (int i = index; i < deleteElement.number - 1; i++) deleteElement.arr[i] = deleteElement.arr[i + 1];
                    deleteElement.number--;
                    Array.Resize(ref deleteElement.arr, deleteElement.number);
                }
                return deleteElement;
            }
        }
        static void Main(string[] args)
        {
            TArray small = new TArray(10);
            small.input();
            Console.WriteLine("Output of the first array:");
            small.output();
            TArray big = new TArray(small);
            big.input();
            Console.WriteLine("Output of the second array:");
            big.output();
            Console.WriteLine("The largest element of the first array: " + small.maxElement());
            Console.WriteLine("The smallest element of the second array: " + big.minElement());
            Console.WriteLine("Sorting the second array: ");
            big.sortArray();
            big.output();
            Console.WriteLine("The sum of the elements of the first array: " + small.sumElements());
            Console.WriteLine("Adding elements of the first and second arrays:");
            TArray addition = small + big;
            addition.output();
            Console.WriteLine("Subtracting elements of the second array from the first:");
            TArray subtraction = small - big;
            subtraction.output();
            Console.WriteLine("Multiplying the elements of the second array by 2: ");
            TArray multiplication = big * 2;
            multiplication.output();
            TOderedArray odered = new TOderedArray(big);
            Console.WriteLine("Adding an element to the array:");
            odered += 2;
            odered.output();
            Console.WriteLine("Removing an element from the array:");
            odered -= 1;
            odered.output();
        }
    }
}
