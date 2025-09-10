using System.Collections.Generic;
using wpf_chat_history.Model;

namespace wpf_chat_history.Mapper
{
    public class SpeakMapper
    {
        /// <summary>
        /// 查询系统中全部的群组
        /// </summary>
        public static List<SpeakGroupVO> GetMusicList()
        {
            List<SpeakGroupVO> list = new List<SpeakGroupVO>();
            for (int i = 1; i <= 20; i++)
            {
                SpeakGroupVO speakGroupVO = new SpeakGroupVO();
                speakGroupVO.GroupName = $"分组名称{i}";
                speakGroupVO.GroupOwnerName = $"用户名称{i}";
                list.Add(speakGroupVO);
            }
            return list;
        }

        /// <summary>
        /// 查询指定群组的聊天记录
        /// </summary>
        public static List<MessageVO> GetMessageListByGroupId()
        {
            List<MessageVO> list = new List<MessageVO>();
            for (int i = 1; i <= 20; i++)
            {
                MessageVO messageVO = new MessageVO();
                messageVO.MessageFromName = $"用户名称{i}";
                messageVO.MessageText = $"这是一段文本消息这是一段文本消息这是一段文本消息这是一段文本消息这是一段文本消息这是一段文本消息这是一段文本消息这是一段文本消息{i}";
                list.Add(messageVO);
            }
            return list;
        }

    }
}
