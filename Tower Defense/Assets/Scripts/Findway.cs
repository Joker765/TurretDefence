using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//得到我编辑的WayPoint 数组；

public class Findway : MonoBehaviour {

    public static Transform[] pos;

    private void Awake()
    {
        pos = new Transform[transform.childCount];
        for (int i=0; i < pos.Length; i++)
        {
            pos[i] = transform.GetChild(i); 
        }
    } 
}
