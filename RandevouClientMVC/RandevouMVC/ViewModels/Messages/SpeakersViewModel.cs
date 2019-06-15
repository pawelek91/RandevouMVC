using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.ViewModels.Messages
{
    public class SpeakersViewModel
    {
        public int SpeakerId { get; set; }
        public string SpeakerName { get; set; }
        public string MessageShortContent { get; set; }
    }
}
