using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerCamera; // Посилання на камеру гравця
    public float speed = 5f; // Дробове значення швидкості
    public float mouseSens = 5f; // Чутливість миші

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



    }
}
