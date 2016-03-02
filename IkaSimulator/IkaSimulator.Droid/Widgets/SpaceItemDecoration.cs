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
using Android.Support.V7.Widget;
using Android.Graphics;

namespace IkaSimulator.Droid.Widgets
{
    class SpaceItemDecoration : RecyclerView.ItemDecoration
    {
        int Space { get; set; }

        public SpaceItemDecoration(int space)
        {
            this.Space = space;
        }

        public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state)
        {
            if (parent.GetChildLayoutPosition(view) != 0)
            {
                outRect.Top = Space;
            }
        }
    }
}