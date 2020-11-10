using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    public float speed = 5.0f;
    public Color color;

    private float width;
    private Vector3 touchStartPosition;
    void Awake()
    {
        width = Screen.width / 2.0f;
    }
    void Start()
    {
        transform.GetComponent<Renderer>().material.SetColor("_Color", color);
    }
    void Update()
    {
        MoveInput();
    }
    private void MoveInput()
    {
        // Управлеятся приблизительно так же как и в "color bump 3D".
        // Управляется одним пальцем, свайпами влево, вправо, а так же шарик ускоряется свайпами верх, вниз.
        // Скорость можно отрегулировать в inspector

        Vector3 pos = Vector3.zero;
        float totalSpeed = speed / 2;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            pos = touch.position;
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (touchStartPosition.y - touch.position.y > 50)
                {
                    totalSpeed *= 0.5f;
                }
                else if (touchStartPosition.y - touch.position.y < -50)
                {
                    totalSpeed *= 2f;
                }
            }
            pos.x = (pos.x - width) / width * speed * Time.fixedDeltaTime;
        }
        transform.Translate(new Vector3(pos.x, 0.0f, totalSpeed * Time.fixedDeltaTime));
    }
}
