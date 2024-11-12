using System;
using Uralstech.UBhashini.Data;

namespace Uralstech.UBhashini.Exceptions
{
    public class BhashiniAudioIOException : Exception
    {
        public BhashiniAudioIOException(string message, BhashiniAudioFormat format) : base($"Unsupported Bhashini API audio format \"{format}\": {message}") { }

        public BhashiniAudioIOException(string message, Exception innerException) : base(message, innerException) { }

        public BhashiniAudioIOException(string message) : base(message) { }
    }
}
