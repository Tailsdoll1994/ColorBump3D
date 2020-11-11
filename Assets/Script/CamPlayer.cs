using UnityEngine;

public class CamPlayer : MonoBehaviour
{
    // Переменная кординат камеры. Публичная, чтобы легче корректировать её.
    public Vector3 vector;

    // Переменная игрок. Приватная т.к. в Start() находится при помощи Tag. 
    private GameObject target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = new Vector3(
            transform.position.x, 
            target.transform.position.y + vector.y, 
            target.transform.position.z - vector.z);
    }
}
