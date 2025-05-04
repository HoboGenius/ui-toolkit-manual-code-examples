using UnityEngine;

namespace UIToolkitExamples
{
    [CreateAssetMenu(menuName = "UI Toolkit Examples/Texture Asset")]
    public class TextureAsset : ScriptableObject
    {
        public Texture2D texture;

        public void Reset()
        {
            texture = null;
        }
    }
}