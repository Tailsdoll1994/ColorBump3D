using UnityEngine;

public class CamPlayer : MonoBehaviour
{
    public Vector3 vector;
    private GameObject target;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        // Камера следит за объектом только с тегом "Player".
        // Растояние камеры можно отрегулировать в inspector

        transform.position = new Vector3(transform.position.x, target.transform.position.y + vector.y, target.transform.position.z - vector.z);
    }
}
