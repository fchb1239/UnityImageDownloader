using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ImageDownloader : MonoBehaviour
{
    [Header("GitHub")]
    public string username = "fchb1239";
    public string repository = "UnityImageDownloader";
    public string branch = "main";
    public string path = "TestImages/MyImage.png";

    [Header("Resolution")]
    public int width = 512;
    public int height = 512;

    private void Awake()
    {
        StartCoroutine(LoadImage());
    }

    private IEnumerator LoadImage()
    {
        //Sends web request
        Debug.Log("Downloading image");
        var imageGet = GetImageRequest();
        yield return imageGet.SendWebRequest();

        //Creates and loads texture
        Debug.Log("Creating and loadingtexture");
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        tex.LoadImage(imageGet.downloadHandler.data);

        //Applies to material
        Debug.Log("Applying to material");
        transform.GetComponent<MeshRenderer>().material.mainTexture = tex;

        Debug.Log("Done");
    }

    private UnityWebRequest GetImageRequest()
    {
        var request = new UnityWebRequest($"https://raw.githubusercontent.com/{username}/{repository}/{branch}/{path}", "GET");

        request.downloadHandler = new DownloadHandlerBuffer();

        return request;
    }
}

/*
MIT License

Copyright (c) 2022 fchb1239

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */