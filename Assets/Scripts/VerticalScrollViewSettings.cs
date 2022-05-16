using System;
using NaughtyAttributes;
using UnityEditor;
using UnityEngine;

namespace ScrollViewTest
{
    [Serializable]
    [CreateAssetMenu( fileName = "VerticalScrollViewSettings", menuName = "SettingsAssets/VerticalScrollViewSettings" )]
    public class VerticalScrollViewSettings : ScriptableObject
    {
        [SerializeField] private string path;
        [SerializeField, EnumFlags] private EFilesFormat formats;

        public string Path => path;
        public EFilesFormat Formats => formats;

        [Button]
        private void SelectDirectory()
        {
            path = EditorUtility.OpenFolderPanel( "Select Images Directory", "", "" );

            if( path.StartsWith( Application.dataPath ) )
                path = "Assets" + path.Substring( Application.dataPath.Length );


            EditorUtility.SetDirty( this );
        }

        public enum EFilesFormat
        {
            Jpg = 1 << 0,
            Png = 1 << 1,
        }
    }
}
