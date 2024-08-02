using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    //public float maxScale = 2.0f;
    //public float minScale = 0.5f;
    //public Vector3 scaleAxis = new Vector3(1, 1, 0); // X軸とY軸にスケーリング
    public float scaleSpeed = 1.0f;
    private bool scalingUp = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ScaleObject(gameObject, maxScale, minScale, scaleAxis);
    }

    public void ScaleObject(GameObject obj, float maxScale, float minScale, Vector3 scaleAxis)
    {
        Vector3 scale = obj.transform.localScale;
        Vector3 initialPosition = obj.transform.position;

        if (scalingUp)
        {
            scale += scaleAxis * scaleSpeed * Time.deltaTime;
            initialPosition += new Vector3(0, 2.4f, 0) * Time.deltaTime;
            if (Vector3.Dot(scale, scaleAxis) >= maxScale)
            {
                scale = scaleAxis * maxScale;
                scalingUp = false;
            }
        }
        else
        {
            scale -= scaleAxis * scaleSpeed * Time.deltaTime;
            initialPosition -= new Vector3(0, 2.4f, 0) * Time.deltaTime;
            if (Vector3.Dot(scale, scaleAxis) <= minScale)
            {
                scale = scaleAxis * minScale;
                scalingUp = true;
            }
        }

        obj.transform.localScale = scale;
        obj.transform.position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);
    }
}
