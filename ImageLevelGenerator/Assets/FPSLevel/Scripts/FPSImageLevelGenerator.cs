using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSImageLevelGenerator : MonoBehaviour {

    public Texture2D LevelImage;
    public Color32 floorColor, wall1Color, wall2Color, wall3Color, playerColor, doorColor, enemyColor;
    public GameObject floorPrefab, wall1Prefab, wall2Prefab, wall3Prefab, playerPrefab, doorPrefab, enemyPrefab;
    private int[,] levelData;

    GameObject floor, ceiling, wall, door, enemy;

    public Transform levelLayout, enemies;

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
            for(int y = 0; y < LevelImage.height; y++)
            {
                Color32 data = LevelImage.GetPixel(x, y);
                if (data.Equals(floorColor))
                {
                    levelData[x, y] = 1;
                }

                if (data.Equals(wall1Color))
                {
                    levelData[x, y] = 2;
                }

                if (data.Equals(wall2Color))
                {
                    levelData[x, y] = 3;
                }

                if (data.Equals(wall3Color))
                {
                    levelData[x, y] = 4;
                }

                if (data.Equals(playerColor))
                {
                    levelData[x, y] = 5;
                }

                if(data.Equals(doorColor))
                {
                    levelData[x, y] = 6;
                }

                if(data.Equals(enemyColor))
                {
                    levelData[x, y] = 7; 
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
                switch(levelData[x,y])
                {
                    case 1:
                        floor = Instantiate(floorPrefab, new Vector3(x * 1, -1, y * 1), transform.rotation);
                        ceiling = Instantiate(floorPrefab, new Vector3(x * 1, 1, y * 1), transform.rotation);

                        floor.transform.parent = levelLayout.transform;
                        ceiling.transform.parent = levelLayout.transform;
                        break;

                    case 2:
                        wall = Instantiate(wall1Prefab, new Vector3(x * 1, 0, y * 1), transform.rotation);

                        wall.transform.parent = levelLayout.transform;
                        break;

                    case 3:
                        wall = Instantiate(wall2Prefab, new Vector3(x * 1, 0, y * 1), transform.rotation);

                        wall.transform.parent = levelLayout.transform;
                        break;

                    case 4:
                        wall = Instantiate(wall3Prefab, new Vector3(x * 1, 0, y * 1), transform.rotation);

                        wall.transform.parent = levelLayout.transform;
                        break;

                    case 5:
                        Instantiate(playerPrefab, new Vector3(x * 1, 0, y * 1), transform.rotation);
                        floor = Instantiate(floorPrefab, new Vector3(x * 1, -1, y * 1), transform.rotation);
                        ceiling = Instantiate(floorPrefab, new Vector3(x * 1, 1, y * 1), transform.rotation);

                        floor.transform.parent = levelLayout.transform;
                        ceiling.transform.parent = levelLayout.transform;
                        break;

                    case 6:
                        door = Instantiate(doorPrefab, new Vector3(x * 1, 0, y * 1), transform.rotation);
                        floor = Instantiate(floorPrefab, new Vector3(x * 1, -1, y * 1), transform.rotation);
                        ceiling = Instantiate(floorPrefab, new Vector3(x * 1, 1, y * 1), transform.rotation);

                        ceiling.transform.parent = levelLayout.transform;
                        floor.transform.parent = levelLayout.transform;
                        door.transform.parent = levelLayout.transform;
                        break;

                    case 7:
                        enemy = Instantiate(enemyPrefab, new Vector3(x * 1, 0, y * 1), transform.rotation);
                        floor = Instantiate(floorPrefab, new Vector3(x * 1, -1, y * 1), transform.rotation);
                        ceiling = Instantiate(floorPrefab, new Vector3(x * 1, 1, y * 1), transform.rotation);

                        ceiling.transform.parent = levelLayout.transform;
                        floor.transform.parent = levelLayout.transform;
                        enemy.transform.parent = enemies.transform;
                        break;
                }
            }
        }
    }
}
