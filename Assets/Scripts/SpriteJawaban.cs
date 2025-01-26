using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteJawaban : MonoBehaviour
{
    public GameManager gameManager;
    public int idxJawab;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Question question = gameManager.GetQuestion();

        if (question.isYapping)
        {
            //..
        }
        else
        {
            if (spriteRenderer)
            {
                spriteRenderer.sprite = question.listJawaban[idxJawab].sprite;
            }
            else
            {
                //..
            }
            /* if(question.listJawaban[idxJawab].sprite){
                if(spriteRenderer){
                    spriteRenderer.sprite = question.listJawaban[idxJawab].sprite;
                }else{
                    //..
                }
            }else{
                //..
            } */
        }
    }
}
