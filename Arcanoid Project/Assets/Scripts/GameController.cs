using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject brickPref;
    private GameObject[,] bricks = new GameObject[2,5];
    private float posX = -4f, posY = 3f;

    public static int destroyCount;

    void Start()
    {
        destroyCount = 0;
        for (int i = 0; i < 2; i++) 
        {
            for (int j = 0; j < 5; j++)
            {
                bricks[i,j] = Instantiate(brickPref);
                bricks[i,j].transform.position = new Vector2(posX, posY);
                posX += 2f;
            }
            posY -= 1f;
            posX = -4f;
        }   
    }

    void Update()
    {
        if(destroyCount == bricks.Length)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
