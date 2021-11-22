// See https://aka.ms/new-console-template for more information
using Playground;
using System.Linq;

Console.WriteLine("Hello, World!");

var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var strings = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

//// 1 strings: preved strings na uppercase
//var ustrings = strings.Select(x => x.ToUpper());

//PrintList(ustrings.ToList());

// // 2 numbers: zjistit v poli suda cisla

//bool isEvenNumbers = numbers.All(x => x % 2 == 0);

//Console.WriteLine($"jsou vsechna cisla suda: {isEvenNumbers}");

//// 3 -vypiste cisla v poli numbers jako slova

//var result = numbers.Select(x => strings[x]);
//PrintList(result.ToList());
////foreach (var number in numbers)
////{
////    Console.WriteLine($"{strings[number]}");
////}


//// 4 - zjistěte kolik obsahují všechna
//// slova v poli "strings" dohromady písmen

//var count = strings.Select(x=> x.Length).Sum();
//Console.WriteLine($"Soucet vsech pismen v poli strings: {count}");

//// 5 - 

//var strUL = strings.Select(x => new UpperLowerString(x))
//                   .Select(objX => $"upper:{objX.UpperCase} lower:{objX.LowerCase}");

//PrintList(strUL.ToList()); 
// // 5 - pomoci tuplu

//var res = strings.Select(slovo => (slovo.ToUpper(), slovo.ToLower()));

//PrintItems<(string, string)>(res);

//// 6 -frekvence vyskytu jednotlivych pismen ve vsech polozkach pole strings

//var OneString = string.Join("", strings);  // spojim slova do jednoho retezce
//var res2 = OneString                                   // pracuji se stringem jako s kolekci znaku
//                    .GroupBy(x => x)                   // seskupuji podle pismenek (char v lkolekci string)
//                    .Select(g => (g.Key, g.Count()))   // udelam tuple obsahujici klic a pocet vyskytu
//                    .OrderByDescending(x => x.Item2)
//                    .ThenBy(x => x.Key)
//                    ;    
//PrintItems<(char, int)>(res2);

// 7. Dictionary

var bookdir = @"D:\Source\Repos\CNET2\CNET2\Playground\Books";

foreach (var file in GetFilesFromDir(bookdir))
{
    var dict = TextTools.TextTools.FreqAnalyze(file);
    var top10 = TextTools.TextTools.GetTopWord(10, dict);

    var fi = new FileInfo(file);

    Console.WriteLine("KNIHA: " + fi.Name);
    PrintList(top10.Select(x => $"{x.Key} : {x.Value}").ToList());
    Console.WriteLine();
}


Console.WriteLine();


// PRINT LIST
static void PrintList(List<string> list)
{
    foreach (var item in list)
    {
        Console.WriteLine(item);
    }
}

static void PrintItems<T>(IEnumerable<T> items)
{
    foreach(var item in items)
    {
        Console.WriteLine(item);
    }
}

static Dictionary<char, int> CharFreq(string input)
{
    var tuples = input                                 // pracuji se stringem jako s kolekci znaku
                    .GroupBy(x => x)                   // seskupuji podle pismenek (char v lkolekci string)
                    .Select(g => (g.Key, g.Count()))   // udelam tuple obsahujici klic a pocet vyskytu
                    .OrderByDescending(x => x.Item2)
                    .ThenBy(x => x.Key)
                    ;

    Dictionary<char, int> dict = new Dictionary<char, int>();

    foreach (var item in tuples)
    {
        dict.Add(item.Key, item.Item2);
    }

    return dict;


}

static IEnumerable<string> GetFilesFromDir(string dir)
{
    return Directory.EnumerateFiles(dir);
}