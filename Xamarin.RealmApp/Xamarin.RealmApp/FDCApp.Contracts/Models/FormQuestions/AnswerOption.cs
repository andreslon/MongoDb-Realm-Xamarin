using System;
using Prism.Mvvm;
using SQLite;

namespace FDCApp.Contracts.Models.FormQuestions
{
    public partial class AnswerOption : BindableBase
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public bool IsValidOption { get; set; }
        public bool IsActive { get; set; }
    }
}