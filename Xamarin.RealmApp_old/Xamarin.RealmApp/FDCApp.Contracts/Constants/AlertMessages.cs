namespace FDCApp.Contracts.Constants
{
    public static class AlertMessages
    {
        //Message
        public const string RequiredFields = "Please fill all the required fields";
        public const string SuccessfullySaved = "Data saved successfully";
        public const string ErrorSaving = "Error saving the information";
        public const string DeviceNotAllowedCamera = "Device does not allow to take photos.";
        public const string ImageSelectedNotAllowed = "Device does not allow image selection.";
        public const string NoteRequired = "You must write a note";
        public const string TicketDeleteRestricted = "You can't delete this ticket because the produce value at {0} becomes negative.";
        public const string TicketEditRestricted = "You can't edit this ticket volume less than ({0}) because the produce value at {1} becomes negative.";
        public const string NoPreviousTickets = "There are no previous tickets";
        public const string AssetDirectionRequired = "Please write the asset directions";
        public const string ActivityRequired = "You must choose at least one activity";
        public const string MaxTicketNumber = "The ticket number can only have a maximum of {0} characters";
        public const string OK = "OK";
        public const string ChooseImage = "Choose image";
        public const string TakePhoto = "Take photo";
        public const string Loading = "Loading...";
        public const string Cancel = "Cancel";
        public const string FormsHasNoSite = "Forms has no site selected";
        public const string FormsHasNoAsset = "Forms has no asset selected";
        public const string NoAssociatedVisit = "No associated visit form found.";
        public const string SelectedFormNoFound = "Selected form type was not found.";
        public const string SelectedFormIdNoFound = "Selected form id was not found.";
        public const string SelectedFormNoQuestion = "Selected form does not have Sections/Questions configured.";
        public const string SyncingMasterData = "Syncing master data...";
        public const string ReconciliatingCFData = "Reconciliating carryforward data...";
        public const string SyncOverwriteButton = "Sync + Overwrite";
        public const string SyncOverwriteTitle = "Sync and Overwrite?";
        public const string LastVisits_No_Visits = "Selected asset does not have stored visits.";
        public const string DowntimeEndDateRequired = "Make sure you have entered data for Downtime End date: {0}, Please verify.";
        public const string DowntimeEndDateEarlierThanStartDate = "Downtime end date {0} can't be earlier or equal than Downtime start date {1}. Please enter a valid value.";
        public const string MetricValueValidation = "{0}, {1} at {2}: {3}"; //0=asset name, 1=metric name, 2=metric day, 3=metric error message
        public const string ConditionFields = "Please check conditions in all fields";

        //Confirmation
        public const string DeleteDirection = "Delete direction";
        public const string Confirmation = "Are you sure?";
        public const string DeleteTicket = "Delete ticket";
        public const string DeleteForm = "Delete form";
        public const string DeleteNote = "Delete Note";
        public const string DiscardChanges = "Discard changes?";
        public const string PendingChanges = "There are unsaved changes. Exiting without saving will cause loss of unsaved data.";
        public const string TicketNumberConfirmation = "Do you have an actual ticket number? Please enter your ticket number if you have one.";
        public const string SyncOverwriteSites = "App will attempt to save any unsaved data, and then download latest data for ALL SITES in this route, overwriting local database. Do you want to proceed?";

        public const string Logout_Title = "Logout";
        public const string Logout_Prompt = "There are some data pending for syncing. Do you want to logout anyway?";

        //MessageError
        public const string ErrorConfiguringMetrics = "Error configuring metrics";
        public const string ErrorConfiguringFields = "Error configuring fields";
        public const string ValueMustLess = "Value must be less than {0}";
        public const string AssetMissingValues = "The {0} has missing values: {1}";
        public const string NoHaulDateMetrciFound = "No haul date or volume metrics were found.";
        public const string MissingValues = "There are some missing/wrong values, Please verify.";
        public const string AssetHasMissingValues = "The Asset has missing values.";
        public const string RegisterTreatmentAlert = "You have registered data for Treatment, UOM or Quantity on {0} for asset: {1}, Please add values for all of them.";
        public const string RegisteredDataAsset = "You have registered data for Downtime Start date on asset: {0}, Please select the corresponding downtime reason.";
        public const string NegativeValueTankProduced = "There is a negative value {0} on Tank produce at {1}, Please correct this.";
        public const string FillMandatoryFields = "Please fill in {0} all mandatory fields {1}";
        public const string CombinedCycleLess24 = "Combined cycle time On/Off on {0} must be less or equal than 24 hours, please verify.";
        public const string TankHeight = "Tank height, ";
        public const string StrapFactor = "Strap factor";
        public const string PictureAndFieldsValidation = "Please make sure the front picture has been taken and fill in all the fields.";
        public const string PermissionFeatureNotEnought = "FDC does not have enought permission to use this feature, please go to settings and enable it manually.";
        public const string PermissionFeatureDisabled = "Permission to this feature had been disabled, please go to settings and enable it manually.";
        public const string PermissionFeatureRestricted = "Permission to this feature had been restricted, please go to settings and enable it manually.";
        public const string ShutValveMissingValues = "The {0} has missing values: Please fill the Shut valve/Off Time value at {1}";
        public const string OpenValveMissingValues = "The {0} has missing values: Please fill the Open valve/On Time value at {1}";
        public const string EmptyValues = "Please enter the value";
        public const string MandatoryMetrics = "Please fill in {0} all mandatory fields on date {1}";
        public const string NoItems = "There are no items to show";


        //log messages
        public const string Log_API_Error = "Error getting data from server.";
        public const string Log_API_Data_Error = "Error getting data from server.";
        public const string Log_Unknown_Error = "Unknown error.";
    }                                               
}
