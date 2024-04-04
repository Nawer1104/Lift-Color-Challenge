using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.Infrastructure.Utils.Swipe;

public class Controller : MonoBehaviour
{
    [SerializeField] private SwipeListener swipeListener;
    [SerializeField] private Elevator elevator;

    private void OnEnable()
    {
        swipeListener.OnSwipe.AddListener(OnSwipe);
    }

    private void OnSwipe(string swipe)
    {
        switch(swipe)
        {
            case "Left":

                break;
            case "Right":

                break;
            case "Up":

                if (elevator.transform.position.y >= 5.5f)
                {
                    return;
                }
                elevator.transform.position += new Vector3(0f, 1.5f, 0f);
                break;
            case "Down":

                if (elevator.transform.position.y <= -2f)
                {
                    return;
                }

                elevator.transform.position += new Vector3(0f, -1.5f, 0f); ;
                break;
        }
    }

    private void OnDisable()
    {
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }
}
