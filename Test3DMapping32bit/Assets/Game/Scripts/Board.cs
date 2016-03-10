//using UnityEngine;

//public class Board : MonoBehaviour {

//    public Logic Logic;
//    public GameObject[,] Tiles = new GameObject[HORIZONTAL_TILES_AMOUNT, VERTICAL_TILES_AMOUNT];
//    public GameObject Origin;

//    private const int HORIZONTAL_TILES_AMOUNT = 8;
//    private const int VERTICAL_TILES_AMOUNT = 8;



//    // Use this for initialization
//    void Start()
//    {
//        SpawnBoard();
//    }

//    private void SpawnBoard()
//    {
//        for (var x=0; x<HORIZONTAL_TILES_AMOUNT; ++x)
//        {
//            for (var y=0; y<VERTICAL_TILES_AMOUNT; ++y)
//            {
//                Tiles[x, y] = CreateTile(x, y); 
//            }
//        }
//    }

//    private GameObject CreateTile(int x, int y)
//    {
//        var isBlack = (x + y) % 2 == 0;
//        var tile = Instantiate(isBlack ? Logic.Prefabs.BlackTile : Logic.Prefabs.WhiteTile);
//        var tileMesh = tile.GetChildGameObject("Base").GetComponent<MeshFilter>();
//        var tileMeshWidth = tileMesh.mesh.bounds.size.x * tile.transform.localScale.x;
//        var tileMeshDepth = tileMesh.mesh.bounds.size.z * tile.transform.localScale.z;
//        var offset = new Vector3(x * tileMeshWidth * 2, 0, y * tileMeshDepth * 2);
//        tile.transform.Translate(offset);
//        tile.transform.parent = Origin.transform;
//        return tile;
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
