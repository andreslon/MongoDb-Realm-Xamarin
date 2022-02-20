using FDCApp.Contracts.Core;
using System.Collections.Generic;
using System.Linq;

namespace FDCApp.Contracts.Models.DynamicForms
{
    public class DynamicFormContainer : PropertyClass
    {
        public DynamicFormContainer()
        {
            Sections = new List<DynamicFormSection>();
        }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public List<DynamicFormSection> Sections { get; set; }

        public List<DynamicFormSection> VisibleSections => GetVisibleSections();

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
            foreach (var section in Sections)            
                section.ValidateData();

            IsValid = !Sections.Any(a => !a.IsValid);
        }

        public List<DynamicFormItem> GetContainerItems()
        {
            var formItems = from sections in Sections
                            from items in sections.QuestionItems                            
                            select items;
            return formItems.ToList();
        }

        public DynamicFormItem GetContainerItem(string key)
        {
            var formItems = from sections in Sections
                            from items in sections.QuestionItems
                            where items.Key == key
                            select items;
            return formItems.FirstOrDefault();
        }

        private List<DynamicFormSection> GetVisibleSections()
        {
            return Sections.Where(a => a.IsVisible).ToList();
        }
    }
}
