using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDirector : MonoBehaviour
{
    private GameObject gameDirector;

    // enumの定義
    public enum GenerateKind
    {
        COIN,
        BLOCK,
        NONE
    }

    // enum型の変数を宣言
    public GenerateKind generateKind;

    // Start is called before the first frame update
    void Start()
    {
        // GameDirectorゲームオブジェクトを取得
        gameDirector = GameObject.Find("GameDirector");

        // enumの値を設定
        generateKind = GenerateKind.NONE;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("coinGenerateBlock"))
        {
            generateKind = GenerateKind.COIN;
        }
        else if (gameObject.CompareTag("blockGenerateBlock"))
        {
            generateKind = GenerateKind.BLOCK;
        }
        // GameDirectorのHandleBlockCollision関数を呼び出す
        gameDirector.GetComponent<GameDirector>().HandleBlockCollision(collision, transform, generateKind);
    }
}
