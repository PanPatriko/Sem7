using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lab1Wcf
{
    public class ComplexCalculator : IComplexCalculator
    {
        public Complex Add(Complex a, Complex b)
        {
            return CalcAdd(a.Real, a.Imag, b.Real, b.Imag);
        }

        public Complex Add(double ar, double ai, double br, double bi)
        {
            return CalcAdd(ar, ai, br, bi);
        }

        private Complex CalcAdd(double ar, double ai, double br, double bi)
        {
            Complex complex = new Complex();
            complex.Real = ar + br;
            complex.Imag = ai + bi;
            return complex;
        }
        public Complex Divide(Complex a, Complex b)
        {
                return CalcDivide(a.Real, a.Imag, b.Real, b.Imag);        
        }

        public Complex Divide(double ar, double ai, double br, double bi)
        {
                return CalcDivide(ar, ai, br, bi);
        }

        private Complex CalcDivide(double ar, double ai, double br, double bi)
        {
            if(br == 0 && bi == 0 )
            {

                DivideByZeroException exception = new DivideByZeroException
                {
                    Message = "Divisor should be non-zero.",
                    Details = @"Dividing a number by 0 will always give you infinity, please enter a non-zero number for divisor.",
                    Divident = new Complex { Real = ar, Imag = ai}
                };
                throw new FaultException<DivideByZeroException>(exception,new FaultReason(new FaultReasonText("Divide by zero")));
            }
            Complex complex = new Complex();
            complex.Real = ((ar * br) + (ai * bi)) / ((Math.Pow(br, 2) + Math.Pow(bi, 2)));
            complex.Imag = (-(ar * bi) + (ai * br)) / ((Math.Pow(br, 2) + Math.Pow(bi, 2)));
            return complex;
        }
        public Complex Multiply(Complex a, Complex b)
        {
            return CalcMultiply(a.Real, a.Imag, b.Real, b.Imag);
        }

        public Complex Multiply(double ar, double ai, double br, double bi)
        {
            return CalcMultiply(ar, ai, br, bi);
        }

        private Complex CalcMultiply(double ar, double ai, double br, double bi)
        {
            Complex complex = new Complex();
            complex.Real = ((ar * br) - (ai * bi));
            complex.Imag = (ar * bi) + (ai * br);
            return complex;
        }
        public Complex Substract(Complex a, Complex b)
        {
            return CalcSubstract(a.Real, a.Imag, b.Real, b.Imag);
        }

        public Complex Substract(double ar, double ai, double br, double bi)
        {
            return CalcSubstract(ar, ai, br, bi);
        }
        private Complex CalcSubstract(double ar, double ai, double br, double bi)
        {
            Complex complex = new Complex();
            complex.Real = ar - br;
            complex.Imag = ai - bi;
            return complex;
        }
    }
}
