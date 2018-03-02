using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public GameObject playerPrefab;
    public GameObject groundPrefab;
    public GameObject enemyPrefab;
    public GameObject pigPrefab;

    public float tileWidth = 1f;
    public float tileHeight = 1f;

    public string levelFile = "levelfile.txt";


	// Use this for initialization
	void Start () {
		
        string levelString = File.ReadAllText(Application.dataPath + Path.DirectorySeparatorChar + levelFile);
        string[] levelLines = levelString.Split('\n');
        int width=0;
        for(int row = 0; row < levelLines.Length; row++)
        {
            string currentLine = levelLines[row];
            width = currentLine.Length;
            for (int col = 0; col < currentLine.Length; col++)
            {
                char currentChar = currentLine[col];
                if (currentChar == 'x')
                {
                    GameObject groundObj = Instantiate(groundPrefab);
                    groundObj.transform.position = new Vector3(col * tileWidth, -row * tileHeight, 0);
                }
                else if (currentChar == 'p')
                {
                    GameObject playerObj = Instantiate(playerPrefab);
                    playerObj.transform.position = new Vector3(col * tileWidth, -row * tileHeight, 0);
                }
                else if (currentChar == 'e')
                {
                    GameObject enemyObj = Instantiate(enemyPrefab);
                    enemyObj.transform.position = new Vector3(col * tileWidth, -row * tileHeight, 0);
                }
                else if (currentChar == 't')
                {
                    GameObject pigObj = Instantiate(pigPrefab);
                    pigObj.transform.position = new Vector3(col * tileWidth, -row * tileHeight, 0);
                }

            }
        }

        float myX = -(width*tileWidth) / 2f + tileWidth / 2f;
        float myY = (levelLines.Length * tileHeight) / 2f - tileHeight / 2f;
        transform.position = new Vector3(myX, myY, 0);
    }
   
}
