namespace FDCApp.Contracts.Constants
{
    public static class MetricIdentifier
    {
        //Constants
        public const string Constant_Base_Presure = "MTR112";
        public const string Constant_Rankine = "MTR116";
        public const string Constant_Temperature = "MTR110";
        public const string Constant_Gravity = "MTR111";

        //Domestic location
        public const string DomesticLocation_Read_Frecuency_Month = "DLM001";
        public const string DomesticLocation_Customer_Name = "DLM002";
        public const string DomesticLocation_Service_Address = "DLM003";
        public const string DomesticLocation_Service_Address_Directions = "DLM004";
        public const string DomesticLocation_Service_Address_Lat_Long = "DLM005";
        public const string DomesticLocation_Read_Date = "MTR142";
        public const string DomesticLocation_Read_Pressure = "MTR143";
        public const string DomesticLocation_Index = "MTR144";
        public const string DomesticLocation_Invisible = "MTR147";
        public const string DomesticLocation_Uncorrected_Calculation = "MTR104";
        public const string DomesticLocation_Volume = "MTR145";
        public const string DomesticLocation_Comments = "MTR146";

        //Tank metrics
        public const string Tank_Top_Gauge = "MTR035";
        public const string Tank_Volume = "MTR005";
        public const string Tank_Produced = "MTR004";
        public const string Tank_Water_Hauled = "MTR186";
        public const string Tank_Oil_Hauled = "MTR187";

        //Tank metrics        
        public const string Hybrid_Tank_Water_Gauge = "MTR162";
        public const string Hybrid_Tank_Oil_Volume = "MTR163";
        public const string Hybrid_Tank_Water_Volume = "MTR164";
        public const string Hybrid_Tank_Oil_Produced = "MTR165";
        public const string Hybrid_Tank_Water_Produced = "MTR166";

        //Well        
        public const string Well_Production_Method = "MTR096";
        public const string Well_Treatment = "MTR087";
        public const string Well_Quantity = "MTR067";
        public const string Well_UOM = "MTR088";
        public const string Well_Shut_Valve = "MTR155";
        public const string Well_Open_Valve = "MTR156";

        //Meter        
        public const string Meter_Static_Line_Pressure = "MTR034";
        public const string Meter_Differential = "MTR022";
        public const string Meter_Coefficient = "MTR109";
        public const string Meter_Rotary_Uncorrected_Calculation = "MTR104";
        public const string Meter_CCF = "MTR126";
        public const string Meter_Index_Begin_Date = "MTR027";
        public const string Meter_Index_End_Date = "MTR028";

        public const string Meter_Rotary_Begin_Index = "MTR101";
        public const string Meter_Rotary_End_Index = "MTR100";
        public const string Meter_NFG_Begin_Mec_Index = "MTR106";
        public const string Meter_NFG_End_Mec_Index = "MTR107";
        public const string Meter_Chart_Cycle_Time_On = "MTR021";
        public const string Meter_Chart_Cycle_Time_Off = "MTR020";

        //Downtime
        public const string Downtime_Start_Date = "MTR052";
        public const string Downtime_End_Date = "MTR051";
        public const string Downtime_Reason = "MTR085";

        //Tickets
        public const string Ticket_Volume = "MTR009";
        public const string Ticket_Total_Volume = "MTR001";
        public const string Ticket_Haul_Date = "MTR037";
        public const string Ticket_Produced = "MTR004";
        public const string Ticket_Fluid_Disposition = "MTR081";
        public const string Ticket_Destination = "MTR080";
        public const string Ticket_Transporter = "MTR082";
        public const string Ticket_Disposal_Company = "MTR094";
        public const string Ticket_Liquid = "MTR038";

        public const string Ticket_Net_Volume = "MTR172";
        public const string Ticket_Gross_Volume = "MTR171";

        //INSPECTIONS AND AST FORMS
        public const string DIKE_SHAPE_QUESTION_ID = "3.1";
        public const string TOTAL_TANK_STORAGE_ID = "3.8";
        public const string LARGEST_TANK_STORAGE_ID = "3.9";
        public const string MINIMUN_DIKE_CAPACITY = "3.10";
        public const string SPCC_COMMENTARY = "5.1";
        public const string AST_COMMENTARY = "1.0";
        public const string WV_WELL_NUMBER = "WV-4.2";
        public const string WV_WELL_NAME = "WV-4.3";
    }
}