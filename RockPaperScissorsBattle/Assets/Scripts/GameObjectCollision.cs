using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectCollision : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (this.CompareTag("rock") && collision.gameObject.CompareTag("scissors"))
        {
            collision.gameObject.GetComponentInChildren<GameObjectProperties>().Type = 0;
        }
        else if (this.CompareTag("paper") && collision.gameObject.CompareTag("rock"))
        {
            collision.gameObject.GetComponentInChildren<GameObjectProperties>().Type = 1;
        }
        else if (this.CompareTag("scissors") && collision.gameObject.CompareTag("paper"))
        {
            collision.gameObject.GetComponentInChildren<GameObjectProperties>().Type = 2;

        }
    }
}
