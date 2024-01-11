using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.CompareTag("rock") && collision.gameObject.CompareTag("scissors"))
        {
            collision.gameObject.GetComponentInChildren<GameObjectProperties>().Type = 0;
            this.GetComponentInChildren<GameObjectMovement>().Target_acquired = false;
            this.GetComponentInChildren<GameObjectMovement>().Target = null;

        }
        else if (this.CompareTag("paper") && collision.gameObject.CompareTag("rock"))
        {
            collision.gameObject.GetComponentInChildren<GameObjectProperties>().Type = 1;
            this.GetComponentInChildren<GameObjectMovement>().Target_acquired = false;
            this.GetComponentInChildren<GameObjectMovement>().Target = null;
        }
        else if (this.CompareTag("scissors") && collision.gameObject.CompareTag("paper"))
        {
            collision.gameObject.GetComponentInChildren<GameObjectProperties>().Type = 2;
            this.GetComponentInChildren<GameObjectMovement>().Target_acquired = false;
            this.GetComponentInChildren<GameObjectMovement>().Target = null;

        }
    }
}
