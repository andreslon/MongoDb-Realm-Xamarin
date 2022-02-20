namespace FDCApp.Contracts.Constants
{
    public static class MetricAction
    {
        //Common actions
        public const string Save = "Save";
        public const string Submit = "Submit";
        public const string Edit = "Edit";
        public const string New = "New";
        public const string Selection = "Selection";
        public const string Validation = "Validate data";
        public const string Delete = "Delete";
        public const string Search = "Search";

        //Error actions
        public const string ErrorGeneric = "Error";
        public const string ErrorSaving = "Error saving data";
        public const string ErrorDeleting = "Error deleting data";
        public const string ErrorValidating = "Error validating data";
        public const string ErrorConfiguring = "Error configuring data";
        public const string ErrorTakingPhoto = "Error taking photo";
        public const string ErrorGallerySelection = "Error selecting from gallery";
        public const string ErrorApiGet = "Error getting info from API";
        public const string ErrorAuthentication = "Authentication error";
        public const string ErrorDatabase = "Database error";
        public const string ErrorLoading = "Loading error";
        public const string ErrorGettingFeatureConfiguration = "Error getting feature configuration";

        //Application actions
        public const string Init = "Initialization";
        public const string Sleep = "Moved to background";        
        public const string Resume = "Moved to foreground";

        //Sync actions
        public const string Download = "Download";
        public const string Downloading = "Downloading";
        public const string DownloadSuccessfull = "Download successfull";
        public const string DownloadFail = "Download fail";
        public const string DownloadWithErrors = "Download with errors";
        public const string Upload = "Upload";
        public const string Uploading = "Uploading";
        public const string UploadSuccessfull = "Upload successfull";
        public const string UploadFail = "Upload fail";
        public const string UploadWithErrors = "Upload with errors";
        public const string SyncProcessStart = "Sync process start";
        public const string SyncProcessEnd = "Sync process end";

        //BL Actions
        public const string CFReconciliationProcessStart = "CF reconciliation process start";
        public const string CFReconciliationProcessEnd = "CF reconciliation process end";
        public const string CFReconciliationProcessError = "CF reconciliation process error";

        //User actions
        public const string ADLogin = "AD Login";
        public const string LoggingIn = "Signing In";
        public const string LoggingFail = "Logging fail";
        public const string LoggingSuccess = "Logging successfull";
        public const string Logout = "Signing Out";
        public const string LogoutFail = "Signing Out fail";
        public const string AuthenticationCanceled = "Authentication canceled";
        public const string ForceTokenRefresh = "Force Token refresh";

        //Picture actions
        public const string PictureSelection = "Image selection";
        public const string PictureTakePhoto = "Photo taken";
        public const string PictureGallerySelection = "Gallery selection";
        public const string PictureReplace = "Replace picture";

        //Permissions
        public const string Granted = "Granted";
        public const string Denied = "Denied";
        public const string Disabled = "Disabled";
        public const string Restricted = "Restricted";

        //Form actions
        public const string Open = "Open";
        public const string Close = "Close";
        public const string ListViewTypeNoSupported = "Warning";

        //Especific actions
        public const string RecalculateTankVolume = "Recalculate Tank volume";
    }
}