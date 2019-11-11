using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalculator
{
    class Program
    {
        public static List<ClsMaTran> ListMatrix = new List<ClsMaTran>();
        static void Main(string[] args)
        {
            ClsMaTran A = new ClsMaTran();
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
                                            int d, c, from, to;
                                            Console.WriteLine("Nhap so dong: ");
                                            d = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Nhap so cot: ");
                                            c = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Nhập khoảng giá trị: ");
                                            Console.Write("From: ");
                                            from = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("To: ");
                                            to = Convert.ToInt32(Console.ReadLine());

                                            ListMatrix[randomnhap - 1].RanDomMatrix(d, c, from, to);
                                            Console.WriteLine("Ok!");
                                            Console.ReadKey();
                                            randomnhap = InMenu();
                                        }
                                        goto Menu1;
                                    }
                                case 3:
                                    {
                                        int docfile = InMenu();
                                        while (docfile != 0)
                                        {
                                            Console.WriteLine("Nhap ten file: ");
                                            string filename = Console.ReadLine();
                                            ListMatrix[docfile - 1].ReadTxt(filename);
                                            Console.WriteLine("OK!");
                                            Console.ReadKey();
                                            docfile = InMenu();
                                        }
                                        goto Menu1;
                                    }
                                case 4:
                                    {
                                        int docfile = InMenu();
                                        while (docfile != 0)
                                        {
                                            Console.WriteLine("Nhap ten file: ");
                                            string filename = Console.ReadLine();
                                            ListMatrix[docfile - 1].ReadExcel(filename);
                                            Console.WriteLine("OK!");
                                            Console.ReadKey();
                                            docfile = InMenu();
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
                case 6:
                    {
                        int t = 0, kq = 0;
                        SelectOneMatrix(ref t, ref kq);
                        ListMatrix[kq - 1] = ListMatrix[t - 1].NghichDao();
                        ListMatrix[kq - 1].PrintfMatrix();
                        Console.WriteLine("Complete!");
                        Console.ReadKey();
                        goto MainMenu;
                    }
                case 7:
                    {
                        int t1 = 0, kq1 = 0;
                        SelectOneMatrix(ref t1, ref kq1);
                        ListMatrix[kq1 - 1] = ListMatrix[t1 - 1].TinhCos();
                        Console.WriteLine("Ok!");
                        Console.ReadKey();
                        goto MainMenu;
                    }

                case 8:
                    {
                    Menu2:
                        int nhap = InMenuIn();
                        if (nhap == 0)
                            goto MainMenu;
                        else
                        {
                            switch (nhap)
                            {
                                case 1:
                                    int a = InMenu();
                                    while (a != 0)
                                    {
                                        ListMatrix[a - 1].PrintfMatrix();
                                        Console.WriteLine("Ok!");
                                        Console.ReadKey();

                                        a = InMenu();
                                    }
                                    goto Menu2;

                                case 2:
                                    int b = InMenu();
                                    while (b != 0)
                                    {
                                        Console.WriteLine("Nhap ten file: ");
                                        string filename = Console.ReadLine();
                                        ListMatrix[b - 1].WriteTxt(filename);
                                        Console.WriteLine("Ok!");
                                        Console.ReadKey();

                                        b = InMenu();
                                    }
                                    goto Menu2;
                                case 3:
                                    int c = InMenu();
                                    while (c != 0)
                                    {
                                        Console.WriteLine("Nhap ten file: ");
                                        string filename = Console.ReadLine();
                                        ListMatrix[c - 1].WriteExcel(filename);
                                        Console.WriteLine("Ok!");
                                        Console.ReadKey();

                                        c = InMenu();
                                    }
                                    goto Menu2;

                            }
                        }
                    }
                    int nhap2 = InMenu();
                    while (nhap2 != 0)
                    {
                        ListMatrix[nhap2 - 1].PrintfMatrix();
                        Console.WriteLine("Ok!");
                        Console.ReadKey();
                        nhap2 = InMenu();
                    }
                    goto MainMenu;

                default:
                    break;
            }

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
            Console.WriteLine("7. Do tuong dong giua Cosin voi cac Vecto trong Matrix.");
            Console.WriteLine("8. In matrix.");
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
            Console.WriteLine("3. Doc tu file Txt.");
            Console.WriteLine("4. Doc tu file Excel.");
            Console.WriteLine("0. Tro ve.");
            int x;
            do
            {
                Console.WriteLine("\n--Chon thao tac: ");
                x = Convert.ToInt32(Console.ReadLine());
            }
            while (x < 0 || x > 4);
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
        public static void SelectMatrixToCalculators(ref int t1, ref int t2, ref int kq)
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
        public static int InMenuIn()
        {
            Console.Clear();
            Console.WriteLine("====================MATRIX CALCULATORS====================");
            Console.WriteLine("1. In ra man hinh.");
            Console.WriteLine("2. In ra file Txt.");
            Console.WriteLine("3. IN ra file Excel.");
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
        public static void SelectOneMatrix(ref int t, ref int kq)
        {
            Console.WriteLine("====================MATRIX CALCULATORS====================");
            do
            {
                Console.WriteLine("Chon matrix:");
                Console.WriteLine("1.A\n2.B\n3.C");
                t = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Chon matrxi luu ket qua.");
                Console.WriteLine("1.A\n2.B\n3.C");
                kq = Convert.ToInt32(Console.ReadLine());

            } while (t < 1 || t > 3 || kq < 1 || kq > 3);

        }

    }
}
