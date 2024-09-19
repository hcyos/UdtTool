using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UdtTool.Support.UI.Units
{
    public class MagicStackPanel : StackPanel
    {
        #region ItemHeight Property
        /// <summary>
        /// 条目高度。
        /// </summary>
        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        public static readonly DependencyProperty ItemHeightProperty = DependencyProperty.Register(
            nameof(ItemHeight),
            typeof(double),
            typeof(MagicStackPanel),
            new PropertyMetadata(36.0, OnItemHeightPropertyChanged)
        );

        private static void OnItemHeightPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MagicStackPanel panel)
                panel.RefreshPanelItems(panel);
        }
        #endregion

        #region PanelHeight Property

        public double PanelHeight
        {
            get { return (double)GetValue(PanelHeightProperty); }
            set { SetValue(PanelHeightProperty, value); }
        }
        public static readonly DependencyProperty PanelHeightProperty = DependencyProperty.Register(
            nameof(PanelHeight),
            typeof(double),
            typeof(MagicStackPanel),
            new PropertyMetadata(0.0, OnPanelHeightPropertyChanged)
        );

        private static void OnPanelHeightPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MagicStackPanel panel)
                panel.RefreshPanelItems(panel);
        }
        #endregion

        #region OddBackground Property
        /// <summary>
        /// 奇数行背景色。
        /// </summary>
        public Brush OddBackground
        {
            get { return (Brush)GetValue(OddBackgroundProperty); }
            set { SetValue(OddBackgroundProperty, value); }
        }
        public static readonly DependencyProperty OddBackgroundProperty = DependencyProperty.Register(
            nameof(OddBackground),
            typeof(Brush),
            typeof(MagicStackPanel),
            new PropertyMetadata(Brushes.Green, OnOddBackgroundPropertyChanged)
        );

        private static void OnOddBackgroundPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MagicStackPanel panel)
                panel.RefreshPanelItems(panel);
        }
        #endregion

        #region EvenBackground Property
        /// <summary>
        /// 偶数行背景色。
        /// </summary>
        public Brush EvenBackground
        {
            get { return (Brush)GetValue(EvenBackgroundProperty); }
            set { SetValue(EvenBackgroundProperty, value); }
        }

        public static readonly DependencyProperty EvenBackgroundProperty = DependencyProperty.Register(
            nameof(EvenBackground),
            typeof(Brush),
            typeof(MagicStackPanel),
            new PropertyMetadata(Brushes.Orange, OnEvenBackgroundPropertyChanged)
        );

        private static void OnEvenBackgroundPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MagicStackPanel panel)
                panel.RefreshPanelItems(panel);
        }
        #endregion

        #region RefreshPanelItems Method
        private void RefreshPanelItems(MagicStackPanel panel)
        {
            panel.Children.Clear();
            panel.Height = panel.ItemHeight;
            int index = (int)(panel.PanelHeight / panel.ItemHeight);
            for (int i = 0; i < index; i++)
            {
                var border = new Border
                {
                    Height = panel.ItemHeight,
                    Background = i % 2 == 0 ? EvenBackground : OddBackground,
                };
                panel.Children.Add(border);
            }
        }
        #endregion
    }
}
