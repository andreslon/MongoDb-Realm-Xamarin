using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;
using Newtonsoft.Json;

namespace FDCApp.Contracts.Models.FormAnswers
{
    public class FormAnswer : IBaseLocalModel
    {
        public FormAnswer()
        {
            AnswerValues = new List<AnswerValue>();
            UID = Guid.NewGuid();
        }

        [JsonProperty("id")]
        [PrimaryKey]
        public Guid UID { get; set; }

        [Indexed]
        public Guid QuestionId { get; set; }

        [Indexed]
        public string QuestionCode { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<AnswerValue> AnswerValues { get; set; }

        [ForeignKey(typeof(VisitForm))]
        public Guid VisitFormId { get; set; }

        public FormAnswer Clone()
        {
            var result = (FormAnswer)this.MemberwiseClone();
            result.AnswerValues = new List<AnswerValue>();

            return result;
        }
    }
}
