using System.Security.Cryptography;
using System.IO;
using System.Linq;

namespace Suoja
{
    class SuojaProvider
    {

        RijndaelManaged AesProvider = new RijndaelManaged();
        HMACSHA256 HMACProvider = new HMACSHA256();

        private byte[] _aesKey;
        /// <summary>
        /// The Key used for en-/decrypting.
        /// </summary>
        public byte[] AesKey
        {
            get
            {
                return _aesKey;
            }
            set
            {
                _aesKey = value;
                AesProvider.Key = value;
            }
        }

        private byte[] _aesIV;
        /// <summary>
        /// The IV (Initialization Vector) used for en-/decrypting.
        /// </summary>
        public byte[] AesIV
        {
            get
            {
                return _aesIV;
            }
            set
            {
                _aesIV = value;
                AesProvider.IV = value;
            }
        }

        /// <summary>
        /// Initialize a new SuojaProvider with randomly generated Key and IV.
        /// </summary>
        public SuojaProvider()
        {
            AesProvider = new RijndaelManaged(); //Initialize the Rijndael-implementation
            AesProvider.KeySize = 256; //Set KeySize
            AesProvider.BlockSize = 128; //Set BlockSize
            AesProvider.Padding = PaddingMode.Zeros; //Set Padding
            AesProvider.Mode = CipherMode.CBC; //Set Mode
            AesProvider.GenerateKey(); //Generate Key
            _aesKey = AesProvider.Key; //Save Key
            AesProvider.GenerateIV(); //Generate IV (Initialization Vector)
            _aesIV = AesProvider.IV; //Save IV

        }

        /// <summary>
        /// Initialize a new SuojaProvider using exisiting Key and IV.
        /// </summary>
        /// <param name="data">Data storage containing a valid Key and IV.</param>
        public SuojaProvider(SuojaCryptographicData data)
        {
            AesProvider = new RijndaelManaged(); //Initialize the Rijndael-implementation
            AesProvider.KeySize = 256; //Set KeySize
            AesProvider.BlockSize = 128; //Set BlockSize
            AesProvider.Padding = PaddingMode.Zeros; //Set Padding
            AesProvider.Mode = CipherMode.CBC; //Set Mode
            AesIV = data.AesIV; //Import existing Key
            AesKey = data.AesKey; //Import existing IV
        }

        /// <summary>
        /// Export the Providers randomly generated Key and IV.
        /// </summary>
        /// <returns></returns>
        public SuojaCryptographicData GetCryptographicData()
        {
            SuojaCryptographicData data = new SuojaCryptographicData(); //Create new data storage
            data.AesIV = AesIV; //Export IV
            data.AesKey = AesKey; //Export Key
            return data;
        }

        /// <summary>
        /// Encrypts a file.
        /// </summary>
        /// <param name="filepath">Path of the original file.</param>
        /// <param name="outputPath">Path of the place, where to save the encrypted file.</param>
        /// <returns></returns>
        public bool Encrypt(string filepath, string outputPath)
        {
            try
            {
                FileStream inputStream = new FileStream(filepath, FileMode.Open);
                FileStream outputStream = new FileStream(outputPath + ".data", FileMode.Create);
                ICryptoTransform ict = AesProvider.CreateEncryptor();
                CryptoStream stream = new CryptoStream(outputStream, ict, CryptoStreamMode.Write);

                int data;
                while ((data = inputStream.ReadByte()) != -1) //While there is data left
                    stream.WriteByte((byte)data); //Encrypt and write that data

                inputStream.Dispose(); //Cleanup
                stream.Dispose(); //Cleanup
                outputStream.Dispose(); //Cleanup
                ict.Dispose(); //Cleanup

                CreateHMACSignature(outputPath + ".data", outputPath); //Create a signature to validate the file
                string[] filenames = { outputPath + ".data", outputPath + ".hmac" };
                SuojaCompression.Compress(filenames, outputPath); //Store the signature in the file

                return true; //Everything went fine
            }
            catch
            {
                return false; //Something went wrong
            }
        }

        /// <summary>
        /// Decrypts a file.
        /// </summary>
        /// <param name="filepath">Path of the encrypted file.</param>
        /// <param name="outputPath">Path of the place, where to save the decrypted file.</param>
        /// <returns></returns>
        public bool Decrypt(string filepath, string outputPath)
        {
            //try
            //{
                SuojaCompression.Extract(filepath, filepath.Remove(filepath.Length - filepath.Split('\\').Last().Length, filepath.Split('\\').Last().Length));

                if (ValidateHMACSignature(filepath + ".data", filepath + ".hmac")) //Check if the signature is valid
                {

                    FileStream inputStream = new FileStream(filepath + ".data", FileMode.Open);
                    FileStream outputStream = new FileStream(outputPath, FileMode.Create);
                    ICryptoTransform ict = AesProvider.CreateDecryptor();
                    CryptoStream stream = new CryptoStream(inputStream, ict, CryptoStreamMode.Read);

                    int data;
                    while ((data = stream.ReadByte()) != -1) //While there is data left
                        outputStream.WriteByte((byte)data); //Decrypt and write that data

                    outputStream.Dispose(); //Cleanup
                    stream.Dispose(); //Cleanup
                    inputStream.Dispose(); //Cleanup
                    ict.Dispose(); //Cleanup

                    return true; //Everything went fine 
                }
                return false;
            //}
            //catch
            //{
            //    return false; //Something went wrong (eg. wrong Key/IV)
            //}
        }

        private void CreateHMACSignature(string filepath, string outputPath)
        {
            FileStream inputStream = new FileStream(filepath, FileMode.Open);
            FileStream outputStream = new FileStream(outputPath + ".hmac", FileMode.Create);
            HMACProvider = new HMACSHA256(AesKey);
            byte[] hash = HMACProvider.ComputeHash(inputStream); //Create a signature
            outputStream.Write(hash, 0, hash.Length); //Save in file

            inputStream.Dispose(); //Cleanup
            HMACProvider.Dispose(); //Cleanup
            outputStream.Dispose(); //Cleanup
        }

        private bool ValidateHMACSignature(string filepath, string signaturepath)
        {
            FileStream inputStream = new FileStream(filepath, FileMode.Open); 
            FileStream signatureInputStream = new FileStream(signaturepath, FileMode.Open);
            HMACProvider = new HMACSHA256(AesKey);
            byte[] hash = HMACProvider.ComputeHash(inputStream); //Create a signature
            byte[] signature = new byte[signatureInputStream.Length]; 

            signatureInputStream.Read(signature, 0, signature.Length); //Load the files signature

            inputStream.Dispose(); //Cleanup
            HMACProvider.Dispose(); //Cleanup
            signatureInputStream.Dispose(); //Cleanup
            return hash.SequenceEqual(signature); //Check if the signatures are valid
        }

    }
}
