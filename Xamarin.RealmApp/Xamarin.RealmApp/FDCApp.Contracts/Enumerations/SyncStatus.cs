namespace FDCApp.Contracts.Enumerations
{
    public enum SyncStatusLocal
    {
        None = 0,
        Synced = 1,
        Pending = 2,
        Error = 3,
        New = 4,
        PendingParentConfirmation = 5,
        Trash = 6
    }
}
