using System.Collections.Generic;
using UnityEngine;

namespace UIToolkitExamples
{
    [CreateAssetMenu(menuName = "UI Toolkit Examples/TexturePackAsset")]
    public class TexturePackAsset : ScriptableObject
    {
        public List<Texture2D> textures;

        public void Reset()
        {
            textures = new() { null, null, null, null };
        }
    }
}