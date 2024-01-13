using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject target=null;

    [SerializeField]
    private bool target_acquired;

    private GameManager gameManager = GameManager.Instance;

    private List<GameObject> gameObjects = null;

    public bool Target_acquired { get => target_acquired; set => target_acquired = value; }
    public GameObject Target { get => target; set => target = value; }

    private void Start()
    {
        gameObjects = gameManager.GameObjects;
    }

    private void Update()
    {
        if (Target_acquired)
        {
            if (this.CompareTag("rock") && !target.gameObject.CompareTag("scissors"))
            {
                
                this.GetComponentInChildren<GameObjectMovement>().Target_acquired = false;
                this.GetComponentInChildren<GameObjectMovement>().Target = null;

            }
            else if (this.CompareTag("paper") && !target.gameObject.CompareTag("rock"))
            {
                
                this.GetComponentInChildren<GameObjectMovement>().Target_acquired = false;
                this.GetComponentInChildren<GameObjectMovement>().Target = null;
            }
            else if (this.CompareTag("scissors") && !target.gameObject.CompareTag("paper"))
            {
                
                this.GetComponentInChildren<GameObjectMovement>().Target_acquired = false;
                this.GetComponentInChildren<GameObjectMovement>().Target = null;

            }
            else
            {

                transform.position = Vector2.Lerp(this.transform.position, Target.transform.position, 0.8f*Time.deltaTime);
            }

        }
        else
        {
            acquired_target();
        }
        
    }

    private void acquired_target()
    {
        double distancia=100;
        double distancia2 = 0;
        foreach (GameObject obj in gameObjects)
        {
            if (!obj.Equals(this)) {
                if (this.CompareTag("rock") && obj.CompareTag("scissors"))
                {
                    distancia2 = Mathf.Sqrt(Mathf.Pow((this.transform.position.x - obj.transform.position.x), 2) + Mathf.Pow((this.transform.position.y - obj.transform.position.y), 2));
                    if (distancia>distancia2)
                    {
                        distancia = distancia2;
                        target = obj;
                        target_acquired = true;

                    }
                 

                }
                else if (this.CompareTag("paper") && obj.CompareTag("rock"))
                {
                    distancia2 = Mathf.Sqrt(Mathf.Pow((this.transform.position.x - obj.transform.position.x), 2) + Mathf.Pow((this.transform.position.y - obj.transform.position.y), 2));
                    if (distancia > distancia2)
                    {
                        distancia = distancia2;
                        target = obj;
                    }


                }
                else if (this.CompareTag("scissors") && obj.CompareTag("paper"))
                {
                    distancia2 = Mathf.Sqrt(Mathf.Pow((this.transform.position.x - obj.transform.position.x), 2) + Mathf.Pow((this.transform.position.y - obj.transform.position.y), 2));
                    if (distancia > distancia2)
                    {
                        distancia = distancia2;
                        target = obj;
                    }
                 

                }
            }
        }

        if (Target !=null)
        {
            target_acquired = true;
        }
        else
        {
            target_acquired = false;
        }
        
    }

}
