using System.Security.Cryptography;
using System.IO;
using System.Linq;
using System;

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
            AesIV = data.IV; //Import existing Key
            AesKey = data.Key; //Import existing IV
        }

        /// <summary>
        /// Export the Providers randomly generated Key and IV.
        /// </summary>
        /// <returns></returns>
        public SuojaCryptographicData GetCryptographicData()
        {
            SuojaCryptographicData data = new SuojaCryptographicData(); //Create new data storage
            data.IV = AesIV; //Export IV
            data.Key = AesKey; //Export Key
            return data;
        }

        /// <summary>
        /// Encrypts a file.
        /// </summary>
        /// <param name="filepath">Path of the original file.</param>
        /// <param name="outputPath">Path of the place, where to save the encrypted file.</param>
        /// <returns></returns>
        public EnumerationTypes.JobResult Encrypt(string filepath, string outputPath, string keyPath)
        {
            try
            {
                FileStream inputStream = new FileStream(filepath, FileMode.Open); //Input stream that reads the original file
                FileStream outputStream = new FileStream(PathHelper.GetDirectory(filepath) + ".data", FileMode.Create); //Output stream that writes the encrypted file
                ICryptoTransform ict = AesProvider.CreateEncryptor(); //Contains the data for the encryption
                CryptoStream stream = new CryptoStream(outputStream, ict, CryptoStreamMode.Write); //Stream used for encryption

                int data;
                while ((data = inputStream.ReadByte()) != -1) //While there is data left
                    stream.WriteByte((byte)data); //Encrypt and write that data

                inputStream.Dispose(); //Cleanup
                stream.Dispose(); //Cleanup
                outputStream.Dispose(); //Cleanup
                ict.Dispose(); //Cleanup

                CreateKeyHash(keyPath, PathHelper.GetDirectory(keyPath) + ".sha256"); //Create a signature to validate the key 
                CreateHMACSignature(PathHelper.GetDirectory(filepath) + ".data", PathHelper.GetDirectory(filepath) + ".hmac"); //Create a signature to validate the file
                string[] filenames = { PathHelper.GetDirectory(filepath) + ".data", PathHelper.GetDirectory(filepath) + ".hmac", PathHelper.GetDirectory(keyPath) + ".sha256" }; //Combine data and signatures
                SuojaCompression.Compress(filenames, outputPath); //Store the all contents in the file

                return EnumerationTypes.JobResult.Fine; //Everything went fine
            }
            catch
            {
                return EnumerationTypes.JobResult.Unknown; //Something went wrong
            }
        }

        /// <summary>
        /// Decrypts a file.
        /// </summary>
        /// <param name="filepath">Path of the encrypted file.</param>
        /// <param name="outputPath">Path of the place, where to save the decrypted file.</param>
        /// <returns></returns>
        public EnumerationTypes.JobResult Decrypt(string filepath, string outputPath, string keyPath)
        {
            try
            {
                SuojaCompression.Extract(filepath, PathHelper.GetDirectory(filepath));
                if (!ValidateKeyHash(keyPath, PathHelper.GetDirectory(filepath) + ".sha256"))
                {
                    return EnumerationTypes.JobResult.BadKey; //Something went wrong (eg. wrong Key/IV)
                }
                if (ValidateHMACSignature(PathHelper.GetDirectory(filepath) + ".data", PathHelper.GetDirectory(filepath) + ".hmac")) //Check if the signature is valid
                {

                    FileStream inputStream = new FileStream(PathHelper.GetDirectory(filepath) + ".data", FileMode.Open); //Input stream that reads the original file
                    FileStream outputStream = new FileStream(outputPath, FileMode.Create); //Output stream that writes the decrypted file
                    ICryptoTransform ict = AesProvider.CreateDecryptor(); //Contains the data for the decryption
                    CryptoStream stream = new CryptoStream(inputStream, ict, CryptoStreamMode.Read); //Stream used for decryption

                    int data;
                    while ((data = stream.ReadByte()) != -1) //While there is data left
                        outputStream.WriteByte((byte)data); //Decrypt and write that data

                    outputStream.Dispose(); //Cleanup
                    stream.Dispose(); //Cleanup
                    inputStream.Dispose(); //Cleanup
                    ict.Dispose(); //Cleanup

                    return EnumerationTypes.JobResult.Fine; //Everything went fine 
                }
                return EnumerationTypes.JobResult.BadData; //Wrong signature
            }
            catch
            {
                return EnumerationTypes.JobResult.Unknown; //Something went wrong
            }
        }

        private void CreateHMACSignature(string filepath, string outputPath)
        {

            FileStream inputStream = new FileStream(filepath, FileMode.Open); //Input stream that reads the encrypted file
            FileStream outputStream = new FileStream(outputPath, FileMode.Create); //Output stream that writes the signature
            HMACProvider = new HMACSHA256(AesKey);
            byte[] hash = HMACProvider.ComputeHash(inputStream); //Create a signature
            outputStream.Write(hash, 0, hash.Length); //Save in file

            inputStream.Dispose(); //Cleanup
            HMACProvider.Dispose(); //Cleanup
            outputStream.Dispose(); //Cleanup
        }

        private bool ValidateHMACSignature(string filepath, string signaturePath)
        {
            try
            {
                FileStream inputStream = new FileStream(filepath, FileMode.Open); //Input stream that reads the encrypted file
                FileStream signatureInputStream = new FileStream(signaturePath, FileMode.Open); //Input stream that reads the signature
                HMACProvider = new HMACSHA256(AesKey);
                byte[] hash = HMACProvider.ComputeHash(inputStream); //Create a signature
                byte[] signature = new byte[signatureInputStream.Length];  //Prepare a byte array for the existing signature

                signatureInputStream.Read(signature, 0, signature.Length); //Load the files signature

                inputStream.Dispose(); //Cleanup
                HMACProvider.Dispose(); //Cleanup
                signatureInputStream.Dispose(); //Cleanup
                return hash.SequenceEqual(signature); //Check if the signatures are valid
            }
            catch
            {
                return false;
            }
        }

        private void CreateKeyHash(string filepath, string outputPath)
        {
            FileStream inputStream = new FileStream(filepath, FileMode.Open); //Input stream that reads the encrypted file
            FileStream outputStream = new FileStream(outputPath, FileMode.Create); //Output stream that writes the signature
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hash = sha.ComputeHash(inputStream); //Create a signature
                outputStream.Write(hash, 0, hash.Length); //Save in file
            }
            inputStream.Dispose(); //Cleanup
            outputStream.Dispose(); //Cleanup
        }

        private bool ValidateKeyHash(string filepath, string signaturePath)
        {
            try
            {
                FileStream inputStream = new FileStream(filepath, FileMode.Open); //Input stream that reads the encrypted file
                FileStream signatureInputStream = new FileStream(signaturePath, FileMode.Open); //Input stream that reads the signature
                byte[] hash;
                using (SHA256 sha = SHA256.Create())
                {
                    hash = sha.ComputeHash(inputStream); //Create a signature
                }
                byte[] signature = new byte[signatureInputStream.Length];  //Prepare a byte array for the existing signature

                signatureInputStream.Read(signature, 0, signature.Length); //Load the files signature

                inputStream.Dispose(); //Cleanup
                signatureInputStream.Dispose(); //Cleanup
                return hash.SequenceEqual(signature); //Check if the signatures are valid
            }
            catch
            {
                return false;
            }
        }
    }
}
