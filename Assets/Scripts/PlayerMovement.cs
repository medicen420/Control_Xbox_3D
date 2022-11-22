using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variable que almacena la velocidad en la que se moverá el personaje
    public float speed;
    //Variable que almacena la velocidad de rotación
    public float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //CÓDIGO PARA MOVER AL PERSONAJE CON EL JOYSTICK IZQUIERDO DEL CONTROL DE XBOX ONE
        //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");



        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        //*********************************************************************************






        //CÓDIGO PARA QUE EL PERSONAJE ROTE EN LA DIRECCIÓN EN LA QUE SE ESTÁ MOVIENDO
        //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

        //Verificaremos si el personaje se está moviendo
        //Para ello verificaremos que la dirección del movimiento no sea cero


        //Si el personaje se está moviendo queremos que el personaje gire
        //para mirar en la dirección en la que se está moviendo
        if (movementDirection != Vector3.zero)
        {
            //Para hacer esto estableceremos trasnform.forward a el movementDirection
            //transform.forward = movementDirection;

            //↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
            //Prácticamente con esté simple código podemos hacer que la rotación sea instantánea
            //aún que está se siente un poco antinatural

            //Podemos hacer que el movimiento de rotación sea mucho más suave al hacer que el personaje
            //gire en la dirección deseada durante un período de tiempo.

            //Así que está línea la dejaremos como comentario
            //*****************************************************************************************


            //Estableceremos la dirección de avance que queremos que el personaje gire
            //hacia la dirección del movimiento a una velocidad específica

            //En la parte donde declaramos las variables vamos a crear una nueva variable pública
            //para la velocidad de rotación



            //Ahora necesitaremos obtener la rotación de destino deseada
            //Utilizaremos una varibale Cuaternion, que es un tipo específico para almacenar rotaciones

            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            //Ahora cambiaremos la rotación de nuestro personaje

            //Método para rotar desde nuestra rotación actual hacia la dirección deseada
            //usaremos la variable de velocidad de rotación para controlar que tan rápido el personaje gira rotando
            //eso hay que multiplicarlo por Time.deltaTime
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);



        }
        //*********************************************************************************


    }
}
