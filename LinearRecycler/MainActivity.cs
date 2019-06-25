using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Content;

namespace LinearRecycler
{
    [Activity(Label = "LinearRecycler", MainLauncher = true)]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.Main);
         

            var prv = FindViewById<Button>(Resource.Id.prev);
            var c = new Fragment1();
            prv.Click += delegate
            {
                FragmentTransaction tran = this.FragmentManager.BeginTransaction();
              
                tran.Replace(Resource.Id.fragment_container, c);
                tran.Commit();
                Toast.MakeText(this, "FirstGauge", ToastLength.Short).Show();
            };

            var f = new MyFragment();
            var nxt = FindViewById<Button>(Resource.Id.next);
            nxt.Click += delegate
            {
                FragmentTransaction tran = this.FragmentManager.BeginTransaction();               
                tran.Replace(Resource.Id.fragment_container, f);            

                tran.Commit();
                Toast.MakeText(this, "SecondGauge", ToastLength.Short).Show();
            };


            base.OnCreate(savedInstanceState);
        }
    }

}

