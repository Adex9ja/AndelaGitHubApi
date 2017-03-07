using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SupportToolBar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.V7.App;
using Square.Picasso;

namespace AndelaGitAPI
{
    [Activity(Label = "Profile", Icon = "@drawable/icon", Theme = "@style/AppTheme.NoActionBar")]
    public class ProfileDetails : AppCompatActivity
    {
        private GitHubRes data;
        private ImageView avatar;
        private TextView tusername, turl;
        private Button btnShare;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Profile);
            SupportToolBar toolBar = FindViewById<SupportToolBar>(Resource.Id.toolbar);
            SetSupportActionBar(toolBar);
            SupportActionBar bar = SupportActionBar;
            bar.SetDefaultDisplayHomeAsUpEnabled(true);          

            if (savedInstanceState == null)
                data = getResposeData();

            loadinitComponents();          


        }

      
        private void loadinitComponents()
        {
            avatar =(ImageView) FindViewById(Resource.Id.avatar);
            tusername = (TextView) FindViewById(Resource.Id.txtusername);
            turl = (TextView) FindViewById(Resource.Id.txtgithuburl);
            btnShare = (Button)FindViewById(Resource.Id.btnShare);

                tusername.Text = data.login;
                turl.Text = data.html_url;
                Picasso
                    .With(this)
                    .Load(data.avatar_url)
                    .Resize(300, 300)
                    .CenterCrop()
                    .Into(avatar);
            btnShare.Click += BtnShare_Click;
            turl.Click += Turl_Click;


        }

        private void Turl_Click(object sender, EventArgs e)
        {
            //launchbrowser
            Intent launchBrowser = new Intent(Intent.ActionView, Android.Net.Uri.Parse(data.html_url));
            StartActivity(launchBrowser);
        }
        private String getUserInfo() {
            return "Check out this awesome developer" + "@" + data.login + ", " + data.html_url;
        }
        private void BtnShare_Click(object sender, EventArgs e)
        {
            //launch share intent
            Intent sendIntent = new Intent();
            sendIntent.SetAction(Intent.ActionSend);
            sendIntent.PutExtra(Intent.ExtraText, getUserInfo());
            sendIntent.SetType("text/plain");
            StartActivity(sendIntent);
        }

        
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Finish();
            return base.OnOptionsItemSelected(item);
        }

        private GitHubRes getResposeData()
        {
            string str = Intent.GetStringExtra(Resources.GetString(Resource.String.jsonres));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GitHubRes>(str);
        }
    }
}