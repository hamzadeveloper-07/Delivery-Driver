using UnityEngine;

public class DriveScript : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.1f;
    [SerializeField] float moveSpeed = 0.03f;
    [SerializeField] float boostSpeed = 13f;
    [SerializeField] float slowSpeed = 7f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Booster")
        {
            moveSpeed = boostSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
      moveSpeed = slowSpeed;  
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float steerFB = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,steerFB,0);
    }
}
