﻿using System;
using Xamarin.Forms;

namespace AppEntrevista
{
    [TypeConverter(typeof(VideoSourceConverter))]
    public abstract class VideoSource : Element
    {
        public static VideoSource FromUri(string uri)
        {
            return new UriVideoSource() { Uri = uri };
        }

        public static VideoSource FromFile(string file)
        {
            return new FileVideoSource() { File = file };
        }

        public static VideoSource FromResource(string path)
        {
            return new ResourceVideoSource() { Path = path };
        }

        //public static implicit operator VideoSource(string v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
