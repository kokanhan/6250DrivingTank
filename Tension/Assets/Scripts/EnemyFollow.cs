using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;
    public Transform EnemyRest;
    public bool startFollowing;
    [Header("Enemy Apperance")]
    public Material[] Materials;

    public int AllowedContactTimes = 2;

    private GameObject LeftEye;
    private GameObject RightEye;
    private AudioSource enemySound;
    private int contactTimes;
    // Start is called before the first frame update
    private void Awake()
    {
        LeftEye = GameObject.FindGameObjectWithTag("Boss Left Eye");
        RightEye = GameObject.FindGameObjectWithTag("Boss Right Eye");
        LeftEye.GetComponent<MeshRenderer>().material = Materials[0];
        RightEye.GetComponent<MeshRenderer>().material = Materials[0];
        enemySound = this.GetComponent<AudioSource>();
    }
    void Start()
    {
        //Object.GetComponent<MeshRenderer> ().material = Material1;
        Debug.Log("DUmame");
        startFollowing = false;
        contactTimes = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if(startFollowing == true)
        {
            enemy.SetDestination(Player.position);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            startFollowing = true;
            contactTimes++;
            LeftEye.GetComponent<MeshRenderer>().material = Materials[1];
            RightEye.GetComponent<MeshRenderer>().material = Materials[1];
            if (!enemySound.isPlaying) { 
                enemySound.Play();
            }
            //FindObjectOfType<PlayerManager>().LoseLife(damage);

            if (contactTimes >= AllowedContactTimes && startFollowing == true)
            {
                GameOver();
            }
        }
        if (other.gameObject.tag == "Door")//if enemy hit the closed door
        {
            Debug.Log("Hit the door!");
            StartCoroutine(backoff());
        }
    }

    IEnumerator backoff()
    {
        startFollowing = false;
        enemy.SetDestination(EnemyRest.position);
        yield return new WaitForSeconds(10.0f);
    }

    private void GameOver()
    {
        
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        
    }
}
