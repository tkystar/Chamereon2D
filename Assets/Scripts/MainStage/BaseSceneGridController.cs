using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class BaseSceneGridController : MonoBehaviour
{
    [SerializeField]
    Grid isometricGrid;  
    [SerializeField]
    Tilemap layerBuilding;
    public GameObject Chamereon;
    /*
    [SerializeField]
    Tile circletile;
    */
    Vector3 _chamereonTransform;
    [SerializeField]
    Button PutButton;
    [SerializeField]
    GameObject ButButtonGameObject;
    Vector3Int cellPosition;
    // Start is called before the first frame update
    void Start()
    {
        // １件目
        //circletile.GetTileData.transform
        ButButtonGameObject.SetActive(false);
        PutButton.onClick.AddListener(PutTile);
    }

    // Update is called once per frame
    void Update()
    {
        _chamereonTransform = Chamereon.GetComponent<Transform>().position;
        cellPosition = layerBuilding.WorldToCell(_chamereonTransform);
        if (cellPosition != null)
        {
            var sprite = layerBuilding.GetSprite(cellPosition);
            ButButtonGameObject.SetActive(false);
            if (sprite != null)
            {
                Debug.Log(sprite.name);

                if (sprite.name == "Position")
                {
                    ButButtonGameObject.SetActive(true);
                }
                else
                {
                    ButButtonGameObject.SetActive(false);
                }
                

            }
            

        }

        

    }

    void PutTile()
    {
        /*
        var _chamereonPosition = _chamereonTransform.position;
        var position1z0 = new Vector3Int(_chamereonPosition);
        */
        Tile tile1Wall = Resources.Load<Tile>("Tiles/Harigami01"); // No.2
        cellPosition.y+=2;
        layerBuilding.SetTile(cellPosition, tile1Wall); // No.3
    }
}