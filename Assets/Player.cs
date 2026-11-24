using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerCamera; // Посилання на камеру гравця
    public float speed = 5f; // Дробове значення швидкості
    public float mouseSens = 5f; // Чутливість миші
    public Vector3 cameraPos; // Положення камери

    Rigidbody rb; // Посилання на фізичний компонент
    float yaw, pitch; // Горизонтальна та вертикальна вісі обертання камери

    private void Start() // Виконує код всередині 1 раз, при активації об'єкта
    {
        rb = GetComponent<Rigidbody>(); // Пошук і прив'язка компонанта
    }
    private void Update()
    {
        // Читаємо рух з WASD і рух миші
        float horizontal = Input.GetAxis("Horizontal"); // рух ліво/право
        float vertical = Input.GetAxis("Vertical"); // рух вперед/назад
        float horizontal_M = Input.GetAxis("Mouse X"); // оберт ліво/право
        float vertical_M = Input.GetAxis("Mouse Y"); // оберт вгору/вниз

        // Обчислюємо напрямок погляду

        // Горизонтальний кут + горизонтальне обертання * чутливість миші
        yaw += horizontal_M * mouseSens;
        // Те саме, що вгорі, але вертикально і з обмеженням
        pitch = Mathf.Clamp(pitch - vertical_M * mouseSens, -85f, 85f);

        // Рух у напрямку горизонтального повороту камери

        // В move зберігаємо вектор утворений з напрямку зору та напрямку руху
        Vector3 move = Quaternion.Euler(0, yaw, 0) * new Vector3(horizontal, 0, vertical);
        // Рухає персонажа, використовуючи вектор помножений на швидкість. Рухає в світових координатах
        transform.Translate(move * speed * Time.deltaTime, Space.World);

        // Слідкування камери за гравцем
        playerCamera.transform.position = new Vector3( // Зміна положення камери
            transform.position.x + cameraPos.x, // Положення гравця по X + модифікатор вісі X
            transform.position.y + cameraPos.y, // Положення гравця по Y + модифікатор вісі Y
            transform.position.z + cameraPos.z); // Положення гравця по Z + модифікатор вісі Z

        // Застосовуємо обертання камери мишею
        playerCamera.transform.rotation = Quaternion.Euler(pitch, yaw, 0);
    }
}
