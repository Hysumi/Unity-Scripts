using UnityEngine;

public class ClickAndMove : MonoBehaviour {

    /* Função para movimento ao clicar em um objeto que não o player.
     *  Com um objeto de plano de fundo, ao se clicar na tela o player irá até a posição
     * onde o click ocorreu.
     */

    RaycastHit hit;
    Vector3 playerSpeed, firstHit;
    public float speed, erro = 0.1f;

    void MoveOnClick()
    {
        if (Input.GetMouseButton(0))
        {
            //Pegando a posição do touch na tela em relação a câmera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 

            if (Physics.Raycast(ray, out hit))
            {
                //Pega a diferença entre o toque e a posição do player, normaliza e multiplica pela velocidade.
                playerSpeed = (hit.point - this.gameObject.transform.position).normalized * speed;
                firstHit = hit.point;
            }
        }
        //Zera as posições Z (2D)
        playerSpeed.z = 0;
        firstHit.z = 0;

        if ((firstHit - this.gameObject.transform.position).sqrMagnitude > erro)
            this.gameObject.transform.position += playerSpeed * Time.deltaTime;
    }
}
