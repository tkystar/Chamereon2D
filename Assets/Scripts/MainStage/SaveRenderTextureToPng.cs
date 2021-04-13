using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;


public class SaveRenderTextureToPng : MonoBehaviour
{

    public RenderTexture RenderTextureRef;
    public Button save;

    // Use this for initialization
    void Start()
    {
        save.onClick.AddListener(savePng);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void savePng()
    {

        Texture2D tex = new Texture2D(RenderTextureRef.width, RenderTextureRef.height, TextureFormat.RGB24, false);
        //Texture2D tex = new Texture2D(600, 800, TextureFormat.RGB24, false);
        RenderTexture.active = RenderTextureRef;
        tex.ReadPixels(new Rect(0, 0, RenderTextureRef.width, RenderTextureRef.height), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToPNG();
        Object.Destroy(tex);

        //Write to a file in the project folder
        File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);

    }


}