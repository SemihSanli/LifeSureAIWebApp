using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LifeSureApp.ViewModels
{
    public class FAQAIViewModel
    {
        public string QuestionTitle { get; set; }
        public string QuestionAnswer { get; set; }
        public string Question { get; set; }
        public string DebugMessage { get; set; } 
    }
}