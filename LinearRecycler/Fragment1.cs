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
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Gauges.SfCircularGauge;

namespace LinearRecycler
{
    public class Fragment1 : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

           
        }
        RangePointer rangePointer;
        NeedlePointer needlePointer;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
            var view = inflater.Inflate(Resource.Layout.gauge, container, false);
            view.SetTag(view.Id, Tag);
            var TestGaugeGauge = view.FindViewById<SfCircularGauge>(Resource.Id.gauge1);


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
            rangePointer.Color = Color.Green;
            rangePointer.EnableAnimation = true;
            pointers.Add(rangePointer);

            needlePointer = new NeedlePointer();
            needlePointer.Value = 50;
            needlePointer.LengthFactor = 0.7;
            needlePointer.KnobColor = Color.Green;
            needlePointer.Color = Color.Green;
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
            return view;
          
        }
    }
}