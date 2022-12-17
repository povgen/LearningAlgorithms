// See https://aka.ms/new-console-template for more information
using myProject;
int[] sortedArr = { 0, 2, 3, 5, 6, 7, 8, 9, 10, 12, 22, 45, 77, 78 };
//List<int> unsortedList = new() { 3, 4, 5, 2, 0, 9, 3, 2, 7, 90, 54, 22, 4, 0, 2};
int[] unsortedList = { 3, 4, 5, 2, 0, 9, 3, 2, 7, 90, 54, 22, 4, 0, 2};

string[] mods =
{
    "1 - Binary search",
    "2 - Get smallest",
    "3 - Selections sort",
};

Console.WriteLine("Hello, World!");

Console.WriteLine("Please select mode:\n" + string.Join('\n', mods));
int mode = 3; //Helper.getIntFromUser()
switch (mode)
{
    case 1:
        Console.WriteLine("Please enter searched value");

        int searchVal = Helper.GetIntFromUser();

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
        Console.WriteLine(string.Join(' ', Algorithms.SelectionSortSecVer(unsortedList)));
    break;
    default:
        Console.WriteLine($"Entered mode not found!");
    break;
}


