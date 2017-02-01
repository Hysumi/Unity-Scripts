using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    #region General Variables

    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    //Define os ângulo máximo e mínimo de rotação em Y
    public float minimumY = 0F;
    public float maximumY = 60F;

    public float rotationY = 0F;
    public float rotationX = 0F;

    #endregion

    #region Third Person Variables

    public float distance = 10.0f;
    public float height = 5.0f;
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;

    #endregion

    public void FirstPersonCameraRotation(GameObject mainCamera)
    {
        //Caso esteja usando rigidbody, congela as rotações.
        if (mainCamera.GetComponent<Rigidbody>())
            mainCamera.GetComponent<Rigidbody>().freezeRotation = true;

        //Pega o ângulo atual y + a rotação de X
        rotationX = mainCamera.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX; 

        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        mainCamera.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }

    public void ThirdPersonCameraRotation(GameObject mainCamera, Transform target)
    {
        //Caso não tenha um alvo
        if (!target) return;

        //Pega o ângulo atual y + a rotação de X
        rotationX = target.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        target.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        //Calcula o atual ângulo de rotação
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        //Amortece a rotação no eixo Y
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        //Amortece a alteração de altura
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        //Converte os ângulos em rotação
        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Define a posição da câmera no eixo x-z do plano
        //para a distância atrás do alvo
        mainCamera.transform.position = target.position;
        mainCamera.transform.position -= currentRotation * Vector3.forward * distance;

        //Define a altura da câmera
        mainCamera.transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        //Foca no alvo
        mainCamera.transform.LookAt(target);
    }
}
