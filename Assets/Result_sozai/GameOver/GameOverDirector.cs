using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //LoadScene���g�����߂ɕK�v

public class GameOverDirector : MonoBehaviour
{
    public Button restartButton;
    public GameObject alien;
    public RectTransform buttonRectTransform;

    void Start()
    {
        // �{�^���Ƀ��X�i�[��ǉ�
        restartButton.onClick.AddListener(TransitionToScene);
    }

    // �w�肳�ꂽ�V�[���ɑJ�ڂ�����֐�
    void TransitionToScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    // Alien��Button�̓�����A��������֐�
    void FollowAlien()
    {
        // Alien�̃��[���h���W���X�N���[�����W�ɕϊ�
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(alien.transform.position);

        // Button�̈ʒu��Alien�̈ʒu���y��������64�s�N�Z������ɐݒ�
        screenPosition.y += 64;

        // Button�̈ʒu���X�N���[�����W�ɐݒ�
        buttonRectTransform.position = screenPosition;
    }
    void Update()
    {
        FollowAlien();
    }
}
