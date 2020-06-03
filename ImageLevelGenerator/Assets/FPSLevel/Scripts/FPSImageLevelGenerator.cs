using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSImageLevelGenerator : MonoBehaviour {

    public Texture2D LevelImage;  //Texture2D is used to read the selected Image to build level
    public Color32 floorColor, wall1Color, wall2Color, wall3Color, playerColor, doorColor, enemyColor; //Color32 gives you access to RGBA (255,255,255,255)
    public GameObject floorPrefab, wall1Prefab, wall2Prefab, wall3Prefab, playerPrefab, doorPrefab, enemyPrefab; //Prefabs used to build the different parts of the level

    private int[,] levelData; //[,] is used as a coorindate system for building the level

    GameObject floor, ceiling, wall, door, enemy; //Applying names to each of the built prefabs

    public Transform levelLayout, enemies; //Used to attach instantiated prefabs as a child to make the hierarchy cleaner

    // Use this for initialization
    void Start () {
        //Getting the length and height of the image for the level
        levelData = new int[LevelImage.width, LevelImage.height];
        GenerateLevelData();
        BuildLevel();
    }

    /// <summary>
    /// This method is used to generate the level's data by setting the color of each pixel to a set number that will be used in BuildLevel();
    /// </summary>
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

    /// <summary>
    /// BuildLevel() is used to take each set value used for the colors into a switch function that will generate the correct prefabs needed
    /// Once the prefabs are instantiated, they will become a child to a parent to make the hiearchy cleaner 
    /// Example case 1 builds out the floor and ceiling and the children are added to the level Layout as their parent;
    /// </summary>
    void BuildLevel()
    {
        for (int x = 0; x < LevelImage.width; x++)
        {
            for (int y = 0; y < LevelImage.height; y++)
            {
                switch(levelData[x,y])
                {
                    //This case builds out the floor and ceiling
                    case 1:
                        floor = Instantiate(floorPrefab, new Vector3(x * 1, -1, y * 1), transform.rotation);
                        ceiling = Instantiate(floorPrefab, new Vector3(x * 1, 1, y * 1), transform.rotation);

                        floor.transform.parent = levelLayout.transform;
                        ceiling.transform.parent = levelLayout.transform;
                        break;

                    //This case builds out the first set of walls
                    case 2:
                        wall = Instantiate(wall1Prefab, new Vector3(x * 1, 0, y * 1), transform.rotation);

                        wall.transform.parent = levelLayout.transform;
                        break;

                    //This case builds out the second set of walls
                    case 3:
                        wall = Instantiate(wall2Prefab, new Vector3(x * 1, 0, y * 1), transform.rotation);

                        wall.transform.parent = levelLayout.transform;
                        break;

                    //This case builds out the third set of walls
                    case 4:
                        wall = Instantiate(wall3Prefab, new Vector3(x * 1, 0, y * 1), transform.rotation);

                        wall.transform.parent = levelLayout.transform;
                        break;

                    //This case builds out the player, floor and ceiling surrounding the player
                    case 5:
                        Instantiate(playerPrefab, new Vector3(x * 1, 0, y * 1), transform.rotation);
                        floor = Instantiate(floorPrefab, new Vector3(x * 1, -1, y * 1), transform.rotation);
                        ceiling = Instantiate(floorPrefab, new Vector3(x * 1, 1, y * 1), transform.rotation);

                        floor.transform.parent = levelLayout.transform;
                        ceiling.transform.parent = levelLayout.transform;
                        break;

                    //This case builds out the door, floor and ceiling surrounding the door
                    case 6:
                        door = Instantiate(doorPrefab, new Vector3(x * 1, 0, y * 1), transform.rotation);
                        floor = Instantiate(floorPrefab, new Vector3(x * 1, -1, y * 1), transform.rotation);
                        ceiling = Instantiate(floorPrefab, new Vector3(x * 1, 1, y * 1), transform.rotation);

                        ceiling.transform.parent = levelLayout.transform;
                        floor.transform.parent = levelLayout.transform;
                        door.transform.parent = levelLayout.transform;
                        break;

                    //This case builds out the enemy, floor and ceiling surrounding the enemy
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
