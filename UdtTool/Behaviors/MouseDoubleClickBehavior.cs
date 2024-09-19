using System.Windows;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace UdtTool.Behaviors
{
    /// <summary>
    /// 这个行为用于处理鼠标双击事件。
    /// </summary>
    public class MouseDoubleClickBehavior : Behavior<FrameworkElement>
    {
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command",
            typeof(ICommand),
            typeof(MouseDoubleClickBehavior),
            new PropertyMetadata(null)
        );

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
        }

        private void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (Command != null && Command.CanExecute(null))
                {
                    Command.Execute(null);
                }
            }
        }
    }
}
