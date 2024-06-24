using System;
using UnityEngine;
using UnityEngine.UI;

namespace Uralstech.UBhashini.Demo.Logger
{
    public class ULogHandler : MonoBehaviour, ILogHandler
    {
        [SerializeField] private Text _logsText;
        private ILogHandler _logHandler;

        private void Awake()
        {
            _logHandler = Debug.unityLogger.logHandler;
            
            Debug.unityLogger.logHandler = this;
        }

        public void LogException(Exception exception, UnityEngine.Object context)
        {
            _logsText.text += $"\n<color=#FF0000>{exception.Message}</color>";

            _logHandler.LogException(exception, context);
        }

        public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
        {
            string message = string.Format(format, args);
            _logsText.text += logType switch
            {
                LogType.Error or LogType.Assert or LogType.Exception => $"\n<color=#FF0000>{message}</color>",
                LogType.Warning => $"\n<color=#FFD100>{message}</color>",
                _ => $"\n<color=#FFFFFF>{message}</color>",
            };

            _logHandler.LogFormat(logType, context, format, message);
        }
    }
}
