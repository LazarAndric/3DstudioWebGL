using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureHandler : MonoBehaviour
{
    [SerializeField]
    private WriterHandler writer;
    [SerializeField]
    private MeshRenderer pictureMesh;
    public Texture baseMap;
    private Picture picture;
    private void Start()
    {
        picture = gameObject.AddComponent<Picture>();
        picture.PictureName = "Mothers boy";
        picture.Description = "Picture from Monaco asdf fgh ye e cvb yuk  opicu xkjcn asldfj oiqwuer nzlxn jasdfopiweru ousaodfn lzxjasdf asf";
        picture.Author = "Lazar Andric";
        picture.Cost = 2000;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            StartWriter(picture);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            ClearData();
        }
    }
    

    public void StartWriter(Picture picture)
    {
        List<string> texts= new List<string>();
        texts.Add(picture.PictureName);
        texts.Add(picture.Description);
        texts.Add(picture.Author);
        texts.Add(picture.Cost.ToString());
        writer.StartWriter(texts);
    }
    public void ClearData()
    {
        writer.ClearWriter();
    }

    public void SetPicture(Picture picture) => this.picture = picture;
    public void SetPictureMaterial(ref Material material, Texture baseMap) => material.SetTexture("_MainTex", baseMap);
}
