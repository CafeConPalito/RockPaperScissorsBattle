using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //PATRON SINGLETON
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
       
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
          
            return _instance;
        }
    }
   
    private void Awake()
    {
       
        if (_instance == null)
        {
            _instance = this;
        }
        
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

       
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField]
    private GameObject[] gameObjects = null;

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private int numbergameobjects;

    private int tramo;
    private int contador = 0;
    private int type = 0;

    private void Start()
    {
        gameObjects = new GameObject[numbergameobjects];
        tramo = numbergameobjects / 3;

        for (int i = 0; i < numbergameobjects; i++)
        {

            gameObjects[i]=Instantiate(prefab, new Vector3(Random.Range(-8.0f,4.9f), Random.Range(-4.0f, 4.9f), 0), Quaternion.identity);

            if (tramo>contador)
            {
                contador++;

            }else if (tramo == contador)
            {
                contador = 0;
                type++;
            }

            gameObjects[i].GetComponentInChildren<GameObjectProperties>().Type = type;

        }
    }

}
