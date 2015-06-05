using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawLine : MonoBehaviour {

	private LineRenderer lineRenderer;
	private float counter;
	private float dist;

	private Vector3 prevPos;

	public Transform origin;
	public Transform dest;
	public Vector2 lineWidth=new Vector2(0.45f, 0.45f);
	public float frac=0.1f;
	public Material material;

	public float lineDrawSpeed;
	//public List<LineRenderer> lineParts;
	public List<GameObject> lineComparts;
	private List<Vector3> pA;
	private List<Vector3> pB;

	private int c=0;

	// Use this for initialization
	void Start () {
		//lineRenderer = GetComponent<LineRenderer> ();
		//lineRenderer.SetPosition (0, origin.position);
		prevPos = origin.position;
		//lineRenderer.SetWidth (lineWidth.x,lineWidth.y);
		dist = Vector3.Distance (origin.position, dest.position);
		Debug.Log ("origin, X= " + origin.position.x.ToString ()+", Y= "+origin.position.y.ToString ()+", Z= "+origin.position.z.ToString ());
		Debug.Log ("dest, X= " + dest.position.x.ToString ()+", Y= "+dest.position.y.ToString ()+", Z= "+dest.position.z.ToString ());
		//		lineParts = new List<LineRenderer> ();
		lineComparts = new List<GameObject> ();

		//compute line components coordinates
		pA= new List<Vector3> ();
		pB= new List<Vector3> ();
		int t = 0;
		while (t++<10) {
			pA.Add(prevPos);
			Vector3 offset=frac * (dest.position-origin.position);
			//Debug.Log ("offset, X= " + offset.x.ToString ()+", Y= "+offset.y.ToString ()+", Z= "+offset.z.ToString ());
			pB.Add( offset + prevPos);
			prevPos=pB[pB.Count-1];
		}
		Debug.Log ("pA.Count= " + pA.Count.ToString ());
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		if (counter < dist) {
		if (c < pA.Count-1) {
			lineComparts.Add (new GameObject ("line"));
			LineRenderer lr = lineComparts [lineComparts.Count - 1].AddComponent<LineRenderer> ();
			//lineParts.Add(lr);
			lr.SetWidth (lineWidth.x,lineWidth.y);
			//Material material = (Material)Resources.Load("Materials/Line", typeof(Material));

			Debug.Log ("mat length="+ lr.materials.Length.ToString());
			//lr.materials.SetValue(material,0);
			lr.materials[0]= material;
			lr.sharedMaterial=material;
			Debug.Log (material.ToString());
			Debug.Log (lr.materials[0].ToString());
			//lineComparts [lineComparts.Count - 1].renderer.material= material;
			lr.SetPosition (0, pA[c]);
			lr.SetPosition (1, pB[c]);
			c++;

//			counter += .001f / lineDrawSpeed;
//			float x = Mathf.Lerp (prevPos, dist, counter);
//			Vector3 pointAlongLine = x * Vector3.Normalize (dest.position - origin.position) + prevPos;
//			lr.SetPosition (1, pointAlongLine);
//			prevPos = pointAlongLine;
//		}
//			counter+=.001f/lineDrawSpeed;
//			float x=Mathf.Lerp(0,dist,counter);
//			Vector3 pointAlongLine=x * Vector3.Normalize(dest.position-origin.position) + origin.position;
//			lineRenderer.SetPosition(1,pointAlongLine);
		}
	
	}
//	public void StartDrawing(){
//		//lineRenderer = GetComponent<LineRenderer> ();
//		lineRenderer.SetPosition (0, origin.position);
//		//lineRenderer.SetWidth (0.45f, 0.45f);
//		dist = Vector3.Distance (origin.position, dest.position);
//
//	}
}
