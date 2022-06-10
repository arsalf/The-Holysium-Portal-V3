using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTreeManager : MonoBehaviour
{
     // specify an appropriate object for bonus
    [SerializeField] private GameObject player;
    private TreeInstance [] trees;
    private float terrainWidth;
    private float terrainheight;
    private float terrainY;
    
    void Awake ()
    {
        Terrain terrain = Terrain.activeTerrain;
        terrainWidth = terrain.terrainData.size.x;
        terrainheight = terrain.terrainData.size.z;
        terrainY = terrain.terrainData.size.y;
        trees = terrain.terrainData.treeInstances;
        // output all tree positions
        if (trees.Length>0)
        {
            for (int i = 0;i<trees.Length;i ++) {            
                Debug.Log ("Tree Point Ke -" + i + " " + treePosToWorldPoint (trees [i] .position));
            }
        }
        // [Bonus] Returns the position of the tree closest to the position specified in the argument
        Vector3 nearestTreePos = nearestTree(player.transform.position);
        Debug.Log (nearestTreePos);
    }
    ///<summary>
    /// Convert tree position to world coordinates
    ///</summary>
    Vector3 treePosToWorldPoint (Vector3 treePos)
    {
        return new Vector3 (treePos.x * terrainWidth, treePos.y * terrainY, treePos.z * terrainheight);
    }
    ///<summary>
    /// Returns the position of the tree closest to the position specified in the argument
    ///</summary>
    Vector3 nearestTree(Vector3 targetPos)
    {
        Vector3 NearestPos = Vector3.negativeInfinity;
        
        if (trees.Length == 0) 
        {
            Debug.LogError ("No trees could be obtained");
            return NearestPos;
        }
        
        NearestPos = treePosToWorldPoint (trees [0] .position);
        float nearestTreeDistance = Vector3.Distance (treePosToWorldPoint (trees [0] .position), targetPos);
        
        for (int i = 0;i<trees.Length;i ++) 
        {
            if (Vector3.Distance (treePosToWorldPoint (trees [i] .position), targetPos)<nearestTreeDistance) 
            {
                NearestPos = treePosToWorldPoint (trees [i] .position);
                nearestTreeDistance = Vector3.Distance (treePosToWorldPoint (trees [i] .position), targetPos);
            }
        }                    

        return NearestPos;
    }
}
