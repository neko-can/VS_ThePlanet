using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMesh : MonoBehaviour {

    public GameObject targetObj;
    public GameObject verticesPrefab;

    MeshFilter targetMeshFilter;
    Mesh targetMesh = new Mesh();
    List<Vector3> targetVerticesList = new List<Vector3>();
    List<int> targetTrianglesList = new List<int>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateMesh()
    {
        //Update中にMeshの座標更新
        targetMesh.vertices = targetVerticesList.ToArray();
        targetMesh.triangles = targetTrianglesList.ToArray();
        targetMesh.RecalculateNormals();
        targetMeshFilter.sharedMesh = targetMesh;

        //可視化Verticesの移動
    }

    bool IsMeshUpdating()
    {
        //Meshの更新条件
        //・案1：不特定多数のVerticesが選択されたら
        bool IsUpdating = false;
        return IsUpdating;
    }

    void ShowVertices()
    {
        GameObject verticesClone;

        for(int i = 0; i < targetVerticesList.Count; i++)
        {
            verticesClone = GameObject.Instantiate(verticesPrefab);
            verticesClone.transform.position = targetVerticesList[i];
        }

    }

    void GetMesh()
    {
        //現在のMeshの取得
        targetMesh = targetObj.GetComponent<MeshFilter>().sharedMesh;
        targetVerticesList.AddRange(targetMesh.vertices);
        targetTrianglesList.AddRange(targetMesh.triangles);
    }
}
