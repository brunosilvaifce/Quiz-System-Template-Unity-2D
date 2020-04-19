using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class NotaFinal : MonoBehaviour
{
    public Text nota;
    public Text infoAcertos;
    public GameObject star1, star2, star3;
    private int idModo;
    private int idTema;


    // Use this for initialization
    void Start()
    {

        idModo = PlayerPrefs.GetInt("idModo");
        idTema = PlayerPrefs.GetInt("idTema");

        int notaF = PlayerPrefs.GetInt("notaFTemp" + idModo.ToString() + idTema.ToString());
        int acertos = PlayerPrefs.GetInt("acertosTemp" + idModo.ToString() + idTema.ToString());

        nota.text = notaF.ToString();

        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        infoAcertos.text = "Você Acertou " + acertos.ToString() + " de 3 Questões";

        if (notaF == 10)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if (notaF >= 7)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }
        else if (notaF >= 5)
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
