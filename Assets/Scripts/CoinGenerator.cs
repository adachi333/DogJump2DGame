using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    // コインのプレハブ
    public GameObject coinPrefab;
    // コインが生成される位置のオフセット
    public Vector3 coinSpawnOffset = new Vector3(0, 1, 0);

    // コインを生成する関数
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
