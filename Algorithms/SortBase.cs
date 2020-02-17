using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Visualiser.Algorithms
{
    public abstract class SortBase : ISort
    {
        public abstract SortElem[] Apply(SortElem[] sortArray);
        public void Swap(SortElem[] sortArray, int swap, int with)
        {
            SortElem temp = sortArray[swap];
            sortArray[swap] = sortArray[with];
            sortArray[with] = temp;
        }
    }
}
