using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    public float pSp = 1;
    public float pJp = 1;
    private float hDir;
    private float vDir;
    private Rigidbody2D rb;
    private bool jp = false;
    private bool gr = false;



    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hDir = Input.GetAxisRaw("Horizontal");
        vDir = Input.GetAxisRaw("Vertical");
        //transform.position += new Vector3(hDir, vDir, 0) * Time.deltaTime*pSp;
        if(Input.GetButtonDown("Jump")&& gr)
        {
            jp = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(hDir*pSp, rb.velocity.y);
        if (jp&&gr)
        {
            rb.AddForce(Vector2.up * pJp, ForceMode2D.Impulse);
            jp = false;
            gr = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Box")
        {
            gr = true;
        }
    }
}
