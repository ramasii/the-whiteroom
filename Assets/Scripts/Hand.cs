using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private Vector3 defPos;
    private Animator animator;

    void Awake()
    {
        defPos = transform.position;
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(worldPos.y > -1.6){
            transform.position = Vector3.Lerp(transform.position, defPos, Time.deltaTime * 5);
            Cursor.visible = true;
        }else{
            worldPos.z = 0;
            // transform.position = worldPos;
            transform.position = Vector3.Lerp(transform.position, worldPos, Time.deltaTime * 5);

            if(Input.GetMouseButtonDown(0)){
                animator.SetTrigger("Click");
            }

            Cursor.visible = false;
        }


    }
}
