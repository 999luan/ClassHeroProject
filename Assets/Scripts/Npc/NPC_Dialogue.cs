using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{

    public float dialogueRange;
    public LayerMask playerLayer;

    public DialogSettings dialogue;

    bool playerHit;

    private List<string> sentences = new List<string>();
    private List<string> actorName = new List<string>();
    private List<Sprite> actorSprite = new List<Sprite>();


    void Start()
    {
        GetNpcTextTalk();
    }
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.E) && playerHit)
        {


            DialogControl.instance.Speech(sentences.ToArray(), actorName.ToArray(), actorSprite.ToArray());
        }
    }
    
    void GetNpcTextTalk()
    {
        for(int i = 0; i < dialogue.dialogues.Count; i++) 
        {
              switch(DialogControl.instance.language)
            {
                case DialogControl.idiom.pt:
                sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                break;
                 case DialogControl.idiom.eng:
                sentences.Add(dialogue.dialogues[i].sentence.whiteEnglish);
                break;
                 case DialogControl.idiom.fav:
                sentences.Add(dialogue.dialogues[i].sentence.blackEnglish);
                break;
            }
            actorName.Add(dialogue.dialogues[i].actorName);
            actorSprite.Add(dialogue.dialogues[i].profile);

            
        }
    }
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);
        if(hit != null)
        {
            playerHit = true;

        }else
        {
            playerHit = false;
            
        }
    }

    private void OnDrawGizmosSelected()
     {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);  
    }

}
