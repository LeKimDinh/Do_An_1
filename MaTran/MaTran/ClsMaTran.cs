using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Excel = Microsoft.Office.Interop.Excel;

namespace MaTran
{
    public class ClsMaTran
    {
        //Các thuộc tính, hàm dựng, properties
        #region
        //Thuộc tính
        private int soDong;
        private int soCot;
        private double[,] matrix;
        private List<double> ListDoDaiVector;
        //Hàm dựng
        public ClsMaTran()
        {
            this.soDong = 0;
            this.SoCot = 0;
            this.Matrix = new double[1000, 1000];
            this.ListDoDaiVector = new List<double>();          
        }
        public ClsMaTran(int sodong, int socot, double[,] matrix)
        {
            this.soDong = sodong;
            this.SoCot = socot;
            this.Matrix = new double[1000, 1000];
            this.matrix = matrix;
            this.ListDoDaiVector = new List<double>();

        }
        //Properties
        public int SoDong { get => soDong; set => soDong = value; }
        public int SoCot { get => soCot; set => soCot = value; }
        public double[,] Matrix { get => matrix; set => matrix = value; }
        #endregion

<<<<<<< HEAD
        //các phương thức nhập xuất
        #region
=======
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
        public void NghichDao()
        {
            if (this.SoDong != this.soCot)
            {
                Console.WriteLine("There is no inverse matrix\n");
                return;
            }
            ClsMaTran B = new ClsMaTran();
            B.soDong = this.soDong;
            B.soCot = this.soDong;
            for(int i = 0; i < this.soDong; i++)
            {
                for(int j = 0; j < this.soDong; j++)
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
            double k = Det(this,this.SoDong);
            for (int i = 0; i < this.SoDong; i++)
                for (int j = 0; j < this.SoDong; j++)
                    B.Matrix[i,j] /= k;
            if (k == 0) Console.WriteLine("There is no inverse matrix\n");
            else B.PrintfMatrix();
            return;
        }
        public double Det(ClsMaTran A ,int n)
        {
            int i, j, k, dem = 0, kt=0;
            double[] b = new double[100];
            double kq = 1, h;
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
                                double t = A.Matrix[k,i];
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
            b[n-1] = A.Matrix[n-1,n-1];
            for (i = 0; i < n; i++) kq *= b[i];
            if (dem % 2 == 0) return kq;
            return -kq;
        }
        private double Con(ClsMaTran A, int SoN, int h, int c)
        {
            ClsMaTran B = new ClsMaTran();
            B.soDong = SoN;
            B.soCot = SoN;
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
            if ((h + c) % 2 == 0) return Det(B,SoN - 1);
            return -Det(B,SoN - 1);
        }
>>>>>>> d5e59ec1e0245aa5f0bba9c76e98f317f94cfd3b
        public void PrintfMatrix()
        {
            for (int i = 0; i < this.SoDong; i++)
            {
                for (int j = 0; j < this.SoCot; j++)
                {
                    Console.Write(string.Format("{0}\t", Math.Round(this.Matrix[i, j], 5)));
                }
                Console.WriteLine();
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

        public void RanDomMatrix(int sodong, int socot, int from, int to)
        {
            this.SoDong = sodong;
            this.SoCot = socot;
            Random rd = new Random();
            for (int i = 0; i < this.SoDong; i++)
            {
                for (int j = 0; j < this.soCot; j++)
                {
                    this.matrix[i, j] = rd.Next(from, to);
                }
            }
        }

        public void ReadTxt(string filename)
        {
<<<<<<< HEAD
            FileStream fs = new FileStream(filename + ".txt", FileMode.Open);
=======
            FileStream fs = new FileStream("D:\\test.txt", FileMode.Open);
>>>>>>> d5e59ec1e0245aa5f0bba9c76e98f317f94cfd3b
            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            this.SoDong = Convert.ToInt32(rd.ReadLine().ToString());
            this.SoCot = Convert.ToInt32(rd.ReadLine().ToString());
            for (int i = 0; i < this.SoDong; i++)
            {
                for (int j = 0; j < this.SoCot; j++)
                {
                    this.Matrix[i, j] = Convert.ToDouble(rd.ReadLine().ToString());
                    Console.Write(string.Format("{0}\t", Math.Round(this.Matrix[i, j], 5)));
                }
                Console.WriteLine();
            }
            fs.Close();
            //​Console.ReadLine();
        }

        public void WriteTxt(string filename)
        {
            using (TextWriter tw = new StreamWriter(filename + ".txt"))
            {
                tw.Write(this.SoDong);
                tw.Write("\t");
                tw.WriteLine(this.SoCot);

                for (int i = 0; i < this.SoDong; i++)
                {
                    for (int j = 0; j < this.SoCot; j++)
                    {
                        tw.WriteLine(this.matrix[i,j]);
                    }
                }
            }
        }

        public void WriteExcel(string filename)
        {
            //Tạo excel app object
            Excel.Application xlSamp = new Microsoft.Office.Interop.Excel.Application();
            if (xlSamp == null)
            {
                Console.WriteLine("Excel chua duoc cai dat!");
                Console.ReadKey();
                return;
            }
            //Tạo excel book và sheet
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlSamp.Workbooks.Add(misValue);
            //Mặc định ghi ma trận lên Sheet thứ nhất
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //tiến hành ghi ma trận
            //Hai ô đầu tiên ghi số dòng và số cột của ma trận
            xlWorkSheet.Cells[1, 1] = this.SoDong;
            xlWorkSheet.Cells[1, 2] = this.SoCot;

            for (int i = 0; i < this.SoDong; i++)
                for (int j = 0; j < this.SoCot; j++)
                    xlWorkSheet.Cells[i + 2, j + 1] = this.matrix[i, j];

            //Đường dẫn mặc định ở thư mục Document với file name truyền vào.
            string location = filename + ".xls";
            xlWorkBook.SaveAs(location, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlSamp.Quit();

            //Xuất ra file Excel
            try{
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSamp);
                xlSamp = null;
            }
            catch (Exception ex){
                xlSamp = null;
                Console.Write("Error " + ex.ToString());
            }
            finally
            { GC.Collect(); }
            
        }
        #endregion

        //các phương thức tính toán
        #region
        public ClsMaTran Cong(ClsMaTran A, ClsMaTran B)
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
                    C.matrix[i, j] = A.matrix[i, j] - B.matrix[i, j];
                }
            }
            return C;
        }
        public ClsMaTran Nhan(ClsMaTran A, ClsMaTran B)
        {
            if (A.SoCot != B.SoDong)
                return null;

            ClsMaTran C = new ClsMaTran();
            C.SoDong = A.SoDong;
            C.SoCot = B.SoCot;
            for (int i = 0; i < A.SoDong; i++)     // dòng của ma trận 1
            {
                for (int j = 0; j < B.SoCot; j++)   // cột của ma trận 2
                {
                    double sum = 0;
                    for (int k = 0; k < A.SoDong; k++)
                        sum += A.Matrix[i, k] * B.Matrix[k, j];
                    C.Matrix[i, j] = sum;
                }
            }
            return C;
        }
        public ClsMaTran ChuyenVi()
        {
            ClsMaTran C = new ClsMaTran();
            C.SoDong = this.SoCot;
            C.SoCot = this.SoDong;
            for (int i = 0; i < this.soDong; i++)
            {
                for (int j = 0; j < this.SoCot; j++)
                {
                    C.Matrix[j, i] = this.Matrix[i, j];
                }
            }
            return C;
        }
        public void NghichDao()
        {
            if (this.SoDong != this.soCot)
            {
                Console.WriteLine("There is no inverse matrix\n");
                return;
            }
            ClsMaTran B = new ClsMaTran();
            B.soDong = this.soDong;
            B.soCot = this.soDong;
            for (int i = 0; i < this.soDong; i++)
            {
                for (int j = 0; j < this.soDong; j++)
                {
                    B.Matrix[i, j] = Con(this, this.SoDong, i, j);
                }
            }
            for (int i = 0; i < this.SoDong - 1; i++)
            {
                for (int j = i + 1; j < this.SoDong; j++)
                {
                    double t = B.Matrix[i, j];
                    B.Matrix[i, j] = B.Matrix[j, i];
                    B.Matrix[j, i] = t;
                }
            }
            double k = Det(this, this.SoDong);
            for (int i = 0; i < this.SoDong; i++)
                for (int j = 0; j < this.SoDong; j++)
                    B.Matrix[i, j] /= k;
            if (k == 0) Console.WriteLine("There is no inverse matrix\n");
            else B.PrintfMatrix();
            return;
        }
        public double Det(ClsMaTran A, int n)
        {
            int i, j, k, dem = 0, kt = 0;
            double[] b = new double[100];
            double kq = 1, h;
            for (i = 0; i < n - 1; i++)
            {
                if (A.Matrix[i, i] == 0)
                {
                    kq = 0;
                    for (j = i + 1; j < n; j++)
                    {
                        if (A.Matrix[i, j] != 0)
                        {
                            for (k = 0; k < n; k++)
                            {
                                double t = A.Matrix[k, i];
                                A.Matrix[k, i] = A.Matrix[k, j];
                                A.Matrix[k, j] = t;
                            }
                            dem++;
                            kt++;
                            break;
                        }
                    }
                    if (kt == 0) return 0;
                }
                b[i] = A.Matrix[i, i];
                for (j = 0; j < n; j++) A.Matrix[i, j] /= b[i];
                for (j = i + 1; j < n; j++)
                {
                    h = A.Matrix[j, i];
                    for (k = 0; k < n; k++) A.Matrix[j, k] = A.Matrix[j, k] - h * A.Matrix[i, k];
                }

            }
            b[n - 1] = A.Matrix[n - 1, n - 1];
            for (i = 0; i < n; i++) kq *= b[i];
            if (dem % 2 == 0) return kq;
            return -kq;
        }
        private double Con(ClsMaTran A, int SoN, int h, int c)
        {
            ClsMaTran B = new ClsMaTran();
            B.soDong = SoN;
            B.soCot = SoN;
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
                    B.Matrix[x, y] = A.Matrix[i, j];
                }
            }
            if ((h + c) % 2 == 0) return Det(B, SoN - 1);
            return -Det(B, SoN - 1);
        }
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
        public ClsMaTran TinhCos()
        {
            double s;
            LayDoDai();
            ChuanHoaMatrix();

            ClsMaTran kq = new ClsMaTran();
            kq.SoCot = this.SoDong;
            kq.SoDong = this.SoDong;

            int t = 0, i = 0;
            for (; t < this.SoDong; t++)
            {
                for (i = t; i < this.SoDong; i++)
                {
                    s = 0;
                    for (int j = 0; j < this.SoCot; j++)
                    {
                        s += this.matrix[t, j] * this.matrix[i, j];
                    }
                    kq.matrix[i, t] = s;
                }
            }
            return kq;
        }
