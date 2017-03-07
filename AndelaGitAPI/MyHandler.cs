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

namespace AndelaGitAPI
{
    class MyHandler : Handler
    {
        private Context vcontext;
        private AlertDialog.Builder builder;
        private ProgressDialog progress;
        public MyHandler(Context mcontex) {
            vcontext = mcontex;
        }

        public override void DispatchMessage(Message msg)
        {
            base.DispatchMessage(msg);
            switch (msg.What) {
                case 0:
                    progress.Dismiss();
                    builder = new AlertDialog.Builder(vcontext);
                    builder.SetTitle("Network Error");
                    builder.SetMessage("Error in connection. Please make sure you have a working internet connection!");
                    builder.SetPositiveButton("Ok", (o, b) =>
                    {
                        builder.Dispose();
                    });
                    builder.Show();
                    break;
                case 1:
                    progress = new ProgressDialog(vcontext);
                    progress.SetMessage(msg.Obj.ToString());
                    progress.Indeterminate = true;
                    progress.SetProgressStyle(ProgressDialogStyle.Spinner);
                    progress.SetCancelable(false);
                    progress.Show();
                    break;
                case 2:
                    progress.Dismiss();
                    break;
            }
        }
    }
    public class JSonResponse
    {
        public string total_count { get; set; }
        public string incomplete_results { get; set; }
        public GitHubRes[] items { get; set; }

    }
    public class GitHubRes
    {
        public string login { get; set; }
        public string id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public string site_admin { get; set; }
        public string score { get; set; }
        public string url { get; set; }

    }
}