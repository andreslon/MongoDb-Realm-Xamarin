using FDCApp.Contracts.Core;
using System.Collections.Generic;
using System.Linq;

namespace FDCApp.Contracts.Models.DynamicForms
{
    public class DynamicFormSection : PropertyClass
    {
        public DynamicFormSection()
        {
            QuestionItems = new List<DynamicFormItem>();
            IsVisible = true;
        }

        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public int InnerColumns { get; set; }
        public List<DynamicFormItem> QuestionItems { get; set; }

        public bool IsVisible { get; set; }

        private bool _isValid;
        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
                RaisePropertyChanged(nameof(IsValid));
            }
        }

        public void ValidateData()
        {
            foreach (var question in QuestionItems)
            {
                question.ValidateData();
                question.ValidateCondition();
            }

            this.IsValid = !this.QuestionItems.Any(a => !a.IsValid);
        }
    }
}
