using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Sorting_Visualiser.Algorithms
{
    class BubbleSort : SortBase
    {
        public static ISort Default = new BubbleSort();

        public override SortElem[] Apply(SortElem[] sortArray)
        {
            int n = sortArray.Length;
            while (n > 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (sortArray[i].sortProp > sortArray[i + 1].sortProp)
                    {
                        Swap(sortArray, i, i + 1);
                    }
                }
                n--;
            }
            Algorithm_Finish();
            return sortArray;
        }
    }
}
