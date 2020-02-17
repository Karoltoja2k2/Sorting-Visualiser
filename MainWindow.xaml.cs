﻿using Sorting_Visualiser.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Sorting_Visualiser
{

    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Random random;
        public List<SolidColorBrush> rainbowColors;
        public SortElem[] sortArray;
        public Generator generator;

        public bool loaded = false;

        public MainWindow()
        {
            random = new Random();
            InitializeComponent();
            Loaded += Loaded_Event;                      
        }

        public void Loaded_Event(object sender, RoutedEventArgs e)
        {
            loaded = true;
            generator = new Generator();
            sortArray = generator.New_Array(500);
            Render_Array();
        }

        public void Render_Array()
        {
            grid.Children.Clear();
            for (int i = 0; i < sortArray.Length; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                column.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(column);
                
                Grid.SetColumn(sortArray[i].rect, i);
                grid.Children.Add(sortArray[i].rect);
            }
        }

        private void Change_Size(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (loaded)
            {
                sortArray = generator.New_Array((int)sizeSlider.Value);
                Render_Array();
            }
        }

        private void ShuffleBtn(object sender, RoutedEventArgs e)
        {
            Thread thr = new Thread(Shuffle_Array);
            thr.Start();
        }

        private void SortBtn(object sender, RoutedEventArgs e)
        {
            Thread thr = new Thread(Bubble_Sort);
            thr.Start();
        }

        private void SelectionBtn(object sender, RoutedEventArgs e)
        {
            Thread thr = new Thread(Selection_Sort);
            thr.Start();
        }

        
        private void Selection_Sort() => InvokeEffect(SelectionSort.Default);
        private void Bubble_Sort() => InvokeEffect(BubbleSort.Default);
        private void Shuffle_Array() => InvokeEffect(Shuffle.Default);

        private void InvokeEffect(ISort sort)
        {
            sortArray = sort.Apply(sortArray);
        }


    }
}
