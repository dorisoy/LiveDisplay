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

namespace LiveDisplay.Activities.ActivitiesEventArgs
{
    public class LockScreenLifecycleEventArgs:EventArgs
    {
        public ActivityStates State { get; set; }
    }
}