using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    public SpriteRenderer renderer;
    public Sprite jumpingSprite;
    public Sprite normalSprite;
    public Sprite leftFacingSprite;
    public Sprite leftJumpingSprite;
    public Sprite rightWalk;
    public Sprite leftWalk;
    public Sprite centreWalk;
    public Sprite centreWalkLeft;
    public GameObject Camera;
    public GameObject background;
    public float xOffset = 0f;

    AudioSource audioData;
    public bool plasma;
    public GameObject plasmaAmmo;
    public float speed;
    public float jumpHeight;
    public float jumpSpeed;
    public bool jumping = false;
    public bool comingDown = true;
    public bool leftFacing = false;
    int walkIndex = 0;

    bool dashing = false;
    float end = 0;
    float dashStartX = 0;

    Vector3 jumpStart = new Vector3(0, 0, 0);

    public float xChange = 0f;
    public float yChange = 0f;
    Vector2 startScale = new Vector2();

    void Start(){
        startScale = transform.localScale;
        Camera = GameObject.Find("Camera");
        renderer = GetComponent<SpriteRenderer>();

        if (SceneManager.GetActiveScene().name == "ResourceRun"){
            background = GameObject.Find("background");
        }
    }

    void Update(){

        PlayerPrefs.SetString("Scene", SceneManager.GetActiveScene().name);

        Vector2 scale = transform.localScale;

        if (Input.GetKey(KeyCode.D)){
            walkIndex++;
            leftFacing = false;

            if (walkIndex == 30){
                walkIndex = 0;
                gameObject.GetComponent<SpriteRenderer>().sprite = rightWalk;
            }else if (walkIndex >= 20){
                gameObject.GetComponent<SpriteRenderer>().sprite = rightWalk;
            }else if (walkIndex >= 10){
                gameObject.GetComponent<SpriteRenderer>().sprite = centreWalk;
            }else if (walkIndex > 0){
                gameObject.GetComponent<SpriteRenderer>().sprite = rightWalk;
            }

            xChange += speed;
        }
        
        if (Input.GetKey(KeyCode.A)){
            walkIndex++;
            leftFacing = true;

            if (walkIndex == 30){
                walkIndex = 0;
                gameObject.GetComponent<SpriteRenderer>().sprite = leftWalk;
            }else if (walkIndex >= 20){
                gameObject.GetComponent<SpriteRenderer>().sprite = leftWalk;
            }else if (walkIndex >= 10){
                gameObject.GetComponent<SpriteRenderer>().sprite = centreWalkLeft;
            }else if (walkIndex > 0){
                gameObject.GetComponent<SpriteRenderer>().sprite = leftWalk;
            }

            xChange -= speed;
        }
        
        if (Input.GetKey(KeyCode.Space)){

            if (!jumping && !comingDown){
                jumpStart = transform.position;
                jumping = true;
                comingDown = true;
                audioData = GetComponent<AudioSource>();
                audioData.Play(0);

                if (leftFacing){
                    gameObject.GetComponent<SpriteRenderer>().sprite = leftJumpingSprite;
                }else{
                    gameObject.GetComponent<SpriteRenderer>().sprite = jumpingSprite;
                }

            }else{
               if (transform.position.y < jumpStart.y + jumpHeight && jumping){
                   if (leftFacing){
                        gameObject.GetComponent<SpriteRenderer>().sprite = leftJumpingSprite;
                    }else{
                        gameObject.GetComponent<SpriteRenderer>().sprite = jumpingSprite;
                    }
                   yChange += jumpSpeed;
                   Debug.Log(transform.position.y);
               }else{
                   jumping = false;
               }
            }
        }

        if (Input.GetKeyUp(KeyCode.F) && plasma){
            Instantiate(plasmaAmmo, new Vector3(transform.position.x + 1, transform.position.y, 0), Quaternion.identity);
        }

        if (Input.GetKeyUp(KeyCode.Space)){
            jumping = false;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && !dashing || Input.GetKeyUp(KeyCode.RightShift) && !dashing){
            if (gameObject.GetComponent<SpriteRenderer>().sprite == rightWalk || gameObject.GetComponent<SpriteRenderer>().sprite == normalSprite || gameObject.GetComponent<SpriteRenderer>().sprite == jumpingSprite){
                dashing = true;
                end = speed;
                dashStartX = transform.position.x;
            } else if (gameObject.GetComponent<SpriteRenderer>().sprite == leftWalk || gameObject.GetComponent<SpriteRenderer>().sprite == leftFacingSprite || gameObject.GetComponent<SpriteRenderer>().sprite == leftJumpingSprite){
                dashing = true;
                end = speed*-1;
                dashStartX = transform.position.x;
            }
        }

        if (SceneManager.GetActiveScene().name == "ResourceRun"){
            background.transform.position += new Vector3(xChange / 2, 0, 0) * Time.deltaTime;
        }

        transform.position += new Vector3(xChange, yChange, 0) * Time.deltaTime;

        xOffset += xChange;

        xChange = 0f;
        yChange = 0f;

        if (xOffset > 1){
            Camera.transform.position += new Vector3(xChange, 0, 0);
        }

        if (dashing){
            transform.position += new Vector3((speed)*(end/System.Math.Abs(end)), 0, 0);
            if (end/System.Math.Abs(end) == 1 && transform.position.x >= (dashStartX + end)){
                dashing = false;
            }
            if (end/System.Math.Abs(end) == -1 && transform.position.x <= (dashStartX - end)){
                dashing = false;
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject.tag == "superjump"){
            jumpSpeed *= 2;
            jumpHeight *= 2;
            Destroy(collision.gameObject);
            comingDown = jumping;
        }else if (collision.gameObject.tag == "plasmapickup"){
            plasma = true;
            Destroy(collision.gameObject);
            comingDown = jumping;
        }else{
            if (transform.position.y >= (collision.gameObject.transform.position.y - 1)){
                comingDown = false;
            }
        }
        
        Debug.Log(transform.position.y + "char, " + collision.gameObject.transform.position.y + "platform");

        if (leftFacing){
            gameObject.GetComponent<SpriteRenderer>().sprite = leftFacingSprite;
        }else{
            gameObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
        }

        if (collision.gameObject.name == "death" || collision.gameObject.tag == "enemy"){
            SceneManager.LoadScene("Dead", LoadSceneMode.Single);
        }

        if (collision.gameObject.name == "portal1"){
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }else if (collision.gameObject.name == "portal2"){
            SceneManager.LoadScene("Level3", LoadSceneMode.Single);
        }else if (collision.gameObject.name == "portal3"){
            SceneManager.LoadScene("Level4", LoadSceneMode.Single);
        }else if (collision.gameObject.name == "portal4"){
            SceneManager.LoadScene("Level5", LoadSceneMode.Single);
        }else if (collision.gameObject.name == "portal5"){
            SceneManager.LoadScene("Level6", LoadSceneMode.Single);
        }else if (collision.gameObject.name == "portal6"){
            SceneManager.LoadScene("Level7", LoadSceneMode.Single);
        }else if (collision.gameObject.name == "portal7"){
            SceneManager.LoadScene("Level8", LoadSceneMode.Single);
        }else if (collision.gameObject.name == "portal8"){
            SceneManager.LoadScene("Level9", LoadSceneMode.Single);
        }else if (collision.gameObject.name == "portal9"){
            SceneManager.LoadScene("Level10", LoadSceneMode.Single);
        }else if (collision.gameObject.name == "portal10"){
            SceneManager.LoadScene("MainGameBegins", LoadSceneMode.Single);
        }else if (collision.gameObject.tag == "endportal"){
            PlayerPrefs.SetFloat("Resources", PlayerPrefs.GetFloat("Resources") + 50);
            SceneManager.LoadScene("Faction", LoadSceneMode.Single);
        }

    }

    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.tag != "plasma" && collision.gameObject.tag != "plasmapickup" && collision.gameObject.tag != "superjump"){
            comingDown = true;
        }else{
            comingDown = false;
        }
    }
}
