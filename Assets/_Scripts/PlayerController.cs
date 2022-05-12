using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float _baseSpeed = 10.0f;
    float _gravidade = 9.8f;

    public int playerHealth = 100;

    CharacterController characterController;

    //Referência usada para a câmera filha do jogador
    GameObject playerCamera;
    //Utilizada para poder travar a rotação no angulo que quisermos.
    float cameraRotation;

    public GameObject pausePanel;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        // Cursor.lockState = CursorLockMode.Locked;

        playerCamera = GameObject.Find("Main Camera");
        cameraRotation = 0.0f;

    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Verificando se é preciso aplicar a gravidade
        float y = 0;
        if (!characterController.isGrounded)
        {
            y = -_gravidade;
        }

        //Tratando movimentação do mouse
        float mouse_dX = Input.GetAxis("Mouse X");
        float mouse_dY = Input.GetAxis("Mouse Y");

        //Tratando a rotação da câmera
        cameraRotation += -mouse_dY * 4;
        cameraRotation = Mathf.Clamp(cameraRotation, -75.0f, 75.0f);



        Vector3 direction = transform.right * x + transform.up * y + transform.forward * z;

        characterController.Move(direction * _baseSpeed * Time.deltaTime);

        if(!pausePanel.activeSelf){
            playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);
            transform.Rotate(Vector3.up, mouse_dX * 4);
        }

        if (playerHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }

    }


    void LateUpdate()

    {
        Debug.DrawRay(playerCamera.transform.position, transform.forward * 10.0f, Color.magenta);
        // if (Physics.Raycast(playerCamera.transform.position, transform.forward, out hit, 100.0f))
        // {
        //     Debug.Log(hit.collider.name);
        // }
    }
}
