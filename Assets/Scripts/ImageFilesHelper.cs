using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ScrollViewTest
{
    public sealed class ImageFilesHelper
    {
        public static Texture2D GetTexture( string filePath )
        {
            if( !File.Exists( filePath ) )
            {
                Debug.LogWarning( $"{nameof(filePath)}: {filePath} does not exist." );
                return null;
            }

            byte[] byteArray = File.ReadAllBytes( filePath );

            Texture2D sampleTexture = new Texture2D( 2, 2 );

            bool isLoaded = sampleTexture.LoadImage( byteArray );

            if( isLoaded )
                return sampleTexture;

            Debug.LogWarning( $"Failed to load at {nameof(filePath)}." );
            return null;
        }


        public static void GetFilesInfo( HashSet<ImageFileInfo> outFilesInfo, string folderPath, VerticalScrollViewSettings.EFilesFormat formats )
        {
            outFilesInfo.Clear();

            if( !Directory.Exists( folderPath ) )
            {
                Debug.LogWarning( $"{nameof(folderPath)}: {folderPath} does not exist." );
                return;
            }

            foreach( Enum format in formats.GetFlags() )
            {
                foreach( string filePath in Directory.GetFiles( folderPath, $"*.{format.ToString().ToLower()}" ) )
                {
                    outFilesInfo.Add( new ImageFileInfo( GetTexture( filePath ), new FileInfo( filePath ) ) );
                }
            }
        }
    }
}
