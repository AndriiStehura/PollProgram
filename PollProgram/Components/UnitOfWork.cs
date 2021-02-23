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
        private ResultsRepository _resultsRepository;

        public UnitOfWork()
        {
            _pollQuestionsRepository = new PollQuestionsRepository();
            _resultsRepository = new ResultsRepository();
        }

        public PollQuestionsRepository PollQuestions => _pollQuestionsRepository;
        public ResultsRepository ResultsRepository => _resultsRepository;
    }
}
