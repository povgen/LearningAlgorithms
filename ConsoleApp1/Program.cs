// See https://aka.ms/new-console-template for more information
using myProject;
int[] sortedArr = { 0, 2, 3, 5, 6, 7, 8, 9, 10, 12, 22, 45, 77, 78 };
List<int> unsortedList = new() { 3, 4, 5, 2, 0, 9, 3, 2, 7, 90, 54, 22, 4, 0, 2};
int[] unsortedArr = { 3, 4, 5, 2, 0, 9, 3, 2, 7, 90, 54, 22, 4, 0, 2};

string[] mods =
{
    "1 - Binary search",
    "2 - Get smallest",
    "3 - Selections sort",
    "4 - Recursive sum",
    "5 - Recursive count",
    "6 - Recursive max",
    "7 - Binary search recursive",
    "8 - Recursive max - book's resolve",
    "9 - QuickSort"

};

Console.WriteLine("Hello, World!");

Console.WriteLine("Please select mode:\n" + string.Join('\n', mods));
int mode = Helper.GetIntFromUser(); // 3
int searchVal;
switch (mode)
{
    case 1:
        Console.WriteLine("Please enter searched value");

        searchVal = Helper.GetIntFromUser();

        int i;
        int? res = Algorithms.BinarySearch(sortedArr, searchVal, out i);
        if (res.HasValue)
            Console.WriteLine($"Index searched num: {res.Value}. Was done {i} iteration");
        else
            Console.WriteLine($"Searched num wasn't find D:. Was done {i} iteration");
    break;

    case 2: Console.WriteLine("The smallest num is: "+ sortedArr[Algorithms.FindSmallest(sortedArr)]); break;

    case 3:
        Console.WriteLine(string.Join(' ', unsortedList));
        Console.WriteLine(string.Join(' ', Algorithms.SelectionSort(unsortedList)));
    break;

    case 4: Console.WriteLine("Sum ("+ string.Join(", ", sortedArr)+") = " + Algorithms.Sum(sortedArr)); break;
    case 5: Console.WriteLine("Count ("+ sortedArr.Count()+ ") ("+ string.Join(", ", sortedArr)+") = " + Algorithms.Count(sortedArr)); break;
    case 6: Console.WriteLine("Max ("+ sortedArr.Max()+ ") ("+ string.Join(", ", sortedArr)+") = " + Algorithms.Max(sortedArr)); break;

    case 7:
        Console.WriteLine("Please enter searched value");

        searchVal = Helper.GetIntFromUser();

        var searched = Algorithms.BinarySearchRecursive(sortedArr, searchVal);
        var searched2 = Algorithms.BinarySearchRecursiveSecVer(sortedArr, searchVal);

        if (searched == null) searched = -1;
        if (searched2 == null) searched2 = -1;
            Console.WriteLine($"Index searched num: {searched.Value} / {searched2.Value}.");
     break;

    case 8: Console.WriteLine("Max (" + sortedArr.Max() + ") (" + string.Join(", ", sortedArr) + ") = " + Algorithms.MaxVerSec(sortedArr)); break;


    case 9:
        Console.WriteLine(string.Join(' ', unsortedList));
        Console.WriteLine(string.Join(' ', Algorithms.QuickSort(unsortedArr)));
    break;


    default:
        Console.WriteLine($"Entered mode not found!");
    break;
}


