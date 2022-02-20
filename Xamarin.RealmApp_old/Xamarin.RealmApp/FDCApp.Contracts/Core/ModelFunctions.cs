using FDCApp.Contracts.Models.FormQuestions;
using System;
using System.Data;
using System.Linq;

namespace FDCApp.Contracts.Core
{
    public static class ModelFunctions
    {
        public static bool IsConditionExpressionValid(string condition, FormQuestion dependantQuestion)
        {
            if (string.IsNullOrEmpty(dependantQuestion.Answer))
                return false;

            Guid selectedAnswerValue;
            Guid.TryParse(dependantQuestion.Answer, out selectedAnswerValue);
            var selectedAnswer = dependantQuestion.AnswerOptions.FirstOrDefault(a => a.Id == selectedAnswerValue);
            if (selectedAnswer == null)
                return false;

            var finalExpression = condition.Replace($"{dependantQuestion.QuestionCode}", selectedAnswer.Description);

            finalExpression = finalExpression.Replace("{", "");
            finalExpression = finalExpression.Replace("}", "");

            return TestCondition(finalExpression);
        }

        public static bool TestCondition(string c)
        {
            var dt = new DataTable();
            dt.Columns.Add("col");
            dt.Rows.Add("row");
            var rows = dt.Select(c);
            return rows.Length > 0;
        }
    }
}
