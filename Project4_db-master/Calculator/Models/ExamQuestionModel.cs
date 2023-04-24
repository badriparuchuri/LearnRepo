using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    internal class ExamQuestionModel
    {
        public string questionText { get; set; }
        public int questionNumber { get; set; }
        public string optionOne { get; set; }
        public string optionTwo { get; set; }
        public string optionThree { get; set; }
        public string correctOptionValue { get; set; }
    }
}
