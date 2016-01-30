using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class ManageTiles : MonoBehaviour {

    public static Transform Cam1, Cam2;

    private int _tilesNRows;
    private Vector2 _chunkSize = new Vector2(1, 1);
    private Vector3 _chunkCenter = new Vector3(0,0,0);
    private Dictionary<IntPoint, Transform> _tiles;
    // Use this for initialization
	void Awake () {
        Cam1 = GameObject.Find("Virgin Cam").transform;
        Cam2 = GameObject.Find("Cannibal Cam").transform;
        _tilesNRows = gameObject.transform.childCount / 3;
        _tiles = new Dictionary<IntPoint, Transform>();
        int j = 0;
        for (int i = 0; i < gameObject.transform.childCount; i++ )
        {
            j += (i%_tilesNRows < 2 ? 0 : 1);
            _tiles.Add(new IntPoint(i%_tilesNRows, j), gameObject.transform.GetChild(i));
        }
        TilePlacementHandler();
	}
	
	// Update is called once per frame
	void Update () {
        TilePlacementHandler();
	}

   private void TilePlacementHandler()
    {
        IntPoint nD = ExtendedMath.DistanceIntervals(new Vector2(Cam1.position.x, Cam1.position.z), new Vector2(_chunkCenter.x, _chunkCenter.z), _chunkSize/2);
        if ((nD.x > 0 ^ nD.x < 0) | (nD.y > 0 ^ nD.y < 0))
        {
            _chunkCenter = new Vector2(_chunkCenter.x + (nD.x * _chunkSize.x), _chunkCenter.z + (nD.y * _chunkSize.y));
            IntPoint negaDir = new IntPoint((int)ExtendedMath.InvertValue((nD.x != 0 ? nD.x : nD.y)), (nD.y != 0 ? nD.y : (int)ExtendedMath.InvertValue(nD.x)));
            ShuffleTiles(negaDir);
        }
    }

    private void ShuffleTiles(IntPoint negaDir)
    {
        Vector2 startPos = Resenter();
        Vector2 halfCube = _chunkSize / 2;
        Dictionary<IntPoint, Transform> tTiles = new Dictionary<IntPoint,Transform>();
        for (int y = 0; y < _tilesNRows; y++)
        {
            for (int x = 0; x < _tilesNRows-1; x++)
            {
                Transform aT = _tiles[new IntPoint(x, y)];
                IntPoint nN = new IntPoint((x + negaDir.x), (y + negaDir.y));
                if (nN.x >= _tilesNRows ^ nN.x < 0 | nN.y >= _tilesNRows ^ nN.y < 0)
                {
                    nN = new IntPoint((_tilesNRows - 1) - (nN.x - negaDir.x), (_tilesNRows - 1) - (nN.y - negaDir.y));
                    Vector2 s = new Vector2(startPos.x + ((nN.y) * halfCube.x), startPos.y + ((nN.y) * -(halfCube.y)));
                    aT.gameObject.transform.position = new Vector3(s.x + (halfCube.x * nN.x),0, s.y + (halfCube.y * nN.x));
                }
               tTiles.Add(nN, aT);
            }
        }
    }

    public Vector2 Resenter() { return new Vector2(_chunkCenter.x - (_tilesNRows / 2) + (_chunkSize.x / 2), _chunkCenter.y); }
}