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
    {//here somwhe error on searchValue = 3
        if (sortedArray.Count == 0) return -5;
        if (sortedArray.Count == 1) return sortedArray[0] == searchValue ? searchValue : null;

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

	public static int[] QuickSort(int[] arr)
	{
		if (arr.Length < 2) return arr;
		int[] pivot = { arr[0] };

        Stack<int> less = new Stack<int>();
        Stack<int> greater = new Stack<int>();

		for (int i = 1; i < arr.Length; i++)
		{
			if (arr[i] < pivot[0]) less.Push(arr[i]);
			else greater.Push(arr[i]);
		}


		return QuickSort(less.ToArray<int>()).Concat(pivot.Concat(QuickSort(greater.ToArray<int>()))).ToArray<int>();

    }



    public static int[] QuiickSortV2(int[] array) => QuiickSortV2(array, 0, array.Length-1);
    public static int[] QuiickSortV2(int[] array, int leftIndex, int rightIndex) //из интернета
    {
        var i = leftIndex;
        var j = rightIndex;
        var pivot = array[leftIndex];

        while (i <= j) // пока не дошли до середины (т.е. пока слева все эл-ты не стали 
        {
            while (array[i] < pivot) { i++; } // доходим до элемента, который нужно перенести на другую сторону (вправо от опорного эл-та)

            while (array[j] > pivot) { j--; } // доходим до элемента, который нужно перенести на другую стороне (слева от эл-та)

            if (i <= j) //если индексы не зашли друг за друга (напирмер все эл-ты в массиве одинаковые)
            {
                //меняем эл-ты местами
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                //смещаем указатели т.к. поменянные эл-ты  уже отсортированы относительно pivot
                i++;
                j--;
            }
        }

        if (leftIndex < j)
            QuiickSortV2(array, leftIndex, j); //иииии, что массив как-то по ссылке передаётся или что, как результат сортировки сохраняется 

        if (i < rightIndex)
            QuiickSortV2(array, i, rightIndex);

        return array;
    }

    public static void Test(int[] arr) { for (int i = 0; i < arr.Length; i++) arr[i] = -99; }

}
