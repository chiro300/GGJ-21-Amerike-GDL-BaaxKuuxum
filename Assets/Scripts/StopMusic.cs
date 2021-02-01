using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject.FindObjectOfType<MusicClass>().StopMusic();
    }

}
