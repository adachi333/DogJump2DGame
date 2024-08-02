using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    // �u���b�N�̃v���n�u
    public GameObject blockPrefab;
    // �u���b�N�����������ʒu�̃I�t�Z�b�g
    public Vector3 blockSpawnOffset = new Vector3(1, -3, 0);

    GameObject gameDirector;
    private bool isUpperBlockInitialized = false;

    // ������Sprite
    public Sprite initialSprite;
    // �ύX���Sprite
    public Sprite newSprite;

    // �u���b�N�𐶐�����֐�
    public void GenerateBlock(Vector3 collisionBlockPosition, GameDirector.GenerateBlockKind generateBlockKind)
    {
        if (generateBlockKind == GameDirector.GenerateBlockKind.LOWER)
        {
            // x�������ɂP�V�t�g
            blockSpawnOffset.x += 1;
        }
        else if (generateBlockKind == GameDirector.GenerateBlockKind.UPPER)
        {
            // ����̂�InitializeUpperBlockSpawn�����s
            if (!isUpperBlockInitialized)
            {
                InitializeUpperBlockSpawn();
                isUpperBlockInitialized = true;
            }
            // x��������-�P�V�t�g
            blockSpawnOffset.x -= 1;
        }
        Instantiate(blockPrefab, collisionBlockPosition + blockSpawnOffset, Quaternion.identity);
    }

    // �X�v���C�g��ݒ肷��֐�
    public void SetSpriteRenderer(Sprite sprite)
    {
        // SpriteRenderer���擾
        SpriteRenderer spriteRenderer = blockPrefab.GetComponent<SpriteRenderer>();
        // Sprite��ݒ�i�ύX�j
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = sprite;
        }
        else
        {
            Debug.LogError("SpriteRenderer��������܂���ł����B");
        }
    }

    // ��������u���b�N������������֐�
    public void InitializeUpperBlockSpawn()
    {
        gameDirector = GameObject.Find("GameDirector");
        // �u���b�N�����������ʒu�̃I�t�Z�b�g
        blockSpawnOffset = new Vector3(10, 5, 0);
        // �u���b�N�̃X�v���C�g��V���ɐݒ�
        SetSpriteRenderer(newSprite);
    }

    // �X�v���C�g�������ݒ�ɂ��ǂ��֐�
    public void ResetSpriteRenderer()
    {
        // �u���b�N�̃X�v���C�g�������ݒ�ɂ��ǂ�
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
