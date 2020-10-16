using System.Threading; 
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Bird : MonoBehaviour
{
    public GameObject Youwintext;
    public GameObject Youloosetext;
    public  int countofturns = 0;
    public static int life = 5;
    public float delaybeforeloading = 4f;
    public float delaybeforeloading1 = 4f;
    public float timeelapsed;
    public float timeelapsed1;
    private static int score;
    public Transform GreenBird;
    Vector3 _initialPosition;
    private float _timesittingaround;
   public Text playerlife;
    bool _isDragging;
    bool _isGrounded = true;
    [SerializeField] private float _launchPower=500;
    private bool _birdwaslaunched;
    public GameObject prefab_bird;
    private void Awake()
    {

        _initialPosition = transform.position;
    }
    private void Update()
    {
        if(_birdwaslaunched&& GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timesittingaround += Time.deltaTime;
         
        }

        if (transform.position.y > 10|| transform.position.y < -10|| transform.position.x < -10|| transform.position.x > 20|| _timesittingaround>3) 
        {
            if (enemy.count == 3 && countofturns<=3)
            {

               
                Youwintext.SetActive( true);
                timeelapsed += Time.deltaTime;
                if (timeelapsed > delaybeforeloading)
                {
                    SceneManager.LoadScene("Nextlevel");
                }
                countofturns = 0;
            }
            else if(countofturns>3)
            {
               Youloosetext.SetActive(true);
                
               timeelapsed1 += Time.deltaTime;
                if (timeelapsed1 > delaybeforeloading1)
                {
                  SceneManager.LoadScene("menu");
                   countofturns = 0;
                }
               
            }
            else
            {
                Debug.Log(" GreenBird.position ");
                if (_isGrounded == true)
                {
                    countofturns++;
                    life--;
                    Debug.Log(life);
                    playerlife.text = "Remaining life  " + life.ToString();
                    GameObject newBird = Instantiate(prefab_bird, _initialPosition, Quaternion.identity);
                    newBird.GetComponent<Rigidbody2D>().gravityScale = 0;
                    _isGrounded = false;
                    
                    Destroy(this.gameObject);
                }
            }
        }    
    }
 
   

    private void OnMouseDown()
    {
        
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp()
    {

      

        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 direcionToInitialPosition=_initialPosition-transform.position;
         GetComponent<Rigidbody2D>().AddForce(direcionToInitialPosition*_launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdwaslaunched = true;
    }

    private void OnMouseDrag()
    {
    

        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x,newPosition.y);
       
    }
}
