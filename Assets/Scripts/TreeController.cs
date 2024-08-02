using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    //public float scaleSpeed = 1.0f;
    //public float maxScale = 7.5f;
    //public float minScale = 1.0f;

    //private bool scalingUp = true;
    //private Vector3 initialScale;
    //private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        //initialScale = transform.localScale;
        //initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //ScaleTreeY();
    }

    //public void ScaleObject(GameObject obj, float maxScale, float minScale, Vector3 scaleAxis)
    //{
    //    Vector3 scale = obj.transform.localScale;
    //    Vector3 initialPosition = obj.transform.position;

    //    if (scalingUp)
    //    {
    //        scale += scaleAxis * scaleSpeed * Time.deltaTime;
    //        initialPosition += new Vector3(0, 2.4f, 0) * Time.deltaTime;
    //        if (Vector3.Dot(scale, scaleAxis) >= maxScale)
    //        {
    //            scale = scaleAxis * maxScale;
    //            scalingUp = false;
    //        }
    //    }
    //    else
    //    {
    //        scale -= scaleAxis * scaleSpeed * Time.deltaTime;
    //        initialPosition -= new Vector3(0, 2.4f, 0) * Time.deltaTime;
    //        if (Vector3.Dot(scale, scaleAxis) <= minScale)
    //        {
    //            scale = scaleAxis * minScale;
    //            scalingUp = true;
    //        }
    //    }

    //    obj.transform.localScale = scale;
    //    obj.transform.position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);
    //}

    // Tree のｙ軸方向スケールを変化させる関数
    //public void ScaleTreeY()
    //{
    //    // 現在のオブジェクトのスケール（サイズ）を取得
    //    Vector3 scale = transform.localScale;
    //    // scalingUpがtrueの場合、オブジェクトを拡大
    //    if (scalingUp)
    //    {
    //        // scaleSpeedに基づいてY軸方向にスケールを増加
    //        scale.y += scaleSpeed * Time.deltaTime;
    //        // initialPosition.yを増加
    //        initialPosition.y += 2.4f * Time.deltaTime;
    //        // スケールがmaxScaleに達したら
    //        if (scale.y >= maxScale)
    //        {
    //            // スケールをmaxScaleに固定
    //            scale.y = maxScale;
    //            // scalingUpをfalseに設定
    //            scalingUp = false;
    //        }
    //    }
    //    // scalingUpがfalseの場合、オブジェクトを縮小
    //    else
    //    {
    //        // scaleSpeedに基づいてY軸方向にスケールを減少
    //        scale.y -= scaleSpeed * Time.deltaTime;
    //        // initialPosition.yを減少
    //        initialPosition.y -= 2.4f * Time.deltaTime;
    //        // スケールがminScaleに達したら
    //        if (scale.y <= minScale)
    //        {
    //            // スケールをminScaleに固定
    //            scale.y = minScale;
    //            // scalingUpをtrueに設定
    //            scalingUp = true;
    //        }
    //    }
    //    // 更新されたスケールをオブジェクトに適用
    //    transform.localScale = scale;
        
    //    // オブジェクトの位置をinitialPositionに基づいて更新
    //    transform.position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);
    //}
}
