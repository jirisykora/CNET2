// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var strings = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

// 1 preved strings na uppercase
var ustrings = strings.Select(x => x.ToUpper());

PrintList(ustrings.ToList());

 // 2 zjistit v poli suda cisla

bool isEvenNumbers = numbers.All(x => x % 2 == 0);

static void PrintList(List<string> list)
{
    foreach (var item in list)
    {
        Console.WriteLine(item);
    }
}