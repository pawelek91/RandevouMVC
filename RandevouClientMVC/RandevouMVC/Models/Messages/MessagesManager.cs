using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RandevouMVC.Models.ApiQueryProvider;
using RandevouMVC.ViewModels.Messages;

namespace RandevouMVC.Models.Messages
{
    public class MessagesManager : BusinessManager, IMessagesManager
    {
        public MessagesManager(IApiQueryProvider apiQueryProvider) : base(apiQueryProvider)
        {
        }

        public IEnumerable<SpeakersViewModel> GetAllConversations()
        {
            var conversations = _queryProvider.GetLastMessages();
            return conversations.Select(x => new SpeakersViewModel
            {
                SpeakerId = x.SpeakerId,
                SpeakerName = x.SpeakerName,
                MessageShortContent = x.MessageShortContent,
            });
        }

        public IEnumerable<ConversationViewModel> GetConversation(int speakerId)
        {
            var conversation = _queryProvider.GetConversation(speakerId, null, null);
            return conversation.Select(x =>
                new ConversationViewModel
                {
                    Message = x.Content,
                    ReceiverId = x.ReceiverId,
                    ReceiverName = x.ReceiverName,
                    SendDate = x.SendDate,
                    SenderId = x.SenderId,
                    SenderName = x.SenderName,
                });
        }
    }
}
