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
    public class CustomTextCellRenderer : TextCellRenderer
    {
        public CustomTextCellRenderer()
        {
        }

        private Android.Views.View _cell;
        private bool _isSelected;

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            _cell = base.GetCellCore(item, convertView, parent, context);

            _isSelected = false;

            return _cell;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnCellPropertyChanged(sender, args);

            var cell = sender as TextCell;

            if (args.PropertyName == "IsSelected")
            {

                _isSelected = !_isSelected;

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