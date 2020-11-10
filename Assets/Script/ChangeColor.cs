using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public string nameObject;
    private GameObject player;
    public bool swapOne = false;
    public bool swapTwo = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerEnter(Collider collider)
    {
        // Чтобы скрипт работал, нужно зайти в inspector и указать в поле nameObject tag объекта с которым нужно будет поменяться цветом
        // Всего этих тега три, это "Cube", "Sphere", "Cylinder".
        // Так же можно выбрать способ изменения цвета. 
        // swapOne игрок перекрашваитеся в цвет nameObject
        // swapTwo игрок и nameObject меняются цветами

        if (collider.gameObject.name == "Player" && swapOne == true && swapTwo == false)
        {
            GameObject[] listBarriers = GameObject.FindGameObjectsWithTag(nameObject);
            player.GetComponent<Renderer>().material.color = listBarriers[0].GetComponent<Renderer>().material.GetColor("_Color");
        }
        else if (collider.gameObject.name == "Player" && swapTwo == true && swapOne == false)
        {
            GameObject[] listBarriers = GameObject.FindGameObjectsWithTag(nameObject);
            Color colorPlayer = player.GetComponent<Renderer>().material.GetColor("_Color");
            player.GetComponent<Renderer>().material.color = listBarriers[0].GetComponent<Renderer>().material.GetColor("_Color");
            foreach (GameObject Barriers in listBarriers)
            {
                Barriers.GetComponent<Renderer>().material.color = colorPlayer;
            }
        }
    }

}
