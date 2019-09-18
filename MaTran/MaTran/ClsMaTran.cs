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
        private float[,] matrix;
        public ClsMaTran()
        {
            this.soDong = 0;
            this.SoCot = 0;
            this.Matrix = new float[1000, 1000];
        }
        public int SoDong { get => soDong; set => soDong = value; }
        public int SoCot { get => soCot; set => soCot = value; }
        public float[,] Matrix { get => matrix; set => matrix = value; }

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
                    float sum = 0;
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
                    float t = B.Matrix[i,j];
                    B.Matrix[i,j] = B.Matrix[j,i];
                    B.Matrix[j,i] = t;
                }
            }
            float k = Det(this.SoDong);
            for (int i = 0; i < this.SoDong; i++)
                for (int j = 0; j < this.SoDong; j++)
                    B.Matrix[i,j] /= k;
            if (k == 0) Console.WriteLine("There is no inverse matrix\n");
            else B.PrintfMatrix();
            return true;
        }

        public float Det(int n)
        {
            int i, j, k, dem = 0, kt=0;
            float[] b = new float[100];
            float kq = 1, h;
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
                                float t = this.Matrix[k,i];
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
        private float Con(ClsMaTran A, int SoN, int h, int c)
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
                    Console.Write(string.Format("{0}\t", this.Matrix[i, j]));
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
                            this.Matrix[i, j] = float.Parse(Console.ReadLine());
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
    }
}
