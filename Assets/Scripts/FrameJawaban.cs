using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameJawab : MonoBehaviour
{
    public GameManager gameManager;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Question question = gameManager.GetQuestion();

        if(gameManager.isEnding == false){
            if(question.isYapping){
                animator.SetBool("Show", false);
            }else{
                if(question.isAnwered){
                    animator.SetBool("Show", false);
                }else{
                    animator.SetBool("Show", true);
                }
            }
        }else{
            animator.SetBool("Show", false);
        }
    }
}
