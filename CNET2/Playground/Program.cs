// See https://aka.ms/new-console-template for more information
using Playground;
using System.Diagnostics;
using System.Linq;

Console.WriteLine("Hello, World!");

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

// https://www.gutenberg.org/cache/epub/2036/pg2036.txt
// https://www.gutenberg.org/files/16749/16749-0.txt
// https://www.gutenberg.org/cache/epub/19694/pg19694.txt
// stahnete texty z techto tri adres a paralelne provedte textovou analyzu
// a vypiste vysledky - kazdou knihu samostatne

var client = new HttpClient();
var res1 = await client.GetAsync("https://www.gutenberg.org/cache/epub/2036/pg2036.txt");
var res2 = await client.GetAsync("https://www.gutenberg.org/files/16749/16749-0.txt");
var res3 = await client.GetAsync("https://www.gutenberg.org/cache/epub/19694/pg19694.txt");

if (res1.IsSuccessStatusCode)
    {
        var content1 = await res1.Content.ReadAsStringAsync();
        var task1 = Task.Run(() =>
        {
            var dict = TextTools.TextTools.FreqAnalyzeFromString(content1);
            var top10 = TextTools.TextTools.GetTopWord(10, dict);

            Console.WriteLine("TASK1 - https://www.gutenberg.org/cache/epub/2036/pg2036.txt");
            PrintItems(top10); 
        });
        task1.Wait();
}

if (res2.IsSuccessStatusCode)
{
    var content2 = await res2.Content.ReadAsStringAsync();
    var task2 = Task.Run(() =>
    {
        var dict = TextTools.TextTools.FreqAnalyzeFromString(content2);
        var top10 = TextTools.TextTools.GetTopWord(10, dict);

        Console.WriteLine("TASK2 - https://www.gutenberg.org/files/16749/16749-0.txt");
        PrintItems(top10);
    });
    task2.Wait();
}

if (res3.IsSuccessStatusCode)
{
    var content3 = await res3.Content.ReadAsStringAsync();
    var task3 = Task.Run(() =>
    {
        var dict = TextTools.TextTools.FreqAnalyzeFromString(content3);
        var top10 = TextTools.TextTools.GetTopWord(10, dict);

        Console.WriteLine("TASK3 - https://www.gutenberg.org/cache/epub/19694/pg19694.txt");
        PrintItems(top10);
    });
    task3.Wait();
}

stopwatch.Stop();
Console.WriteLine(Environment.NewLine + "elapsed time (ms): " + stopwatch.ElapsedMilliseconds);

Console.WriteLine();



//// Tasks example
//static void async TaskExample() { 
//    var task1 = Task.Run(() =>
//    {
//        TextTools.TextTools.FreqAnalyzeFromFile(@"D:\Source\Repos\CNET2\CNET2\BigFiles\words01.txt", Environment.NewLine);
//        Console.WriteLine("Task 1 finished.");
//    });


//    var task2 = Task.Run(() =>
//    {
//        TextTools.TextTools.FreqAnalyzeFromFile(@"D:\Source\Repos\CNET2\CNET2\BigFiles\words09.txt", Environment.NewLine);
//        Console.WriteLine("Task 2 finished.");
//    });


//    await Task.WhenAny(task1, task2);


//    Console.WriteLine("Program finished.");
//    Console.WriteLine();
//}



//var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
//var strings = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

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

//var bookdir = @"D:\Source\Repos\CNET2\CNET2\Playground\Books";
//var str = "123456";

////Console.WriteLine(Char.IsDigit(str));

//foreach (var file in GetFilesFromDir(bookdir))
//{
//    var dict = TextTools.TextTools.FreqAnalyze(file);
//    var top10 = TextTools.TextTools.GetTopWord(10, dict);

//    var fi = new FileInfo(file);

//    Console.WriteLine("KNIHA: " + fi.Name);
//    PrintList(top10.Select(x => $"{x.Key} : {x.Value}").ToList());
//    Console.WriteLine();
//}


//Console.WriteLine();


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