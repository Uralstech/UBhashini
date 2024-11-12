using System;
using Uralstech.UBhashini.Data;

namespace Uralstech.UBhashini.Exceptions
{
    /// <summary>
    /// Exception thrown during IO-related audio processing failures.
    /// </summary>
    public class BhashiniAudioIOException : Exception
    {
        internal BhashiniAudioIOException(string message, BhashiniAudioFormat format) : base($"Unsupported Bhashini API audio format \"{format}\": {message}") { }

        internal BhashiniAudioIOException(string message, Exception innerException) : base(message, innerException) { }

        internal BhashiniAudioIOException(string message) : base(message) { }
    }
}
