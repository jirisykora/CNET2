﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var strings = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };


var ustrings = strings.Select(x => x.ToUpper());

foreach (var ustring in ustrings)
{
    Console.WriteLine(ustring);
}