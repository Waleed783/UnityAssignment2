
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    public static int count = 0;
   [SerializeField] private GameObject _cloudParticlePrefab;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
       
        Bird bird = collision.collider.GetComponent<Bird>();
        if(bird!=null)
        {
           Instantiate(_cloudParticlePrefab,transform.position,Quaternion.identity);
            Destroy(gameObject);
            count++;
            return;
        }

        enemy enem = collision.collider.GetComponent<enemy>();
        if (enem != null)
        {
            return;
        }
        if (collision.contacts[0].normal.y < -0.5)
        {
             Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            count++;
            return;
        }
        

    }
}
