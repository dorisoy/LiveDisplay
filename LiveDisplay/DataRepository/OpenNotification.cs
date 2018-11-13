﻿using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using LiveDisplay.Factories;
using LiveDisplay.Misc;
using System;
using System.Collections.Generic;

namespace LiveDisplay.Servicios.Notificaciones
{
    internal class OpenNotification : Java.Lang.Object
    {
        private int position;

        public OpenNotification(int position)
        {
            this.position = position;
        }

        public string GetTitle()
        {
            try
            {
                return CatcherHelper.statusBarNotifications[position].Notification.Extras.Get(Notification.ExtraTitle).ToString();
            }
            catch
            {
                return "";
            }
        }

        public string GetText()
        {
            try
            {
                return CatcherHelper.statusBarNotifications[position].Notification.Extras.Get(Notification.ExtraText).ToString();
            }
            catch
            {
                return "";
            }
        }

        public static void ClickNotification(int position)
        {
            var pendingIntent = CatcherHelper.statusBarNotifications[position].Notification.ContentIntent;
            try
            {
                pendingIntent.Send();
            }
            catch
            {
                System.Console.WriteLine("Click Notification failed, fail in pending intent");
            }
            pendingIntent.Dispose();
        }

        public static List<Button> RetrieveActionButtons(int position)
        {
            List<Button> buttons = new List<Button>();
            var actions = CatcherHelper.statusBarNotifications[position].Notification.Actions;
            if (actions != null)
            {
                double weight = (double)1 / actions.Count;
                float weightfloat =
                float.Parse(weight.ToString());
                string paquete = CatcherHelper.statusBarNotifications[position].PackageName;
                foreach (var action in actions)
                {
                    Button anActionButton = new Button(Application.Context)
                    {
                        LayoutParameters = new LinearLayout.LayoutParams(0, ViewGroup.LayoutParams.WrapContent, weightfloat),
                        Text = action.Title.ToString(),
                    };
                    anActionButton.SetMaxLines(1);
                    anActionButton.SetTextColor(Android.Graphics.Color.White);
                    anActionButton.Click += (o, e) =>
                    {
                        try
                        {
                            action.ActionIntent.Send();
                        }
                        catch (Exception ex)
                        {
                            Log.Error("Action button ex:", ex.ToString());
                        }
                    };

                    anActionButton.Gravity = GravityFlags.CenterVertical;
                    TypedValue typedValue = new TypedValue();
                    Application.Context.Theme.ResolveAttribute(Resource.Attribute.selectableItemBackground, typedValue, true);
                    anActionButton.SetBackgroundResource(typedValue.ResourceId);
                    if (Build.VERSION.SdkInt > BuildVersionCodes.M)
                    {
                        anActionButton.SetCompoundDrawablesRelativeWithIntrinsicBounds(IconFactory.ReturnActionIconDrawable(action.Icon, paquete), null, null, null);
                    }
                    buttons.Add(anActionButton);
                }
                return buttons;
            }
            return null;
        }

        internal static bool IsRemovable(int position)
        {
            if (CatcherHelper.statusBarNotifications[position].IsClearable == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool NotificationHasActionButtons(int position)
        {
            if (CatcherHelper.statusBarNotifications[position].Notification.Actions != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal string GetWhen()
        {
            try
            {
                return CatcherHelper.statusBarNotifications[position].Notification.When.ToString();
            }
            catch
            {
                return "";
            }
        }

        internal string GetAppName()
        {
            try
            {
                return PackageUtils.GetTheAppName(CatcherHelper.statusBarNotifications[position].PackageName);
            }
            catch
            {
                return "";
            }
        }

        public static bool NotificationIsAutoCancel(int position)
        {
            if (CatcherHelper.statusBarNotifications[position].Notification.Flags.HasFlag(NotificationFlags.AutoCancel) == true)
            {
                return true;
            }
            return false;
        }

        public static void SendInlineText(string text)
        {
            //Implement me.
        }
    }
}