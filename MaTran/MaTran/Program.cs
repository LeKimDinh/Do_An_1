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
            ClsMaTran B = new ClsMaTran();
            ClsMaTran C = new ClsMaTran();
            //A.RanDomMatrix(4, 4);
            //A.RanDomMatrix(10, 20);
            //A.TinhCos();
            //maTran.PrintfMatrix();

            //ClsMaTran B = new ClsMaTran();
            //B.RanDomMatrix(100, 100);
            //maTran2.EnterMatrix();
            //maTran2.PrintfMatrix();
            //ClsMaTran C = new ClsMaTran();
            //C = A * B;
            //C.WriteTxt();
            //A.WriteTxt();
            int x = InMenu1();

            switch (x)
            {
                case 1:
                    {
                        ahihi:
                        int nhap = InMenuNhap();
                        if (nhap == 0)
                            x = InMenu1();
                        else
                        {
                            switch (nhap)
                            {

                                case 1:
                                    {
                                        int nhaptay = InMenu(); 
                                        while (nhaptay != 0)
                                        {                                           
                                            switch (nhaptay)
                                            {
                                                case 1:
                                                        A.EnterMatrix();
                                                    break;
                                                case 2:                                                 
                                                        B.EnterMatrix();
                                                    break;
                                                case 3:                                                   
                                                        C.EnterMatrix();
                                                    break;
                                                default:
                                                    break;
                                            }
                                            nhaptay = InMenu();
                                        }
                                        goto ahihi;
                                        //InMenuNhap();                                        
                                    }

                                case 2:
                                    {
                                        int randomnhap = InMenu();
                                        while (randomnhap != 0)
                                        {                                            
                                            switch (randomnhap)
                                            {
                                                case 1:
                                                    A.RanDomMatrix(100,100);
                                                    Console.WriteLine("Ok!");
                                                    Console.ReadKey();
                                                    break;
                                                case 2:
                                                    B.RanDomMatrix(100,100);
                                                    Console.WriteLine("Ok!");
                                                    Console.ReadKey();
                                                    break;
                                                case 3:
                                                    C.RanDomMatrix(100, 100);
                                                    Console.WriteLine("Ok!");
                                                    Console.ReadKey();
                                                    break;
                                                default:
                                                    break;
                                            }
                                            randomnhap = InMenu();
                                        }
                                        goto ahihi;
                                    }
                                   
                                default:
                                    break;
                            }

                        }

                    }
                    break;
                case 2:
                    {
                        int t1=0, t2=0;
                        SelectMatrixToCalculators(ref t1, ref t2);
                    }
                    break;
                default:
                    break;
            }
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
                x = int.Parse(Console.ReadLine());
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
