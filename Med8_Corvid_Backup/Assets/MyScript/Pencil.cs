using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pencil : MonoBehaviour
{

    // Drawing object.
    public TargetCanvas CanvasReciever;
    public Transform tipTransform;
    float raycastLength = 0.12f;
    private RaycastHit touch;
    private bool lastTouch;
    private Quaternion lastAngle;

    public UnityEvent ContactIsMade, contactLost;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast (tipTransform.position, transform.forward, out touch, raycastLength))
        {
            this.CanvasReciever.setColor(Color.black);
            this.CanvasReciever.setTouchPosition(touch.textureCoord.x, touch.textureCoord.y);
            this.CanvasReciever.toggleTouch(true);
        }
        else
        {
            this.CanvasReciever.toggleTouch(false);
        }
    }

    /*
       private void placeholder()
        {
            rightIndexTipPos = rightIndexTip.Transform.position;
            Quaternion rightIndexTipRo = rightIndexTip.Transform.rotation;
            this.transform.position = rightIndexTipPos;
            this.transform.rotation = rightIndexTipRo;

            float tipHeight = tip.transform.localScale.z;
            Vector3 tipPos = tip.transform.position;
            Ray ray = new Ray(tip.transform.position, tip.transform.forward);
            RaycastHit hit;

            Debug.DrawRay(tip.transform.position, Vector3.down * raycastLength);

            if (Physics.Raycast(ray, out hit, raycastLength))
            {
                if (hit.collider.tag == "NewTag")
                {
                    ContactIsMade.Invoke();
                }
            }
        }
    */
}
