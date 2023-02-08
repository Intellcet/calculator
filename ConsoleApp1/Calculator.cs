using System.Collections;

namespace ConsoleApp1;

public class Calculator
{
    public Double add(Double a, Double b)
    {
        return a + b;
    }

    public Double sub(Double a, Double b)
    {
        return a - b;
    }
    
    public Double mult(Double a, Double b)
    {
        return a * b;
    }
    
    public Double div(Double a, Double b)
    {
        if (b != 0)
        {
            return a / b;
        }

        throw new Exception("Division on zero!");
    }

    public String calculate(String str)
    {
        var separatedString = str.Split(' ').Where(el => !el.Equals("")).ToArray();

        var sad = 0;
        var counter = 0;

        while (counter < separatedString.Length)
        {
            if (separatedString[counter] == "+")
            {
                var k = this.add(Double.Parse(separatedString[counter - 2]),
                Double.Parse(separatedString[counter - 1]));

                separatedString[counter - 2] = k.ToString();
                separatedString = separatedString.Where((el, idx) => idx != counter - 1).Where((el, idx) => idx != counter - 1).ToArray();
                counter -= 2;
                
            } else

            if (separatedString[counter] == "-")
            {
                var k = this.sub(Double.Parse(separatedString[counter - 2]), Double.Parse(separatedString[counter - 1]));
                
                separatedString[counter - 2] = k.ToString();
                
                separatedString = separatedString.Where((el, idx) => idx != counter - 1).Where((el, idx) => idx != counter - 1).ToArray();
                counter -= 2;
                
            } else

            if (separatedString[counter] == "*")
            {
                var k = this.mult(Double.Parse(separatedString[counter - 2]),
                Double.Parse(separatedString[counter - 1]));
                
                separatedString[counter - 2] = k.ToString();
                
                separatedString = separatedString.Where((el, idx) => idx != counter - 1).Where((el, idx) => idx != counter - 1).ToArray();
                counter -= 2;
                
            } else
            
            if (separatedString[counter] == "/") 
            {
                var k = this.div(Double.Parse(separatedString[counter - 2]), Double.Parse(separatedString[counter - 1]));
                
                separatedString[counter - 2] = k.ToString();
                
                separatedString = separatedString.Where((el, idx) => idx != counter - 1).Where((el, idx) => idx != counter - 1).ToArray();
                counter -= 2;
                
            }

            counter++;
        }
        
        return separatedString[0];
    }
}