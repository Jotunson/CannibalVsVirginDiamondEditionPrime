using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class ManageTiles : MonoBehaviour {

    public static Transform Cam1, Cam2;

    // Use this for initialization
	void Awake () {
        Cam1 = GameObject.Find("Virgin Cam").transform;
        Cam2 = GameObject.Find("Cannibal Cam").transform;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

  /*  private void TilePlacementHandler()
    {
        IntPoint nD = ExtendedMath.DistanceIntervals(player.position, _chunkCenter, WorldTileManager.chunkSize / 2);
        if ((nD.x > 0 ^ nD.x < 0) | (nD.y > 0 ^ nD.y < 0))
        {
            _chunkCenter = new Vector2(_chunkCenter.x + (nD.x * WorldTileManager.chunkSize.x), _chunkCenter.y + (nD.y * WorldTileManager.chunkSize.y));
            IntPoint negaDir = new IntPoint((int)ExtendedMath.InvertValue((nD.x != 0 ? nD.x : nD.y)), (nD.y != 0 ? nD.y : (int)ExtendedMath.InvertValue(nD.x)));
            return ShuffleTiles(negaDir, act);
        }
    }

    private void ShuffleTiles()
    {
        Vector2 startPos = Resenter();
        Vector2 halfCube = WorldTileManager.chunkSize / 2;
        Dictionary<IntPoint, ActiveTile> tTiles = new Dictionary<IntPoint, ActiveTile>();
        for (int y = 0; y < WorldTileManager.numActiveTiles.y; y++)
        {
            for (int x = 0; x < WorldTileManager.numActiveTiles.x; x++)
            {
                ActiveTile aT = activeTiles[new IntPoint(x, y)];
                IntPoint nN = new IntPoint((x + negaDir.x), (y + negaDir.y));
                for (int i = 0; i < WorldTileManager.numOfLayers; i++)
                {
                    if (nN.x >= WorldTileManager.numActiveTiles.x ^ nN.x < 0 | nN.y >= WorldTileManager.numActiveTiles.y ^ nN.y < 0)
                    {
                        nN = new IntPoint((WorldTileManager.numActiveTiles.x - 1) - (nN.x - negaDir.x), (WorldTileManager.numActiveTiles.y - 1) - (nN.y - negaDir.y));
                        Vector2 s = new Vector2(startPos.x + ((nN.y) * halfCube.x), startPos.y + ((nN.y) * -(halfCube.y)));
                        aT.tile[i].gameObject.transform.position = new Vector3(s.x + (halfCube.x * nN.x), s.y + (halfCube.y * nN.x));
                    }
                    aT.tile[i].name = ("L" + i + " x: " + nN.x + " y: " + nN.y);
                }
                tTiles.Add(nN, aT);
            }
        }
    }

    public Vector2 Resenter() { return new Vector2(_chunkCenter.x - (WorldTileManager.actTileSize.x / 2) + (WorldTileManager.chunkSize.x / 2), _chunkCenter.y); }*/
}
