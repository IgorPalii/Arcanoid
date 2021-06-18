using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    private int brickHealth;
    private Color brickColor;
    private SpriteRenderer srend;

    private void Start()
    {
        brickHealth = (int)Random.Range(1f, 3.9f);
        srend = GetComponent<SpriteRenderer>();
        SetColor();
    }

    private void SetColor()
    {
        switch (brickHealth)
        {
            case 3:
                brickColor = Color.red;
                break;
            case 2:
                brickColor = Color.magenta;
                break;
            case 1:
                brickColor = Color.cyan;
                break;
            case 0:
                Destroy(gameObject);
                GameController.destroyCount++;
                break;
            default:
                break;
        }
        srend.color = brickColor;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            brickHealth -= 1;
            SetColor();
        }
    }
}
