using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Переменная для поиска объектов по тегам.
    public string nameObject;

    // Переменная для выбора смены цветов.
    public bool ChangeTwo = false;

    // Переменная игрок. Приватная т.к. в Start() находится при помощи Tag. 
    private GameObject player;

    // Переменная список барьеров. Приватный т.к. в Start() находится при помощи nameObject.
    private GameObject[] listBarriers;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        listBarriers = GameObject.FindGameObjectsWithTag(nameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            if (ChangeTwo == false)
            {
                // Игрок окрашивает в выбраный объект
                player.GetComponent<Renderer>().material.color = 
                listBarriers[0].GetComponent<Renderer>().material.GetColor("_Color");
            }
            else 
            {
                // Запуска метода с обменом цветов
                both();
            }
        }
    }

    void both()
    {
        // Записываем цвет в который окрашен игрок в переменую colorPlayer
        Color colorPlayer = player.GetComponent<Renderer>().material.GetColor("_Color");

        // Игрок окрашивает в выбраный объект
        player.GetComponent<Renderer>().material.color = 
        listBarriers[0].GetComponent<Renderer>().material.GetColor("_Color");

        // В цикле перекрашиваем все выбраные объекты в цвет игрока
        foreach (GameObject Barriers in listBarriers)
        {
            Barriers.GetComponent<Renderer>().material.color = colorPlayer;
        }
    }
}
