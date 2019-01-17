using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace PersonalExpenses.Droid.CustomRenderers
{
    class CustomViewCellRenderer : ViewCellRenderer
    {

        private Android.Views.View _cell;
        private bool _isSelected;

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            _cell = base.GetCellCore(item, convertView, parent, context);

            _isSelected = false;

            _cell.SetBackgroundColor(Android.Graphics.Color.Transparent);

            return _cell;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnCellPropertyChanged(sender, e);

            var cell = sender as ViewCell;

            if (e.PropertyName == "IsSelected")
            {

                _isSelected = !_isSelected;


                if (_isSelected)
                {
                    switch (cell.StyleId)
                    {
                        case "blue":
                            _cell.SetBackgroundColor(Android.Graphics.Color.CornflowerBlue);
                            break;
                        case "red":
                            _cell.SetBackgroundColor(Android.Graphics.Color.PaleVioletRed);
                            break;
                        case "transparent":
                            _cell.SetBackgroundColor(Android.Graphics.Color.Transparent);
                            break;
                        case "green":
                            _cell.SetBackgroundColor(Android.Graphics.Color.LightSeaGreen);
                            break;
                        default:
                            _cell.SetBackgroundColor(Android.Graphics.Color.LightGray);
                            break;
                    }
                }
                else
                    _cell.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }

        }

    }
}