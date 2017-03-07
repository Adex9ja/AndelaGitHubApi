using Android.App;
using Android.Widget;
using Android.OS;
using SupportToolBar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.V7.App;
using System.Net.Http;
using System;
using Android.Util;
using Android.Support.V7.Widget;
using Android.Views;
using System.Collections.Generic;
using Android.Content.Res;
using Android.Content;
using Android.Graphics;
using Java.Lang;
using Square.Picasso;

namespace AndelaGitAPI
{
    [Activity(Label = "Andela", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        private string baseaddress;
        private string fullpath;
        private string query;
        private MyHandler myhandler;
        private ListView listview;
        GitHubRes[] items;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            SupportToolBar toolBar = FindViewById<SupportToolBar>(Resource.Id.toolbar);
            SetSupportActionBar(toolBar);

            initializeComponents();
            

        }

        private void initializeComponents()
        {
            listview = (ListView)FindViewById(Resource.Id.listview);
            baseaddress = "https://api.github.com";
            query = "location:lagos";
            fullpath = baseaddress + "/search/users?q=" + query;
            myhandler = new MyHandler(this);

            fetchAllUserInLagos();
        }

        private async void fetchAllUserInLagos()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    myhandler.ObtainMessage(1, "Fetching Data...Please wait").SendToTarget();
                    client.BaseAddress = new System.Uri(baseaddress);
                    client.DefaultRequestHeaders.Add("User-Agent", "AndelaGitAPI");
                    var res = await client.GetAsync(new System.Uri(fullpath));
                    string resposnse = res.Content.ReadAsStringAsync().Result;
                    JSonResponse mresponse = Newtonsoft.Json.JsonConvert.DeserializeObject<JSonResponse>(resposnse);
                    int temp = 0;
                    bool mflag = int.TryParse(mresponse.total_count, out temp);
                    if (mflag == true && temp > 0)
                        loadListItem(mresponse.items);
                    myhandler.ObtainMessage(2, null).SendToTarget();
                }
                catch (System.Exception e)
                {
                    myhandler.ObtainMessage(0, e.Message).SendToTarget();
                }

            }
        }

        private void loadListItem(GitHubRes[] items)
        {
            this.items = items;
            listview.Adapter = new MyArrayAdapter(this, items);
            listview.ItemClick += Listview_ItemClick;
        }

        private void Listview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent intent = new Intent(this, typeof(ProfileDetails));
            intent.PutExtra(this.Resources.GetString(Resource.String.jsonres), Newtonsoft.Json.JsonConvert.SerializeObject(items[e.Position]));
            StartActivity(intent);
        }

        private class MyArrayAdapter : BaseAdapter
        {
            private Activity _activity;
            private GitHubRes[] _data;
            public MyArrayAdapter(Activity vactivity, GitHubRes[] data)
            {
                _activity = vactivity; _data = data;
            }
            public override int Count
            {
                get
                {
                   return  _data.Length;
                }
            }

            public override Java.Lang.Object GetItem(int position)
            {
                return position;
            }

            public override long GetItemId(int position)
            {
                return position;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                var view = convertView ?? _activity.LayoutInflater.Inflate(Resource.Layout.list_item, parent, false);
                var txtusername = view.FindViewById<TextView>(Resource.Id.txtusername);
                var imgavatar = view.FindViewById<ImageView>(Resource.Id.avatar);

                txtusername.Text = _data[position].login;                

                string imageUri = _data[position].avatar_url;
                Picasso
                    .With(_activity)
                    .Load(imageUri)
                    .Resize(50, 50)
                    .CenterCrop()
                    .Into(imgavatar);

                return view;
            }

          
        }
    }
       
   
}

