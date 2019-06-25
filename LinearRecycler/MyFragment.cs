using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Gauges.SfLinearGauge;

namespace LinearRecycler
{

    public class MyFragment : Fragment
    {

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.MyFragment, container, false);
            view.SetTag(view.Id, Tag);
            RecyclerView recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            var layoutManager = new LinearLayoutManager(Activity);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.HasFixedSize = true;         
            var adapter = new RecyclerAdapter(new string[] { "A" });
            recyclerView.SetAdapter(adapter);
          
            return view;

        }
    }
}