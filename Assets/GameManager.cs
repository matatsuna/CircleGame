using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public BlockManager BlockProvider { get; private set; }
    public GameObject BlocksArea { get; private set; }

    void Start()
    {
        this.BlockProvider = GetComponent<BlockManager>();
        this.BlocksArea = GameObject.Find("Blocks");

        // 配置の初期化
        InitializeStage();
    }

    /// <summary>
    /// ブロック配置の初期化
    /// </summary>
    private void InitializeStage()
    {
        var blocks = new List<Block>();

        // 開始位置とブロックのサイズ
        var startPosX = -7.5f;
        var startPosY = 7.5f;
        var width = 1.5f;
        var height = 1.5f;

        for (int i = 0; i < 11; i++)
        {
            var posY = startPosY - height * i;
            for (int j = 0; j < 11; j++)
            {
                var posX = startPosX + width * j;
                var position = new Vector3(posX, 0.9f, posY);
                var block = BlockProvider.Create(this.BlocksArea.GetComponent<Transform>(), position);
                blocks.Add(block);
            }
        }
    }
    public void Click()
    {
        SceneManager.LoadScene("main");
    }
}
