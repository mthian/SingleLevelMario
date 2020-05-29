using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public GameObject instructions;
    public MainCharacter mainCharScript;
    public GameObject heart0;
    public GameObject heart1;
    public GameObject heart2;

    //Awake happens before Start (used to do stuff in this scripts before starts in other scripts)
    private void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != null) {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        GameObject player = GameObject.Find("MainCharacter");
        mainCharScript = player.GetComponent<MainCharacter>();

    }

    // Update is called once per frame
    void Update() {
        if (Input.anyKey) {
            playerStart();
        }
        if (mainCharScript.health == 2) {
            heart2.SetActive(false);
        } else if (mainCharScript.health == 1) {
            heart1.SetActive(false);
        } else if (mainCharScript.health == 0) {
            heart0.SetActive(false);
        }
    }

    public void playerStart() {
        instructions.SetActive(false);
    }
}
