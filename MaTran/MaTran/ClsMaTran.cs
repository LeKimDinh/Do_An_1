using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaTran
{
    public class ClsMaTran
    {
        private int soDong;
        private int soCot;
        private double[,] matrix;
        private List<double> ListDoDaiVector;
        private List<double> ListDoDaiVector2;

        public ClsMaTran()
        {
            this.soDong = 0;
            this.SoCot = 0;
            this.Matrix = new double[1000, 1000];
            this.ListDoDaiVector = new List<double>();
            this.ListDoDaiVector2 = new List<double>();
        }
        public int SoDong { get => soDong; set => soDong = value; }
        public int SoCot { get => soCot; set => soCot = value; }
        public double[,] Matrix { get => matrix; set => matrix = value; }

        public ClsMaTran Cong(ClsMaTran A, ClsMaTran B)
        {
            ClsMaTran C = new ClsMaTran();
            
            if(A.soDong != B.soDong || A.soCot != B.soCot)
            {
                return null;
            }
            C.SoDong = A.SoDong;
            C.SoCot = A.SoCot;
            for (int i = 0; i < A.soDong; i++)
            {
                for (int j = 0; j < A.soCot; j++)
                {
                    C.matrix[i,j] = A.matrix[i,j] + B.matrix[i,j];
                }
            }
            return C;
        }
        public ClsMaTran Tru(ClsMaTran A, ClsMaTran B)
        {
            ClsMaTran C = new ClsMaTran();

            if (A.soDong != B.soDong || A.soCot != B.soCot)
            {
                return null;
            }
            C.SoDong = A.SoDong;
            C.SoCot = A.SoCot;
            for (int i = 0; i < A.soDong; i++)
            {
                for (int j = 0; j < A.soCot; j++)
                {
                    C.matrix[i,j] = A.matrix[i,j] - B.matrix[i,j];
                }
            }
            return C;
        }
        public ClsMaTran Nhan(ClsMaTran A, ClsMaTran B)
        {
            ClsMaTran C = new ClsMaTran();
            C.SoDong = A.SoDong;
            C.SoCot = A.SoCot;
            for(int i = 0; i < A.SoDong; i++)     // dòng của ma trận 1
            {
                for(int j = 0; j < B.SoCot; j++)   // cột của ma trận 2
                {
                    double sum = 0;
                    for(int k = 0; k < A.soDong; k++)
                        sum += A.Matrix[i,k] * B.Matrix[k,j];
                    C.Matrix[i,j] = sum;
                }
            }
            return C;
        }
        public ClsMaTran ChuyenVi()
        {
            ClsMaTran C = new ClsMaTran ();
            C.SoDong = this.SoCot;
            C.SoCot = this.SoDong;
            for(int i = 0; i < this.soDong; i++)
            {
                for(int j=0; j < this.SoCot; j++)
                {
                    C.Matrix[j,i] = this.Matrix[i,j];
                }
            }
            return C;
        }
        public bool NghichDao()
        {
            if (this.SoDong != this.soCot)
            {
                Console.WriteLine("There is no inverse matrix\n");
                return false;
            }
            ClsMaTran B = new ClsMaTran();
            for(int i = 0; i < this.SoDong; i++)
            {
                for(int j = 0; j < this.SoDong; j++)
                {
                    B.Matrix[i,j] = Con(this, this.SoDong, i, j);
                }
            }
            for(int i = 0; i < this.SoDong - 1; i++)
            {
                for(int j = i + 1; j < this.SoDong; j++)
                {
                    double t = B.Matrix[i,j];
                    B.Matrix[i,j] = B.Matrix[j,i];
                    B.Matrix[j,i] = t;
                }
            }
            double k = Det(this.SoDong);
            for (int i = 0; i < this.SoDong; i++)
                for (int j = 0; j < this.SoDong; j++)
                    B.Matrix[i,j] /= k;
            if (k == 0) Console.WriteLine("There is no inverse matrix\n");
            else B.PrintfMatrix();
            return true;
        }
        public double Det(int n)
        {
            int i, j, k, dem = 0, kt=0;
            double[] b = new double[100];
            double kq = 1, h;
            for (i = 0; i < n - 1; i++)
            {
                if (this.Matrix[i,i] == 0)
                {
                    kq = 0;
                    for (j = i + 1; j < n; j++)
                    {
                        if (this.Matrix[i,j] != 0)
                        {
                            for (k = 0; k < n; k++)
                            {
                                double t = this.Matrix[k,i];
                                this.Matrix[k,i] = this.Matrix[k,j];
                                this.Matrix[k,j] = t;
                            }
                            dem++;
                            kt++;
                            break;
                        }
                    }
                    if (kt == 0) return 0;
                }
                b[i] = this.Matrix[i,i];
                for (j = 0; j < n; j++) this.Matrix[i,j] /= b[i];
                for (j = i + 1; j < n; j++)
                {
                    h = this.Matrix[j,i];
                    for (k = 0; k < n; k++) this.Matrix[j,k] = this.Matrix[j,k] - h * this.Matrix[i,k];
                }
                
            }
            b[n - 1] = this.Matrix[n - 1,n - 1];
            for (i = 0; i < n; i++) kq *= b[i];
            if (dem % 2 == 0) return kq;
            return -kq;
        }
        private double Con(ClsMaTran A, int SoN, int h, int c)
        {
            ClsMaTran B = new ClsMaTran();
            int i, j, x = -1, y;
            for (i = 0; i < SoN; i++)
            {
                if (i == h) continue;
                x++;
                y = -1;
                for (j = 0; j < SoN; j++)
                {
                    if (j == c) continue;
                    y++;
                    B.Matrix[x,y] = A.Matrix[i,j];
                }
            }
            if ((h + c) % 2 == 0) return Det(SoN - 1);
            return -Det(SoN - 1);
        }
        public void PrintfMatrix()
        {
            for (int i = 0; i < this.SoDong; i++)
            {
                for(int j=0;j<this.SoCot;j++)
                {
                    Console.Write(string.Format("{0}\t", Math.Round(this.Matrix[i, j], 2)));
                }
                Console.WriteLine();
            }
        }
        public void EnterMatrix()
        {
            int kt;
            do
            {
                try
                {
                    Console.Write(" Moi ban nhap so DONG cua Matrix: ");
                    this.soDong = int.Parse(Console.ReadLine());
                    kt = 1;
                }
                catch
                {
                    Console.WriteLine("Du lieu vao khong chinh xac, vui long nhap lai!\n");
                    kt = 0;
                }
            }
            while (kt == 0);

            do
            {
                try
                {
                    Console.Write(" Moi ban nhap so COT cua Matrix: ");
                    this.SoCot = int.Parse(Console.ReadLine());
                    kt = 1;
                }
                catch
                {
                    Console.WriteLine("Du lieu vao khong chinh xac, vui long nhap lai!\n");
                    kt = 0;
                }
            }
            while (kt == 0);

            for (int i = 0; i < this.SoDong; i++)
            {
                for (int j = 0; j < this.SoCot; j++)
                {
                    do
                    {
                        try
                        {
                            Console.Write(" Moi ban nhap gia tri cua A[{0}][{1}]: ", i, j);
                            this.Matrix[i, j] = double.Parse(Console.ReadLine());
                            kt = 1;
                        }
                        catch
                        {
                            Console.WriteLine("Du lieu vao khong chinh xac, vui long nhap lai!\n");
                            kt = 0;
                        }
                    }
                    while (kt == 0);
                    Console.Write("\n");
                }
            }
        }
        public void RanDomMatrix(int sodong, int socot)
        {
            this.SoDong = sodong;
            this.SoCot = socot;
            Random rd = new Random();
            for (int i = 0; i < this.SoDong; i++)
            {
                for (int j = 0; j < this.soCot; j++)
                {
                    this.matrix[i, j] = rd.Next(0, 100);
                }
            }
        }
        public void WriteTxt()
        {
            using (TextWriter tw = new StreamWriter("Result.txt"))
            {
                for (int j = 0; j < this.SoDong; j++)
                {
                    for (int i = 0; i < this.SoCot; i++)
                    {
                        if (i != 0)
                        {
                            tw.Write("\t");
                        }
                        tw.Write(this.matrix[i, j]);
                    }
                    tw.WriteLine();
                }
            }
        }

        //Operator
        public static ClsMaTran operator +(ClsMaTran A, ClsMaTran B)
        {
            ClsMaTran C = new ClsMaTran();

            if (A.soDong != B.soDong || A.soCot != B.soCot)
            {
                return null;
            }
            C.SoDong = A.SoDong;
            C.SoCot = A.SoCot;
            for (int i = 0; i < A.soDong; i++)
            {
                for (int j = 0; j < A.soCot; j++)
                {
                    C.matrix[i, j] = A.matrix[i, j] + B.matrix[i, j];
                }
            }
            return C;

        }
        public static ClsMaTran operator -(ClsMaTran A, ClsMaTran B)
        {
            ClsMaTran C = new ClsMaTran();

            if (A.soDong != B.soDong || A.soCot != B.soCot)
            {
                return null;
            }
            C.SoDong = A.SoDong;
            C.SoCot = A.SoCot;
            for (int i = 0; i < A.soDong; i++)
            {
                for (int j = 0; j < A.soCot; j++)
                {
                    C.matrix[i, j] = A.matrix[i, j] - B.matrix[i, j];
                }
            }
            return C;

        }
        public static ClsMaTran operator *(ClsMaTran A, ClsMaTran B)
        {
            ClsMaTran C = new ClsMaTran();
            C.SoDong = A.SoDong;
            C.SoCot = A.SoCot;
            for (int i = 0; i < A.SoDong; i++)     // dòng của ma trận 1
            {
                for (int j = 0; j < B.SoCot; j++)   // cột của ma trận 2
                {
                    double sum = 0;
                    for (int k = 0; k < A.soDong; k++)
                        sum += A.Matrix[i, k] * B.Matrix[k, j];
                    C.Matrix[i, j] = sum;
                }
            }
            return C;
        }

        //
        private void LayDoDai()
        {
            ListDoDaiVector.Clear();
            for (int i = 0; i < this.SoDong; i++)
            {
                double sum = 0;
                for (int j = 0; j < this.soCot; j++)
                {
                    sum += this.matrix[i, j] * this.matrix[i, j];
                }
                ListDoDaiVector.Add(Math.Sqrt(sum));
            }
        }
        private void LayDoDai2()
        {
            for (int i = 0; i < this.SoDong; i++)
            {
                double sum = 0;
                for (int j = 0; j < this.soCot; j++)
                {
                    sum += this.matrix[i, j] * this.matrix[i, j];
                }
                ListDoDaiVector2.Add(Math.Sqrt(sum));
            }
        }
        private void ChuanHoaMatrix()
        {
            for (int i = 0; i < this.SoDong; i++)
            {
                for (int j = 0; j < this.SoCot; j++)
                {
                    this.matrix[i, j] = this.matrix[i, j] / this.ListDoDaiVector[i];
                }
            }
        }
        private double TinhTichVoHuong(double[] t1, double[] t2)
        {
            t1 = new double[this.SoCot];
            t2 = new double[this.SoCot];
            double X = 0;
            for (int i = 0; i < this.SoCot; i++)
            {
                X += t1[i] * t2[i];
            }
            
            return X;
        }
        public void TinhCos()
        {
            LayDoDai();
            //ChuanHoaMatrix();
            //LayDoDai();
            ClsMaTran kq = new ClsMaTran();
            kq.SoCot = this.SoCot;
            kq.SoDong = this.SoDong;

            for (int t = 0; t < this.SoDong; t++)
            {
                for (int i = 0; i < this.SoDong; i++)
                {
                    //if (i >= t)
                    {
                        double s = 0;
                        for (int j = 0; j < this.SoCot; j++)
                        {
                            s += this.matrix[t, j] * this.matrix[i, j];
                        }
                        if(t ==1 && i == 1)
                        {
                            Console.WriteLine(s);
                        }
                        kq.matrix[t, i] = s;
                    }
                }
            }
            kq.PrintfMatrix();







            // ban dau khoi tao ma tran ket qua 
            //for(int i = 0; i < kq.SoDong; i++)
            //{
            //    for(int j=0;j<kq.SoCot;j++)
            //    {
            //        if (i == j) kq.Matrix[i, j] = 1;
            //        else kq.Matrix[i, j] = 0;
            //    }
            //}
            // chia tung dong roi chen vao ma tran nhung cho khac 1
           
        }
        public void test()
        {
            this.LayDoDai();
            for (int i = 0; i < this.SoDong; i++)
            {
                Console.Write(ListDoDaiVector[i] + " ");
            }
            Console.WriteLine();

            this.ChuanHoaMatrix();
            PrintfMatrix();

            this.LayDoDai();
            for (int i = 0; i < this.SoDong; i++)
            {
                Console.Write(ListDoDaiVector[i] + " ");
            }
            Console.WriteLine();

        }
        public void In()
        {
            LayDoDai();
            for (int i = 0; i < this.SoDong; i++)
            {
                Console.Write(ListDoDaiVector[i] + " ");
            }
            Console.WriteLine();
            //

            ChuanHoaMatrix();

            //
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < this.SoDong; i++)
            {
                Console.Write(ListDoDaiVector[i] + " ");
            }
            Console.WriteLine();
            ClsMaTran mt = new ClsMaTran();
            mt.SoDong = this.SoDong;
            mt.SoCot = this.SoCot;
            for (int i = 0; i <= this.SoDong/2; i++)
            {
                for (int j = 0; j < this.SoDong; j++)
                {
                    mt.matrix[i, j] = ListDoDaiVector[i] / ListDoDaiVector[j];
                    mt.matrix[j, i] = ListDoDaiVector[i] / ListDoDaiVector[j];

                }
            }
            mt.PrintfMatrix();
        }

    }
}
