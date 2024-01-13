using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectorScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text rockText;
    [SerializeField]
    private TMP_Text paperText;
    [SerializeField]
    private TMP_Text scissorsText;

    private GameManager gameManager = GameManager.Instance;

    public void changeRock()
    {
       rockText.SetText(GameObject.Find("SRock").GetComponent<Slider>().value.ToString());
    }
    public void changePaper()
    {
        paperText.SetText(GameObject.Find("SPaper").GetComponent<Slider>().value.ToString());
    }
    public void changeScissors()
    {
        scissorsText.SetText(GameObject.Find("SScissors").GetComponent<Slider>().value.ToString());
    }

    public void tobattle()
    {
        gameManager.Numberrock = (int) GameObject.Find("SRock").GetComponent<Slider>().value;
        gameManager.Numberpaper = (int)GameObject.Find("SPaper").GetComponent<Slider>().value;
        gameManager.Numberscissors =(int) GameObject.Find("SScissors").GetComponent<Slider>().value;
        SceneManager.LoadScene("Battle");
    }
}
