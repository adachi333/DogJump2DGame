using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    // �R�C���̃v���n�u
    public GameObject coinPrefab;
    // �R�C�������������ʒu�̃I�t�Z�b�g
    public Vector3 coinSpawnOffset = new Vector3(0, 1, 0);

    // �R�C���𐶐�����֐�
    public void GenerateCoin(Vector3 blockPosition)
    {
        Instantiate(coinPrefab, blockPosition + coinSpawnOffset, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
