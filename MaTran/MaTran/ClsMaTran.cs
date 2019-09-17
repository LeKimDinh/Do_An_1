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
        private int[][] matrix;
        public ClsMaTran()
        {
            this.soDong = 0;
            this.soCot = 0;
        }
        public int SoDong { get => soDong; set => soDong = value; }
        public int SoCot { get => soCot; set => soCot = value; }
        public int[][] Matrix { get => matrix; set => matrix = value; }

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
                    C.matrix[i][j] = A.matrix[i][j] + B.matrix[i][j];
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
            for (int i = 0; i < A.soDong; i++)
            {
                for (int j = 0; j < A.soCot; j++)
                {
                    C.matrix[i][j] = A.matrix[i][j] - B.matrix[i][j];
                }
            }
            return C;
        }
        public ClsMaTran Nhan(ClsMaTran A, ClsMaTran B)
        {
            ClsMaTran C = new ClsMaTran();
            for(int i = 0; i < SoDong; i++)     // dòng của ma trận 1
            {
                for(int j = 0; j < SoCot; j++)   // cột của ma trận 2
                {
                    int sum = 0;
                    for(int k = 0; k < soDong; k++)
                        sum += A.Matrix[i][k] * B.Matrix[k][j];
                    C.Matrix[i][j] = sum;
                }
            }

            return C;

        }

        public ClsMaTran ChuyenVi(ClsMaTran A)
        {
            ClsMaTran C = new ClsMaTran ();
            for(int i = 0; i < soDong; i++)
            {
                for(int j=0; j < SoCot; j++)
                {
                    C.Matrix[j][i] = A.Matrix[i][j];
                }
            }
            return C;
        }

        public bool NghichDao(ref ClsMaTran A,int SoD,int SoC)
        {
            if(SoD!=SoC)
                return false;

            return true;
        }

        public float Det(ClsMaTran A,int n)
        {
            float k=0;

            return k;
        }

    }
}
