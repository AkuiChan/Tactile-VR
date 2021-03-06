﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(MeshRenderer))]
public class TargetCanvas : MonoBehaviour
{
    private int textureSize = 2048;
    private int pensize = 10;
    private Texture2D texture;
    private Color[] color;

    private bool touching, touchingLast;
    private float posX, posY;
    private float lastX, lastY;

    // Start is called before the first frame update
    void Start()
    {
        ResetCanvas(); 
    }

    // Update is called once per frame
    void Update()
    {
        int x = (int)(posX * textureSize - (pensize / 2));
        int y = (int)(posY * textureSize - (pensize / 2));

        if (touchingLast)
        {
            texture.SetPixels(x, y, pensize, pensize, color);

            for (float t = 0.01f; t < 1.00f; t+= 0.01f)
            {
                int lerpx = (int)Mathf.Lerp(lastX, (float)x, t);
                int lerpy = (int)Mathf.Lerp(lastY, (float)y, t);

                texture.SetPixels(lerpx, lerpy, pensize, pensize, color);
            }

            texture.Apply();
        }

        this.lastX = (float)x;
        this.lastY = (float)y;
        this.touchingLast = this.touching;
    }

    public void toggleTouch(bool touching)
    {
        this.touching = touching;
    }

    public void setTouchPosition(float x, float y)
    {
        this.posX = x;
        this.posY = y;
    }

    public void setColor(Color color)
    {
        this.color = Enumerable.Repeat<Color>(color, pensize * pensize).ToArray();
    }

    public void ResetCanvas()
    {
        Debug.Log("Canvas Is Reset");
        Renderer rendere = GetComponent<Renderer>();
        this.texture = new Texture2D(textureSize, textureSize);
        rendere.material.mainTexture = this.texture;
    }
}
