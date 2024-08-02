using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    float pastTime = 0;

    public bool isMoveEnd()
    {
        return pastTime > 6.0f;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pastTime += Time.deltaTime;
        if (!isMoveEnd())
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }
    }
}
