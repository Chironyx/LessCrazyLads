using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] VarStorge varStorge;
    [SerializeField] GameObject player;
    [SerializeField] private float bounds;
    [SerializeField] private float distance;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                if(-bounds <= distance && touch.deltaPosition.x < 0)
                {
                    distance += touch.deltaPosition.x * Time.deltaTime;
                    player.transform.position += transform.TransformDirection(touch.deltaPosition.x * Time.deltaTime * varStorge.playerSpeed, 0, 0);
                }
                else if (bounds >= distance && touch.deltaPosition.x > 0)
                {
                    distance += touch.deltaPosition.x * Time.deltaTime;
                    player.transform.position += transform.TransformDirection(touch.deltaPosition.x * Time.deltaTime, 0, 0);
                }

            } 


        }

    }
}

