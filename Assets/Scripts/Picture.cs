using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Picture : MonoBehaviour
{

    [SerializeField]
    private int id;
    [SerializeField]
    private string pictureName;
    [SerializeField]
    private string description;
    [SerializeField]
    private string author;
    [SerializeField]
    private float cost;

    public float Cost
    {
        get { return cost; }
        set { cost = value; }
    }


    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string PictureName
    {
        get { return pictureName; }
        set { pictureName = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }



}