using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lab1Wcf
{
    [ServiceContract]
    public interface IComplexCalculator
    {

        [OperationContract (Name = "AddComplexData")]
        Complex Add(Complex a, Complex b);

        [OperationContract (Name = "AddDoubleData")]
        Complex Add(double ar,double ai, double br, double bi);

        [OperationContract (Name = "SubstractComplexData")]
        Complex Substract(Complex a, Complex b);

        [OperationContract (Name = "SubstractDoubleData")]
        Complex Substract(double ar, double ai, double br, double bi);

        [OperationContract (Name = "DivideComplexData")]
        [FaultContract(typeof(DivideByZeroException))]
        Complex Divide(Complex a, Complex b);

        [OperationContract (Name = "DivideDoubleData")]
        [FaultContract(typeof(DivideByZeroException))]
        Complex Divide(double ar, double ai, double br, double bi);

        [OperationContract (Name = "MultiplyComplexData")]
        Complex Multiply(Complex a, Complex b);

        [OperationContract (Name = "MultiplyDoubleData")]
        Complex Multiply(double ar, double ai, double br, double bi);

    }

    [DataContract]
    public class DivideByZeroException
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Details { get; set; }

        [DataMember]
        public Complex Divident { get; set; }
    }

    [DataContract]
    public class Complex
    {
        double real;
        double imag;

        [DataMember]
        public double Real
        {
            get { return real; }
            set { real = value; }
        }

        [DataMember]
        public double Imag
        {
            get { return imag; }
            set { imag = value; }
        }
    }
}

