using System;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models.FormAnswers
{
    public class AnswerValue : IBaseLocalModel
    {
        public AnswerValue()
        {
            UID = System.Guid.NewGuid();
        }

        [JsonProperty("id")]
        [PrimaryKey]
        public Guid UID { get; set; }

        public Guid? Guid { get; set; }
        public DateTime? Date { get; set; }
        public double Num { get; set; }
        public string Text { get; set; }
        public Guid? FormAnswerUid { get; set; }

        [ForeignKey(typeof(FormAnswer))]
        public Guid FormAnswerId { get; set; }

        public AnswerValue Clone()
        {
            var result = (AnswerValue)this.MemberwiseClone();
            return result;
        }
    }
}