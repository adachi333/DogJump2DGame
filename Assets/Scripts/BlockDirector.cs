using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDirector : MonoBehaviour
{
    private GameObject gameDirector;

    // enum�̒�`
    public enum GenerateKind
    {
        COIN,
        BLOCK,
        NONE
    }

    // enum�^�̕ϐ���錾
    public GenerateKind generateKind;

    // Start is called before the first frame update
    void Start()
    {
        // GameDirector�Q�[���I�u�W�F�N�g���擾
        gameDirector = GameObject.Find("GameDirector");

        // enum�̒l��ݒ�
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
        // GameDirector��HandleBlockCollision�֐����Ăяo��
        gameDirector.GetComponent<GameDirector>().HandleBlockCollision(collision, transform, generateKind);
    }
}
