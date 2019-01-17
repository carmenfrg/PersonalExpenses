using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using PersonalExpenses.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(TextCell), typeof(CustomTextCellRenderer))]
[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomProgressBarRenderer))]
namespace PersonalExpenses.iOS.CustomRenderers
{
    class CustomProgressBarRenderer : ProgressBarRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);

            if (double.IsNaN(e.NewElement.Progress))
                Control.ProgressTintColor = Color.FromHex("#000000").ToUIColor();
            else if (e.NewElement.Progress < 0.3)
                Control.ProgressTintColor = Color.FromHex("#90FCF9").ToUIColor();
            else if (e.NewElement.Progress < 0.5)
                Control.ProgressTintColor = Color.FromHex("#3DFAFF").ToUIColor();
            else if (e.NewElement.Progress < 0.7)
                Control.ProgressTintColor = Color.FromHex("#7CC6FE").ToUIColor();
            else if (e.NewElement.Progress < 0.0)
                Control.ProgressTintColor = Color.FromHex("#192BC2").ToUIColor();
            else
                Control.ProgressTintColor = Color.FromHex("#150578").ToUIColor();

            LayoutSubviews();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            float scaleX = 1.0f;
            float scaleY = 4.0f;

            var transform = CGAffineTransform.MakeScale(scaleX, scaleY);
            Transform = transform;
        }
    }
}
