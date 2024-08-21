namespace ConsoleApp1;

public class Task67
{
    public string AddBinary(string a, string b)
    {
        var result = new List<char>();
        var length = Math.Max(a.Length, b.Length);
        var overflow = false;
        for (int i = 0; i < length; i++)
        {
            if (i < a.Length && i < b.Length)
            {
                if (a[a.Length - i - 1] == '1' && b[b.Length - i - 1] == '1')
                {
                    if (overflow)
                    {
                        result.Add('1');
                    }
                    else
                    {
                        result.Add('0');
                        overflow = true;
                    }
                }
                else if (a[a.Length - i - 1] == '0' && b[b.Length - i - 1] == '0')
                {
                    if (overflow)
                    {
                        result.Add('1');
                        overflow = false;
                    }
                    else
                    {
                        result.Add('0');
                    }
                }
                else if (a[a.Length - i - 1] == '1')
                {
                    if (overflow)
                    {
                        result.Add('0');
                    }
                    else
                    {
                        result.Add('1');
                        overflow = false;
                    }
                }
                else
                {
                    if (overflow)
                    {
                        result.Add('0');
                    }
                    else
                    {
                        result.Add('1');
                        overflow = false;
                    }
                }
            }
            else if (i < a.Length)
            {
                if (overflow)
                {
                    if (a[a.Length - i - 1] == '0')
                    {
                        result.Add('1');
                        overflow = false;
                    }
                    else
                    {
                        result.Add('0');
                    }
                }
                else
                {
                    result.Add(a[a.Length - i - 1]);
                }
            }
            else
            {
                if (overflow)
                {
                    if (b[b.Length - i - 1] == '0')
                    {
                        result.Add('1');
                        overflow = false;
                    }
                    else
                    {
                        result.Add('0');
                    }
                }
                else
                {
                    result.Add(b[b.Length - i - 1]);
                }
            }
        }
        if (overflow)
        {
            result.Add('1');
        }

        result.Reverse();
        return new string(result.ToArray());
    }
}

