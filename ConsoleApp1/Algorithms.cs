using System;
namespace myProject;
public static class Algorithms
{
	public static int? BinarySearch(int[] sortedArray, int searchValue, out int i)
	{
		i = 0;
		int low = 0;
        int hight = sortedArray.Length - 1;

		while (low <= hight)
		{
            int mid = (Int32)Math.Round((low + hight)/ 2.0);
			int guess = sortedArray[mid];
			if (guess == searchValue)
				return mid;
			else if (guess > searchValue)
				hight = mid - 1;
			else 
				low = mid + 1;
			i++;
        }

        return null;
	}

    //TODO binarySearch
    public static int? BinarySearchRecursive(int[] sortedArray, int searchValue) => BinarySearchRecursive(sortedArray, searchValue, 0, sortedArray.Length-1);


    public static int? BinarySearchRecursive(int[] sortedArray, int searchValue, int low, int hight)
	{
		if(low > hight) return null;

        int mid = (Int32)Math.Round((low + hight) / 2.0);

		if (sortedArray[mid] == searchValue) return mid;

		if (sortedArray[mid] > searchValue) hight = mid - 1;
        else low = mid + 1;

        return BinarySearchRecursive(sortedArray, searchValue, low, hight);

    }

	public static int? BinarySearchRecursiveSecVer(int[] sortedArray, int searchValue) => BinarySearchRecursiveSecVer(new List<int>(sortedArray), searchValue);

    public static int? BinarySearchRecursiveSecVer(List<int> sortedArray, int searchValue, int offset = 0)
    {
        if (sortedArray.Count == 0) return null;

        int mid = (Int32)Math.Floor(sortedArray.Count / 2.0);

		if (sortedArray[mid] == searchValue) return offset + mid;


		return sortedArray[mid] > searchValue ? BinarySearchRecursiveSecVer(sortedArray.GetRange(0, mid), searchValue, offset) 
			: BinarySearchRecursiveSecVer(sortedArray.GetRange(mid, sortedArray.Count - 1), offset + mid);

    }

    /// <param name="arr"></param>
    /// <returns>index of smallest elemnt of array</returns>
    public static int FindSmallest(int[] arr)
	{
		int smallestIndex = 0;
		for (int i = 1; i < arr.Length; i++)
		{
			if (arr[i] < arr[smallestIndex])
			{
				smallestIndex = i;
			}
		}
		return smallestIndex;

    }

    /// <summary>Extract the smallest elment from List </summary>
    /// <param name="arr"></param>
    /// <returns>smallest element in List</returns>
    public static int PopSmallestElement(ref List<int> arr)
    {
        int smallestEl = arr[0];
        arr.ForEach((el) => {
            if (el < smallestEl) smallestEl = el;
        });
		arr.Remove(smallestEl);
        return smallestEl;
    }

    public static List<int> SelectionSort(List<int> arr)
	{
		List<int> result = new();
		while (arr.Count > 0) { result.Add(PopSmallestElement(ref arr)); }
		return result;
	}

	public static int Sum(int[] arr) => Sum(new Stack<int>(arr));	

	public static int Sum(Stack<int> arr) => arr.Count == 0 ? 0 : arr.Pop() + Sum(arr);


    public static int Count(int[] arr) => Count(new Stack<int>(arr));

    public static int Count(Stack<int> arr)	
	{
		if (arr.Count == 0) return 0;
		arr.Pop();
		return 1 + Count(arr);
	}

	public static int Max(int[] arr) => Max(new Stack<int>(arr), arr[0]);

	public static int Max(Stack<int> arr, int max) 
	{
		if (arr.Count == 0) return max;
		var curEl = arr.Pop();
		if (max < curEl) max = curEl;
		return Max(arr, max);

    }

	public static int MaxVerSec(int[] arr) => MaxVerSec(new List<int>(arr));

    public static int MaxVerSec(List<int> arr)
    {
        if (arr.Count == 2) return arr[0] > arr[1] ? arr[0] : arr[1];

		int sub_max = MaxVerSec(arr.GetRange(1, arr.Count - 1));

		return arr[0] > sub_max ? arr[0] : sub_max;

    }


}
