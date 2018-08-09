using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isdraging = false;
    private Vector2 startTouch, swipeDelta;

    private void Update()
    {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        #region Standalone Inputs
        if(Input.GetMouseButtonDown(0))
        {
            tap = true;
            isdraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isdraging = false;
            Reset();
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length >0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isdraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                {
                isdraging = false;
                Reset();
            }
        }
        #endregion

        // Calculate the distance
        swipeDelta = Vector2.zero;
        if (isdraging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        // Did we cross the deadzone
        if(SwipeDelta.magnitude > 150)
        {
            // Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            RaycastHit _hit;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                // Left or Right
                if (x < 0)
                {
                    swipeLeft = true;
                    if (Physics.Raycast(transform.position, -transform.right, out _hit, 1))
                    {
                        if(_hit.collider.gameObject.tag == "Wall")
                        {
                            //Debug.Log("I hit a wall when trying to go left");
                            swipeLeft = false;
                            return;
                        }
                    }
                }
                else
                {
                    swipeRight = true;
                    if (Physics.Raycast(transform.position, transform.right, out _hit, 1))
                    {
                        if (_hit.collider.gameObject.tag == "Wall")
                        {
                            //Debug.Log("I hit a wall when trying to go left");
                            swipeRight = false;
                            return;
                        }
                    }
                }

            }
            else
            {
                // Up or Down
                if (x < 0)
                {
                    swipeUp = true;
                    if (Physics.Raycast(transform.position, transform.forward, out _hit, 1))
                    {
                        if (_hit.collider.gameObject.tag == "Wall")
                        {
                            //Debug.Log("I hit a wall when trying to go left");
                            swipeUp = false;
                            return;
                        }
                    }
                }
                else
                {
                    swipeDown = true;
                    if (Physics.Raycast(transform.position, -transform.forward, out _hit, 1))
                    {
                        if (_hit.collider.gameObject.tag == "Wall")
                        {
                            //Debug.Log("I hit a wall when trying to go left");
                            swipeDown = false;
                            return;
                        }
                    }
                }
            }
                

            Reset();
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isdraging = false;
    }

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }

}