using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using wpf_chat_history.Mapper;
using wpf_chat_history.Model;

namespace wpf_chat_history
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }


        // 音频播放器实例
        private MediaPlayer _audioPlayer;
        private ListView _SpeakGroupListView;
        private ListView _MessageRecordListView;
        private TextBlock _SpeakMessageRecordListHeader;

        public MainWindow()
        {
            InitializeComponent();

            // 1. 控件
            _SpeakGroupListView = SpeakGroupListView;
            _SpeakMessageRecordListHeader = SpeakMessageRecordListHeader;
            _MessageRecordListView = MessageRecordListView;
            _audioPlayer = new MediaPlayer(); // 初始化播放器

            // 2. 定义数据源
            List<SpeakGroupVO> speakGroupVOs = SpeakMapper.GetMusicList();

            // 3. 绑定数据源
            _SpeakGroupListView.ItemsSource = speakGroupVOs;

            // 4. 选中某个分组的事件
            _SpeakGroupListView.SelectionChanged += SpeakGroupListView_SelectionChanged;
        }

        /// <summary>
        /// 点击切换当前被选中的分组
        /// </summary>
        private void SpeakGroupListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SpeakGroupVO selectedItem = SpeakGroupListView.SelectedItem as SpeakGroupVO;
            if (selectedItem != null)
            {
                _SpeakMessageRecordListHeader.Text = selectedItem.GroupName;
                List<MessageVO> messages = SpeakMapper.GetMessageListByGroupId();
                _MessageRecordListView.ItemsSource = messages;

                // 滚动到最后
                {
                    if (_MessageRecordListView.Items.Count == 0) return;
                    // 获取最后一项
                    var lastItem = MessageRecordListView.Items[MessageRecordListView.Items.Count - 1];
                    // 滚动到最后一项（UI 线程安全）
                    MessageRecordListView.Dispatcher.Invoke(() =>
                    {
                        MessageRecordListView.ScrollIntoView(lastItem);
                        // 强制滚动到底部（解决某些情况下 ScrollIntoView 不生效的问题）
                        if (MessageRecordListView.ItemContainerGenerator.ContainerFromItem(lastItem) is ListViewItem item)
                        {
                            item.BringIntoView();
                        }
                    });
                }
            }
        }
    }
}
