using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerLevelGen : MonoBehaviour {

    public Texture2D LevelImage;
    public Color32 groundColor, pipeColor, block1Color, block2Color, playerColor;
    public GameObject groundPrefab, pipePrefab, block1Prefab, block2Prefab, playerPrefab;
    private int[,] levelData;

    // Use this for initialization
    void Start () {
        levelData = new int[LevelImage.width, LevelImage.height];
        GenerateLevelData();
        BuildLevel();
    }

    void GenerateLevelData()
    {
        for (int x = 0; x < LevelImage.width; x++)
        {
            for (int y = 0; y < LevelImage.height; y++)
            {
                Color32 data = LevelImage.GetPixel(x, y);
                if (data.Equals(groundColor))
                {
                    levelData[x, y] = 1;
                }

                if (data.Equals(pipeColor))
                {
                    levelData[x, y] = 2;
                }

                if (data.Equals(block1Color))
                {
                    levelData[x, y] = 3;
                }

                if (data.Equals(block2Color))
                {
                    levelData[x, y] = 4;
                }
            }
        }
    }

    void BuildLevel()
    {
        for (int x = 0; x < LevelImage.width; x++)
        {
            for (int y = 0; y < LevelImage.height; y++)
            {
                switch (levelData[x, y])
                {
                    case 1:
                        Instantiate(groundPrefab, new Vector3(x, y, 0), transform.rotation);
                        break;

                    case 2:
                        Instantiate(pipePrefab, new Vector3(x, y, 0), transform.rotation);
                        break;

                    case 3:
                        Instantiate(block1Prefab, new Vector3(x, y, 0), transform.rotation);
                        break;

                    case 4:
                        Instantiate(block2Prefab, new Vector3(x, y, 0), transform.rotation);
                        break;
                }
            }
        }
    }
}
