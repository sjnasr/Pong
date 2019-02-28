using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;


    float height;

    string input;
    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
    }

    public void Init(bool isRightPaddle)
    {

        isRight = isRightPaddle;

        Vector2 pos = Vector2.zero;

        if(isRightPaddle)
        {
            //place paddle on right side
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x; //Move a bit to the left

            input = "PaddleRight";
        }
        else
        {
            //place paddle on left side
            pos = new Vector2(GameManager.bottomleft.x, 0);
            pos += Vector2.right * transform.localScale.x; //Move a bit to the right

            input = "PaddleLeft";
        }

        //Update this paddle's position
        transform.position = pos;

        transform.name = input;
    }

    // Update is called once per frame
    void Update()
    {
        //lets move the paddle
        //GetAxis is a number between -1 to 1 
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        //Restrict movement
        //If paddle is too low and user is continuing moving down, stop
        if (transform.position.y < GameManager.bottomleft.y + height / 2 && move < 0)
        {
            move = 0;
        }

        //If paddle is too high and user is continuing moving up, stop
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }

        transform.Translate(move * Vector2.up);
    }
}
