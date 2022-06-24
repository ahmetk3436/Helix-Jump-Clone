using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    public GameObject splashPrefab;
    private GameManager gm;
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.AddForce(Vector3.up * jumpForce);
        GameObject splash = Instantiate(splashPrefab, transform.position + new Vector3(0,-0.22f,0), splashPrefab.transform.rotation);
        splash.transform.SetParent(collision.transform);
        string materialName = collision.gameObject.GetComponent<MeshRenderer>().material.name;
        if (materialName == "Safe Color (Instance)")
        {
            print("+5");
        } else if (materialName == "Unsafe Color (Instance)")
        {
            print("oyun kaybedildi");
            gm.RestartGame();
        } else if (materialName == "Last Ring (Instance)")
        {
            print("bölüm baþarýyla geçildi");
            gm.RestartGame();

        }
    }
}
