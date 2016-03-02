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

namespace IkaSimulator.Droid.Utils
{
    class ResourceConverter
    {

        public static int GetDrawableID(Context context, String fileName)
        {
            return context.Resources.GetIdentifier(fileName, "drawable", context.PackageName);
        }

        public static int GetStringID(Context context, String stringName)
        {
            return context.Resources.GetIdentifier(stringName, "string", context.PackageName);
        }

        public static int GetColorID(Context context, String colorName)
        {
            return context.Resources.GetIdentifier(colorName, "color", context.PackageName);
        }
    }
}