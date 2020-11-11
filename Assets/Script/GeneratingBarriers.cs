using UnityEngine;

public class GeneratingBarriers : MonoBehaviour
{
    /* 
     * Переменная дубликтов объектов по ширине.
     * Публичная, чтобы легче указывать кол-во по ширине.
     */
    public int cloneWidth;

    /* 
     * Переменная дубликтов объектов по высоте.
     * Публичная, чтобы легче указывать кол-во по высоте.
     */
    public int cloneHeight;

    // Переменная выбора создаваемых объектов.
    public int selectObj = 1;

    /* 
     * Переменная размеров по осям.
     * Публичная, чтобы легче указывать размеры объектов.
     */
    public float scaleX, scaleY, scaleZ;

    // Переменная цвета. Публичная, чтобы легче корректировать её.
    public Color color;

    // Переменная создаваемых объектов.
    private GameObject objects;

    // Переменная дубликтов создаваемых объектов.
    private GameObject cloneObj;

    // Перменная отступ.
    private const float Indent = 1.5f;

    // Переменная размеры по осям X, Z.
    private float copyScaleX, copyScaleZ;

    void Start()
    {
        choseObj();
        selectColor();
        setMassAndPosition();
        generation();
    }

    void setMassAndPosition()
    {
        // Устонавливаем дефольтные кординаты на которых стоит спавн объекта.
        objects.transform.position = new Vector3(
            transform.position.x, 
            transform.position.y, 
            transform.position.z);

        // Добовляем всем объектам нулевую массу.
        objects.AddComponent<Rigidbody>().mass = 0;
    }

    void selectColor()
    {
        // Указываем нужный цвет объектам.
        MeshRenderer renderer = objects.GetComponent<MeshRenderer>();
        renderer.material.SetColor("_Color", color);
    }

    void generation()
    {
        /* 
         * Не уверен на сколько это хороший способ клонирования объектов,
         * Однако другого я так и не смог придумать.
         */ 
        for (int i = 0; i < cloneHeight; i++)
        {
            for (int j = 0; j < cloneWidth; j++)
            {
                // Пропускаем первую этерацию циклов, чтобы убрать два лишних объекта.
                if (i == 0 && j == 0)
                {
                    continue;
                }

                // Создаем копии объектов и передаем все их свойтсва в cloneObj.
                cloneObj = Instantiate(objects, objects.transform.position, Quaternion.identity);

                // Записываем размеры клонированых объектов в отдельные переменые.
                copyScaleX = cloneObj.transform.localScale.x;
                copyScaleZ = cloneObj.transform.localScale.z;

                /* 
                 * И тут самое сложное как по мне.
                 * На основе позиции объектов, их размеров и колчиства по,
                 */
                /// <param name="cloneHeight"></param>
                /// <param name="cloneWidth"></param>
                /* 
                 * Производится рассчет того на сколько нужно отступить кол-во векторов,
                 * Чтобы объекты не соприкосались с друг с другом.
                 */
                cloneObj.transform.position = new Vector3(
                    transform.position.x + j * (copyScaleX * Indent), 1.0f, 
                    transform.position.z + i * (copyScaleZ * Indent));
            }
        }
    }

    void choseObj()
    {
        // Взависимости от числа создается объект с указаным размером и тегом.
        /// Если в переменной <param name="scaleX, scaleY, scaleZ"></param>,
        /// не указать размеры, то игра запуститься с лагам.

        switch (selectObj)
        {
            case 1:
                objects = GameObject.CreatePrimitive(PrimitiveType.Cube);
                objects.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
                objects.transform.gameObject.tag = "Wall";
                break;

            case 2:
                objects = GameObject.CreatePrimitive(PrimitiveType.Cube);
                objects.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
                objects.transform.gameObject.tag = "Cube";
                break;

            case 3:
                objects = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                objects.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
                objects.transform.gameObject.tag = "Sphere";
                break;

            case 4:
                objects = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                objects.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
                objects.transform.gameObject.tag = "Cylinder";
                break;

            default:
                Debug.Log("Других объектов нет");
                break;
        }
    }
}
