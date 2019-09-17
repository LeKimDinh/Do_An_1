using System;
using System.Collections.Generic;
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
            this.Matrix = new float[100,100];
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
            for (int i = 0; i < A.soDong; i++)
            {
                for (int j = 0; j < A.soCot; j++)
                {
                    C.matrix[i,j] = A.matrix[i,j] + B.matrix[i,j];
                }
            }
            PrintfMatrix(C);
            return C;
        }
        public ClsMaTran Tru(ClsMaTran A, ClsMaTran B)
        {
            ClsMaTran C = new ClsMaTran();

            if (A.soDong != B.soDong || A.soCot != B.soCot)
            {
                return null;
            }
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

        public ClsMaTran ChuyenVi(ClsMaTran A)
        {
            ClsMaTran C = new ClsMaTran ();
            for(int i = 0; i < A.soDong; i++)
            {
                for(int j=0; j < A.SoCot; j++)
                {
                    C.Matrix[j,i] = A.Matrix[i,j];
                }
            }
            return C;
        }

        public bool NghichDao(ref ClsMaTran A)
        {
            if (A.SoDong != A.soCot)
            {
                Console.WriteLine("There is no inverse matrix\n");
                return false;
            }
            ClsMaTran B = new ClsMaTran();
            for(int i = 0; i < A.SoDong; i++)
            {
                for(int j = 0; j < A.SoDong; j++)
                {
                    B.Matrix[i,j] = Con(A, A.SoDong, i, j);
                }
            }
            for(int i = 0; i < A.SoDong - 1; i++)
            {
                for(int j = i + 1; j < A.SoDong; j++)
                {
                    float t = B.Matrix[i,j];
                    B.Matrix[i,j] = B.Matrix[j,i];
                    B.Matrix[j,i] = t;
                }
            }
            float k = Det(ref A, A.SoDong);
            for (int i = 0; i < A.SoDong; i++)
                for (int j = 0; j < A.SoDong; j++)
                    B.Matrix[i,j] /= k;
            if (k == 0) Console.WriteLine("There is no inverse matrix\n");
            else PrintfMatrix(B);
            return true;
        }

        public float Det(ref ClsMaTran A ,int n)
        {
            int i, j, k, dem = 0, kt=0;
            float[] b = new float[100];
            float kq = 1, h;
            for (i = 0; i < n - 1; i++)
            {
                if (A.Matrix[i,i] == 0)
                {
                    kq = 0;
                    for (j = i + 1; j < n; j++)
                    {
                        if (A.Matrix[i,j] != 0)
                        {
                            for (k = 0; k < n; k++)
                            {
                                float t = A.Matrix[k,i];
                                A.Matrix[k,i] = A.Matrix[k,j];
                                A.Matrix[k,j] = t;
                            }
                            dem++;
                            kt++;
                            break;
                        }
                    }
                    if (kt == 0) return 0;
                }
                b[i] = A.Matrix[i,i];
                for (j = 0; j < n; j++) A.Matrix[i,j] /= b[i];
                for (j = i + 1; j < n; j++)
                {
                    h = A.Matrix[j,i];
                    for (k = 0; k < n; k++) A.Matrix[j,k] = A.Matrix[j,k] - h * A.Matrix[i,k];
                }
                
            }
            b[n - 1] = A.Matrix[n - 1,n - 1];
            for (i = 0; i < n; i++) kq *= b[i];
            if (dem % 2 == 0) return kq;
            return -kq;
        }
        public float Con(ClsMaTran A, int SoN, int h, int c)
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
            if ((h + c) % 2 == 0) return Det(ref B, SoN - 1);
            return -Det(ref B, SoN - 1);
        }

        public void PrintfMatrix(ClsMaTran A)
        {
            Console.WriteLine("Ma trận được in ra: ");
            for (int i = 0; i < A.SoDong; i++)
            {
                for(int j=0;j<A.SoCot;j++)
                {
                    Console.Write("     {0}", A.Matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        public void EnterMatrix( ClsMaTran A)
        {           
            Console.Write(" Moi ban nhap so dong cua mang: ");
            A.soDong = int.Parse(Console.ReadLine());
            Console.Write(" Moi ban nhap so cot cua mang: ");
            A.soCot = int.Parse(Console.ReadLine());
            
                for (int i = 0; i < A.SoDong; i++)
                {
                    for (int j = 0; j < A.SoCot; j++)
                    {
                        Console.Write(" Moi ban nhap gia tri cua A[{0}][{1}]: ", i, j);
                        A.Matrix[i,j] = float.Parse(Console.ReadLine());
                    }
                    Console.Write("\n");
                }                       
        }
    }
}
