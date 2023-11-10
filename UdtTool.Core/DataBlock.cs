using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace UdtTool.Core
{
    /// <summary>
    /// 数据块
    /// </summary>
    public class DataBlock
    {
        #region Properties

        /// <summary>
        /// 获取或设置数据块名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 获取或设置数据块编号
        /// </summary>
        public int Number { get; set; } = 50002;

        /// <summary>
        /// 获取或设置数据块所属结构类型
        /// </summary>
        public List<Structure> Structures { get; set; } = new();

        /// <summary>
        /// 获取或设置数据块所属标签
        /// </summary>
        public ObservableCollection<Tag> Tags { get; set; } = new ObservableCollection<Tag>();

        #endregion Properties

        #region Constructors

        /// <summary>
        /// 初始化 <see cref="DataBlock"/> 类的新实例。
        /// </summary>
        public DataBlock()
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