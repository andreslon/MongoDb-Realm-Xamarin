using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using FDCApp.Contracts.Constants;
using FDCApp.Contracts.Core;
using FDCApp.Contracts.Enumerations;

namespace FDCApp.Contracts.Models.DynamicForms
{
    public class DynamicFormItem : PropertyClass, IGridViewItem
    {
        public DynamicFormItem()
        {
            Items = new List<MetricList>();
            ExpressionObjects = new List<DynamicFormItem>();
            ExpressionObjectsIds = new List<string>();
            RelatedObjects = new List<DynamicFormItem>();
            RelatedObjectsIds = new List<string>();
            ItemEvents = new List<Action>();

            Mandatory = false;
            _isValid = true;
            IsEnabled = true;
            IsVisible = true;
            IsReadOnly = false;
            IsClearDateEnabled = true;
            Value = "";
            GroupKey = "";
            CheckValue = false;
            MaxDate = DateTime.UtcNow;
            MinDate = DateTime.Today.AddDays(-30);
            SelectedDate = null;
            ControlSize = DynamicControlSize.Large;
            KeyboardEntryType = KeyboardEntryType.NotAsigned;
        }

        public FormItemType Type { get; set; }
        public string ItemTitle { get; set; }
        public string ItemDescription { get; set; }
        public DateTime ItemDate { get; set; }
        public string TextMask { get; set; }
        public List<MetricList> Items { get; set; }
        public string Key { get; set; }
        public string GroupKey { get; set; }
        public Guid GroupKeyUID { get; set; }
        public bool Mandatory { get; set; }
        public bool CheckValue { get; set; }
        public string More { get; set; }
        public KeyboardEntryType KeyboardEntryType { get; set; }
        public bool IsPassword { get; set; }
        public bool IsEmail { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsVisible { get; set; }
        public bool IsPreviousValue { get; set; }
        public bool IsClearDateEnabled { get; set; }
        public bool IsCalculated { get; set; }
        public int Order { get; set; }
        public int MaxLength { get; set; }
        public decimal CalculationFactor { get; set; }
        public bool CarryForward { get; set; }
        public MetricEntryValueType ItemEntryValueType { get; set; }
        public SyncStatusLocal Status { get; set; }
        public DateTime MaxDate { get; set; }
        public DateTime MinDate { get; set; }
        public string ImageUrl { get; set; }
        public byte[] ImageContent { get; set; }
        public string FormulaFunction { get; set; }
        public DateTime DefaultDate { get; set; }
        public string DefaultValue { get; set; }
        public string DefaultValueText { get; set; }
        public DynamicControlSize ControlSize { get; set; }
        public int ColumnSpan { get; set; } = 1;
        public int RowSpan { get; set; } = 1;
        public int? Column { get; set; }
        public int? Row { get; set; }
        public bool IsCalculatedItem { get; set; }

        public int IntegerPlaces { get; set; }
        public int DecimalPlaces { get; set; }

        //metric lineage specific values
        public string LastUpdateUserName { get; set; }
        public string SourceSystem { get; set; }
        public EntryTypes EntryType { get; set; }

        //group metric types
        public string GroupCode { get; set; }
        public string GroupSubCode { get; set; }

        public ICommand Command { get; set; }
        public List<Action> ItemEvents { get; set; }

        //related metrics for listing
        public List<string> RelatedObjectsIds { get; set; }
        public List<DynamicFormItem> RelatedObjects { get; set; }

        //metric expecific field
        public string Format { get; set; }
        public string Validation { get; set; }

        //well - downtime properties
        public Guid? ProductionMethodBeforeUid { get; set; }
        public string ProductionMethodBeforeText { get; set; }

        //Expression for calculations
        public string Expression { get; set; }
        public List<string> ExpressionObjectsIds { get; set; }
        public List<DynamicFormItem> ExpressionObjects { get; set; }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get
            {
                return this._isEnabled;
            }
            set
            {
                this._isEnabled = value;
                RaisePropertyChanged(nameof(IsEnabled));
            }
        }

