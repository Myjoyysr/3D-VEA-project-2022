using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public GameManager manager;

    private Vector3 spawn;
    private Quaternion spawn_rotation;
    public GameObject deathParticles;
    public bool usesManager = true;

    public AudioClip[] audioClip;
    public AudioSource audioPlayer;

    



    // Start is called before the first frame update
    void Start()
    {
        spawn = transform.position;
        spawn_rotation = transform.rotation;
        
        if (usesManager)
        {
            manager = manager.GetComponent<GameManager>();
        }
        audioPlayer = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -15f){
            Die();
        }
    }
    
    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Enemy")
        {
            Die();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Enemy")
        {
            Die();
        }


        if (other.transform.tag == "Goal")
        {
            if(usesManager)
            {
                manager.CompleteLevel();
            }
            Time.timeScale = 0f;
            PlaySound(1);
        }
        if(other.transform.tag == "Banana")
        {
            if(usesManager)
            {
                manager.AddBanana();
            }
            PlaySound(0);
            Destroy(other.gameObject);
        }
    
    }

    void PlaySound(int clip)
    {
        audioPlayer.clip = audioClip[clip];
        audioPlayer.Play();
    }





    void Die(){
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        transform.position = spawn;
        transform.rotation = spawn_rotation;
        Instantiate(deathParticles, transform.position, Quaternion.identity);
    }
}
