using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //LoadScene���g�����߂ɕK�v

public class TitleDirector : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//�X�y�[�X�������ꂽ��
        {
            SceneManager.LoadScene("GameScene"); //GameScene�Ɉړ�����
        }
    }
}
