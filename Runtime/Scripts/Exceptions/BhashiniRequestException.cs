using System;
using UnityEngine.Networking;

namespace Uralstech.UBhashini.Exceptions
{
    /// <summary>
    /// Exception thrown due to request-related failures.
    /// </summary>
    public class BhashiniRequestException : Exception
    {
        internal BhashiniRequestException(UnityWebRequest request)
            : base($"Failed Bhashini API request! URI: {request.uri.AbsoluteUri} | Reason: {request.error} | Details:\n{request.downloadHandler.text}") { }

        internal BhashiniRequestException(string message) : base(message) { }
    }
}
