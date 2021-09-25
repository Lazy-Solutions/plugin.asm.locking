#if UNITY_EDITOR

using System;
using UnityEngine;

namespace AdvancedSceneManager.Support.Locking
{

    /// <summary>An info class for locking objects. Has no effect by itself. See <see cref="LockUtility"/>.</summary>
    [Serializable]
    public class LockInfo
    {

        public static LockInfo Empty { get; } = new LockInfo();

        [SerializeField] private bool m_isEnabled;
        [SerializeField] private string m_by;
        [SerializeField] private string m_message;

        public bool isEnabled => m_isEnabled;
        public string by => m_by;
        public string message => m_message;

        public string AsTooltip =>
            !isEnabled
            ? "Lock"
            : "Locked by: " + Environment.NewLine +
            (string.IsNullOrWhiteSpace(by) ? "(unspecified)" : by) + Environment.NewLine +
            Environment.NewLine +
            "Message:" + Environment.NewLine +
            (string.IsNullOrWhiteSpace(message) ? "(unspecified)" : message);

        /// <summary>Locks the associated object.</summary>
        public LockInfo Lock(string name = null, string message = null)
        {
            m_isEnabled = true;
            m_by = name;
            m_message = message;
            return this;
        }

        /// <summary>Unlocks the associated object.</summary>
        public LockInfo Unlock()
        {
            m_isEnabled = false;
            m_by = "";
            m_message = "";
            return this;
        }

    }

}

#endif
