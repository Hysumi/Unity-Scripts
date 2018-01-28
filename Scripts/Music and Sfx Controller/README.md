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
    public AudioClip sfxName;
    ```
 * Na função em que for ativar o som, por o código:
    ```Javascript
    //Para Som 3D
    AudioManager.instance.PlaySound(sfxName, position);
    //Para Som 2D
    AudioManager.instance.PlaySOund(sfxName);
    ``` 

## Utilizando Biblíoteca de Sfx ou Músicas
 * No `EmptyGameObject` criado na configuração de ambiente, adicione o script `SoundLibrary.cs`.
 * No `Inspector` do objeto defina:
    * Quantos grupos vai ter: `Sound Groups Size`.
    * No grupo, determine o `Group Name`.
    * Determine o tamanho do grupo.
    * Arraste os áudios (músicas ou sfx) para o Inspector. 
 * Para `Música`, utilizar a função: 
    * `fadeDuration`: É do tipo `Float`. Determina o tempo de transição entre a música atual e a próxima. Recebe 1f por padrão. 
  ```Javascript
  AudioManager.instance.PlayMusic(AudioClip, fadeDuration);
  ```
 * Para `Sfx 3D`:
    ```Javascript
    //Toca um sfx aleatória do grupo. groupName: string; position: Vector3;
    AudioManager.instance.PlaySound(groupName, position);

    //Toca um sfx do grupo determinada pelo nome do arquivo. groupName: string; sfxName: string; position: Vector3; 
    AudioManager.instance.PlaySound(groupName, sfxName, position);
    
    //Toca um sfx do grupo determinada pela posição na ordem do grupo. groupName: string; idSfx: int; position: Vector3; 
    AudioManager.instance.PlaySound(groupName, idSfx, position);
    ```

 * Para `Sfx 2D`:
    ```Javascript
    //Toca um sfx aleatória do grupo. groupName: string; 
    AudioManager.instance.PlaySound(groupName);

    //Toca um sfx do grupo determinada pelo nome do arquivo. groupName: string; sfxName: string;
    AudioManager.instance.PlaySound(groupName, sfxName);
    
    //Toca um sfx do grupo determinada pela posição na ordem do grupo. groupName: string; idSfx: int;
    AudioManager.instance.PlaySound(groupName, idSfx);
    
    ```

### Obs:
 * PlayMusic: Melhor para música.
 * PlayClipAtPoint: Não pode ser usado para som 2D pois ele toca em um ponto específico no espaço 3D.
 * PlayOneShot: Som 2D. Não passa posição.

