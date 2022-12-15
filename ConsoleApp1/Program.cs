// See https://aka.ms/new-console-template for more information
using myProject;

Console.WriteLine("Hello, World!");
Console.WriteLine("Please enter searched value");


int[] arr = { 0, 2, 3, 5, 6, 7, 8, 9, 10, 12, 22, 45, 77, 78 };
int searchVal;

while (!Int32.TryParse(Console.ReadLine(), out searchVal)) Console.WriteLine("Enter correct integer number!");

int i;
int? res = Algorithms.BinarySearch(arr, searchVal, out i);
if (res.HasValue)
    Console.WriteLine($"Index searched num: {res.Value}. Was done {i} iteration");
else
    Console.WriteLine($"Searched num wasn't find D:. Was done {i} iteration");
