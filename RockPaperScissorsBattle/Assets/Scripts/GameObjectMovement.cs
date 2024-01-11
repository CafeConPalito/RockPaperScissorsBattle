using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject target=null;

    [SerializeField]
    private bool target_acquired;

    private void Update()
    {
        if (target_acquired)
        {
            transform.position = Vector2.Lerp(this.transform.position, target.transform.position, Time.deltaTime);
        }
        
    }
}
