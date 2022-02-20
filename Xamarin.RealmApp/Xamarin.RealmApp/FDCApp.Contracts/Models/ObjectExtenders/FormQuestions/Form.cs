using System;
using System.Collections.Generic;
using System.Linq;

namespace FDCApp.Contracts.Models.FormQuestions
{
    public partial class Form
    {
        public bool HasModifiedValues()
        {
            var formQuestions = GetFormQuestions();
            return formQuestions.Any(a => a.WasValueChanged);
        }

        public List<FormQuestion> GetFormQuestions()
        {
            var formQuestions = from sections in Sections
                                from questions in sections.Questions
                                select questions;
            return formQuestions.ToList();
        }
    }
}
