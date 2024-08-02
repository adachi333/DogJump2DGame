using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;  // LoadScene���g�����߂ɕK�v

public class PlayerController : MonoBehaviour
{
    // Rigidbody2D�R���|�[�l���g���i�[����ϐ�
    Rigidbody2D rigid2D;
    // Animator�R���|�[�l���g���i�[����ϐ�
    Animator animator;
    // �W�����v�̋�����ݒ肷��ϐ�
    float jumpForce = 780.0f;
    // ���s���̗͂�ݒ肷��ϐ�
    float walkForce = 30.0f;
    // ������s���x��ݒ肷��ϐ�
    float maxWalkSpeed = 2.0f;
    // �l�������R�C���̖���
    public int getCoinCount = 0;
    // �l���ł���R�C���̏������
    public int getCoinMax = 3;
    // �R�C�����擾�����Ƃ��̌��ʉ����i�[����ϐ�
    public AudioClip coinSE;
    // �W�����v�����Ƃ��̌��ʉ����i�[����ϐ�
    public AudioClip jumpSE;
    // �S�[���t���b�O�ɓ��B�����Ƃ��̌��ʉ����i�[����ϐ�
    public AudioClip goalFlagSE;
    // AudioSource �R���|�[�l���g���i�[����ϐ�
    AudioSource aud;
    // �ҋ@��Ԃ��ǂ����������t���O
    private bool isWaiting = false;
    // �ҋ@���Ԃ��i�[����ϐ�
    private float waitTime = 0.0f;
    // �o�ߎ��Ԃ��i�[����ϐ�
    private float elapsedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // �A�v���P�[�V�����̃t���[�����[�g��60�ɐݒ�
        Application.targetFrameRate = 60;
        // Rigidbody2D�R���|�[�l���g���擾
        this.rigid2D = GetComponent<Rigidbody2D>();
        // Animator�R���|�[�l���g���擾
        this.animator = GetComponent<Animator>();
        // AudioSource�R���|�[�l���g���擾
        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // �ҋ@��Ԃ̏ꍇ
        if (isWaiting)
        {
            // �o�ߎ��Ԃ̍X�V
            elapsedTime += Time.deltaTime;
            // �o�ߎ��Ԃ��ݒ�ҋ@���Ԉȏ�ƂȂ����ꍇ
            if (elapsedTime >= waitTime)
            {
                Debug.Log("Waiting Ended.");
                Debug.Log("�S�[��");
                // ClearScene �֑J�ڂ�����
                SceneManager.LoadScene("ClearScene");
                // �ҋ@�t���O�����낷
                isWaiting = false;
            }
        }
        // �ҋ@��Ԃł͂Ȃ��ꍇ
        if (!isWaiting)
        {
            // �W�����v����
            if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
            {
                // animator �� JumpTrigger ��ݒ�
                this.animator.SetTrigger("JumpTrigger");
                // �����G���W����p���āA������֗͂�������
                this.rigid2D.AddForce(transform.up * this.jumpForce);
                // ���ʉ��Đ��i��x�����j
                this.aud.PlayOneShot(this.jumpSE);
            }

            // ���E�ړ�
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

            // �v���C���̑��x
            float speedx = Mathf.Abs(this.rigid2D.velocity.x);

            // �X�s�[�h����
            if (speedx < this.maxWalkSpeed)
            {
                this.rigid2D.AddForce(transform.right * key * this.walkForce);
            }

            // ���������ɉ����Ĕ��]
            if (key != 0)
            {
                transform.localScale = new Vector3(key, 1, 1);
            }

            // �v���C���̑��x�ɉ����ăA�j���[�V�������x��ς���
            if (this.rigid2D.velocity.y == 0)
            {
                this.animator.speed = speedx / 2.0f;
            }
            else
            {
                this.animator.speed = 1.0f;
            }

            // ��ʊO�ɏo���ꍇ
            if (transform.position.y < -10)
            {
                // GameOverScene �֑J�ڂ�����
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }

    // �Փ˔���
    void OnTriggerEnter2D(Collider2D collision)
    {
        // �R�C�����l��
        if (collision.gameObject.CompareTag("Coin"))
        {
            // �R�C���l������������l�ɒB���Ă��Ȃ��ꍇ
            if (getCoinCount < getCoinMax)
            {
                // �l���R�C���̃J�E���g���C���N�������g
                ++getCoinCount;
            }
            // ���ʉ��Đ��i��x�����j
            this.aud.PlayOneShot(this.coinSE);
            // �R�C���I�u�W�F�N�g��j��
            Destroy(collision.gameObject);
        }
        // �S�[���ɓ��B
        else if (collision.gameObject.CompareTag("Goal"))
        {
            // ���ʉ��Đ��i��x�����j
            this.aud.PlayOneShot(this.goalFlagSE);
            // 1.7�b�ҋ@����
            isWait(1.7f);

        }
    }
    // �ҋ@�֐�
    void isWait(float seconds)
    {
        // �f�o�b�O���O
        Debug.Log("Waiting Started");
        // �ҋ@���Ԃ̐ݒ�
        waitTime = seconds;
        // �o�ߎ��Ԃ̏�����
        elapsedTime = 0.0f;
        // �ҋ@�t���O�����Ă�
        isWaiting = true;
    }
}
