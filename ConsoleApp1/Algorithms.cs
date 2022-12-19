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


}
