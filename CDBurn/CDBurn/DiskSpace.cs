namespace CDBurn
{
    public class DiskSpace
    {
        public delegate void UsedSpaceChangedHandler(long value);
        public event UsedSpaceChangedHandler UsedSpaceChanged;
        public long TotalSpace { get; set; }
        private long _usedSpace;
        public long UsedSpace
        {
            get => _usedSpace;
            set
            {
                _usedSpace = value;
                UsedSpaceChanged?.Invoke(_usedSpace);
            }
        }
    }
}
