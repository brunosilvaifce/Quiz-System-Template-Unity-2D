using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Responder : MonoBehaviour
{
    public Text pergunta;
    public Text infoModo;
    public Text respostaA;
    public Text respostaB;
    public Text respostaC;
    public Text respostaD;
    public Text infoResposta;

    public GameObject barraTempo;
    public int idModo, idTema;

    public string[] modoJogo;
    public float tempTime;
    public float duracao;

    public string[] perguntas;
    public string[] respostasA;
    public string[] respostasB;
    public string[] respostasC;
    public string[] respostasD;
    public string[] corretas;

    private int idPergunta;

    private float acertos, media;
    private float questoes;

    // Use this for initialization
    void Start ()
    {
        barraTempo.SetActive(false);
        idModo = PlayerPrefs.GetInt("idModo");
        idTema = PlayerPrefs.GetInt("idTema");
        idPergunta = 0;

        questoes = perguntas.Length;

        infoModo.text = modoJogo[idModo];

        pergunta.text = perguntas[idPergunta];
        respostaA.text = respostasA[idPergunta];
        respostaB.text = respostasB[idPergunta];
        respostaC.text = respostasC[idPergunta];
        respostaD.text = respostasD[idPergunta];

        infoResposta.text = "Respondendo " + (idPergunta + 1) + " de " + questoes.ToString() + " Questões.";

        switch(idModo)
        {
            case 1:
                barraTempo.SetActive(false);
                duracao = 0;
                break;
            case 2:
                barraTempo.SetActive(true);
                duracao = 10;
                break;
            case 3:
                barraTempo.SetActive(true);
                duracao = 3;
                break;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(duracao > 0)
        {
            tempTime += Time.deltaTime;

            float percentual = (tempTime / duracao) * 70;
            float tamanhoBarra = 70 - percentual;

            if(tamanhoBarra < 0)
            {
                tamanhoBarra = 0;
            }

            barraTempo.transform.localScale = new Vector3(tamanhoBarra, 70, 70);

            if(tempTime >= duracao)
            {
                proxima();
            }
        }
	}

    public void resposta(string alternativa)
    {
        switch(alternativa)
        {
            case "A" :
                if (respostasA[idPergunta] == corretas[idPergunta])
                {
                    acertos += 1;
                }
                break;

            case "B":
                if (respostasB[idPergunta] == corretas[idPergunta])
                {
                    acertos += 1;
                }
                break;

            case "C":
                if (respostasC[idPergunta] == corretas[idPergunta])
                {
                    acertos += 1;
                }
                break;

            case "D":
                if (respostasD[idPergunta] == corretas[idPergunta])
                {
                    acertos += 1;
                }
                break;
        }
        proxima();
    }

    public void proxima()
    {
        tempTime = 0;
        idPergunta += 1;

        if(idPergunta <= (questoes - 1))
        {
            pergunta.text = perguntas[idPergunta];
            respostaA.text = respostasA[idPergunta];
            respostaB.text = respostasB[idPergunta];
            respostaC.text = respostasC[idPergunta];
            respostaD.text = respostasD[idPergunta];

            infoResposta.text = "Respondendo " + (idPergunta + 1) + " de " + questoes.ToString() + " Questões.";
        }
        else ///caso tenha terminado as perguntas
        {
            float media = 10 * (acertos / questoes);
            int notaF = Mathf.RoundToInt(media);

            if (notaF > PlayerPrefs.GetInt("notaF" + idModo.ToString() + idTema.ToString()))
            {
                PlayerPrefs.SetInt("notaF" + idModo.ToString() + idTema.ToString(), notaF);
            }

            PlayerPrefs.SetInt("notaFTemp" + idModo.ToString() + idTema.ToString(), notaF);

            if (acertos > PlayerPrefs.GetInt("acertos" + idModo.ToString() + idTema.ToString()))
            {
                PlayerPrefs.SetInt("acertos" + idModo.ToString() + idTema.ToString(), (int)acertos);
            }

            PlayerPrefs.SetInt("acertosTemp" + idModo.ToString() + idTema.ToString(), (int)acertos);

            SceneManager.LoadScene("NotaFinal");
        }
    }

}
