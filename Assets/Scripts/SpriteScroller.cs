using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed; // control X and Y movespeed in Unity Inspector
 
    void Start()
    {
        Renderer renderer = GetComponent<SpriteRenderer>();
        MaterialPropertyBlock propBlock = new MaterialPropertyBlock();
        renderer.GetPropertyBlock(propBlock);
 
        propBlock.SetFloat("_XSpeed", moveSpeed.x);
        propBlock.SetFloat("_YSpeed", moveSpeed.y);
 
        renderer.SetPropertyBlock(propBlock);
    }

}
   /* the orig code from lecture, above code is a solution for background being weird and
   stuff, solution came from TA in replies to the same problem.(lect 125) 
   [SerializeField] Vector2 moveSpeed;

    Vector2 offset;
    Material material;
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
       offset = moveSpeed * Time.deltaTime;
       material.mainTextureOffset += offset ;
    }*/
