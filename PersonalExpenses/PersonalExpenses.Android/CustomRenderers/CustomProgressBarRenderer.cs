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
using PersonalExpenses.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(TextCell), typeof(CustomTextCellRenderer))]
[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomViewCellRenderer))]
[assembly: ExportRenderer(typeof(Xamarin.Forms.ProgressBar), typeof(CustomProgressBarRenderer))]
namespace PersonalExpenses.Droid.CustomRenderers
{
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {

        public CustomProgressBarRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
        {
            base.OnElementChanged(e);

            if (double.IsNaN(e.NewElement.Progress))
                Control.ProgressDrawable.SetTint(Color.FromHex("#000000").ToAndroid());
            else if(e.NewElement.Progress < 0.3)
                Control.ProgressDrawable.SetTint(Color.FromHex("#90FCF9").ToAndroid());
            else if (e.NewElement.Progress < 0.5)
                Control.ProgressDrawable.SetTint(Color.FromHex("#3DFAFF").ToAndroid());
            else if (e.NewElement.Progress < 0.7)
                Control.ProgressDrawable.SetTint(Color.FromHex("#7CC6FE").ToAndroid());
            else if (e.NewElement.Progress < 0.0)
                Control.ProgressDrawable.SetTint(Color.FromHex("#192BC2").ToAndroid());
            else 
                Control.ProgressDrawable.SetTint(Color.FromHex("#150578").ToAndroid());

            Control.ScaleY = 2.0f;
        }

    }
}