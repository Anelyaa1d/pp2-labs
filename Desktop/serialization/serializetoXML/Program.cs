using System;
using System.IO;
using System.Xml.Serialization;

namespace serializetoXML
{
    [Serializable]
    public class Complex
    {
        public int l1;
        public int l2;
        public Complex()
        {

        }
        public Complex(int _l1, int _l2)
        {
            l1 = _l1;
            l2 = _l2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Complex complex = new Complex(3, 5);
            Console.WriteLine("object created");
            XmlSerializer formatter = new XmlSerializer(typeof(Complex));
            /*using (FileStream fs = new FileStream("complex.xml", FileMode.Create))
            {
                formatter.Serialize(fs, complex);
                Console.WriteLine("object serialized");
            }*/
            //deserialization
            using (FileStream fs = new FileStream("complex.xml", FileMode.Open))
            {
                Complex newComplex = (Complex)formatter.Deserialize(fs);
                Console.WriteLine("object deserialized");
                Console.WriteLine("L1 - {5} : L2 - {2}");
            }
        }
    }
}

