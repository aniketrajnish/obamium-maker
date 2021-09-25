using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NativeGalleryManager : MonoBehaviour
{
    [SerializeField] GameObject go;
    private IEnumerator Screenshot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D tex = new Texture2D(Screen.width, Screen.height / 2, TextureFormat.RGB24, false);

        tex.ReadPixels(new Rect(0, Screen.height / 3.75f, Screen.width, Screen.height / 2), 0, 0);
        tex.Apply();

        NativeGallery.SaveImageToGallery(tex, "OBAMIUM Screenshots", "Obamium" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png");
        Destroy(tex);
    }

    public void TakeScreenshot()
    {
        StartCoroutine(Screenshot());
    }

    public void PickImage()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create Texture from selected image
                Texture2D texture = NativeGallery.LoadImageAtPath(path);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }

                Material material = go.GetComponent<Renderer>().material;
                if (!material.shader.isSupported) // happens when Standard shader is not included in the build
                    material.shader = Shader.Find("Legacy Shaders/Diffuse");

                material.mainTexture = texture;

            }
        }, "Select a PNG image", "image/png");

        Debug.Log("Permission result: " + permission);
    }
}
