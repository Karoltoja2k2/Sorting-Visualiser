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
            sortArray = sortArray.OrderBy(x => random.Next()).ToArray();

            for (int i = 0; i < sortArray.Length; i++)
            {
                App.Current.Dispatcher.Invoke(new Action(() => Grid.SetColumn(sortArray[i].rect, i)));
                Thread.Sleep(5);
            }
            return sortArray;
        }
    }
}
