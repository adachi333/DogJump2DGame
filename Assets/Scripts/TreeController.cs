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

    // Tree �̂��������X�P�[����ω�������֐�
    //public void ScaleTreeY()
    //{
    //    // ���݂̃I�u�W�F�N�g�̃X�P�[���i�T�C�Y�j���擾
    //    Vector3 scale = transform.localScale;
    //    // scalingUp��true�̏ꍇ�A�I�u�W�F�N�g���g��
    //    if (scalingUp)
    //    {
    //        // scaleSpeed�Ɋ�Â���Y�������ɃX�P�[���𑝉�
    //        scale.y += scaleSpeed * Time.deltaTime;
    //        // initialPosition.y�𑝉�
    //        initialPosition.y += 2.4f * Time.deltaTime;
    //        // �X�P�[����maxScale�ɒB������
    //        if (scale.y >= maxScale)
    //        {
    //            // �X�P�[����maxScale�ɌŒ�
    //            scale.y = maxScale;
    //            // scalingUp��false�ɐݒ�
    //            scalingUp = false;
    //        }
    //    }
    //    // scalingUp��false�̏ꍇ�A�I�u�W�F�N�g���k��
    //    else
    //    {
    //        // scaleSpeed�Ɋ�Â���Y�������ɃX�P�[��������
    //        scale.y -= scaleSpeed * Time.deltaTime;
    //        // initialPosition.y������
    //        initialPosition.y -= 2.4f * Time.deltaTime;
    //        // �X�P�[����minScale�ɒB������
    //        if (scale.y <= minScale)
    //        {
    //            // �X�P�[����minScale�ɌŒ�
    //            scale.y = minScale;
    //            // scalingUp��true�ɐݒ�
    //            scalingUp = true;
    //        }
    //    }
    //    // �X�V���ꂽ�X�P�[�����I�u�W�F�N�g�ɓK�p
    //    transform.localScale = scale;
        
    //    // �I�u�W�F�N�g�̈ʒu��initialPosition�Ɋ�Â��čX�V
    //    transform.position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);
    //}
}
