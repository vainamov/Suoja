namespace Suoja
{
    class SuojaCryptographicData
    {
        private byte[] _aesKey;
        public byte[] AesKey
        {
            get
            {
                return _aesKey;
            }
            set
            {
                _aesKey = value;
            }
        }

        private byte[] _aesIV;
        public byte[] AesIV
        {
            get
            {
                return _aesIV;
            }
            set
            {
                _aesIV = value;
            }
        }
    }
}
