using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FadeInOut : MonoBehaviour {

    public Image FadeImg;
    public float fadeSpeed = 1.5f;
    public bool sceneStarting = true;


    void Awake()
    {
        //Deixa a imagem ocupando a tela toda
        FadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
    }

    void FadeToClear()
    {
        // Faz a interpolação entre a cor da imagem e a transparência
        FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
    }


    void FadeToBlack()
    {
        // Faz a interpolação entre a cor da imagem e a cor preta
        FadeImg.color = Color.Lerp(FadeImg.color, Color.black, fadeSpeed * Time.deltaTime);
    }


    void StartScene()
    {
        //Se a cena começa, deixa a imagem transparente
        FadeToClear();

        // Quando o alpha estiver quase = 0
        if (FadeImg.color.a <= 0.05f)
        {
            // Define a cor como clear e desabilita a imagem
            FadeImg.color = Color.clear;
            FadeImg.enabled = false;

            // A cena não está mais começando
            sceneStarting = false;
        }
    }

    public void EndScene(string SceneName)
    {
        // habilita a imagem
        FadeImg.enabled = true;

        // Começa a dar o fade out
        FadeToBlack();

        // Quando estiver com o alpha em 1
        if (FadeImg.color.a >= 0.95f)
            // Carrega a cena ou faça qualquer outra o coisa
            SceneManager.LoadScene(SceneName);
    }
}
