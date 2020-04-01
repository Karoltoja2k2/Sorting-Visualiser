using Sorting_Visualiser.Algorithms;
using Sorting_Visualiser.Renders;
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

        public Thread thr;
        public IRender currentRender = HorizontalPyramid.Default;

        private int chosenAlg = 0;
        public bool loaded = false;
        public bool run = false;

        public MainWindow()
        {
            random = new Random();
            InitializeComponent();
            Loaded += Loaded_Event;                      
        }

        public void Loaded_Event(object sender, RoutedEventArgs e)
        {
            loaded = true;
            InvokeRender(currentRender);
        }


        private void Change_Size(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (loaded)
            {
                InvokeRender(currentRender);
            }
        }

        private void ShuffleBtn(object sender, RoutedEventArgs e)
        {
            thr = new Thread(Shuffle_Array);
            Buttons_Change_State(true);
            thr.Start();
        }

        private void Select_Alg(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Int32.TryParse((string)btn.CommandParameter, out chosenAlg);
            switch (chosenAlg)
            {
                case 0:
                    ExpanderSort.Header = "Selection";
                    break;
                case 1:
                    ExpanderSort.Header = "Bubble";
                    break;
                case 2:
                    ExpanderSort.Header = "Merge";
                    break;
                case 3:
                    ExpanderSort.Header = "Insertion";
                    break;
                case 4:
                    ExpanderSort.Header = "Cocktail";
                    break;
            }
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            switch (chosenAlg)
            {
                case 0:
                    thr = new Thread(Selection_Sort);
                    break;
                case 1:
                    thr = new Thread(Bubble_Sort);
                    break;
                case 2:
                    thr = new Thread(Merge_Sort);
                    break;
                case 3:
                    thr = new Thread(Insertion_Sort);
                    break;
                case 4:
                    thr = new Thread(Cocktail_Sort);
                    break;
            }
            Buttons_Change_State(false);
            thr.Start();
            e.Handled = true;
        }

        private void StopBtn(object sender, RoutedEventArgs e)
        {
            if (thr != null && thr.IsAlive)
            {
                thr.Abort();
            }
            Buttons_Change_State(true);
        }

        private void Selection_Sort() => InvokeSort(SelectionSort.Default);
        private void Bubble_Sort() => InvokeSort(BubbleSort.Default);
        private void Merge_Sort() => InvokeSort(MergeSort.Default);
        private void Insertion_Sort() => InvokeSort(InsertSort.Default);
        private void Cocktail_Sort() => InvokeSort(CocktailSort.Default);

        private void Shuffle_Array() => InvokeSort(Shuffle.Default);

        private void Render_Horizontal_Pyramid(object sender, RoutedEventArgs e) => InvokeRender(HorizontalPyramid.Default);
        private void Render_Horizontal_Square(object sender, RoutedEventArgs e) => InvokeRender(HorizontalSquare.Default);
        private void Render_Vertical_Pyramid(object sender, RoutedEventArgs e) => InvokeRender(VerticalPyramid.Default);
        private void Render_Vertical_Square(object sender, RoutedEventArgs e) => InvokeRender(VerticalSquare.Default);


        private void InvokeSort(ISort sort)
        {
            sortArray = sort.Apply(sortArray);            
        }

        private void InvokeRender(IRender render)
        {
            currentRender = render;
            ExpanderRender.Header = render.ITitle;
            sortArray = render.New_Array((int)sizeSlider.Value);
            render.Render_Array(grid);
        }

        public void Buttons_Change_State(bool active)
        {
            run = !active;
            if(active)
            {                
                startBtn.Click += Start;
                startBtn.Click -= StopBtn;
                startBtn.Content = "Start";
            }
            else
            {
                startBtn.Click -= Start;
                startBtn.Click += StopBtn;
                startBtn.Content = "Stop";
            }

            shuffleBtn.IsEnabled = active;
            selectionBtn.IsEnabled = active;
            bubbleBtn.IsEnabled = active;
            mergeBtn.IsEnabled = active;
            insertBtn.IsEnabled = active;
            cocktailBtn.IsEnabled = active;
            sizeSlider.IsEnabled = active;
        }


        private void mouseOutExpander(object sender, MouseEventArgs e)
        {
            Expander exp = (Expander)sender;
            exp.IsExpanded = false;
        }

        private void mouseInExpander(object sender, MouseEventArgs e)
        {
            Expander exp = (Expander)sender;
            exp.IsExpanded = true;
        }

        private void Close_Game_Window(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Minimize_Game_Window(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Drag_Window(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

    }
}
