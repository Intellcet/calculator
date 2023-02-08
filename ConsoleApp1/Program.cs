namespace ConsoleApp1;

class Hello {         
    static void Main(string[] args)
    {
        Parse parse = new Parse();
        Calculator calculator = new Calculator();

        String str = Console.ReadLine() ?? throw new Exception("Empty string!");

        var parsedStr = parse.getPrefixNotation(str);
        parse.isParsedStrValid(parsedStr);
        
        System.Console.WriteLine(parsedStr);

        var answer = calculator.calculate(parsedStr);
        System.Console.WriteLine(answer);
    }
}