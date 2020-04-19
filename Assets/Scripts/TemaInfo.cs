using UnityEngine;
using System.Collections;

public class TemaInfo : MonoBehaviour
{
    public GameObject star1, star2, star3;
    public int idTema;
    private int idModo;

	void Start ()
    {
        idModo = PlayerPrefs.GetInt("idModo");
        int notaF = PlayerPrefs.GetInt("notaF" + idModo.ToString() + idTema.ToString());

        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

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
	

}
