using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class player : MonoBehaviour
{
    public int velocidade = 10;
    public int forcaPulo = 7;
    public bool noChao;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START");
        TryGetComponent(out rb);
    }

    private void OnCollisionEnter(Collision collisionr)
    {
        if (!noChao  && collisionr.gameObject.tag == "Chão")
        {
            noChao = true;
        }
}
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log("UPDATE");
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direcao = new Vector3(h, 0, v);
        rb.AddForce(direcao * velocidade * Time.deltaTime, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
        }
        
         
        
        if (transform.position.y < -5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
