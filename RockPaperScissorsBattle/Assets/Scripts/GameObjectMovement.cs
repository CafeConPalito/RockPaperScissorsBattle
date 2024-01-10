using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    private bool target_acquired;

    private void Update()
    {
        transform.position=Vector2.Lerp(this.transform.position, target.transform.position, Time.deltaTime);
    }
}
