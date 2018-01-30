﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LiveDisplay.BroadcastReceivers
{
    [BroadcastReceiver (Permission = "android.permission.RECEIVE_BOOT_COMPLETED", Label ="BootBroadcastReceiver")]
    public class BootCompleteReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Intent lanzarLockScreen = new Intent(context, typeof(LockScreenActivity));
            lanzarLockScreen.AddFlags(ActivityFlags.NewTask);
            context.StartActivity(lanzarLockScreen);

        }
    }
}