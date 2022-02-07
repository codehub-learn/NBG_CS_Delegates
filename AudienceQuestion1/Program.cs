namespace AudienceQuestion1
{
    public class Program
    {
        public delegate void addDelegate(int num);
        public delegate int returnDelegate(int num);
        public static int staticNum { get; set; } = 1;
        static void Main(string[] args)
        {
            addDelegate myAddDelegate = Add1;
            myAddDelegate += Add2;
            myAddDelegate(1);

            //Equivalent without delegate
            Add1(1);
            Add2(1);

            //Multicast delegatae with return
            returnDelegate myReturnDelegate = ReturnPlus1;
            myReturnDelegate += ReturnPlus2;
            int x = 1;
            Console.WriteLine("myReturnDelegate returns: "+myReturnDelegate(staticNum));
        }

        public static void Add1(int number)
        {
            Console.WriteLine(number + 1);
        }

        public static void Add2(int number)
        {
            Console.WriteLine(number + 2);
        }

        public static int ReturnPlus1(int num)
        {
            return num + 1;
        }

        public static int ReturnPlus2(int num)
        {
            return num + 2;
        }
    }
}