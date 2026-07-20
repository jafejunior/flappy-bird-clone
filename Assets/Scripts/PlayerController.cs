using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    private Rigidbody thisRigidyBody;
    public float jumpPower = 2;
    public float jumpInterval = 0.2f;
    private float jumpCooldown = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisRigidyBody =  GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // Update cooldown
        jumpCooldown -= Time.deltaTime;
        bool isGameActive = GameManager.Instance.IsGameActive();
        bool canJump = jumpCooldown <= 0 && isGameActive;

        // Verification if can jump
        if (canJump){
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if (jumpInput){
                Jump();
            }
        }

        // Toogle Gravity
        thisRigidyBody.useGravity = isGameActive;
    }

    void OnCollisionEnter(Collision other)
    {
        CustomOnCollision(other.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        CustomOnCollision(other.gameObject);
    }

    void CustomOnCollision(GameObject other){
        // Verify collision on sensor to pass of the obstacle
        bool isSensorPass = other.gameObject.CompareTag("sensor");
        if (isSensorPass){
            // Pontuação incrementa +1
            int score = GameManager.Instance.score++;
            Debug.Log("Passou! Pontuação: " + score);
        }else{
            // Game over
            GameManager.Instance.EndGame();
        }
    }

    private void Jump()
    {
        // Reset cooldwon
        jumpCooldown = jumpInterval;

        // Apply Force
        thisRigidyBody.linearVelocity = Vector3.zero;
        thisRigidyBody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
    }
}
