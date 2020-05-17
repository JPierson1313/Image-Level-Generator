using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeldaLevelGenerator : MonoBehaviour {

    public Texture2D LevelImage;
    public Color32 floorColor, wallColor, playerColor, potColor, doorColor;
    public GameObject floorPrefab, wallPrefab, playerPrefab, potPrefab, doorPrefab;
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
                if(data.Equals(floorColor))
                {
                    levelData[x, y] = 1;
                }

                if (data.Equals(wallColor))
                {
                    levelData[x, y] = 2;
                }

                if (data.Equals(playerColor))
                {
                    levelData[x, y] = 3;
                }

                if (data.Equals(potColor))
                {
                    levelData[x, y] = 4;
                }

                if (data.Equals(doorColor))
                {
                    levelData[x, y] = 5;
                }
            }
        }
    }

    void BuildLevel()
    {
        for (int x = 0; x < LevelImage.width - 1; x++)
        {
            for (int y = 0; y < LevelImage.height - 1; y++)
            {
                switch (levelData[x,y])
                {
                    case 1:
                        //Instantiate(floorPrefab, new Vector3(x * 1, -1, y * 1), transform.rotation);
                        //Instantiate(floorPrefab, new Vector3(x * 3, -3, y * 3), transform.rotation);
                        break;

                    case 2:
                        Instantiate(wallPrefab, new Vector3(x * 3, 0, y * 3), transform.rotation);
                        //Instantiate(wallPrefab, new Vector3(x * 1, 0, y * 1), transform.rotation);
                        break;

                    case 3:
                        //Instantiate(playerPrefab, new Vector3(x * 3, 0, y * 3), transform.rotation);
                        //Instantiate(floorPrefab, new Vector3(x * 1, -1f, y * 1), transform.rotation);
                        break;

                    case 4:
                        Instantiate(potPrefab, new Vector3(x * 3, 0, y * 3), transform.rotation);
                        //Instantiate(potPrefab, new Vector3(x * 1, 0, y * 1), transform.rotation);
                        break;

                    case 5:
                        //Instantiate(doorPrefab, new Vector3(x * 1, 0, y * 1), transform.rotation);
                        Instantiate(doorPrefab, new Vector3(x * 3, 0, y * 3), transform.rotation);
                        break;
                }
            }
        }
    }
}
