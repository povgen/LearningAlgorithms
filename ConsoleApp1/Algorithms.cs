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


    public static int[] SelectionSortSecVer(int[] arr)
    {
        Stack<int> result = new();
		result.Push(arr[0]);
		int curPos = 0;
		for (int i = 0; i < arr.Length; i++)
		{
			for (int j = 0; j < arr.Length; j++)
			{
				if (arr[j] < result.Last()) { result.Push(arr[j]); break; }
			}
		}
        return result.ToArray();
    }
}
