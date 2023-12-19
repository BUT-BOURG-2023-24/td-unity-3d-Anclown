using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int score;
    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get { return _instance; }}
    private static T _instance;

    public void Awake(){

        if (_instance == null){
            _instance = this as T;
        }
        else {
            Debug.LogError($"{GetType()} Existe ! Destruction de l'objet.");
            Destroy(gameObject);
        }
    }
}