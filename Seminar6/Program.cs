
public class Program
{

    //Дан массив и число.Найдите три числа в массиве сумма которых равна искомому числу.
    //Подсказка: если взять первое число в массиве, можно ли найти в оставшейся его части два
    //числа равных по сумме первому.

    public static void Main(string[] args)
    {
        int[] array = { 1, 2, 3, 4, 5, 6, 7 };
        int targetSum = 10;

        List<int[]> result = FindThreeNumbersWithSum(array, targetSum);

        if (result.Count > 0)
        {
            foreach (int[] triplet in result)
            {
                Console.WriteLine($"Triplet: {triplet[0]}, {triplet[1]}, {triplet[2]}");
            }
        }
        else
        {
            Console.WriteLine("No triplets found.");
        }
    }

    public static List<int[]> FindThreeNumbersWithSum(int[] array, int targetSum)
    {
        List<int[]> triplets = new List<int[]>();

        for (int i = 0; i < array.Length - 2; i++)
        {
            int firstNum = array[i];
            int remainingSum = targetSum - firstNum;
            HashSet<int> seen = new HashSet<int>();

            for (int j = i + 1; j < array.Length; j++)
            {
                int secondNum = array[j];
                int thirdNum = remainingSum - secondNum;

                if (seen.Contains(thirdNum))
                {
                    int[] triplet = { firstNum, secondNum, thirdNum };
                    triplets.Add(triplet);
                }

                seen.Add(secondNum);
            }
        }

        return triplets;
    }
}