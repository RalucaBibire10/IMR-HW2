using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class drawingScript : MonoBehaviour
{
    public GameObject chalk;
    public GameObject board;
    public Color c = Color.white;
    private LineRenderer lineRenderer;
    private bool isDrawing = false;
    private List<LineRenderer> lines = new List<LineRenderer>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 chalkPos = chalk.transform.position;
        Vector3 boardPos = board.transform.position;
        Collider boardCollider = board.GetComponent<Collider>();
        Collider chalkCollider = chalk.GetComponent<Collider>();
        /*bool verify = (boardPos[2] - chalkPos[2] < 0.2f &&
        chalkPos[0] < ((boardCollider.bounds.size.x) / 2 - boardPos[0]) &&
        chalkPos[0] > boardPos[0] - (boardCollider.bounds.size.x / 2) &&
        chalkPos[1] > boardCollider.bounds.size.y / 2 &&
        chalkPos[1] < boardCollider.bounds.size.y);*/
        if (boardPos[2] - chalkPos[2] < 0.2f/*chalkCollider.bounds.Intersects(boardCollider.bounds)*/)
        {
            if (!isDrawing)
            {
                lineRenderer = new GameObject().AddComponent<LineRenderer>();
                lineRenderer.SetPosition(0, chalkPos);
                lineRenderer.SetPosition(1, chalkPos);
                lineRenderer.startWidth = 0.1f;
                lineRenderer.endWidth = 0.1f;
                lineRenderer.SetColors(c, c);
                Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
                lineRenderer.material = whiteDiffuseMat;
                lineRenderer.positionCount = 2;
                lines.Add(lineRenderer);
                isDrawing = true;
            }

            lines[lines.Count - 1].positionCount++;
            Vector3 pos = new Vector3(chalkPos[0], chalkPos[1], chalkPos[2]);
            lines[lines.Count - 1].SetPosition(lines[lines.Count - 1].positionCount - 1, pos);

        }
        else
        {
            isDrawing = false;
        }
    }
}
