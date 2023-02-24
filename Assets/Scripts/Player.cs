using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Rigidbody rb;
    public float velocidad;
    public float tiempo;
    public GameObject Flashligth;
    public GameObject victoria;
    public GameObject Salida;
    public GameObject locks;
    public GameObject perdedor;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public float horizontalSpeed = 2.0F;
    public int puntaje;
    public Text info;


    void Update()
    {
        tiempo = Time.deltaTime;
        if (tiempo==0)
        {

        }
        else
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            Vector3 movmentX = new Vector3(inputX, 0, 0);
            Vector3 movmentY = new Vector3(0, 0, inputY);

            rb.transform.Translate(movmentX * velocidad * Time.deltaTime);
            rb.transform.Translate(movmentY * velocidad * Time.deltaTime);

            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            transform.Rotate(0, h, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))

        {
            velocidad *= 2;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))

        {
            velocidad /= 2;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Linterna"))
        {
            Destroy(collision.gameObject);
            Flashligth.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Llave"))
        {
            Destroy(collision.gameObject);
            puntaje++;
            info.text = ("Llaves: " + puntaje);
        }
        if (collision.gameObject.CompareTag("Locks") && puntaje == 3)
        {
            locks.SetActive(false);
            Salida.SetActive(true);
        }
        if (collision.gameObject.CompareTag("salida"))
        {
            victoria.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        if (collision.gameObject.CompareTag("Malo"))
        {
            perdedor.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}