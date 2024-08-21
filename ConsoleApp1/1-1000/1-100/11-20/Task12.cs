using System.Text;

namespace ConsoleApp1;

public class Task12
{
    public static string IntToRoman(int num)
    {
        var result = new StringBuilder();
        var current = num;
        var thousands = (current - current % 1000) / 1000;
        if (thousands > 0)
        {
            result.Append(ThousandsToRoman(thousands));
        }
        current %= 1000;
        var hundreds = (current - current % 100) / 100;
        if (hundreds > 0)
        {
            result.Append(ToRoman(hundreds, 'M', 'D', 'C'));
        }
        current %= 100;
        var decades = (current - current % 10) / 10;
        if (decades > 0)
        {
            result.Append(ToRoman(decades, 'C', 'L', 'X'));
        }
        current %= 10;
        if (current > 0)
        {
            result.Append(ToRoman(current, 'X', 'V', 'I'));
        }
        return result.ToString();
    }

    private static string ThousandsToRoman(int thousands)
    {
        var builder = new StringBuilder();
        for (int i = 0; i < thousands; i++)
        {
            builder.Append('M');
        }

        return builder.ToString();
    }

    private static string ToRoman(int number, char highNumber, char centerNumber, char currentNumber)
    {
        var builder = new StringBuilder();
        if (number == 9)
        {
            builder.Append(currentNumber);
            builder.Append(highNumber);
        }
        else if (number >= 5)
        {
            builder.Append(centerNumber);
            for (int i = 0; i < number - 5; i++)
            {
                builder.Append(currentNumber);
            }
        }
        else if (number == 4)
        {
            builder.Append(currentNumber);
            builder.Append(centerNumber);
        }
        else
        {
            for (int i = 0; i < number; i++)
            {
                builder.Append(currentNumber);
            }
        }

        return builder.ToString();
    }
}
