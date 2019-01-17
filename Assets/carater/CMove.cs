using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CMove : MonoBehaviour {
    public float speed = 5f;
    float translationX = 0f;
    float translationY = 0f;
    Animator animator;
   

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown("m"))
        {
            SceneManager.LoadScene(sceneName: "Inn");
        }*/
        ///Change the GameObject's movement in the X axis
        translationX = Input.GetAxis("Horizontal") * speed;
        //Change the GameObject's movement in the Y axis
        translationY = Input.GetAxis("Vertical") * speed;
        animator.SetFloat("UD", translationY/speed);
        animator.SetFloat("RL", translationX/speed);
        if (Input.GetKeyDown("space") && !PauseMenu.GameIsPaused && !Shop.GameInShop)
        {
            string anim = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
            Vector3 posPlayer = gameObject.transform.position;
            Collider2D Player = gameObject.GetComponent<BoxCollider2D>();
            GameObject[] objecs = GameObject.FindGameObjectsWithTag("Interac");
            foreach (GameObject objec in objecs)
            {
                Vector3 TargetPos = objec.transform.position;
                Collider2D target = objec.GetComponent<BoxCollider2D>();
                //Debug.Log(objec.name + " at: " + target.Distance(Player).distance);
                //Debug.Log("player at: " + posPlayer + "/" + objec.name + " Bounds: " + Cible);
                float DistanceBetween = target.Distance(Player).distance;
                if(DistanceBetween < 0) {
                    if (anim.Contains("left"))
                    {
                        if (posPlayer.x > TargetPos.x)
                        {
                            print(objec.name + " a Gauche");//game object a gauche
                            objec.SendMessage("Talk");//namer of fct can place params in
                        }
                    }

                    if (anim.Contains("right")) 
                    {
                        if (posPlayer.x < TargetPos.x)
                        {
                            print(objec.name + " a Droite");//game object a droite
                            objec.SendMessage("Reward", gameObject);//namer of fct can place params in
                        }
                            
                    }

                    if (anim.Contains("up"))
                    {
                        if (posPlayer.y < TargetPos.y)
                        {
                            print(objec.name + " en Haut");
                            objec.SendMessage("Talk");//namer of fct can place params in
                        }
                            
                    }//game object a up

                    if (anim.Contains("down"))
                    {
                        if (posPlayer.y > TargetPos.y)
                        {
                            print(objec.name + " en Bas");//game object a down
                        }
                            
                    }
                }
            }
        }
       
    }

    void FixedUpdate ()
    {
        //Move the GameObject
        transform.Translate(new Vector3(translationX * Time.fixedDeltaTime, translationY * Time.fixedDeltaTime, 0));
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Ouput the Collision to the console
        print("Collision : " + collision.gameObject.name);//return name object qu'oin rentre en collision
        print("Animation : " + animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);//return name animation qui joue quand on touche une box
    }
    
}
