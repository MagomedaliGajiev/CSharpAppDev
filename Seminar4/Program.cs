using Classes;

namespace Seminar4
{
    class Program
    {
        static void Main(string[] arg)
        {
           

            var vector = new Vector<double>();

            vector.a = 5;
            vector.b = 2;
            vector.c = 8;

            Console.Write(vector);
        }
    }
}