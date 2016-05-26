namespace Suoja
{
    public class EnumerationTypes
    {
        public enum JobAction
        {
            Encrypt,
            Decrypt
        }

        public enum KeySource
        {
            New,
            File
        }

        public enum HandleMethod
        {
            Compress,
            Individual,
            Equal
        }

        public enum FileNameOption
        {
            Keep,
            Encode
        }

        public enum JobStatus
        {
            Queued,
            Finished,
            Failed
        }
    }
}
