using UnityEngine;

namespace _1_2_3D.Scripts.GameController.SwipeController
{
    public class SwipeController : MonoBehaviour
    {
        public static bool tap, swipeLeft, swipeRight, swipeUp;
        private bool isDraging = false;
        private Vector2 startTouch, swipeDelta;

        private void Update()
        {
            tap = swipeUp = swipeLeft = swipeRight = false;
            #region PC version
            if (Input.GetMouseButtonDown(0))
            {
                tap = true;
                isDraging = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isDraging = false;
                ResetSwipe();
            }
            #endregion

            #region Mobile version
            if (Input.touchCount > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    tap = true;
                    isDraging = true;
                    startTouch = Input.touches[0].position;
                }
                else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                {
                    isDraging = false;
                    ResetSwipe();
                }
            }
            #endregion

            //Просчитать дистанцию
            swipeDelta = Vector2.zero;
            if (isDraging)
            {
                if (Input.touches.Length < 0)
                    swipeDelta = Input.touches[0].position - startTouch;
                else if (Input.GetMouseButton(0))
                    swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }

            //Проверка на пройденность расстояния
            if (swipeDelta.magnitude > 100)
            {
                //Определение направления
                float x = swipeDelta.x;
                float y = swipeDelta.y;
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {

                    if (x < 0)
                        swipeLeft = true;
                    else
                        swipeRight = true;
                }
                else
                {

                    if (y > 0)
                        swipeUp = true;
                }

                ResetSwipe();
            }

        }

        private void ResetSwipe()
        {
            startTouch = swipeDelta = Vector2.zero;
            isDraging = false;
        }

    }
}

