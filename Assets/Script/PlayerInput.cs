using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Переменная скорости. Публичная, чтобы легче корректировать её 
    public float speed = 5.0f;

    // Переменная цвета. Публичная, по той же причине.
    public Color color;

    // Переменная для поправки разрешение экрана под android
    private const float pixelFix = 2.0f;

    // Переменная в которой записывается разрешение экрана по оси X
    private float width;

    // Переменная для записи инфо об позиции при нажатии на сенсор телефона
    private Vector3 touchStartPosition;

    void Awake()
    {
        width = Screen.width / pixelFix;
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
        float halfSpeed = 2.0f;

        /// <param name="pos">Используется для обработки кординат на сенсоре по оси X.</param>
        Vector3 pos = Vector3.zero;

        /// <param name="totalSpeed">Используется для передачи ускорения или замедления скорости объекта по оси Y.</param>
        float totalSpeed = speed / halfSpeed;

        if (Input.touchCount > 0)
        {
            /// <param name="touch">Используется для определения позиции пальца на оси кординат.</param>
            Touch touch = Input.GetTouch(0);
            pos = touch.position;

            // Понижение скорости
            float reducedSpeed = 0.5f;

            // Повышение скорости
            float increaseSpeed = 2.0f;

            // Проверка смещение кординат по оси Y
            int targetAxis = 50;

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (touchStartPosition.y - touch.position.y > targetAxis)
                {
                    totalSpeed *= reducedSpeed;
                }
                else if (touchStartPosition.y - touch.position.y < -targetAxis)
                {
                    totalSpeed *= increaseSpeed;
                }
            }

            /* Рассчитываем и устраняем погрешности по разрешению экрана, а так же 
             * придаём объекту скорости и (так как я не имею опыта в оптимизации на телефонах) 
             * умножаем на Time.fixedDeltaTime*/ 
            pos.x = (pos.x - width) / width * speed * Time.fixedDeltaTime;
        }

        transform.Translate(new Vector3(pos.x, 0.0f, totalSpeed * Time.fixedDeltaTime));
    }
}
