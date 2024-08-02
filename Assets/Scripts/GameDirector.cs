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

    // enum�̒�`
    public enum GenerateBlockKind
    {
        UPPER,
        LOWER,
        NONE
    }

    // enum�^�̕ϐ���錾
    public GenerateBlockKind generateBlockKind;

    // Start is called before the first frame update
    void Start()
    {
        // CoinGenerator�R���|�[�l���g���擾
        coinGenerator = FindObjectOfType<CoinGenerator>();
        // BlockGenerator�R���|�[�l���g���擾
        blockGenerator = FindObjectOfType<BlockGenerator>();
        // TreeController�R���|�[�l���g���擾
        treeController = FindObjectOfType<TreeController>();
        // 
        tree = GameObject.Find("Tree");
        // ObjectScaler�R���|�[�l���g���擾
        objectScaler = FindObjectOfType<ObjectScaler>();
        // PlayerController�R���|�[�l���g���擾
        playerController = FindObjectOfType<PlayerController>();
        // generateBlockCount�̏�����
        generateBlockCount = 0;
        // ��������u���b�N�̎�ނ̏�����
        generateBlockKind = GenerateBlockKind.NONE;
        // AudioSource�R���|�[�l���g���擾
        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Block�ɐڐG�����ꍇ
        if (treeScaleFlag)
        {
            float maxScale = 7.5f;
            float minScale = 1.0f;
            Vector3 scaleAxis = new Vector3(0, 1, 0); // Y���ɃX�P�[�����O
            // Tree�̃X�P�[����ω�������
            objectScaler.ScaleObject(tree, maxScale, minScale, scaleAxis);
            //treeController.ScaleTreeY();
        }
    }
    // �v���C���[�ƃu���b�N���ڐG�����ꍇ�̏����֐�
    public void HandleBlockCollision(Collision2D collision, Transform blockTransform, BlockDirector.GenerateKind generateKind)
    {
        // �v���C���[���u���b�N�ɐڐG�����ꍇ
        if (collision.gameObject.CompareTag("Player"))
        {
            this.aud.PlayOneShot(this.blockSE);
            // enum�̒l�ɉ���������
            switch (generateKind)
            {
                case BlockDirector.GenerateKind.COIN:
                    // �l���R�C����������������ɒB���Ă��Ȃ��ꍇ
                    if (playerController.getCoinCount < playerController.getCoinMax)
                    {
                        // �R�C���𐶐�
                        coinGenerator.GenerateCoin(blockTransform.position);
                    }
                    // �l���R�C����������������ɒB���Ă���ꍇ
                    else
                    {
                        //�Ȃɂ������֐����ʂ���
                        return;
                    }
                    break;
                case BlockDirector.GenerateKind.BLOCK:
                    // �l���R�C���������R�ȏ�̏ꍇ
                    if (playerController.getCoinCount >= 3)
                    {
                        // �t���O�����Ă�
                        treeScaleFlag = true;
                    }
                    // ���������u���b�N�����P�T�𒴂���ꍇ
                    if (generateBlockCount > 15)
                    {
                        // �Ȃɂ������Ɋ֐����ʂ���
                        return;
                    }
                    // �u���b�N�̐����ʒu�ɂ���ދ敪
                    if (0 <= generateBlockCount && generateBlockCount < 12)
                    {
                        // �u���b�N�̎��
                        generateBlockKind = GenerateBlockKind.LOWER;
                    }
                    else if (generateBlockCount >= 12)
                    {
                        // �u���b�N�̎��
                        generateBlockKind = GenerateBlockKind.UPPER;
                    }
                    // �u���b�N�𐶐�
                    blockGenerator.GenerateBlock(blockTransform.position, generateBlockKind);
                    // �����u���b�N�J�E���g���C���N�������g
                    ++generateBlockCount;
                    break;
            }
        }
    }
}
