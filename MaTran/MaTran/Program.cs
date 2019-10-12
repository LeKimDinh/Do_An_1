using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaTran
{
    class Program
    {
        public static List<ClsMaTran> ListMatrix = new List<ClsMaTran>();
        static void Main(string[] args)
        {            
            ClsMaTran A = new ClsMaTran();
            A.RanDomMatrix(100,100);
            A=A.TinhCos();
            A.WriteExcel();
            ClsMaTran B = new ClsMaTran();
            ClsMaTran C = new ClsMaTran();
            ListMatrix.Add(A);
            ListMatrix.Add(B);
            ListMatrix.Add(C);
            MainMenu:
            int x = InMenu1();

            switch (x)
            {
                case 1:
                    {
                    Menu1:
                        int nhap = InMenuNhap();
                        if (nhap == 0)
                            goto MainMenu;
                        else
                        {
                            switch (nhap)
                            {

                                case 1:
                                    {
                                        int nhaptay = InMenu();
                                        while (nhaptay != 0)
                                        {
                                            ListMatrix[nhaptay - 1].EnterMatrix();
                                            nhaptay = InMenu();
                                        }
                                        goto Menu1;
                                        //InMenuNhap();                                        
                                    }

                                case 2:
                                    {
                                        int randomnhap = InMenu();
                                        while (randomnhap != 0)
                                        {
                                            ListMatrix[randomnhap - 1].RanDomMatrix(100, 100);
                                            Console.WriteLine("Ok!");
                                            Console.ReadKey();
                                            randomnhap = InMenu();
                                        }
                                        goto Menu1;
                                    }

                                default:
                                    break;
                            }

                        }

                    }
                    break;
                case 2:
                    {
                        int t1 = 0, t2 = 0, kq = 0;
                        SelectMatrixToCalculators(ref t1, ref t2, ref kq);
                        ListMatrix[kq - 1] = ListMatrix[t1 - 1] + ListMatrix[t2 - 1];
                        ListMatrix[kq - 1].PrintfMatrix();
                        Console.WriteLine("Complete!");
                        Console.ReadKey();
                        goto MainMenu;
                    }
                case 3:
                    {
                        int t1 = 0, t2 = 0, kq = 0;
                        SelectMatrixToCalculators(ref t1, ref t2, ref kq);
                        ListMatrix[kq - 1] = ListMatrix[t1 - 1] - ListMatrix[t2 - 1];
                        ListMatrix[kq - 1].PrintfMatrix();
                        Console.WriteLine("Complete!");
                        Console.ReadKey();
                        goto MainMenu;
                    }
                case 4:
                    {
                        int t1 = 0, t2 = 0, kq = 0;
                        SelectMatrixToCalculators(ref t1, ref t2, ref kq);
                        ListMatrix[kq - 1] = ListMatrix[t1 - 1] * ListMatrix[t2 - 1];
                        ListMatrix[kq - 1].PrintfMatrix();
                        Console.WriteLine("Complete!");
                        Console.ReadKey();
                        goto MainMenu;
                    }
                case 5:
                    {
                        int t = 0, kq = 0;
                        SelectOneMatrix(ref t, ref kq);
                        ListMatrix[kq - 1] = ListMatrix[t - 1].ChuyenVi();
                        ListMatrix[kq - 1].PrintfMatrix();
                        Console.WriteLine("Complete!");
                        Console.ReadKey();
                        goto MainMenu;
                    }

                case 7:
                    int nhap2 = InMenu();
                    while (nhap2 != 0)
                    {
                        ListMatrix[nhap2 - 1].PrintfMatrix();
                        Console.WriteLine("Ok!");
                        Console.ReadKey();
                        nhap2 = InMenu();
                    }
                    goto MainMenu;
                case 8:
                    int nhap3 = InMenu();
                    while (nhap3 != 0)
                    {
                        ListMatrix[nhap3 - 1].TinhCos();
                        Console.WriteLine("Ok!");
                        Console.ReadKey();
                        nhap3 = InMenu();
                    }
                    goto MainMenu;
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
            Console.WriteLine("7. In matrix.");
            Console.WriteLine("8. Do tuong dong giua Cosin voi cac Vecto trong Matrix.");
            Console.WriteLine("0. Thoat!");
            int x;
            do
            {
                Console.WriteLine("\n--Chon thao tac: ");
                x = Convert.ToInt32(Console.ReadLine());
            }
            while (x < 0 || x > 9);
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
            Console.WriteLine("1. Matrix A.");
            Console.WriteLine("2. Matrix B.");
            Console.WriteLine("3. Matrix C.");
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
        public static void SelectMatrixToCalculators(ref int t1,ref int t2, ref int kq)
        {
            Console.WriteLine("====================MATRIX CALCULATORS====================");
            do
            {
                Console.WriteLine("Chon matrxi thu 1.");
                Console.WriteLine("1.A\n2.B\n3.C");
                t1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Chon matrxi thu 2.");
                Console.WriteLine("1.A\n2.B\n3.C");
                t2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Chon matrxi luu ket qua.");
                Console.WriteLine("1.A\n2.B\n3.C");
                kq = Convert.ToInt32(Console.ReadLine());

            } while (t1 < 1 || t1 > 3 || t2 < 1 || t2 > 3 || kq < 1 || kq > 3);

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
        public static void SelectOneMatrix(ref int t, ref int kq)
        {
            Console.WriteLine("====================MATRIX CALCULATORS====================");
            do
            {
                Console.WriteLine("Chon matrxi thu 1.");
                Console.WriteLine("1.A\n2.B\n3.C");
                t = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Chon matrxi luu ket qua.");
                Console.WriteLine("1.A\n2.B\n3.C");
                kq = Convert.ToInt32(Console.ReadLine());

            } while (t < 1 || t > 2 || kq < 1 || kq > 2);

        }

    }
}
