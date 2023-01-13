using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTextureAnimator : MonoBehaviour
{
    private Material Mat;
    private Vector2 Offset;
    public float factor = 40f;
    public GameConfiguration config;

    void Start()
    {
        Mat = gameObject.GetComponent<Renderer>().material;
        Offset = Mat.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        Offset.x = Offset.x + ((config.speed / factor) * Time.deltaTime);
        Mat.SetTextureOffset("_MainTex", Offset);
    }
}
