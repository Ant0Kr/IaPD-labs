using IMAPI2;

namespace CDBurn
{
    public class BurnAction
    {
        public delegate void WriteActionHandler(FormatDataWriteAction a);
        public event WriteActionHandler WriteActionChanged;
        private FormatDataWriteAction _writeAction;
        public FormatDataWriteAction WriteAction
        {
            get => _writeAction;
            set
            {
                if (_writeAction.Equals(value)) return;
                _writeAction = value;
                WriteActionChanged?.Invoke(_writeAction);
            }
        }     
    }
}
