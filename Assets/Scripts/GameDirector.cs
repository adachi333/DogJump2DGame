using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    private CoinGenerator coinGenerator;
    private BlockGenerator blockGenerator;
    private TreeController treeController;
    private ObjectScaler objectScaler;
    private PlayerController playerController;
    private GameObject tree;
    private bool treeScaleFlag = false;
    public int generateBlockCount;

    public AudioClip blockSE;
    private AudioSource aud;

    // enumの定義
    public enum GenerateBlockKind
    {
        UPPER,
        LOWER,
        NONE
    }

    // enum型の変数を宣言
    public GenerateBlockKind generateBlockKind;

    // Start is called before the first frame update
    void Start()
    {
        // CoinGeneratorコンポーネントを取得
        coinGenerator = FindObjectOfType<CoinGenerator>();
        // BlockGeneratorコンポーネントを取得
        blockGenerator = FindObjectOfType<BlockGenerator>();
        // TreeControllerコンポーネントを取得
        treeController = FindObjectOfType<TreeController>();
        // 
        tree = GameObject.Find("Tree");
        // ObjectScalerコンポーネントを取得
        objectScaler = FindObjectOfType<ObjectScaler>();
        // PlayerControllerコンポーネントを取得
        playerController = FindObjectOfType<PlayerController>();
        // generateBlockCountの初期化
        generateBlockCount = 0;
        // 生成するブロックの種類の初期化
        generateBlockKind = GenerateBlockKind.NONE;
        // AudioSourceコンポーネントを取得
        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Blockに接触した場合
        if (treeScaleFlag)
        {
            float maxScale = 7.5f;
            float minScale = 1.0f;
            Vector3 scaleAxis = new Vector3(0, 1, 0); // Y軸にスケーリング
            // Treeのスケールを変化させる
            objectScaler.ScaleObject(tree, maxScale, minScale, scaleAxis);
            //treeController.ScaleTreeY();
        }
    }
    // プレイヤーとブロックが接触した場合の処理関数
    public void HandleBlockCollision(Collision2D collision, Transform blockTransform, BlockDirector.GenerateKind generateKind)
    {
        // プレイヤーがブロックに接触した場合
        if (collision.gameObject.CompareTag("Player"))
        {
            this.aud.PlayOneShot(this.blockSE);
            // enumの値に応じた処理
            switch (generateKind)
            {
                case BlockDirector.GenerateKind.COIN:
                    // 獲得コイン枚数が上限枚数に達していない場合
                    if (playerController.getCoinCount < playerController.getCoinMax)
                    {
                        // コインを生成
                        coinGenerator.GenerateCoin(blockTransform.position);
                    }
                    // 獲得コイン枚数が上限枚数に達している場合
                    else
                    {
                        //なにもせず関数をぬける
                        return;
                    }
                    break;
                case BlockDirector.GenerateKind.BLOCK:
                    // 獲得コイン枚数が３以上の場合
                    if (playerController.getCoinCount >= 3)
                    {
                        // フラグをたてる
                        treeScaleFlag = true;
                    }
                    // 生成したブロック数が１５を超える場合
                    if (generateBlockCount > 15)
                    {
                        // なにもせずに関数をぬける
                        return;
                    }
                    // ブロックの生成位置による種類区分
                    if (0 <= generateBlockCount && generateBlockCount < 12)
                    {
                        // ブロックの種類
                        generateBlockKind = GenerateBlockKind.LOWER;
                    }
                    else if (generateBlockCount >= 12)
                    {
                        // ブロックの種類
                        generateBlockKind = GenerateBlockKind.UPPER;
                    }
                    // ブロックを生成
                    blockGenerator.GenerateBlock(blockTransform.position, generateBlockKind);
                    // 生成ブロックカウントをインクリメント
                    ++generateBlockCount;
                    break;
            }
        }
    }
}
