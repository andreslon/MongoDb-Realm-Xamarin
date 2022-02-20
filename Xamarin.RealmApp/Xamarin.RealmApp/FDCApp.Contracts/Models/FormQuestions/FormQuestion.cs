using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models.FormQuestions
{
    public partial class FormQuestion : IBaseLocalModel
    {
        public FormQuestion()
        {
            IsVisible = true;            
            ExpressionObjects = new List<FormQuestion>();
            ConditionObjects = new List<FormQuestion>();
            MandatoryConditionObjects = new List<FormQuestion>();
            FormulaFunctionObjects = new List<FormQuestion>();
            ConditionObjectRules = new Dictionary<string, string>();
            CalculationUids = new List<string>();
            IsValid = true;

            AnswerOptions = new List<AnswerOption>();
            OrderedAnswerOptions = new List<AnswerOption>();
            DeletedChildrenFormIds = new List<Guid>();
        }

        [PrimaryKey]
        [JsonProperty("id")]
        public Guid UID { get; set; }
        public string QuestionCode { get; set; }
        public string Description { get; set; }
        public string AnswerType { get; set; }
        public string Formula { get; set; }
        public string Validation { get; set; }
        public bool IsMandatory { get; set; }
        public int? ListViewOrder { get; set; }
        public bool IsReadOnly { get; set; }

        [TextBlob(nameof(CalculationUidsBlobbed))]
        public List<string> CalculationUids { get; set; }

        public int Order { get; set; }
        public string DefaultValue { get; set; }
        public string Condition { get; set; }
        public string MandatoryCondition { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<AnswerOption> AnswerOptions { get; set; }        
    }
}
