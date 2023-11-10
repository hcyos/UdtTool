using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace UdtTool.Core
{
    /// <summary>
    /// 结构
    /// </summary>
    public class Structure
    {
        #region Properties

        /// <summary>
        /// 获取或设置结构体名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 获取或设置结构体标签集合
        /// </summary>
        public ObservableCollection<Tag> Tags { get; set; } = new();

        #endregion Properties

        #region Constructors

        public Structure()
        {
            Tags.CollectionChanged += OnTagsCollectionChanged;
        }

        #endregion Constructors

        #region Event Handlers

        /// <summary>
        /// 在 <see cref="Tags"/> 集合发生变化时调用。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTagsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
        }

        #endregion Event Handlers
    }
}