using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class BgMove : MonoBehaviour
{
    //-13.71
    //-13.77686

    //17.77778
    public float bgspeed;
    
    private float bgstartposition;
    private float bglength;
    private void Start()
    {
        bgstartposition = this.transform.position.x;
        bglength = 17.77778f;
        Debug.Log(bglength);
    }

    private void Update()
    {
        float newposition = Mathf.Repeat(Time.time * bgspeed, bglength);
        this.transform.position=new Vector3(bgstartposition-newposition, this.transform.position.y, this.transform.position.z);
    }
}
