using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    private GameManager gameManager = GameManager.Instance;
    private List<GameObject> gameObjects = null;

    private bool compareType=false;
    private bool win=false;

    [SerializeField]
    private TMP_Text wintext;
    [SerializeField]
    private GameObject winobject;
    [SerializeField]
    private GameObject panelwin;

    void Start()
    {
        gameManager.battle();
        gameObjects = gameManager.GameObjects; 
    }

    private void Update()
    {
        if (!win)
        {
            GameObject go = new GameObject();
            go = gameObjects[0];
            foreach (var gameObject in gameObjects)
            {
                if (gameObject.GetComponentInChildren<GameObjectProperties>().Type == go.GetComponentInChildren<GameObjectProperties>().Type)
                {
                    compareType = true;
                }
                else
                {
                    compareType = false;
                    break;
                }
                go = gameObject;


            }
            if (compareType)
            {
                win = true;
                GameObject.Find("Escenario").SetActive(false);
                foreach (var gameObject in gameObjects)
                {
                    gameObject.SetActive(false);
                    
                }

                panelwin.SetActive(true);

                switch (go.GetComponentInChildren<GameObjectProperties>().Type)
                {
                    case 0:
                        winobject.GetComponentInChildren<GameObjectProperties>().Type = 0;
                        wintext.SetText("ROCK WIN");
                        break;
                    case 1:
                        wintext.SetText("PAPER WIN");
                        winobject.GetComponentInChildren<GameObjectProperties>().Type = 1;
                        break;
                    case 2:
                        wintext.SetText("SCISSORS WIN");
                        winobject.GetComponentInChildren<GameObjectProperties>().Type = 2;
                        break;
                    default: break;
                }
       

            }
        }
        
    }

    public void gomain()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
