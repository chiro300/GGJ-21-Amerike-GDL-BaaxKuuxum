using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTime : MonoBehaviour
{
    public int time = 4;

    public string scene = "Zona1";
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wating());
    }

    protected IEnumerator Wating()
    {
        yield return new WaitForSeconds(time);
        
        SceneManager.LoadScene(scene);

        yield return new WaitForSeconds(1);

        player = Instantiate(player, new Vector2(0.52f, 2.62f), player.transform.rotation);
    }
}
