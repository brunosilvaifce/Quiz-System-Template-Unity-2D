using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NavegacaoBasica : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        	
	}

    public void GoTo(string cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void jogarNovamente(string cena)
    {
        int idTema = PlayerPrefs.GetInt("idTema");
        SceneManager.LoadScene("T" + idTema.ToString());
    }
}
