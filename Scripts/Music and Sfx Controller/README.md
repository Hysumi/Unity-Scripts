# Unity Music and Sfx Controller

`Última versão testada: Unity 2017.1.0.f3`

## Configurando o Ambiente:
 1. Criar um `EmptyGameObject` e centralizar.
 2. Colocar o Script `AudioManager.cs` e `MusicManager.cs` no `EmptyGameObject` criado anteriormente.
 3. Criar um `EmptyGameObject` filho e colocar no objeto filho o componente `Audio Listener`.
 4. Remover o componente Audio Listener da `Main Camera`.


## Utilizando Sfx No Objeto
 * Na classe do objeto que vai tocar o efeito sonoro, adicione um:
    ```
    public AudioClip nome;
    ```
 * Na função em que for ativar o som, por o código:
    ```Javascript
    //Para Som 3D
    AudioManager.instance.PlaySound(clip, position);
    //Para Som 2D
    AudioManager.instance.PlaySOund(clip);
    ``` 

## Utilizando Biblíoteca de Sfx ou Músicas
 * No `EmptyGameObject` criado na configuração de ambiente, adicione o script `SoundLibrary.cs`.
 * No `Inspector` do objeto defina:
    * Quantos grupos vai ter: `Sound Groups Size`.
    * No grupo, determine o `Group Name`.
    * Determine o tamanho do grupo.
    * Arraste os Audios (músicas ou sfx) para o Inspector. 
 * Para `Música`, utilizar a função: 
    * `fadeDuration` é do tipo `Float`, ele determina o tempo de transição entre a música atual e a próxima. Recebe 1f por padrão. 
  ```Javascript
  AudioManager.instance.PlayMusic(AudioClip, fadeDuration);
  ```
 * Para `Sfx 3D`:
    ```Javascript
    //Toca um sfx aleatória do grupo. nomeDoGrupo: string; position: Vector3;
    AudioManager.instance.PlaySound(nomeDoGrupo, position);

    //Toca um sfx do grupo determinada pelo nome do arquivo. nomeDoGrupo: string; nomeDoSfx: string; position: Vector3; 
    AudioManager.instance.PlaySound(nomeDoGrupo, nomeDoSfx, position);
    
    //Toca um sfx do grupo determinada pela posição na ordem do grupo. nomeDoGrupo: string; idSfx: int; position: Vector3; 
    AudioManager.instance.PlaySound(nomeDoGrupo, idSfx, position);
    ```

 * Para `Sfx 2D`:
    ```Javascript
    //Toca um sfx aleatória do grupo. nomeDoGrupo: string; 
    AudioManager.instance.PlaySound(nomeDoGrupo);

    //Toca um sfx do grupo determinada pelo nome do arquivo. nomeDoGrupo: string; nomeDoSfx: string;
    AudioManager.instance.PlaySound(nomeDoGrupo, nomeDoSfx);
    
    //Toca um sfx do grupo determinada pela posição na ordem do grupo. nomeDoGrupo: string; idSfx: int;
    AudioManager.instance.PlaySound(nomeDoGrupo, idSfx);
    
    ```

### Obs:
 * PlayMusic: Melhor para música.
 * PlayClipAtPoint: Não pode ser usado para som 2D pois ele toca em um ponto específico no espaço 3D.
 * PlayOneShot: Som 2D. Não passa posição.

