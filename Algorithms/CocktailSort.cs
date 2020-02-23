using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Visualiser.Algorithms
{
    class CocktailSort : SortBase
    {
        public static ISort Default = new CocktailSort();

        public override SortElem[] Apply(SortElem[] sortArray)
        {
            int left = 0;
            int right = sortArray.Length - 1;
            bool change = true;

            while(change)
            {
                change = false;
                for (int i = left; i < right; i ++)
                {
                    if (sortArray[i].sortProp > sortArray[i + 1].sortProp)
                    {
                        Swap(sortArray, i, i + 1);
                        change = true;
                    }
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    if(sortArray[i].sortProp < sortArray[i - 1].sortProp)
                    {
                        Swap(sortArray, i, i - 1);
                        change = true;
                    }
                }
                left++;
            }

            Algorithm_Finish();
            return sortArray;
        }

    }
}
