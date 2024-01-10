using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variable estática privada que contendrá la única instancia de la clase
    private static GameManager _instance;

    // Propiedad pública para acceder a la única instancia de la clase
    public static GameManager Instance
    {
        get
        {
            // Si la instancia es nula, busca un objeto del tipo GameManager en la escena
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            // Devuelve la instancia
            return _instance;
        }
    }

    // Método Awake para inicializar la instancia
    private void Awake()
    {
        // Si la instancia es nula, establece esta instancia como la única instancia
        if (_instance == null)
        {
            _instance = this;
        }
        // Si la instancia ya existe y no es esta, destruye este objeto
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        // No destruye este objeto cuando se carga una nueva escena
        DontDestroyOnLoad(gameObject);
    }

}
