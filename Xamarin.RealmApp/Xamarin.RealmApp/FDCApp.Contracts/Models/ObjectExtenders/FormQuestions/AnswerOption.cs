using System;
using Newtonsoft.Json;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models.FormQuestions
{
    public partial class AnswerOption
    {
        #region Internal properties
        [JsonIgnore]
        [ForeignKey(typeof(FormQuestion))]
        public Guid FormQuestionId { get; set; }        
        #endregion

        #region Internal methods
        public override string ToString()
        {
            return Description;
        }
        #endregion
    }
}
