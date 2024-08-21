namespace ConsoleApp1;

public class Task1442
{
    public int CountTriplets(int[] arr)
    {
        if (arr.Length < 2) return 0;
        var result = 0;
        if (arr.Length > 1)
        {
            for (int i = 0, a = 0, b = 0; i < arr.Length - 1; i++)
            {
                a = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (j > i + 1)
                    {
                        a ^= arr[j - 1];
                    }
                    b = arr[j];
                    for (int k = j; k < arr.Length; k++)
                    {
                        if (k > j)
                        {
                            b ^= arr[k];
                        }

                        if (a == b)
                        {
                            result++;
                        }
                    }
                }
            }
        }

        return result;
    }
}
