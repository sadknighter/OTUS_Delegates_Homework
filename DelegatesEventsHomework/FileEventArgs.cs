namespace DelegatesEventsHomework
{
    public class FileEventArgs : EventArgs
    {
        public string? FileName { get; set; }

        public FileEventArgs(string? fileName)
            :base()
        {
            FileName = fileName;
        }
    }
}
