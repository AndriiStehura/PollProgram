using PollProgram.Components.Repositories;
using PollProgram.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PollProgram.Components
{
    public class UnitOfWork
    {
        private PollQuestionsRepository _pollQuestionsRepository;

        public UnitOfWork()
        {
            _pollQuestionsRepository = new PollQuestionsRepository();
        }

        public PollQuestionsRepository PollQuestions => _pollQuestionsRepository;
    }
}
