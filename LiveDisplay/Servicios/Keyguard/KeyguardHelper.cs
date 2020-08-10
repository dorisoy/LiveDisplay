﻿using Android.App;
using Android.Content;
using Android.Hardware.Fingerprints;

namespace LiveDisplay.Servicios.Keyguard
{
    public class KeyguardHelper
    {
        private static KeyguardManager myKM = (KeyguardManager)Application.Context.GetSystemService(Context.KeyguardService);

        public static bool IsSystemSecured()
        {
            if (myKM.IsKeyguardSecure)
                return true;
            return false;
        }
        public static bool IsDeviceCurrentlyLocked()
        {
            KeyguardManager myKM = (KeyguardManager)Application.Context.GetSystemService(Context.KeyguardService);
            if (myKM.IsKeyguardLocked)
                return true;
            return false;
        }
        public static bool IsFingerprintSet()
        {
            FingerprintManager myFM= (FingerprintManager)Application.Context.GetSystemService(Context.KeyguardService);
            if (myFM.IsHardwareDetected == false) return false;

            return myFM.HasEnrolledFingerprints;
        }
    }
}