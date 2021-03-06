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


namespace DerDal
{
    public class DataAdapter : BaseAdapter<string>
    {
        List<string> items;
        Activity context;

        public DataAdapter (Activity context, List<string> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override string this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
           if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.listViewRow, null);

            view.FindViewById<TextView>(Resource.Id.txtItem).Text = item;      
          
            return view;
        }
    }
}