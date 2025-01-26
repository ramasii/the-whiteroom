using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelText : MonoBehaviour
{

    public GameManager gameManager;
    public GameObject triangle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Touch();

        Question question = gameManager.GetQuestion();

        if(question.isYapping){
            setTriangleActive(true);
        }else{
            if(question.isAnwered){
                setTriangleActive(true);
            }else{
                setTriangleActive(false);
            }
        }
    }

    void Action(){
        Debug.Log("Sprite panel ditekan!");
        
        Question question = gameManager.GetQuestion();

        if(question.isYapping){
            gameManager.NextDialog();
        }else{
            if(question.isAnwered){
                gameManager.NextDialog();
            }else{
                Debug.Log("jawab dulu pertanyaannya");
            }
        }
    }

    void Touch(){
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    Action();
                }
            }
        }
    }

    void setTriangleActive(bool b){
        if(triangle){
            triangle.SetActive(b);
        }else{
            Debug.Log("triangle tidak ada");
        }
    }

    void OnMouseDown()
    {
        Debug.Log("klik panel text");
        Action();
    }
}
