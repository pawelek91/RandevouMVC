using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.ViewModels.Messages
{
    public class ConversationViewModel
    {
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public int ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }

        public int Request { get; set; }
    }
}
