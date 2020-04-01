using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sorting_Visualiser.Algorithms
{
    class InsertSort : SortBase
    {
        public static ISort Default = new InsertSort();

        public override SortElem[] Apply(SortElem[] sortArray)
        {
            for (int i = 0; i < sortArray.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (sortArray[j - 1].sortProp > sortArray[j].sortProp)
                    {
                        Swap(sortArray, j - 1, j);
                        Thread.Sleep(1);
                    }
                }
            }
            Algorithm_Finish();
            return sortArray;
        }
    }
}
