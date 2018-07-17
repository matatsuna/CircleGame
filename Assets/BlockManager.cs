using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{

    [SerializeField]
    private GameObject BlockPrefab;

    /// <summary>
    /// ブロックの生成処理
    /// </summary>
    /// <returns></returns>
    public Block Create(Transform parent, Vector3 position)
    {
        var go = Instantiate(this.BlockPrefab, parent) as GameObject;
        var block = go.GetComponent<Block>();
        go.GetComponent<Transform>().position = position;

        return block;
    }
}
