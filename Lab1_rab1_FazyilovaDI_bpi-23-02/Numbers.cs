using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_rab1_FazyilovaDI_bpi_23_02
{
    public class Numbers
    {
        private int a;
        private int b;
        private int c;
        private int d;
        //private bool flag;
        public int A
        {
            get { return a; }
            set { a = value; }
        }
        public int B
        {
            get { return b; }
            set { b = value; }
        }
        public int C
        {
            get { return c; }
            set { c = value; }
        }
        public int D
        {
            get { return d; }
            set { d = value; }
        }
       /* public bool Flag
        {
            get { return flag; }
            set { flag = value; }
        } */
        public Numbers( int a, int b, int c, int d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }
        public double ArithmeticMean()
        {
            return (A + B + C + D) / 4.0;
        }
        public int MaxNumber()
        {
            int max = A;
            if (B > max) max = B;
            if (C > max) max = C;
            if (D > max) max = D;
            return max;
        }
    }
}
