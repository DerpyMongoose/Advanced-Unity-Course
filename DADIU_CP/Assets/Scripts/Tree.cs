using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

    public static Tree instance;

    public GameObject startObject;

    [HideInInspector]
    public Vector3[] newVertices;
    [HideInInspector]
    public Vector3[] newNormals;
    [HideInInspector]
    public Vector2[] newUV;
    [HideInInspector]
    public int[] newTriangles;
    [HideInInspector]
    public int offsetVertices = 0;
    [HideInInspector]
    public int offsetTriangles = 0;
    [HideInInspector]
    public int maxVertices = 65534;
    [HideInInspector]
    public int maxTriangles = 65534;
    //[HideInInspector]
    //public int recursionMax;

    public Vector3 splitAngle1;
    public Vector3 splitAngle2;
    public Vector3 scale1;
    public Vector3 scale2;

    public Mesh mesh;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        mesh = new Mesh();

        if (null == GetComponent<MeshFilter>())
        {
            gameObject.AddComponent<MeshFilter>();
        }
        if (null == GetComponent<MeshRenderer>())
        {
            gameObject.AddComponent<MeshRenderer>();
        }

        GetComponent<MeshFilter>().mesh = mesh;

        //splitAngle1 = new Vector3(30, 0, 0);
        //splitAngle2 = new Vector3(-30, 0, 0);
    }


    //void Update()
    //{
    //    if (null != startObject)
    //    {
    //        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
    //        int i;

    //        newVertices = new Vector3[maxVertices];
    //        newNormals = new Vector3[maxVertices];
    //        newUV = new Vector2[maxVertices];
    //        offsetVertices = 0;
    //        newTriangles = new int[maxTriangles];
    //        offsetTriangles = 0;

    //        //LSystem(0, transform.worldToLocalMatrix * startObject.transform.localToWorldMatrix);

    //        Vector3[] allVertices = new Vector3[offsetVertices];
    //        Vector3[] allNormals = new Vector3[offsetVertices];
    //        Vector2[] allUV = new Vector2[offsetVertices];
    //        int[] allTriangles = new int[offsetTriangles];

    //        for (i = 0; i < offsetVertices; i++)
    //        {
    //            allVertices[i] = newVertices[i];
    //            allNormals[i] = newNormals[i];
    //            allUV[i] = newUV[i];
    //        }
    //        for (i = 0; i < offsetTriangles; i++)
    //        {
    //            allTriangles[i] = newTriangles[i];
    //        }

    //        //Debug.Log(offsetVertices + " " + offsetTriangles);

    //        //mesh.Clear();
    //        mesh.vertices = allVertices;
    //        mesh.normals = allNormals;
    //        mesh.uv = allUV;
    //        mesh.triangles = allTriangles;
    //    }
    //}

    void Update()
    {
        if (null != startObject)
        {
            //print("I am in");
            Mesh mesh = startObject.GetComponent<MeshFilter>().sharedMesh;
            //mesh.Clear();

            int i;

            newVertices = new Vector3[maxVertices];
            newNormals = new Vector3[maxVertices];
            newUV = new Vector2[maxVertices];
            offsetVertices = 0;
            newTriangles = new int[maxTriangles];
            offsetTriangles = 0;

            //print(ScoreManager.amountOfCollectible);
            LSystem(ScoreManager.instance.amountOfCollectible, startObject.transform.worldToLocalMatrix * startObject.transform.localToWorldMatrix);

            Vector3[] allVertices = new Vector3[offsetVertices];
            Vector3[] allNormals = new Vector3[offsetVertices];
            Vector2[] allUV = new Vector2[offsetVertices];
            int[] allTriangles = new int[offsetTriangles];

            for (i = 0; i < offsetVertices; i++)
            {
                allVertices[i] = newVertices[i];
                allNormals[i] = newNormals[i];
                allUV[i] = newUV[i];
            }
            for (i = 0; i < offsetTriangles; i++)
            {
                allTriangles[i] = newTriangles[i];
            }

            //Debug.Log(Tree.instance.offsetVertices + " " + Tree.instance.offsetTriangles);
            mesh.Clear();
            mesh.vertices = allVertices;
            mesh.normals = allNormals;
            mesh.uv = allUV;
            mesh.triangles = allTriangles;
            //for(int k=0; k<allTriangles.Length; k++)
            //{
            //    print(allTriangles[k]);
            //}
        }
    }



    public void LSystem(int recursion, Matrix4x4 startMatrix)
    {
        Matrix4x4 newStartMatrix = startMatrix * Matrix4x4.identity;
        Matrix4x4 endMatrix;

        if (recursion > ScoreManager.instance.recursionMax + 1)
        {
            return;
        }

            endMatrix = newStartMatrix * Matrix4x4.TRS(new Vector3(0, 1.5f, 0),
              Quaternion.Euler(splitAngle1),
              scale1);

            generateTube(2, 9, newStartMatrix, (recursion + 0) / ScoreManager.instance.recursionMax, endMatrix, (recursion + 1) / ScoreManager.instance.recursionMax);

            LSystem(recursion + 1, endMatrix);



            endMatrix = newStartMatrix * Matrix4x4.TRS(new Vector3(0, 1.5f, 0),
              Quaternion.Euler(splitAngle2),
              scale2);

            generateTube(2, 9, newStartMatrix, (recursion + 0) / ScoreManager.instance.recursionMax, endMatrix, (recursion + 1) / ScoreManager.instance.recursionMax);

            LSystem(recursion + 1, endMatrix);

    }

    void generateTube(int na, int nc, Matrix4x4 startMatrix, float startV, Matrix4x4 endMatrix, float endV)
    {
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        int i;
        int j;
        float t;
        Vector3 startPosition = startMatrix.GetColumn(3);
        Vector3 endPosition = endMatrix.GetColumn(3);
        Vector3 startYAxis = startMatrix.MultiplyVector(new Vector3(0, 1, 0));
        Vector3 endYAxis = endMatrix.MultiplyVector(new Vector3(0, 1, 0));
        Vector3 startXAxis = startMatrix.MultiplyVector(new Vector3(1, 0, 0));
        Vector3 endXAxis = endMatrix.MultiplyVector(new Vector3(1, 0, 0));
        Vector3 startZAxis = startMatrix.MultiplyVector(new Vector3(0, 0, 1));
        Vector3 endZAxis = endMatrix.MultiplyVector(new Vector3(0, 0, 1));
        Vector3 position = Vector3.zero;
        Vector3 previousPosition;
        Vector3 yAxis;
        Vector3 xAxis;
        Matrix4x4 matrix;
        Quaternion q;
        Vector3 tempYAxis;
        Vector3 scaling;
        Vector2 uv;

        if (offsetVertices + nc * na > maxVertices || offsetTriangles + 6 * nc * (na - 1) > maxTriangles)
        {
            Debug.LogWarning("Mesh too large.");
            return;
        }

        // create vertices
        for (j = 0; j < na; j++)
        {
            t = j / (na - 1);

            // compute transformation for circle
            previousPosition = position;
            position = (2 * t * t * t - 3 * t * t + 1) * startPosition
             + (t * t * t - 2 * t * t + t) * startYAxis * 2
             + (-2 * t * t * t + 3 * t * t) * endPosition
             + (t * t * t - t * t) * endYAxis * 2;

            if (0 == j)
            {
                yAxis = startYAxis.normalized;
            }
            else if (j == na - 1)
            {
                yAxis = endYAxis.normalized;
            }
            else
            {
                yAxis = (position - previousPosition).normalized;
            }
            xAxis = (1 - t) * startXAxis + t * endXAxis;
            scaling = new Vector3((1 - t) * startXAxis.magnitude + t * endXAxis.magnitude,
                (1 - t) * startYAxis.magnitude + t * endYAxis.magnitude,
                (1 - t) * startZAxis.magnitude + t * endZAxis.magnitude);

            q = Quaternion.FromToRotation(new Vector3(1, 0, 0), xAxis.normalized); // rotate x axis as needed
            tempYAxis = Matrix4x4.TRS(new Vector3(0, 0, 0), q, new Vector3(1, 1, 1)).MultiplyVector(new Vector3(0.0f, 1.0f, 0.0f)); // y axis rotated by q
            q = Quaternion.FromToRotation(tempYAxis, yAxis) * q; // this rotates the y axis to where it should be and the x axis should be correct, too (if possible)
            matrix = Matrix4x4.TRS(position, q, scaling);

            // set vertices
            for (i = 0; i < nc; i++)
            {
                float phi;

                phi = i * 2 * Mathf.PI / (nc - 1);

                newVertices[offsetVertices + j * nc + i] = matrix.MultiplyPoint(new Vector3(Mathf.Cos(phi), 0, -Mathf.Sin(phi)));
                newNormals[offsetVertices + j * nc + i] = matrix.inverse.transpose.MultiplyVector(new Vector3(Mathf.Cos(phi), 0, -Mathf.Sin(phi)));
                newUV[offsetVertices + j * nc + i] = new Vector2(i / (nc - 1), (1 - t) * startV + t * endV);
            }
        }

        // create triangles 	
        for (j = 0; j < na - 1; j++)
        {
            for (i = 0; i < nc - 1; i++)
            {
                newTriangles[offsetTriangles + (j * nc + i) * 6 + 0] = offsetVertices + j * nc + i;
                newTriangles[offsetTriangles + (j * nc + i) * 6 + 1] = offsetVertices + (j + 1) * nc + (i + 1);
                newTriangles[offsetTriangles + (j * nc + i) * 6 + 2] = offsetVertices + (j + 1) * nc + i;
                newTriangles[offsetTriangles + (j * nc + i) * 6 + 3] = offsetVertices + j * nc + i;
                newTriangles[offsetTriangles + (j * nc + i) * 6 + 4] = offsetVertices + j * nc + (i + 1);
                newTriangles[offsetTriangles + (j * nc + i) * 6 + 5] = offsetVertices + (j + 1) * nc + (i + 1);
            }
        }

        offsetVertices = offsetVertices + nc * na;
        offsetTriangles = offsetTriangles + 6 * nc * (na - 1);
    }
}
