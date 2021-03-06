﻿using System.Linq;

namespace Suoja
{
    public class SuojaJob
    {

        /// <summary>
        /// Path of the Input file.
        /// </summary>
        public string Filepath { get; set; }
        /// <summary>
        /// Path of the Directory.
        /// </summary>
        public string BaseDirectory
        {
            get
            {
                return Filepath.Substring(0, Filepath.Length - Filepath.Split('\\').Last().Length);
            }
        }
        /// <summary>
        /// Path of the Key file.
        /// </summary>
        public string Keypath { get; set; }
        /// <summary>
        /// Path of the Output file.
        /// </summary>
        public string OutputPath { get; set; }
        /// <summary>
        /// Action deciding whether to en- or decrypt.
        /// </summary>
        public EnumerationTypes.JobAction Action { get; set; }
        /// <summary>
        /// Source determining what Key and IV is used.
        /// </summary>
        public EnumerationTypes.KeySource Source { get; set; }
        /// <summary>
        /// Option determining how to handle the Output filename.
        /// </summary>
        public EnumerationTypes.FileNameOption Option { get; set; }
        /// <summary>
        /// Whether this job is completed or not.
        /// </summary>
        public bool Done { get; set; }
        /// <summary>
        /// The status of this job.
        /// </summary>
        public EnumerationTypes.JobStatus Status { get; set; }
        /// <summary>
        /// The result of this job.
        /// </summary>
        public EnumerationTypes.JobResult Result { get; set; }
        /// <summary>
        /// Additional information to this job.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Initializes a new SuojaJob that stores all important values.
        /// </summary>
        /// <param name="filepath">Path of the Input file.</param>
        /// <param name="keypath">Path of the Key file.</param>
        /// <param name="action">Action deciding whether to en- or decrypt.</param>
        /// <param name="source">Source determining what Key and IV is used.</param>
        /// <param name="option">Option determining how to handle the Output filename.</param>
        public SuojaJob(string filepath, string keypath, EnumerationTypes.JobAction action, EnumerationTypes.KeySource source, EnumerationTypes.FileNameOption option)
        {
            Filepath = filepath;
            Keypath = keypath;
            Action = action;
            Source = source;
            Option = option;
        }

    }
}
