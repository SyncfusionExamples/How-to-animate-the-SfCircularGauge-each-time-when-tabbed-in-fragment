using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Com.Syncfusion.Gauges.SfCircularGauge;
using Com.Syncfusion.Gauges.SfLinearGauge;
using static Android.Support.V7.Widget.RecyclerView;

namespace LinearRecycler
{
    public class RecyclerHolder : RecyclerView.ViewHolder
    {
      
        public RecyclerHolder(View itemView) : base(itemView)
        {
          
        }
    }

    public class RecyclerAdapter : RecyclerView.Adapter
    {
        string[] items;
        public RecyclerAdapter(string[] data)
        {
            items = data;
        }
        RangePointer rangePointer;
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            View itemView = LayoutInflater.From(parent.Context).
            Inflate(Resource.Layout.row, parent, false);
            var TestGaugeGauge = itemView.FindViewById<SfCircularGauge>(Resource.Id.linear);


            ObservableCollection<CircularScale> circularScales = new ObservableCollection<CircularScale>();
            CircularScale scale = new CircularScale();
            scale.StartValue = 0;
            scale.EndValue = 100;
            scale.Interval = 10;
            scale.ScaleStartOffset = 0.9;
            scale.ScaleEndOffset = 0.85;
            scale.RimWidth = 10;
            scale.RimColor = Color.Gray;
            scale.ShowTicks = false;
            scale.LabelColor = Color.Black;
            scale.LabelOffset = 0.8;
            scale.ShowLabels = false;
            scale.MinorTicksPerInterval = 0;

            ObservableCollection<CircularPointer> pointers = new ObservableCollection<CircularPointer>();
            rangePointer = new RangePointer();
            rangePointer.Value = 50;
            rangePointer.StartOffset = 0.9;
            rangePointer.EndOffset = 0.85;
            rangePointer.Color = Color.Red;
            rangePointer.EnableAnimation = true;
            pointers.Add(rangePointer);


            NeedlePointer needlePointer = new NeedlePointer();
            needlePointer.Value = 50;
            needlePointer.LengthFactor = 0.7;
            needlePointer.KnobColor = Color.Red;
            needlePointer.Color = Color.Red;
            needlePointer.EnableAnimation = true;
            pointers.Add(needlePointer);

            scale.CircularPointers = pointers;
            circularScales.Add(scale);
            TestGaugeGauge.CircularScales = circularScales;

            Header header = new Header();
            header.Text = rangePointer.Value.ToString();
            header.TextColor = Color.Black;
            TestGaugeGauge.Headers.Add(header);
            TestGaugeGauge.SetBackgroundColor(Color.White);

            RecyclerHolder vh = new RecyclerHolder(itemView);
            return vh;
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];
            var holder = viewHolder as RecyclerHolder;
          
        }
        public override int ItemCount
        {
            get
            {
                return items.Length;
            }
        }
    }
}