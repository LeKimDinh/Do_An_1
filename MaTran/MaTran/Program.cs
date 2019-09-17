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
            maTran.EnterMatrix( maTran);
            maTran.PrintfMatrix(maTran);
         
            ClsMaTran maTran2 = new ClsMaTran();
            maTran.EnterMatrix(maTran2);
            maTran.PrintfMatrix(maTran2);

            maTran.Cong(maTran, maTran2);
          
            Console.ReadKey();
        }
    }
}
