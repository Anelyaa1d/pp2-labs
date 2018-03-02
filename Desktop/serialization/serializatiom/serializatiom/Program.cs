using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace serializatiom
{
    [Serializable]
    class Complex
    {
        
        public int c1;
        public int c2;

      
        public Complex()
        {

        }
        public Complex(int _c1, int _c2)
        {
            c1 = _c1;
            c2 = _c2;
        }

        public override string ToString()
        {
            return $"C1 - {c1} : C2 - {c2}";
        }


        public static void SerializeToBinary()
        {
            FileStream fs = new FileStream(@"Complex.ser", FileMode.Create, FileAccess.Write);

            Complex com = new Complex();
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                bf.Serialize(fs, com);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        public static void DeserializeFromBinary(string pathToFile)
        {
            FileStream fs = new FileStream(pathToFile, FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                Complex c = bf.Deserialize(fs) as Complex;

                Console.WriteLine(c);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Complex complex = new Complex(5, 2);
            //Complex.SerializeToBinary();
            Complex.DeserializeFromBinary("Complex.ser");
            Console.ReadKey();
        }
    }
}
