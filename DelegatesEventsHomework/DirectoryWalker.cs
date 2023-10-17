namespace DelegatesEventsHomework
{
    public class DirectoryWalker
    {
        public event EventHandler<FileEventArgs> FileFound;

        private readonly string _directoryPath;

        public DirectoryWalker(string directoryPath)
        {
            _directoryPath = directoryPath;
            FileFound += DirectoryWalker_FileFound;
        }

        private void DirectoryWalker_FileFound(object? sender, FileEventArgs e)
        {
            Console.WriteLine("Raised event: {0}. File found: '{1}'", nameof(DirectoryWalker_FileFound), e.FileName);
        }

        public void Walk()
        {
            if (File.Exists(_directoryPath))
            {
                throw new DirectoryNotFoundException("It's a file. Not a directory");
            }

            var directoryname = Path.GetDirectoryName(_directoryPath);
            
            if (directoryname == null)
            {
                throw new NullReferenceException();
            }

            
            var rootDirectory = new DirectoryInfo(directoryname);

            Walk(rootDirectory);
        }
        private void Walk(DirectoryInfo directoryInfo)
        {
            Thread.Sleep(1000);
            var files = directoryInfo.GetFiles();

            foreach (var file in files)
            {
                OnFileFoundEvent(new FileEventArgs(file.FullName));

                if (Console.KeyAvailable)
                {
                    return;
                }
            }

            var innerDirectories = directoryInfo.GetDirectories();

            foreach (var directory in innerDirectories)
            {
                Walk(directory);

                if (Console.KeyAvailable)
                {
                    return;
                }
            }
        }

        protected virtual void OnFileFoundEvent(FileEventArgs e) => FileFound?.Invoke(this, e);
    }
}
