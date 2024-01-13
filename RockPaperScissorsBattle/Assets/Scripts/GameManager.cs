using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Instancia estática para el acceso global
    public static GameManager Instance { get; private set; }
    public List<GameObject> GameObjects { get => gameObjects; set => gameObjects = value; }
    public int Numberrock { get => numberrock; set => numberrock = value; }
    public int Numberpaper { get => numberpaper; set => numberpaper = value; }
    public int Numberscissors { get => numberscissors; set => numberscissors = value; }

    private void Awake()
    {
        // Comprueba si la instancia ya existe
        if (Instance == null)
        {
            // Si no, establece la instancia a esta
            Instance = this;
        }
        else if (Instance != this)
        {
            // Si la instancia ya existe y no es esta, destruye este objeto para mantener un Singleton
            Destroy(gameObject);
        }

        // No destruye este objeto cuando se recarga la escena
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField]
    private List<GameObject> gameObjects = new List<GameObject>();

    [SerializeField]
    private GameObject prefab;
    
    //[SerializeField]
    //private int numbergameobjects;

    [SerializeField]
    private int numberrock=1;
    [SerializeField]
    private int numberpaper=1;
    [SerializeField]
    private int numberscissors = 1;

    //private int tramo;
    //private int contador = 0;
    //private int type = 0;


    public void battle()
    {
        //INSTANCIAR OBJETOS A PARTES IGUALES
        /*
        tramo = numbergameobjects / 3;

        for (int i = 0; i < numbergameobjects; i++)
        {

            GameObjects[i]=Instantiate(prefab, new Vector3(Random.Range(-8.5f,8.5f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity);

            if (tramo>contador)
            {
                contador++;

            }else if (tramo == contador)
            {
                contador = 0;
                type++;
            }

            GameObjects[i].GetComponentInChildren<GameObjectProperties>().Type = type;

        }*/
        gameObjects = new List<GameObject>();

        bool spawnobject = false;

        for (int i = 0; i < Numberrock; i++)
        {
            GameObject go = null;
            foreach (GameObject obj in gameObjects)
            {
                Vector3 newposition = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-4.5f, 4.5f), 0);
                if (obj.transform.position != newposition) {
                    go = Instantiate(prefab, newposition, Quaternion.identity);
                    go.GetComponentInChildren<GameObjectProperties>().Type = 0;
                    spawnobject = true;
                    break;
                }
            }
            if (!spawnobject)
            {
                go = Instantiate(prefab, new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity);
                go.GetComponentInChildren<GameObjectProperties>().Type = 0;
                spawnobject = true;

            }
            
            gameObjects.Add(go);
        }
        for (int i = 0; i < Numberpaper; i++)
        {
            GameObject go = null;
            foreach (GameObject obj in gameObjects)
            {
                Vector3 newposition = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-4.5f, 4.5f), 0);
                if (obj.transform.position != newposition)
                {
                    go = Instantiate(prefab, newposition, Quaternion.identity);
                    go.GetComponentInChildren<GameObjectProperties>().Type = 1;
                    spawnobject = true;
                    break;
                }
            }
            if (!spawnobject)
            {
                go = Instantiate(prefab, new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity);
                go.GetComponentInChildren<GameObjectProperties>().Type = 1;
                spawnobject = true;

            }

            gameObjects.Add(go);
        }
        for (int i = 0; i < Numberscissors; i++)
        {
            GameObject go = null;
            foreach (GameObject obj in gameObjects)
            {
                Vector3 newposition = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-4.5f, 4.5f), 0);
                if (obj.transform.position != newposition)
                {
                    go = Instantiate(prefab, newposition, Quaternion.identity);
                    go.GetComponentInChildren<GameObjectProperties>().Type =2;
                    spawnobject = true;
                    break;
                }
            }
            if (!spawnobject)
            {
                go = Instantiate(prefab, new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity);
                go.GetComponentInChildren<GameObjectProperties>().Type = 2;
                spawnobject = true;

            }

            gameObjects.Add(go);
        }

    }

    /*GameObject go;
            go = Instantiate(prefab, new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity);
            go.GetComponentInChildren<GameObjectProperties>().Type = 2;
            gameObjects.Add(go);*/

}
