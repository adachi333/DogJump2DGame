using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;  // LoadSceneを使うために必要

public class PlayerController : MonoBehaviour
{
    // Rigidbody2Dコンポーネントを格納する変数
    Rigidbody2D rigid2D;
    // Animatorコンポーネントを格納する変数
    Animator animator;
    // ジャンプの強さを設定する変数
    float jumpForce = 780.0f;
    // 歩行時の力を設定する変数
    float walkForce = 30.0f;
    // 上限歩行速度を設定する変数
    float maxWalkSpeed = 2.0f;
    // 獲得したコインの枚数
    public int getCoinCount = 0;
    // 獲得できるコインの上限枚数
    public int getCoinMax = 3;
    // コインを取得したときの効果音を格納する変数
    public AudioClip coinSE;
    // ジャンプしたときの効果音を格納する変数
    public AudioClip jumpSE;
    // ゴールフラッグに到達したときの効果音を格納する変数
    public AudioClip goalFlagSE;
    // AudioSource コンポーネントを格納する変数
    AudioSource aud;
    // 待機状態かどうかを示すフラグ
    private bool isWaiting = false;
    // 待機時間を格納する変数
    private float waitTime = 0.0f;
    // 経過時間を格納する変数
    private float elapsedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // アプリケーションのフレームレートを60に設定
        Application.targetFrameRate = 60;
        // Rigidbody2Dコンポーネントを取得
        this.rigid2D = GetComponent<Rigidbody2D>();
        // Animatorコンポーネントを取得
        this.animator = GetComponent<Animator>();
        // AudioSourceコンポーネントを取得
        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 待機状態の場合
        if (isWaiting)
        {
            // 経過時間の更新
            elapsedTime += Time.deltaTime;
            // 経過時間が設定待機時間以上となった場合
            if (elapsedTime >= waitTime)
            {
                Debug.Log("Waiting Ended.");
                Debug.Log("ゴール");
                // ClearScene へ遷移させる
                SceneManager.LoadScene("ClearScene");
                // 待機フラグをおろす
                isWaiting = false;
            }
        }
        // 待機状態ではない場合
        if (!isWaiting)
        {
            // ジャンプする
            if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
            {
                // animator に JumpTrigger を設定
                this.animator.SetTrigger("JumpTrigger");
                // 物理エンジンを用いて、上方向へ力を加える
                this.rigid2D.AddForce(transform.up * this.jumpForce);
                // 効果音再生（一度だけ）
                this.aud.PlayOneShot(this.jumpSE);
            }

            // 左右移動
            int key = 0;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.animator.SetTrigger("WalkTrigger");
                key = 1;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.animator.SetTrigger("WalkTrigger");
                key = -1;
            }

            // プレイヤの速度
            float speedx = Mathf.Abs(this.rigid2D.velocity.x);

            // スピード制限
            if (speedx < this.maxWalkSpeed)
            {
                this.rigid2D.AddForce(transform.right * key * this.walkForce);
            }

            // 動く方向に応じて反転
            if (key != 0)
            {
                transform.localScale = new Vector3(key, 1, 1);
            }

            // プレイヤの速度に応じてアニメーション速度を変える
            if (this.rigid2D.velocity.y == 0)
            {
                this.animator.speed = speedx / 2.0f;
            }
            else
            {
                this.animator.speed = 1.0f;
            }

            // 画面外に出た場合
            if (transform.position.y < -10)
            {
                // GameOverScene へ遷移させる
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }

    // 衝突判定
    void OnTriggerEnter2D(Collider2D collision)
    {
        // コインを獲得
        if (collision.gameObject.CompareTag("Coin"))
        {
            // コイン獲得枚数が上限値に達していない場合
            if (getCoinCount < getCoinMax)
            {
                // 獲得コインのカウントをインクリメント
                ++getCoinCount;
            }
            // 効果音再生（一度だけ）
            this.aud.PlayOneShot(this.coinSE);
            // コインオブジェクトを破棄
            Destroy(collision.gameObject);
        }
        // ゴールに到達
        else if (collision.gameObject.CompareTag("Goal"))
        {
            // 効果音再生（一度だけ）
            this.aud.PlayOneShot(this.goalFlagSE);
            // 1.7秒待機する
            isWait(1.7f);

        }
    }
    // 待機関数
    void isWait(float seconds)
    {
        // デバッグログ
        Debug.Log("Waiting Started");
        // 待機時間の設定
        waitTime = seconds;
        // 経過時間の初期化
        elapsedTime = 0.0f;
        // 待機フラグをたてる
        isWaiting = true;
    }
}
