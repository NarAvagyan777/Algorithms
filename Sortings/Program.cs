class Program
{
    public static int[] MyInsertion(int[] arr)
    {
        for (int i = 1; i < arr.Length; ++i)
        {
            int j = i - 1;
            int tmp = arr[i];
            while (j >= 0 && arr[j] > tmp)
            {
                arr[j + 1] = arr[j];
            }
                j--;
                arr[j + 1] = tmp;
        }
        return arr;
    }
    public static int[] MyBubble(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; ++i) {
            for (int j = 0; j < arr.Length - i - 1; ++j)
            {
                if (arr[j] > arr[j + 1])
                {
                    int tmp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = tmp;
                }
            }
        }
        
        return arr;
        }
    public static int[] MySelection(int[] arr)
    {
        /*
        for (int i = arr.Length - 1; i > 0; --i)
        {
            int max = 0;
            for (int j = 0; j <= i; ++j)
            {
                if (arr[max] < arr[j])
                {
                    max = j;
                }

            }
            int tmp = arr[max];
            arr[max] = arr[i];
            arr[i] = tmp;
        }
        return arr;
        */
        for (int i = 0; i < arr.Length; ++i)
        {
            int index = i;
            for (int j = i + 1; j < arr.Length; ++j)
            {
                if (arr[index] > arr[j])
                {
                    index = j;
                }
            }
            int tmp = arr[index];
            arr[index] = arr[i];
            arr[i] = tmp;
        }
        return arr;
     }
    public static bool MyBS(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (arr[mid] == target)
            {
                return true;
            }
            if (arr[mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return false;
    }
    public static bool MyBSRecursive(int[] arr, int target, int left, int Right)
    {

        int Mid = (left + Right) / 2;
        if (left > Right)
        {
            return false;
        }

        if (arr[Mid] == target)
        {
            return true;
        }
        if (arr[Mid] > target)
        {
            return MyBSRecursive(arr, target, left, Mid - 1);
        }
        else
        {
            return MyBSRecursive(arr, target, Mid + 1, Right);
        }
    }
    public static int[] MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
        return arr;
    }
    public static void Merge(int[] arr, int left, int mid, int right)
    {
        int size1 = mid - left + 1;
        int size2 = right - mid;
        int[] arr1 = new int[size1];
        int[] arr2 = new int[size2];
        for (int i = 0; i < size1; ++i)
        {
            arr1[i] = arr[left + i];
        }
        for (int i = 0; i < size2; ++i)
        {
            arr2[i] = arr[mid + 1 + i];
        }
        int index = left;
        int start1 = 0;
        int start2 = 0;

        while (start1 < size1 && start2 < size2)
        {
            if (arr1[start1] < arr2[start2])
            {
                arr[index++] = arr1[start1++];
            }
            else
            {
                arr[index++] = arr2[start2++];
            }
        }
        while (start1 < size1)
        {
            arr[index++] = arr1[start1++];
        }
        while (start2 < size2)
        {
            arr[index++] = arr2[start2++];
        }
    }
    
    
    public static void QuickSort(int[] arr, int left, int right)
    {
        if (left >= right) { return; }
        int pivot = Partition(arr, left, right);
        QuickSort(arr, left, pivot - 1);
        QuickSort(arr, pivot + 1, right);
    }
    public static int Partition(int[] arr, int left, int right)
    {
        int i = left;
        int j = right - 1;
        while (i <= j) 
        {
            while (i <= j && arr[i] <= arr[right])
            {
                ++i;
            }
            while (i <= j && arr[j] > arr[right])
            {
                --j;
            }
            if (i <= j)
            {
                int t = arr[i];
                arr[i] = arr[j];
                arr[j] = t;
            }
        }
        int tmp = arr[right];
        arr[right] = arr[i];
        arr[i] = tmp;
        return left;
    }
    public static int[] MyCounting(int[] arr)
    {
        int[] count = new int[arr.Max() + 1];
        foreach (int item in arr)
        {
            ++count[item];
        }
        int[] newarr = new int[arr.Length];
        int index = 0;
        for (int i = 0; i < count.Length; ++i)
        {
            while (count[i] > 0)
            {
                newarr[index++] = i;
                --count[i];
            }
        }
        return newarr;
    } 

    public static void Main(string[] args)
    {
        int[] arr = { 5, 3, 4,1 };
        //  arr = MyCounting(arr);
         arr = MySelection(arr);
        //   arr = MyBubble(arr);
        // arr = MyInsertion(arr);
        // foreach (int i in arr)
        // {
        //    Console.WriteLine($"{i}");
        //}
        //bool res = MyBS(arr, 4);
        // bool reend1 = MyBSRecursive(arr, 1, 0, arr.Length - 1);
        // var res = MergeSort(arr,0,arr.Length - 1);
        //   QuickSort(arr, 0, arr.Length - 1);
        foreach (int i in arr)
        {
            Console.WriteLine(i);
        }
    }
}
