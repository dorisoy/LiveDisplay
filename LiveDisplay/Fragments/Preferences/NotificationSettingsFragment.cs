using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using AndroidX.Preference;
using LiveDisplay.Activities;

namespace LiveDisplay.Fragments.Preferences
{
    public class NotificationSettingsFragment : PreferenceFragmentCompat
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override void OnResume()
        {
            base.OnResume();
        }

        public override void OnPause()
        {
            base.OnPause();
        }

        public override void OnCreatePreferences(Bundle savedInstanceState, string rootKey)
        {
            AddPreferencesFromResource(Resource.Xml.notification_prefs);

            Preference blacklistpreference = FindPreference("blacklist");
            blacklistpreference.PreferenceClick += Blacklistpreference_PreferenceClick;

            SwitchPreference enablequickreplypreference = FindPreference("enablequickreply?") as SwitchPreference;

            if (Build.VERSION.SdkInt < BuildVersionCodes.N)
            {
                enablequickreplypreference.Enabled = false;
                enablequickreplypreference.Checked = false;
            }
        }

        private void Blacklistpreference_PreferenceClick(object sender, Preference.PreferenceClickEventArgs e)
        {
            Intent intent = new Intent(Application.Context, Java.Lang.Class.FromType(typeof(BlacklistActivity)));
            StartActivity(intent);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}