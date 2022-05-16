using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScrollViewTest
{
    public class Imageview : MonoBehaviour
    {
        [SerializeField, Foldout( "References" ), Required]
        private RawImage image;

        [SerializeField, Foldout( "References" ), Required]
        private AspectRatioFitter aspectRatioFitter;

        [SerializeField, Foldout( "References" ), Required]
        private TMP_Text fileName;

        [SerializeField, Foldout( "References" ), Required]
        private TMP_Text timeSinceCreated;

        public void Setup( ImageFileInfo imgFileInfo )
        {
            fileName.text = imgFileInfo.Name;
            timeSinceCreated.text = imgFileInfo.TimeSinceCreated;
            image.texture = imgFileInfo.Texture2D;
            aspectRatioFitter.aspectRatio = imgFileInfo.Texture2D.width / imgFileInfo.Texture2D.height;

        }
    }
}
