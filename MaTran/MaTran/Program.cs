using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaTran
{
    class Program
    {
        static void Main(string[] args)
        {            
            ClsMaTran maTran = new ClsMaTran();
            maTran.RanDomMatrix(1000, 1000);
            //maTran.EnterMatrix( );
            //maTran.PrintfMatrix();
         
            ClsMaTran maTran2 = new ClsMaTran();
            maTran2.RanDomMatrix(1000, 1000);
            //maTran2.EnterMatrix();
            //maTran2.PrintfMatrix();

            maTran = maTran.Nhan(maTran, maTran2);
            //maTran.PrintfMatrix();
            maTran.WriteTxt();
            Console.WriteLine("Complete!\n");
            Console.ReadKey();
        }
    }
}
