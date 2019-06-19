using RandevouMVC.ViewModels.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Models.Messages
{
    public interface IMessagesManager
    {
        IEnumerable<SpeakersViewModel> GetAllConversations();
        IEnumerable<ConversationViewModel> GetConversation(int speakerId);
        void SendMessage(int receiverId, string content);
    }
}
