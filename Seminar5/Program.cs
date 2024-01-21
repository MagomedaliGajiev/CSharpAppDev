namespace Seminar5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] labyrinth = new int[5, 5, 5];
            Console.Write(HasExit(0, 0, 0, labyrinth));
        }

        static int HasExit(int startI, int startJ, int startK, int[,,] array)
        {
            if (!IsEmpty(startI, startJ, startK, array))
                return 0;

            int count = 0;
            array[startI, startJ, startK] = 2;

            if (startI == 0 && startJ == 0 && startK == 0
                || startI == 0 && startJ == 0 && startK == array.GetLength(2) - 1
                || startI == 0 && startJ == array.GetLength(1) - 1 && startK == 0
                || startI == 0 && startJ == array.GetLength(1) - 1 && startK == array.GetLength(2) - 1
                || startI == array.GetLength(0) - 1 && startJ == 0 && startK == 0
                || startI == array.GetLength(0) - 1 && startJ == 0 && startK == array.GetLength(2) - 1
                || startI == array.GetLength(0) - 1 && startJ == array.GetLength(1) - 1 && startK == 0
                || startI == array.GetLength(0) - 1 && startJ == array.GetLength(1) - 1 && startK == array.GetLength(2) - 1)
                count += 2;
            else if (startI == 0 || startJ == 0 || startK == 0 || startI == array.GetLength(0) - 1 || startJ == array.GetLength(1) - 1 || startK == array.GetLength(2) - 1)
                count++;

            count += HasExit(startI, startJ, startK + 1, array);
            count += HasExit(startI, startJ, startK - 1, array);
            count += HasExit(startI, startJ + 1, startK, array);
            count += HasExit(startI, startJ - 1, startK, array);
            count += HasExit(startI + 1, startJ, startK, array);
            count += HasExit(startI - 1, startJ, startK, array);

            return count;
        }

        static bool IsEmpty(int x, int y, int z, int[,,] array)
        {
            if (x < 0 || x >= array.GetLength(0))
                return false;
            if (y < 0 || y >= array.GetLength(1))
                return false;
            if (z < 0 || z >= array.GetLength(2))
                return false;
            return array[x, y, z] == 0;
        }
    }
}
