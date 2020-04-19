using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModoJogo : MonoBehaviour
{
    public Text modoJogoTxt;
    public Button playButton;
    public string[] modosDeJogo;

	// Use this for initialization
	void Start ()
    {
        playButton.interactable = false;
        modoJogoTxt.text = modosDeJogo[0];
	}
	
    public void selectModo(int idModo)
    {
        modoJogoTxt.text = modosDeJogo[idModo];
        playButton.interactable = true;
        PlayerPrefs.SetInt("idModo", idModo);
    }

}
