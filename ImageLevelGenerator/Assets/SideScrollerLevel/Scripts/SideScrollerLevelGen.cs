using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerLevelGen : MonoBehaviour {

    public Texture2D LevelImage; //Texture2D is used to read the selected Image to build level
    public Color32 groundColor, pipeColor, block1Color, block2Color, playerColor; //Color32 gives you access to RGBA (255,255,255,255)
    public GameObject groundPrefab, pipePrefab, block1Prefab, block2Prefab, playerPrefab; //Prefabs used to build the different parts of the level

    private int[,] levelData; //[,] is used as a coorindate system for building the level

    public Transform levelLayout; //Used to attach instantiated prefabs as a child to make the hierarchy cleaner

    GameObject floor; //Applying names to each of the built prefabs

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

                if(data.Equals(playerColor))
                {
                    levelData[x, y] = 5;
                }
            }
        }
    }

    /// <summary>
    /// BuildLevel() is used to take each set value used for the colors into a switch function that will generate the correct prefabs needed
    /// Once the prefabs are instantiated, they will become a child to a parent to make the hiearchy cleaner 
    /// Example case 1 builds out the floor and the children are added to the level Layout as their parent;
    /// </summary>
    void BuildLevel()
    {
        for (int x = 0; x < LevelImage.width; x++)
        {
            for (int y = 0; y < LevelImage.height; y++)
            {
                //Case 1-4 builds out the level
                //Case 5 builds the player
                switch (levelData[x, y])
                {
                    case 1:
                        floor = Instantiate(groundPrefab, new Vector3(x, y, 0), transform.rotation);
                        floor.transform.parent = levelLayout.transform;
                        break;

                    case 2:
                        floor = Instantiate(pipePrefab, new Vector3(x, y, 0), transform.rotation);
                        floor.transform.parent = levelLayout.transform;
                        break;

                    case 3:
                        floor = Instantiate(block1Prefab, new Vector3(x, y, 0), transform.rotation);
                        floor.transform.parent = levelLayout.transform;
                        break;

                    case 4:
                        floor = Instantiate(block2Prefab, new Vector3(x, y, 0), transform.rotation);
                        floor.transform.parent = levelLayout.transform;
                        break;

                    case 5:
                        Instantiate(playerPrefab, new Vector3(x, y, 0), transform.rotation);
                        break;
                }
            }
        }
    }
}
