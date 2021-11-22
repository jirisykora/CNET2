// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var strings = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

// 1 strings: preved strings na uppercase
var ustrings = strings.Select(x => x.ToUpper());

PrintList(ustrings.ToList());

 // 2 numbers: zjistit v poli suda cisla

bool isEvenNumbers = numbers.All(x => x % 2 == 0);

Console.WriteLine($"jsou vsechna cisla suda: {isEvenNumbers}");

// 3 -vypiste cisla v poli numbers jako slova

var result = numbers.Select(x => strings[x]);
PrintList(result.ToList());

// 4 - zjistěte kolik obsahují všechna
// slova v poli "strings" dohromady písmen

int count = strings.Select(x=> x.Length).Sum();
Console.WriteLine(count);

//foreach (var number in numbers)
//{
//    Console.WriteLine($"{strings[number]}");
//}





// PRINT LIST
static void PrintList(List<string> list)
{
    foreach (var item in list)
    {
        Console.WriteLine(item);
    }
}