using PollProgram.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace PollProgram.Components.Repositories
{
    public class PollQuestionsRepository
    {
        public QuestionBlockViewModel GetBlock()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string text = File.ReadAllText(FilePath, Encoding.GetEncoding("windows-1251"));
            return JsonConvert.DeserializeObject<QuestionBlockViewModel>(text);
        }

        public string FilePath { get; set; }
    }
}
