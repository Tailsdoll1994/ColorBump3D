using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    // Переменная бездна. Публичная, чтобы легче корректировать её.
    public const float abyss = -15.0f;

    // Переменная игрок. Приватная т.к. в Start() находится при помощи Tag. 
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        DeadZone_Abyss();
    }
    private void DeadZone_Abyss()
    {
        if (player.transform.position.y < abyss)
        {
            SceneManager.LoadScene("Level");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        /* После сравнения объектов через тэги, идёт проверка цветов. 
         * Если цвета не совпадают у двух объектов, уровень загружается занаво.*/
        if (comparisonTags(collision))
        {
            if (!collision.transform.GetComponent<Renderer>().material.color.Equals
                (player.transform.GetComponent<Renderer>().material.color))
            {
                SceneManager.LoadScene("Level");
            }
        }
    }
    // Все объекты с которым игрок может столкнуться
    bool comparisonTags(Collision collision)
    {
        return collision.gameObject.tag == "Cube" ||
               collision.gameObject.tag == "Sphere" ||
               collision.gameObject.tag == "Cylinder" ||
               collision.gameObject.tag == "Wall";
    }
}
