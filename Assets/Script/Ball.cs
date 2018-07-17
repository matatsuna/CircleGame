using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private int count = 0;
    private int score = 0;

    private GameObject scoreboard;
    private GameObject scorevalue;
    public AudioClip se1;
    public AudioClip se2;
    private AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(0, 0, -3.0f, ForceMode.Impulse);

        scoreboard = GameObject.Find("ScoreBoard");
        scorevalue = GameObject.Find("ScoreValue");
        scoreboard.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collider)
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        if (collider.gameObject.CompareTag("Block"))
        {
            Destroy(collider.gameObject);
            score++;
            audioSource.clip = se1;
            audioSource.Play();

        }

        if (collider.gameObject.CompareTag("Bar"))
        {
            count++;
            audioSource.clip = se1;
            audioSource.Play();
        }

        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = rigidbody.velocity.normalized * (((float)(count) / 3.0f) + 4.0f);

        if (collider.gameObject.CompareTag("Wall"))
        {
            audioSource.clip = se2;
            audioSource.Play();

            this.gameObject.transform.position = new Vector3(0, -10, 0);
            scorevalue.GetComponent<Text>().text = score.ToString();
            scoreboard.SetActive(true);
        }
    }
}
