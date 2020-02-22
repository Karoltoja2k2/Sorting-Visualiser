using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sorting_Visualiser.Algorithms
{
    class MergeSort : SortBase
    { 
        public static ISort Default = new MergeSort();


        public override SortElem[] Apply(SortElem[] sortArray)
        {
            Merge_Sort(sortArray, 0, sortArray.Length - 1);
            Algorithm_Finish();
            return sortArray;
        }

        public void Merge_Sort(SortElem[] sortArray, int leftBound, int rightBound)
        {
            if (rightBound > leftBound)
            {
                int middle = (leftBound + rightBound) / 2;
                Merge_Sort(sortArray, leftBound, middle);
                Merge_Sort(sortArray, middle + 1, rightBound);

                Merge(sortArray, leftBound, middle, rightBound);
            }
        }

        public void Merge(SortElem[] sortArray, int leftBound, int middle, int rightBound)
        {
            int len1 = middle - leftBound + 1;
            int len2 = rightBound - middle;

            SortElem[] array1 = new SortElem[len1];
            SortElem[] array2 = new SortElem[len2];

            for (int x = 0; x < len1; x++)
                array1[x] = sortArray[leftBound + x];
            for (int y = 0; y < len2; y++)
                array2[y] = sortArray[middle + 1 + y];

            int indexArray1 = 0;
            int indexArray2 = 0;
            int indexSortArray = leftBound;

            while (indexArray1 < len1 && indexArray2 < len2)
            {
                if (array1[indexArray1].sortProp <= array2[indexArray2].sortProp)
                {
                    App.Current.Dispatcher.Invoke(new Action(() => Swap(sortArray, indexSortArray, array1[indexArray1])));
                    sortArray[indexSortArray] = array1[indexArray1];

                    indexArray1++;
                }
                else
                {
                    App.Current.Dispatcher.Invoke(new Action(() => Swap(sortArray, indexSortArray, array2[indexArray2])));
                    sortArray[indexSortArray] = array2[indexArray2];

                    indexArray2++;
                }
                indexSortArray++;
                Thread.Sleep(2);
            }

            while (indexArray1 < len1)
            {
                App.Current.Dispatcher.Invoke(new Action(() => Swap(sortArray, indexSortArray, array1[indexArray1])));
                sortArray[indexSortArray] = array1[indexArray1];
                indexArray1++;
                indexSortArray++;
                Thread.Sleep(2);

            }
            while (indexArray2 < len2)
            {
                App.Current.Dispatcher.Invoke(new Action(() => Swap(sortArray, indexSortArray, array2[indexArray2])));
                sortArray[indexSortArray] = array2[indexArray2];
                indexArray2++;
                indexSortArray++;
                Thread.Sleep(2);

            }

        }

        public void Swap(SortElem[] sortArray, int sortArrayIndex, SortElem elemToFindIndex)
        {
            int index = Grid.GetColumn(elemToFindIndex.rect);

            SortElem temp = sortArray[index];
            sortArray[index] = sortArray[sortArrayIndex];
            sortArray[sortArrayIndex] = temp;
            Display_Swap(sortArray, index, sortArrayIndex);
        }
    }
}
