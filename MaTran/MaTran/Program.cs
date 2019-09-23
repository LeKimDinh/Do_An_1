using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaTran
{
    class Program
    {
        public static List<ClsMaTran> List = new List<ClsMaTran>();
        static void Main(string[] args)
        {            
            ClsMaTran A = new ClsMaTran();
            A.RanDomMatrix(100, 100);
            //maTran.EnterMatrix( );
            //maTran.PrintfMatrix();
         
            ClsMaTran B = new ClsMaTran();
            B.RanDomMatrix(100, 100);
            //maTran2.EnterMatrix();
            //maTran2.PrintfMatrix();
            ClsMaTran C = new ClsMaTran();
            C = A * B;
            C.WriteTxt();
            Console.WriteLine("Complete!\n");
            Console.ReadKey();

           
        }
        public static void Menu()
        {

        }
        public static int InMenu1()
        {
            Console.Clear();
            Console.WriteLine("====================MATRIX CALCULATORS====================");
            Console.WriteLine("1. Nhap matrix.");
            Console.WriteLine("2. Cong matrix.");
            Console.WriteLine("3. Tru matrix.");
            Console.WriteLine("4. Nhan matrix.");
            Console.WriteLine("5. Chuyen vi matrix.");
            Console.WriteLine("6. Nghich dao matrix.");
            Console.WriteLine("0. Thoat!");
            int x;
            do
            {
                Console.WriteLine("\n--Chon thao tac: ");
                x = Convert.ToInt32(Console.ReadLine());
            }
            while (x < 0 || x > 6);
            return x;
        }
        public static int InMenuNhap()
        {
            Console.Clear();
            Console.WriteLine("====================MATRIX CALCULATORS====================");
            Console.WriteLine("1. Nhap tay.");
            Console.WriteLine("2. Tao matrix random.");
            Console.WriteLine("0. Tro ve.");
            int x;
            do
            {
                Console.WriteLine("\n--Chon thao tac: ");
                x = Convert.ToInt32(Console.ReadLine());
            }
            while (x < 0 || x > 2);
            return x;
        }
        public static int InMenu()
        {
            Console.Clear();
            Console.WriteLine("====================MATRIX CALCULATORS====================");
            Console.WriteLine("1. Nhap matrix A.");
            Console.WriteLine("2. Nhap matrix B.");
            Console.WriteLine("3. Nhap matrix C.");
            Console.WriteLine("0. Tro ve.");
            int x;
            do
            {
                Console.WriteLine("\n--Chon thao tac: ");
                x = Convert.ToInt32(Console.ReadLine());
            }
            while (x < 0 || x > 3);
            return x;
        }
        public static void SelectMatrixToCalculators(ref int t1,ref int t2)
        {
            Console.WriteLine("====================MATRIX CALCULATORS====================");                       
                Console.WriteLine("Chon matrxi thu 1.");
                Console.WriteLine("1.A\n2.B\n3.C");
                t1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Chon matrxi thu 2.");
                Console.WriteLine("1.A\n2.B\n3.C");
                t2 = Convert.ToInt32(Console.ReadLine());

        }
        public static void Callculator(int tinh,int t1,int t2)
        {

            switch (tinh)
            {
                case 1:
                   
                   


                default:
                    break;
            }


        }


    }
}
