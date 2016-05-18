namespace Suoja
{
    class SuojaCryptographicData
    {
        private byte[] _key;
        public byte[] Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
            }
        }

        private byte[] _IV;
        public byte[] IV
        {
            get
            {
                return _IV;
            }
            set
            {
                _IV = value;
            }
        }
    }
}
