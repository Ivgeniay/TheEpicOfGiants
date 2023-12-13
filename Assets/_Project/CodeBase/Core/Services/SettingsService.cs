using UnityEngine;
using UnityEngine.XR;

namespace CodeBase.Core.Services
{
    internal class SettingsService : MonoBehaviour
    {
        internal bool CheckXRDevice()
        {
            if (XRSettings.isDeviceActive)
            {
                string activeXRDevice = XRSettings.loadedDeviceName;
                Debug.Log($"XR Device '{activeXRDevice}' is connected.");
                return true;
            }
            else
            {
                Debug.Log("No XR device is connected.");
                return false;
            }
        }
    }
}
