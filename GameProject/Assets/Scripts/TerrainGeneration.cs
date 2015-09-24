using UnityEngine;
using System.Collections;

public class TerrainGeneration : MonoBehaviour {
	
	public GameObject block;
	public GameObject Dirt;
	public GameObject Rock;
	public GameObject Grass;
	public GameObject M1;
	public GameObject Air;
	public GameObject M2;
	public GameObject M3;
	public GameObject M4;

	private float DirtI;
	private float RockI;
	private float GrassI;
	public int aX;
	public int aY;
	public GameObject[,] pnoise;
	public GameObject[,] pnoise1;
	public int seed;
	// Use this for initialization
	void OnEnable () {
		pnoise = new GameObject[aX, aY];
		//pnoise1 = new GameObject[aX, aY];
		Random.seed = seed;
		for (int y=0 ; y<aY ; y++){
			for (int x=0 ; x<aX ; x++){
				DirtI = Random.Range(1,2);
				RockI = Random.Range(0,1);
				GrassI = Random.Range(2,3);
				//float octave1 = intensity/100f;
				//intensity = Mathf.Sin(x/20.0f*Mathf.PI)*Mathf.Sin(y/20.0f*Mathf.PI);



				//Instantiate The Surface Level Octave 2
				pnoise[x,y] = Instantiate(Rock, new Vector3(x*100f,RockI*1f, y*100f), Quaternion.identity) as GameObject;
				pnoise[x,y] = Instantiate(Dirt, new Vector3(x*100f,DirtI*2f, y*100f), Quaternion.identity) as GameObject;

				if(GrassI == 2) {
				int t = Random.Range(0,4);

					if(t == 0) {
						pnoise[x,y] = Instantiate(M1, new Vector3(x*100f,GrassI*1f, y*100f), Quaternion.identity) as GameObject;
					}
					if(t == 1) {
						pnoise[x,y] = Instantiate(M2, new Vector3(x*100f,GrassI*1f,y*100f), Quaternion.identity) as GameObject;

					}
					if(t == 2) {
						pnoise[x,y] = Instantiate(M3, new Vector3(x*100f,GrassI*1f,y*100f), Quaternion.identity) as GameObject;
					}
					if(t == 3) {
						pnoise[x,y] = Instantiate(M4, new Vector3(x*100f,GrassI*1f,y*100f), Quaternion.identity) as GameObject;
					}
				}
				//Instantiate Bedrock level Octave 1
				

				//pnoise[x,y].GetComponent<Renderer>().material.color = new Color(0,1,0,1);
				//pnoise[x,y].GetComponent<Renderer>().material.color = new Color(RockI,intensity2,intensity2,1);

				
			}
		}
	}
	
}

