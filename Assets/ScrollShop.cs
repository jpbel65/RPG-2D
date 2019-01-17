using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollShop : MonoBehaviour
{
    public GameObject ItemContainer;
    public GameObject ImageBase;
    public GameObject TextBase;
    public Camera P_camera;
    public Text Coin;

    Image[] ListChild;
    Text[] listChildText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ListChild = ItemContainer.GetComponentsInChildren<Image>();
        listChildText = ItemContainer.GetComponentsInChildren<Text>();
        if (Input.GetMouseButtonUp(0) && Shop.GameInShop)
        {
            Ray ray = P_camera.ScreenPointToRay(Input.mousePosition);
            Debug.Log("click: " + ray.origin);
            //Debug.Log(ListChild[0].transform.position);
            for (int i = 0; i < ListChild.Length; i++) { 
                if (BoundsSceneImage(ListChild[i]).Contains(ray.origin))
                {
                    Debug.Log("item: " + i);
                    Destroy(ListChild[i].gameObject);
                    Destroy(listChildText[i].gameObject);
                    Coin.text = (int.Parse(Coin.text) + 1).ToString();
                }

            }
        }
    }

    void OnEnable()
    {
        foreach (stats item in Inventory.obj)
        {
            GameObject test = Instantiate(ImageBase, ItemContainer.transform);
            test.GetComponent<Image>().sprite = item.get_sprite();
            GameObject test2 = Instantiate(TextBase, ItemContainer.transform);
            test2.GetComponent<Text>().text = item.get_desc();
        }
    }

    void OnDisable()
    {
        Transform[] childs = ItemContainer.GetComponentsInChildren<Transform>();
        for (int i = 1; i < childs.Length;i++)
        {
            Destroy(childs[i].gameObject);
        }
    }

    Bounds BoundsSceneImage(Image img)
    {
        Bounds result = new Bounds();
        result.center = img.transform.position;
        result.extents = new Vector3(1.1f, 1.1f, 100);
        return result;
    }

}
