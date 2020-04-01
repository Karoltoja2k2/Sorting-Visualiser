using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Sorting_Visualiser.Algorithms
{
    class Shuffle : SortBase
    {
        public static ISort Default = new Shuffle();
        public Random random = new Random();


        public override SortElem[] Apply(SortElem[] sortArray)
        {
            for (int i = 0; i < sortArray.Length; i++)
            {
                int index = i;
                while (index == i)
                {
                    index = random.Next(0, sortArray.Length);
                }
                Swap(sortArray, i, index);
                Thread.Sleep(1);
            }
            Algorithm_Finish();
            return sortArray;
        }

    }
}
