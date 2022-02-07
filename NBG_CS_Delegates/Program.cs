namespace NBG_CS_Delegates
{
    public class Program
    {
        public delegate int OperationDelegate(int num, string text);
        public delegate Animal AnimalDel(string text);
        public delegate void CatDel(Cat Cat);
        public static void Main(string[] args)
        {
            //Assigning Delegates

            OperationDelegate myDelegate = Program.DoubleInput;
            myDelegate = TripleInput;
            Console.WriteLine(myDelegate(1, "Call to TripleInput()"));
            myDelegate = DoubleInput;
            Console.WriteLine(myDelegate(1, "Call to DoubleInput()"));

            //Plugin Methods
            OperationDelegate myDelegate2 = DoubleInput;
            List<int> OperatedNumbers = IntArrayOperation(new int[] { 1, 2, 5 }, myDelegate2);
            Console.WriteLine("Done");

            //Covariance
            AnimalDel myAnimalDel = ReturnCat;
            Animal animal = myAnimalDel("Cadife");
            Console.WriteLine(animal.Name);

            //Contravariance
            CatDel myCatDel = PrintName;
            Cat cat = (Cat)animal;
            myCatDel(cat);

            //Generics
            Action<Cat> action = PrintName; //public delegate void CatDel(Cat Cat);
            Action<Cat, string> action2 = null;
            Func<int, string, int> func = DoubleInput; //public delegate int OperationDelegate(int num, string text);

        }

        //Contravariant Method
        public static void PrintName (Animal animal)
        {
            Console.WriteLine(animal.Name);
        }

        //Covariant Method
        public static Cat ReturnCat(string name)
        {
            return new Cat() { Name = name };
        }

        //Plugin Method
        public static List<int> IntArrayOperation(int[] numbers, OperationDelegate operation) 
        { 
            List<int> operatedNumbers = new List<int>();

            foreach (int number in numbers)
            {
                int result = operation(number, "Iteration Complete");
                operatedNumbers.Add(result);
            }

            return operatedNumbers;
        }
        
        //Compatible Methods with OperationDelegate
        public static int DoubleInput(int input, string successMsg)
        {
            Console.WriteLine(successMsg);
            return input * 2;
        }

        public static int TripleInput(int input, string successMsg)
        {
            Console.WriteLine(successMsg);
            return input * 3;
        }
    }
}