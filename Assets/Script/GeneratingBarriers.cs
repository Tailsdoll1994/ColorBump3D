using UnityEngine;

public class GeneratingBarriers : MonoBehaviour
{
    public int cloneWidth;
    public int cloneHeight;
    public int choseObj = 1;
    public Color color;

    private GameObject objects;
    private GameObject cloneObj;
    private float x, z;
    void Start()
    {
        // В самом начале создаются объекты которые нужно выбрать в inspector'e, при помощи числа.
        // Можно указать количество по ширине и высоте дороги, а так же цвет всех объектов на указаном спавне

        if (choseObj == 1)
        {
            objects = GameObject.CreatePrimitive(PrimitiveType.Cube);
            objects.transform.localScale = new Vector3(20.0f, 4.0f, 2.0f);
            objects.transform.gameObject.tag = "Wall";
        }
        else if (choseObj == 2)
        {
            objects = GameObject.CreatePrimitive(PrimitiveType.Cube);
            objects.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            objects.transform.gameObject.tag = "Cube";
        }
        else if (choseObj == 3)
        {
            objects = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            objects.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
            objects.transform.gameObject.tag = "Sphere";
        }
        else if (choseObj == 4)
        {
            objects = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            objects.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
            objects.transform.gameObject.tag = "Cylinder";
        }
        else
        {
            Debug.Log("Других объектов нет");
        }
        LayerMask mask = LayerMask.NameToLayer("Barriers");
        objects.transform.gameObject.layer = mask;
        objects.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        MeshRenderer renderer = objects.GetComponent<MeshRenderer>();
        renderer.material.SetColor("_Color", color);
        objects.AddComponent<Rigidbody>().mass = 0;
        for (int i = 0; i < cloneHeight; i++)
        {
            for (int j = 0; j < cloneWidth; j++)
            {
                if (i == 0 && j == 0)
                {
                    continue;
                }
                cloneObj = Instantiate(objects, objects.transform.position, Quaternion.identity);
                x = cloneObj.transform.localScale.x;
                z = cloneObj.transform.localScale.z;
                cloneObj.transform.position = new Vector3(transform.position.x + j * (x * 1.5f), 1.0f, transform.position.z + i * (z * 1.5f));
            }
        }
    }
}
