namespace FDCApp.Contracts.Enumerations
{
    public enum DownloadStatus
    {
        Pending,
        Syncing,
        ErrorDownloading,
        Downloaded,
        Outdated,
        ErrorUploading,
        DeletingLocal,
        SavingLocal,
        ErrorSavingLocalData
    }
}
