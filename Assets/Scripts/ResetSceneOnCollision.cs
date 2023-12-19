using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSceneOnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                GameManager.Instance.ReloadGame();
        }       
}
}
