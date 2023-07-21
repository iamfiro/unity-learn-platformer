using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    
    enum Type
    {
        idle,
        hide,
        sidetoside,
        colldestroy,
        updown
    };

    

    Rigidbody rb;

    [SerializeField]
    Type type;
    [SerializeField]
    float hideTime;
    [SerializeField]
    float sideDistance;
    [SerializeField]
    float sideSpeed;
    bool sideStart;
    [SerializeField]
    float upDownSpeed;
    [SerializeField]
    float upDownDistance;
    bool upDownStart;
    bool dirIsUp;
    Vector3 origin;
    bool sideDirRight;
    bool collDetected;
    bool trapisColl;
    bool trapOnece;
    [SerializeField]
    int collDestroyCount;
   
    Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        origin = transform.position;
        sideDirRight = false;
      switch (type)
      {
          case Type.hide:
                StartCoroutine("Hide");
                break;
          case Type.sidetoside:
                SideToSide();
                break;
          case Type.colldestroy:
                trapisColl=true;
                break;
          case Type.updown:
                UpDown();
                break;


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (trapisColl && !trapOnece)
        {
            StartCoroutine(CollDestroy(material));
            trapOnece = true;
        }        
    }

  

    IEnumerator CollDestroy(Material toChange)
    {
            int count = 1;
            while(count<=collDestroyCount)
            {
                                            
                toChange.color = Color.red;
                yield return new WaitForSeconds(0.2f);                
                GetComponent<MeshRenderer>().enabled = false;
                yield return new WaitForSeconds(0.2f);                
                GetComponent<MeshRenderer>().enabled = true;
                count++;
            }   

              
              gameObject.AddComponent<Rigidbody>();


    }

    void SideToSide()
    {

        sideStart = true;
    }

    void UpDown()
    {

        upDownStart = true;
    }


    IEnumerator Hide()
    {
        while (true)
        {
            yield return new WaitForSeconds(hideTime);
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().isTrigger = true;
            yield return new WaitForSeconds(hideTime);
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<Collider>().isTrigger = false;
            
        }
       
    }


    

    // Update is called once per frame
    void Update()
    {
        

        if (sideStart)
        {

            if (this.transform.position.x < origin.x - sideDistance)
                sideDirRight = true; 
            else if(this.transform.position.x > origin.x + sideDistance)
                sideDirRight = false;

            if (sideDirRight)
            {
                transform.Translate(Vector3.right* sideSpeed*Time.deltaTime);
              
            }else if(!sideDirRight)
            {
                transform.Translate(Vector3.left * sideSpeed * Time.deltaTime);                
            }


        }



        if (upDownStart)
        {

            if (this.transform.position.y < origin.y-upDownDistance)
                dirIsUp = true;
            else if (this.transform.position.y > origin.y+upDownDistance)
                dirIsUp = false;

            if (dirIsUp)
            {
                transform.Translate(Vector3.up * upDownSpeed * Time.deltaTime);

            }
            else if (!dirIsUp)
            {
                transform.Translate(Vector3.down * upDownSpeed * Time.deltaTime);
            }


        }
    }

    
}
