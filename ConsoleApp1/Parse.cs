using System.Collections;

namespace ConsoleApp1;

public class Parse
{
    private Boolean isNumber(char symbol)
    {
        switch (symbol)
        {
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9':
            case '0':
                return true;
            default:
                return false;
        }
    }

    public void isParsedStrValid(String str)
    {
        if (str.Contains('('))
        {
            throw new Exception("Открывающих скобок слишком много!");
        }
    }
    
    public String getPrefixNotation(String str)
    {
        ArrayList stack = new ArrayList();
        String res = "";

        for (int i = 0; i < str.Length; i++)
        {
            if (isNumber(str[i]) || str[i] == ' ' || str[i] == ',')
            {
                res += str[i];
                continue;
            }

            if (str[i].Equals('('))
            {
                stack.Add(str[i]);
                continue;
            }

            if (str[i].Equals(')'))
            {
                var isOpenExists = false;
                if (stack.Count != 0)
                {
                    for (var j = stack.Count - 1; j >= 0; j--)
                    {
                        if (!stack[j].Equals('('))
                        {
                            isOpenExists = true;
                            res += " " + stack[j];
                            stack.RemoveAt(j);
                        }
                        else
                        {
                            stack.RemoveAt(j);
                            break;
                        }
                    }
                }

                if (!isOpenExists)
                {
                    throw new Exception("Скобки поставлены некорректно!");
                }
                continue;
            }

            if (isSymbolFunction(str[i]))
            {
                var k = 0;
                var count = 0;
                if (stack.Count != 0)
                {
                    for (k = stack.Count - 1; k >= 0; k--)
                    {
                        var currentFunPriority = getPriority(str[i]);
                        var stackFunPriority = getPriority((char)stack[k]);
                        if (isSymbolFunction((char)stack[k]) &&  stackFunPriority >= currentFunPriority)
                        {
                            count++;
                            res += " " + stack[k];
                        }
                        else
                        {
                            break;
                        }
                    }

                    stack.RemoveRange(stack.Count - count, count);
                }

                stack.Add(str[i]);
            }
        }

        while (stack.Count > 0)
        {
            res += " " + stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
        }

        return res;
    }

    private Boolean isSymbolFunction(char symbol)
    {
        switch (symbol)
        {
            case '+':
            case '-':
            case '*':
            case '/':
                return true;

            default:
                return false;
        }
    }

    private int getPriority(char symbol)
    {
        switch (symbol)
        {
            case '+':
            case '-':
                return 1;

            case '*':
            case '/':
                return 2;

            case '(':
            case ')':
            default:
                return 0;
        }
    }
}