using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(MeshRenderer))]
public class TargetCanvas : MonoBehaviour
{
    public GameObject p1, p2, p3, p4;

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
        Renderer rendere = GetComponent<Renderer>();
        this.texture = new Texture2D(textureSize, textureSize);
        rendere.material.mainTexture = this.texture; 
    }

    // Update is called once per frame
    void Update()
    {
        rescaleCanvas();

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

    void rescaleCanvas()
    {
        float zScale = Vector3.Distance(p1.transform.position, p2.transform.position);
        float xScale = Vector3.Distance(p2.transform.position, p3.transform.position);

        Vector3 newScale = new Vector3(xScale, 1, zScale);

        this.transform.localScale = newScale;
        //float zScale = this.transform.localScale.z;

            
    }
}
