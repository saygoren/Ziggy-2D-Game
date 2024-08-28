using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private float scrollSpeed = 1f;
    private float offset;
    private Material backGroundMaterial;
    void Start()
    {
        backGroundMaterial = GetComponent<Renderer>().material;
    }

  
    void Update()
    {
        offset += scrollSpeed * Time.deltaTime;
        backGroundMaterial.SetTextureOffset("_MainTex",new Vector2(offset,0));
    }
}
