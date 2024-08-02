using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    // ブロックのプレハブ
    public GameObject blockPrefab;
    // ブロックが生成される位置のオフセット
    public Vector3 blockSpawnOffset = new Vector3(1, -3, 0);

    GameObject gameDirector;
    private bool isUpperBlockInitialized = false;

    // 初期のSprite
    public Sprite initialSprite;
    // 変更後のSprite
    public Sprite newSprite;

    // ブロックを生成する関数
    public void GenerateBlock(Vector3 collisionBlockPosition, GameDirector.GenerateBlockKind generateBlockKind)
    {
        if (generateBlockKind == GameDirector.GenerateBlockKind.LOWER)
        {
            // x軸方向に１シフト
            blockSpawnOffset.x += 1;
        }
        else if (generateBlockKind == GameDirector.GenerateBlockKind.UPPER)
        {
            // 初回のみInitializeUpperBlockSpawnを実行
            if (!isUpperBlockInitialized)
            {
                InitializeUpperBlockSpawn();
                isUpperBlockInitialized = true;
            }
            // x軸方向に-１シフト
            blockSpawnOffset.x -= 1;
        }
        Instantiate(blockPrefab, collisionBlockPosition + blockSpawnOffset, Quaternion.identity);
    }

    // スプライトを設定する関数
    public void SetSpriteRenderer(Sprite sprite)
    {
        // SpriteRendererを取得
        SpriteRenderer spriteRenderer = blockPrefab.GetComponent<SpriteRenderer>();
        // Spriteを設定（変更）
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = sprite;
        }
        else
        {
            Debug.LogError("SpriteRendererが見つかりませんでした。");
        }
    }

    // 上方生成ブロックを初期化する関数
    public void InitializeUpperBlockSpawn()
    {
        gameDirector = GameObject.Find("GameDirector");
        // ブロックが生成される位置のオフセット
        blockSpawnOffset = new Vector3(10, 5, 0);
        // ブロックのスプライトを新たに設定
        SetSpriteRenderer(newSprite);
    }

    // スプライトを初期設定にもどす関数
    public void ResetSpriteRenderer()
    {
        // ブロックのスプライトを初期設定にもどす
        SetSpriteRenderer(initialSprite);
    }

        // Start is called before the first frame update
        void Start()
    {
        SetSpriteRenderer(initialSprite);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
