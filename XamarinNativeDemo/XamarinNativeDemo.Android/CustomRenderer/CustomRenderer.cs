using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Widget;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinNativeDemo.Droid.CustomRenderer;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomRenderer))]
[assembly: ExportRenderer(typeof(Picker), typeof(BorderlessPickerRenderer))]
[assembly: ExportRenderer(typeof(Editor), typeof(XEditorRenderer))]

namespace XamarinNativeDemo.Droid.CustomRenderer
{
    public class CustomRenderer : EntryRenderer
    {
        public CustomRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }

    public class BorderlessPickerRenderer : PickerRenderer
    {
        public BorderlessPickerRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.Background = null;
            }
        }
    }

    public class XEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}