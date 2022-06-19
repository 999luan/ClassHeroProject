using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom{
        pt,
        eng,
        fav

    }
    public idiom language;

    [Header("Components")]
    public GameObject dialogObj; // janela do dialogo
    public  Image profileSprite; //sprite do perfil
    public Text speechText; //texto da fala
    public Text actorNameText; //nome do npc
    
    [Header("Settings")]
    public float typingSpeed; //velocidade da fala

    //variaveis de controle

    public bool isShowing; //se a janela de chat ta ativa
    private int index; //indice das sentenças
    private string[] sentences;
    private string[] currentActorName;

    private Sprite[] actorSprite;


    public static DialogControl instance;

   

//awake ´pe chamado antes de todos os Start() na ordem de execucao
    private void Awake() 
    {
        instance = this;
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    //proxima fala
    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else //fim do dialogo
            {
                speechText.text = "";
                actorNameText.text = "";
                index = 0;
                dialogObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }

    }
    //chamar o dialogo
    public void Speech(string[] txt, string[] actorName, Sprite[] actorProfile)
    {
        if(!isShowing)
        {
            dialogObj.SetActive(true);
            sentences = txt;
            currentActorName = actorName;
            actorSprite = actorProfile;
            profileSprite.sprite = actorSprite[index];
            actorNameText.text = currentActorName[index];
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
