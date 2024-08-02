using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //LoadSceneを使うために必要

public class GameOverDirector : MonoBehaviour
{
    public Button restartButton;
    public GameObject alien;
    public RectTransform buttonRectTransform;

    void Start()
    {
        // ボタンにリスナーを追加
        restartButton.onClick.AddListener(TransitionToScene);
    }

    // 指定されたシーンに遷移させる関数
    void TransitionToScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    // AlienとButtonの動きを連動させる関数
    void FollowAlien()
    {
        // Alienのワールド座標をスクリーン座標に変換
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(alien.transform.position);

        // Buttonの位置をAlienの位置よりy軸方向に64ピクセル上方に設定
        screenPosition.y += 64;

        // Buttonの位置をスクリーン座標に設定
        buttonRectTransform.position = screenPosition;
    }
    void Update()
    {
        FollowAlien();
    }
}
