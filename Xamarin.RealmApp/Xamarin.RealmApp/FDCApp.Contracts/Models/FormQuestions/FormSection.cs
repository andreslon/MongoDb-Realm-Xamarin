using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models.FormQuestions
{
    public class FormSection : IBaseLocalModel
    {
        [PrimaryKey]
        [JsonProperty("id")]        
        public Guid UID { get; set; }        
        public string SectionCode { get; set; }
        public string Description { get; set; }
        public bool SectionVisible { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<FormQuestion> Questions { get; set; }

        #region Internal properties
        [JsonIgnore]
        [ForeignKey(typeof(Form))]
        public Guid FormId { get; set; }
        #endregion
    }
}