<<<<<<< HEAD

        #endregion

        //Operator
        #region
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
=======
       // public void WriteExcel()
        //{
        //    string fileName;
        //    Console.Write("Enter File Name :");
        //    fileName = Console.ReadLine();

        //    //Create excel app object
        //    Excel.Application xlSamp = new Microsoft.Office.Interop.Excel.Application();
        //    if (xlSamp == null)
        //    {
        //        Console.WriteLine("Excel is not Insatalled");
        //        Console.ReadKey();
        //        return;
        //    }

        //    //Create a new excel book and sheet
        //    Excel.Workbook xlWorkBook;
        //    Excel.Worksheet xlWorkSheet;
        //    object misValue = System.Reflection.Missing.Value;

        //    //Then add a sample text into first cell
        //    xlWorkBook = xlSamp.Workbooks.Add(misValue);
        //    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

        //    for (int i = 0; i < this.SoDong; i++)
        //    {
        //        for (int j = 0; j < this.SoCot; j++)
        //        {
        //            xlWorkSheet.Cells[i + 1, j + 1] = this.matrix[i, j];

        //        }
        //    }
>>>>>>> d5e59ec1e0245aa5f0bba9c76e98f317f94cfd3b

        }
        public static ClsMaTran operator -(ClsMaTran A, ClsMaTran B)
        {
            ClsMaTran C = new ClsMaTran();

<<<<<<< HEAD
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
        #endregion
        //
=======
        //    //Save the opened excel book to custom location
        //    string location = @"D:\" + fileName + ".xls";//Dont forget, you have to add to exist location
        //    xlWorkBook.SaveAs(location, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
        //    xlWorkBook.Close(true, misValue, misValue);
        //    xlSamp.Quit();

        //    //release Excel Object 
        //    try
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSamp);
        //        xlSamp = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        xlSamp = null;
        //        Console.Write("Error " + ex.ToString());
        //    }
        //    finally
        //    {
        //        GC.Collect();
        //    }

        //}
>>>>>>> d5e59ec1e0245aa5f0bba9c76e98f317f94cfd3b

    }
}
