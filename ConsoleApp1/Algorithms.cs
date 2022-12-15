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
}
