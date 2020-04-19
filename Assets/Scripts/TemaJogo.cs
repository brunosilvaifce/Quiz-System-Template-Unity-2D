using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TemaJogo : MonoBehaviour
{
    public Button playButton;
    public Text temaTxt;

    public GameObject infoWindow;
    public Text infoLevelTxt;
    public GameObject star1, star2, star3;

    private int idModo;
    private int iTema;

    public string[] temasNome;
	// Use this for initialization
	void Start ()
    {
        idModo = PlayerPrefs.GetInt("idModo");
        temaTxt.text = temasNome[0];
        infoWindow.SetActive(false);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
    }
	
	public void selectTema(int idTema)
    {
        iTema = idTema;
        temaTxt.text = temasNome[idTema];
        infoWindow.SetActive(true);
        playButton.interactable = true;
        PlayerPrefs.SetInt("idTema", idTema);

        int notaF = PlayerPrefs.GetInt("notaF" + idModo.ToString() + idTema.ToString());
        int acertos = PlayerPrefs.GetInt("acertos" + idModo.ToString() + idTema.ToString());

        infoLevelTxt.text = "Você Acertou " + acertos.ToString() + " de 20 Questões";

        if (notaF == 10)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if(notaF >= 7)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }
        else if(notaF >= 5)
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }
    }

    public void jogar()
    {
        SceneManager.LoadScene("T" + iTema);
    }
}
