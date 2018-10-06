using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    public bool EditorDebug = true;
    private bool Enabled = true;

    public void SetInputHandler(bool acceptInput)
    {
        Enabled = acceptInput;
    }

    public void DeselectAllObjects()
    {
        //foreach (var selectable in FindObjectsOfType<Touchable>())
        //    selectable.OnDeselected.Invoke();
    }

    public void DebugMessage(string message)
    {
        Debug.Log(message);
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && Enabled)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 500))
                {
                    var touchable = hit.collider.gameObject.GetComponent<Touchable>();

                    if (touchable != null)
                    {
                        if (EditorDebug)
                            Debug.Log("HIT : " + hit.collider.gameObject.name);

                        touchable.OnClick();
                    }
                }
            }

        }
#elif UNITY_ANDROID

            if (Input.touchCount > 0)
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Began)
                    {
                        Ray ray = GameCamera.ScreenPointToRay(touch.position);
                        RaycastHit hit = new RaycastHit();

                        if (Physics.Raycast(ray, out hit, 1000.0f))
                        {
                            var touchComponent = hit.collider.gameObject.GetComponent<TouchBehaviour>();

                            if (touchComponent != null)
                            {
                                touchComponent.Click();
                            }
                        }
                    }
                }
            }
#endif
    }
}