        private DateTime? _selectedDate;
        public DateTime? SelectedDate
        {
            get
            {
                return this._selectedDate;
            }
            set
            {
                this.IsValid = true;
                this._selectedDate = value;

                RaiseItemActions();
                RaisePropertyChanged(nameof(SelectedDate));
            }
        }

        private TimeSpan? _selectedTime;
        public TimeSpan? SelectedTime
        {
            get
            {
                return this._selectedTime;
            }
            set
            {
                if (this._selectedTime != value)
                {
                    this.IsValid = true;
                }
                this._selectedTime = value;

                RaiseItemActions();
                RaisePropertyChanged(nameof(SelectedTime));
            }
        }

        private string _value;
        public string Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;

                if (!IsValidFormat())
                    return;

                ValidateData();
                ValidateCondition();

                RaiseItemActions();
                RaisePropertyChanged(nameof(Value));
            }
        }

        private string _valueText;
        public string ValueText
        {
            get
            {
                return _valueText;
            }
            set
            {
                _valueText = value;
                RaisePropertyChanged(nameof(ValueText));
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                RaisePropertyChanged(nameof(ErrorMessage));
            }
        }

        private bool _isValid;
        public bool IsValid
        {
            get
            {
                return this._isValid;
            }
            set
            {
                this._isValid = value;
                RaisePropertyChanged(nameof(IsValid));
            }
        }

        protected bool IsValidFormat()
        {
            if (this.Type == FormItemType.MetricList)
                return true;

            bool hasValidData = true;
            if (KeyboardEntryType == KeyboardEntryType.Numeric)
            {
                if (string.IsNullOrWhiteSpace(Value))
                    return true;

                string value;

                if (Type == FormItemType.Fraction)
                {
                    var fractionNumbers = Value.Split('/');
                    value = fractionNumbers[0];
                }
                else
                {
                    value = Value;
                }

                bool isNumericValue = value.All(x => char.IsDigit(x) || x == '.' || x == '-');
                if (!isNumericValue)
                {
                    hasValidData = false;

                    if (double.TryParse(value, out var num))
                        this.ErrorMessage = $"This Gauge Height Will Produce Negative Produced Value, Change Gauge";
                    else
                        this.ErrorMessage = $"Only numbers allowed.";
                }
            }

            this.IsValid = hasValidData;
            return hasValidData;
        }

        public void EvaluateExpression()
        {
            if (string.IsNullOrWhiteSpace(this.Expression))
                return;

            bool isExpressionComplete = true;
            string finalExpression = this.Expression;
            bool isDateOperation = false;

            foreach (var item in this.ExpressionObjects)
            {
                var itemVal = "";
                switch (item.Type)
                {
                    case FormItemType.Date:
                        if (item.SelectedDate != null)
                        {
                            isDateOperation = true;
                            itemVal = ((DateTime)item.SelectedDate).ToShortDateString();
                        }
                        break;

                    case FormItemType.Time:
                        if (item.SelectedTime != null)
                        {
                            isDateOperation = true;
                            itemVal = ((TimeSpan)item.SelectedTime).ToString();
                        }
                        break;

                    case FormItemType.Datetime:
                        if (item.SelectedDate != null && item.SelectedTime != null)
                        {
                            isDateOperation = true;
                            DateTime resultDatetime = (DateTime)item.SelectedDate + (TimeSpan)item.SelectedTime;
                            itemVal = resultDatetime.ToString();
                        }
                        else if (item.SelectedDate != null)
                        {
                            isDateOperation = true;
                            itemVal = ((DateTime)item.SelectedDate).ToShortDateString();
                        }
                        break;
                    default:
                        itemVal = item.Value;
                        break;
                }

                if (string.IsNullOrWhiteSpace(itemVal))
                {
                    isExpressionComplete = false;
                }
                else
                {
                    finalExpression = finalExpression.ToLower().Replace($"{item.Key.ToLower()}", itemVal);

                    if (!string.IsNullOrWhiteSpace(item.GroupKey))
                        finalExpression = finalExpression.ToLower().Replace($"{item.GroupKey.ToLower()}", itemVal);
                }
            }

            if (isExpressionComplete)
            {
                try
                {
                    finalExpression = finalExpression.Replace("{", "");
                    finalExpression = finalExpression.Replace("}", "");

                    if (isDateOperation)
                    {
                        var timeResult = GetDatesCalculationResult(finalExpression);

                        switch (this.Type)
                        {
                            case FormItemType.Date:
                            case FormItemType.Datetime:
                            case FormItemType.Time:
                                SelectedTime = timeResult;
                                break;

                            default:
                                this.Value = timeResult.Days.ToString();
                                break;
                        }
                    }
                    else
                    {
                        double result = Convert.ToDouble(new DataTable().Compute(finalExpression, null));
                        this.Value = result.ToString(ConfigConstant.Display_Value_Format);
                    }

#if DEBUG
                    Console.WriteLine($"********* Calculated value: Metric: ({this.ItemTitle}) - Date: ({ItemDate.ToString(ConfigConstant.Display_Date_Format)}) - ({this.Value}) => Expression: ({finalExpression})");
#endif                    
                }
                catch (Exception)
                {
                    this.Value = "...";
                }
            }
            else
            {
                this.Value = "0";
            }
            RaisePropertyChanged(nameof(Value));
        }

        protected TimeSpan GetDatesCalculationResult(string expression)
        {
            //it's going to be working only with two dates, do a better implementation
            expression = expression.Replace("(", "");
            expression = expression.Replace(")", "");

            string action = "";

            string[] dates = expression.Split('-');
            if (dates.Any())
            {
                action = "-";
            }
            else
            {
                dates = expression.Split('+');
                if (dates.Any())
                {
                    action = "+";
                }
            }

            if (!string.IsNullOrEmpty(action))
            {
                DateTime date1;
                bool date1Valid = DateTime.TryParse(dates[0], out date1);

                DateTime date2;
                bool date2Valid = DateTime.TryParse(dates[1], out date2);

                if (date1Valid && date2Valid)
                {
                    TimeSpan resultTime;
                    resultTime = date1 - date2;

                    return resultTime;
                }
            }

            return TimeSpan.MinValue;
        }

        public void ValidateCondition(bool forceValidation = false)
        {
            try
            {
                if (!this.IsValid && !forceValidation)
                    return;

                if (string.IsNullOrWhiteSpace(this.Validation)) throw new ArgumentException("IGNORE");
                if (string.IsNullOrWhiteSpace(this.Value)) throw new ArgumentException("IGNORE");

                string[] validationValues = this.Validation.Split('@');
                if (string.IsNullOrWhiteSpace(validationValues[0])) throw new ArgumentException("IGNORE");

                string condition = validationValues[0].ToUpper();
                foreach (var obj in this.ExpressionObjects)
                {
                    string objVal = (string.IsNullOrEmpty(obj.Value) ? "0" : obj.Value);
                    condition = condition.Replace(obj.GroupKey, objVal);
                }

                switch (Type)
                {
                    case FormItemType.Fraction:
                        var fractionNumbers = Value.Split('/');
                        condition = string.Format(condition, fractionNumbers[0].Split('|'));
                        break;
                    default:
                        condition = string.Format(condition, Value.Split('|'));
                        break;
                }

                this.IsValid = TestCondition(condition);
                if (!this.IsValid && !string.IsNullOrWhiteSpace(validationValues[1]))
                {
                    this.ErrorMessage = validationValues[1];
                }
                else
                {
                    this.ErrorMessage = string.Empty;
                }
            }
            catch (Exception ex)
            {
                //Do nothing
                if (ex.Message != "IGNORE")
                {
                    this.IsValid = false;
                    this.ErrorMessage = "Invalid data";
                }
            }
        }

        protected bool TestCondition(string c)
        {
            var dt = new DataTable();
            dt.Columns.Add("col");
            dt.Rows.Add("row");
            var rows = dt.Select(c);
            return rows.Length > 0;
        }

        public void ValidateData()
        {
            bool hasValidData = true;

            if (Type == FormItemType.MetricList)
            {
                var values = this.Value.Split('|');
                if (values.Any(d => string.IsNullOrWhiteSpace(d)))
                {
                    this.IsValid = false;
                    return;
                }
            }

            if (IsVisible && IsEnabled)
            {
                if (Mandatory)
                {
                    switch (Type)
                    {
                        case FormItemType.EntryField:
                        case FormItemType.DoubleEntryField:
                        case FormItemType.ExpandedList:
                        case FormItemType.List:
                        case FormItemType.EditableList:
                        case FormItemType.SearchableList:
                        case FormItemType.EntryTime:
                        case FormItemType.ThreeEntryField:
                        case FormItemType.DigitsEntryField:
                            hasValidData = (!string.IsNullOrEmpty(Value));
                            break;

                        case FormItemType.Date:
                            if (SelectedDate == null)
                            {
                                hasValidData = false;
                            }
                            else
                            {
                                if (SelectedDate < MinDate)
                                {
                                    hasValidData = false;
                                }
                            }
                            break;

                        case FormItemType.Time:
                            if (SelectedTime == null)
                            {
                                hasValidData = false;
                            }
                            break;

                        case FormItemType.Datetime:
                            if (SelectedDate == null)
                            {
                                hasValidData = false;
                            }
                            else
                            {
                                if (SelectedDate < MinDate)
                                {
                                    hasValidData = false;
                                }
                            }
                            break;

                        case FormItemType.Check:
                            hasValidData = CheckValue;
                            break;

                        case FormItemType.Fraction:
                            var fractionNumbers = Value.Split('/');
                            hasValidData = fractionNumbers.Length > 1;
                            break;

                        default:
                            break;
                    }

                    if (!hasValidData)
                    {
                        if (string.IsNullOrEmpty(this.ErrorMessage))
                        {
                            this.ErrorMessage = "Required field.";
                        }
                    }
                }
                else
                    hasValidData = true;

                if (hasValidData && IsEmail)
                {
                    hasValidData = Regex.Match(Value, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success;
                    if (!hasValidData)
                    {
                        this.ErrorMessage = "Please enter a valid email address.";
                    }
                }

                if (hasValidData && KeyboardEntryType == KeyboardEntryType.Numeric && !string.IsNullOrEmpty(Value) && Type != FormItemType.Fraction)
                {
                    bool isNumericValue = Value.All(x => char.IsDigit(x) || x == '.' || x == '-');
                    if (!isNumericValue)
                    {
                        hasValidData = false;
                        this.ErrorMessage = $"Only numbers allowed.";
                    }
                }
            }

            this.IsValid = hasValidData;
        }

        public void RaiseItemActions()
        {
            if (this.ItemEvents == null)
                return;

            if (!this.ItemEvents.Any())
                return;

            foreach (var itemEvent in this.ItemEvents)
            {
                itemEvent?.Invoke();
            }
        }

        #region Chart methods
        public void EvaluateNamedFunction()
        {
            switch (this.FormulaFunction)
            {
                case "Chart_Volume":
                    GetChartVolume();
                    break;

                case "Rotary_Flow_Calculation":
                    GetRotaryFlowCalculation();
                    break;

                case "Chart_Flow":
                    GetChartFlow();
                    break;

                case "Nfg_Flow":
                    GetNfgFlow();
                    break;
                default:
                    break;
            }
        }

        public void GetChartVolume()
        {
            var linePresure = GetRelatedItemValue(MetricIdentifier.Meter_Static_Line_Pressure);
            var basePresure = GetRelatedItemValue(MetricIdentifier.Constant_Base_Presure);
            var differential = GetRelatedItemValue(MetricIdentifier.Meter_Differential);
            var coefficient = GetRelatedItemValue(MetricIdentifier.Meter_Coefficient);

            decimal result = (decimal)Math.Sqrt((double)((linePresure + basePresure) * differential)) * coefficient;

            this.Value = result.ToString();
        }

        public void GetChartFlow()
        {
            decimal result = 0;

            try
            {
                var linePresure = GetRelatedItemValue(MetricIdentifier.Meter_Static_Line_Pressure);
                var basePresure = GetRelatedItemValue(MetricIdentifier.Constant_Base_Presure);
                var differential = GetRelatedItemValue(MetricIdentifier.Meter_Differential);
                var coefficient = GetRelatedItemValue(PropertiesIdentifier.Meter_Chart_Coefficient);
                var gravity = GetRelatedItemValue(MetricIdentifier.Constant_Gravity);
                var cycleTimeOn = GetRelatedItemValue(MetricIdentifier.Meter_Chart_Cycle_Time_On);
                var cycleTimeOff = GetRelatedItemValue(MetricIdentifier.Meter_Chart_Cycle_Time_Off);


                decimal volume = (decimal)Math.Sqrt((double)((linePresure + basePresure) * differential)) * coefficient;
                decimal volumeGravity = ((decimal)(1 / Math.Sqrt((double)gravity)));
                decimal gravityAdjVolume = (volume / volumeGravity);
                decimal gravityAdjVolume_tempAdjFactor = 1;
                decimal tempAdjVolume = (gravityAdjVolume * gravityAdjVolume_tempAdjFactor);
                decimal totalMcfDayGravity = (decimal)Math.Sqrt((double)(1 / gravity));
                decimal totalMcfDia = (tempAdjVolume * totalMcfDayGravity);
                decimal cyclesResult = (cycleTimeOn + cycleTimeOff);

                decimal adjMcfDayCicle = 0;
                if (cyclesResult > 0)
                {
                    adjMcfDayCicle = (cycleTimeOn / cyclesResult);
                }

                result = (totalMcfDia * adjMcfDayCicle);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"@@@@@@@@@@@@@@@@ ERROR FORMULA GetChartFlow: {ex.Message} - {ex.StackTrace}");
            }

            this.Value = result.ToString();
        }

        public void GetNfgFlow()
        {
            decimal result = 0;

            try
            {
                var basePresure = GetRelatedItemValue(MetricIdentifier.Constant_Base_Presure);
                var linePresure = GetRelatedItemValue(MetricIdentifier.Meter_Static_Line_Pressure);
                var beginIndex = GetRelatedItemValue(MetricIdentifier.Meter_NFG_Begin_Mec_Index);
                var endIndex = GetRelatedItemValue(MetricIdentifier.Meter_NFG_End_Mec_Index);
                var beginDate = GetRelatedItemDate(MetricIdentifier.Meter_Index_Begin_Date);
                var endDate = GetRelatedItemDate(MetricIdentifier.Meter_Index_End_Date);

                double days = 0;
                if (beginDate != null && endDate != null)
                {
                    days = ((DateTime)endDate - (DateTime)beginDate).TotalDays;
                }

                if (days > 0)
                {
                    var readingChange = GetReadingChange(Convert.ToDouble(beginIndex), Convert.ToDouble(endIndex));

                    decimal presures = (basePresure + linePresure) / basePresure * Convert.ToDecimal(readingChange);
                    decimal gravityAdjVolume_tempAdjFactor = 1;
                    decimal temps = presures * gravityAdjVolume_tempAdjFactor;

                    result = temps * (24 / Convert.ToDecimal(days * 24));

                    var isCcfMeter = this.ExpressionObjects.FirstOrDefault(a => a.GroupKey == MetricIdentifier.Meter_CCF);
                    if (isCcfMeter != null && isCcfMeter.ValueText == "YES")
                    {
                        result /= 10;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"@@@@@@@@@@@@@@@@ ERROR FORMULA GetNfgFlow: {ex.Message} - {ex.StackTrace}");
            }

            this.Value = result.ToString();
        }

        public void GetRotaryFlowCalculation()
        {
            decimal result = 0;

            try
            {
                bool useUncorrectedFormula = true;
                var uncorrectedCalculationItem = this.ExpressionObjects.FirstOrDefault(a => a.GroupKey == MetricIdentifier.Meter_Rotary_Uncorrected_Calculation);
                if (uncorrectedCalculationItem != null)
                {
                    useUncorrectedFormula = (uncorrectedCalculationItem.ValueText == "YES");
                }

                var basePresure = GetRelatedItemValue(MetricIdentifier.Constant_Base_Presure);
                var linePresure = GetRelatedItemValue(MetricIdentifier.Meter_Static_Line_Pressure);
                var beginIndex = GetRelatedItemValue(MetricIdentifier.Meter_Rotary_Begin_Index);
                var endIndex = GetRelatedItemValue(MetricIdentifier.Meter_Rotary_End_Index);
                var beginDate = GetRelatedItemDate(MetricIdentifier.Meter_Index_Begin_Date);
                var endDate = GetRelatedItemDate(MetricIdentifier.Meter_Index_End_Date);

                double days = 0;
                if (beginDate != null && endDate != null)
                {
                    days = ((DateTime)endDate - (DateTime)beginDate).TotalDays;
                }

                if (days > 0)
                {
                    double readingChange = GetReadingChange(Convert.ToDouble(beginIndex), Convert.ToDouble(endIndex));

                    if (useUncorrectedFormula)
                    {
                        decimal presures = (basePresure + linePresure) / basePresure * (decimal)readingChange;
                        decimal gravityAdjVolume_tempAdjFactor = 1;
                        decimal temps = presures * gravityAdjVolume_tempAdjFactor;

                        result = temps * (24 / Convert.ToDecimal(days * 24));
                    }
                    else
                    {
                        result = Convert.ToDecimal(readingChange * (24 / (days * 24)));
                    }

                    var isCcfMeter = this.ExpressionObjects.FirstOrDefault(a => a.GroupKey == MetricIdentifier.Meter_CCF);
                    if (isCcfMeter != null)
                    {
                        if (isCcfMeter.ValueText == "YES")
                        {
                            result /= 10;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"@@@@@@@@@@@@@@@@ ERROR FORMULA GetRotaryFlowCalculation: {ex.Message} - {ex.StackTrace}");
            }

            this.Value = result.ToString();
        }

        public static double GetReadingChange(double beginIndex, double endIndex)
        {
            var beginIndexValues = beginIndex.ToString().Split('.');

            double result;
            if (endIndex < beginIndex)
            {
                var odometerLenght = beginIndexValues[0].Length;
                StringBuilder maxValueText = new StringBuilder();

                for (int i = 0; i < odometerLenght; i++)
                {
                    maxValueText.Append(9);
                }

                int maxValue = Convert.ToInt32(maxValueText.ToString()) + 1;
                result = (maxValue - beginIndex) + endIndex;
            }
            else
            {
                result = (endIndex - beginIndex);
            }

            return result;
        }

        protected decimal GetRelatedItemValue(string key)
        {
            try
            {
                var item = this.ExpressionObjects.FirstOrDefault(a => a.GroupKey.ToUpper() == key);
                if (item != null)
                {
                    //normal entry with value
                    if (!string.IsNullOrEmpty(item.Value))
                    {
                        return Convert.ToDecimal(item.Value);
                    }

                    //entry woth no value but default one
                    if (!string.IsNullOrEmpty(item.DefaultValue))
                    {
                        return Convert.ToDecimal(item.DefaultValue);
                    }

                    return 0;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        protected DateTime? GetRelatedItemDate(string key)
        {
            try
            {
                var item = this.ExpressionObjects.FirstOrDefault(a => a.GroupKey.ToUpper() == key);
                if (item != null)
                {
                    if (item.SelectedDate != null)
                    {
                        return (DateTime)item.SelectedDate;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        public DynamicFormItem Clone()
        {
            var result = (DynamicFormItem)this.MemberwiseClone();

            result.ExpressionObjects = new List<DynamicFormItem>();
            result.RelatedObjects = new List<DynamicFormItem>();
            result.Items = new List<MetricList>();

            return result;
        }
    }
}
