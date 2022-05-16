using System;
using UnityEngine;
using System.IO;

namespace ScrollViewTest
{
    public sealed class ImageFileInfo
    {
        private readonly FileInfo fileInfo;
        private readonly DateTime creationTime;

        public Texture2D Texture2D { get; }
        public string Name { get; }

        public string TimeSinceCreated => ( DateTime.Now - creationTime ).ToString();

        public ImageFileInfo( Texture2D texture2D, FileInfo fileInfo )
        {
            this.Texture2D = texture2D;
            this.fileInfo = fileInfo;
            creationTime = fileInfo.CreationTime;
            Name = fileInfo.Name;
        }

        public override bool Equals( object obj )
        {
            if( ReferenceEquals( null, obj ) ) return false;
            if( ReferenceEquals( this, obj ) ) return true;
            if( obj.GetType() != this.GetType() ) return false;
            return Equals( (ImageFileInfo)obj );
        }

        public override int GetHashCode()
        {
            return ( fileInfo != null ? fileInfo.GetHashCode() : 0 );
        }

        private bool Equals( ImageFileInfo other )
        {
            return Equals( fileInfo.FullName, other.fileInfo.FullName );
        }
    }
}
