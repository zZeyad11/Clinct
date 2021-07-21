using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Refractored.Controls;
using RemoteSender;
using System;
using System.Collections.Generic;

namespace Remote_Sender.Helper
{
    delegate void RecyclerViewItemClicked(object sender, RecyclerViewClick Data);
    class RecyclerViewHolder :  RecyclerView.ViewHolder
    {
        public CircleImageView DeviceIcon { get; set; }
        public TextView DeviceName { get; set; }
        public TextView IP { get; set; }

        public CircleImageView Info { get; set; }
        
        public RecyclerViewHolder(View itemview) : base(itemview)
        {
            DeviceIcon = itemview.FindViewById<CircleImageView>(Resource.Id.DeviceIcon);
            DeviceName = itemview.FindViewById<TextView>(Resource.Id.DeviceName);
            IP = itemview.FindViewById<TextView>(Resource.Id.IP_Address);
            Info = itemview.FindViewById<CircleImageView>(Resource.Id.RenameButton);
        }
        
    }
    class RecyclerViewAdapter : RecyclerView.Adapter
    {
        private List<Data> list = new List<Data>();
        public RecyclerView recyclerView;
        public event RecyclerViewItemClicked ItemClicked;
        public event RecyclerViewItemClicked InfoClicked;
        public RecyclerViewAdapter(List<Data> list)
        {
            this.list = list;
        }


        public override int ItemCount
        {
            get
            {
                return list.Count;
            }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            try
            {
                RecyclerViewHolder viewHolder = holder as RecyclerViewHolder;
                viewHolder.DeviceIcon.SetImageResource(list[position].ImageId);
                viewHolder.DeviceName.Text = list[position].DeciveName;
                viewHolder.IP.Text = list[position].IP;
                viewHolder.Info.Visibility = list[position].ShowInfo;
                viewHolder.Info.SetImageResource(list[position].InfoImageId);
                viewHolder.ItemView.Click += delegate
                {
                    ItemClicked(this, new RecyclerViewClick() { Data = list[position] });

                };
                viewHolder.Info.Click += delegate
                {
                    InfoClicked(this, new RecyclerViewClick() { Data = list[position] });
                };
            }
            catch 
            {

               
            }
        }


        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemview = inflater.Inflate(Resource.Layout.Item, parent, false);
            
            return new RecyclerViewHolder(itemview);
        }

        
        
    }


    class RecyclerViewClick : EventArgs
    {
        public Data Data;
    }

  

}