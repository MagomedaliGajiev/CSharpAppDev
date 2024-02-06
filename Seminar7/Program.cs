namespace Seminar9
{
    public class Program
    {
        static void Main(string[] args)
        {
            TestClass originalObj = new TestClass(42, "Hello", 3.14m, new char[] { 'a', 'b', 'c' });

            string savedData = ReflectionExample.SaveClassToString(originalObj);
            Console.WriteLine(savedData);

            TestClass restoredObj = ReflectionExample.LoadClassFromString(savedData);
            Console.WriteLine($"I: {restoredObj.I}");
            Console.WriteLine($"S: {restoredObj.S}");
            Console.WriteLine($"D: {restoredObj.D}");
            Console.WriteLine($"C: {string.Join(", ", restoredObj.C)}");
        }    
    }
}