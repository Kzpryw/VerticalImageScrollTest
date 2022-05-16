using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace ScrollViewTest
{
    public class VerticalScrollImageView : MonoBehaviour
    {
        [SerializeField, Foldout( "References" ), Required] private Transform contentRoot;
        [SerializeField, Foldout( "References" ), Required] private VerticalScrollViewSettings settings;
        [SerializeField, Foldout( "References" ), Required] private Imageview imageviewPrefab;
        [SerializeField, Foldout( "References" ), Required] private Button refreshButton;

        private readonly HashSet<ImageFileInfo> currentImageFiles = new HashSet<ImageFileInfo>();
        private readonly Dictionary<ImageFileInfo, Imageview> toDestroy = new Dictionary<ImageFileInfo, Imageview>();
        private readonly Dictionary<ImageFileInfo, Imageview> sceneImageViews = new Dictionary<ImageFileInfo, Imageview>();

        private void OnEnable()
        {
            refreshButton.onClick.AddListener(RefreshButton_OnClicked);
        }

        private void OnDisable()
        {
            refreshButton.onClick.RemoveListener(RefreshButton_OnClicked);
        }


        [Button]
        private void Refresh()
        {
            ImageFilesHelper.GetFilesInfo( currentImageFiles, settings.Path, settings.Formats );
            toDestroy.Clear();

            foreach( var sceneImage in sceneImageViews )
            {
                if( !currentImageFiles.Contains( sceneImage.Key ) )
                {
                    toDestroy.Add( sceneImage.Key, sceneImage.Value );
                }
            }

            foreach( var currentImagesFile in currentImageFiles )
            {
                if( sceneImageViews.ContainsKey( currentImagesFile ) )
                    continue;

                var imageView = Instantiate( imageviewPrefab, contentRoot );
                sceneImageViews.Add( currentImagesFile, imageView );
                imageView.Setup( currentImagesFile );
            }

            foreach( var destroy in toDestroy )
            {
                Destroy( destroy.Value.gameObject );
                sceneImageViews.Remove( destroy.Key );
            }

        }

        private void RefreshButton_OnClicked()
        {
            Refresh();
        }
    }
}
