using UnityEngine;
using System.Collections;


/// <summary>
/// Eco system UI.
/// Test de dessiner sur le Canvas les triangle correspondant au valeurs de l'EcoSystem
/// ça marche pas...
/// </summary>
public class EcoSystemUI : MonoBehaviour {

	public Canvas drawingCanvas;
	private Texture2D canvasBackground;

	// get the size of the screen
	private int pixels;
	// create a color array
	private Color[] colors;
	private Color pencolor;

	// Use this for initialization
	void Start () {
		canvasBackground = new Texture2D((int)drawingCanvas.transform.localScale.x, (int)drawingCanvas.pixelRect.height);
		pixels = (int)(drawingCanvas.pixelRect.width * drawingCanvas.pixelRect.height );
		colors = new Color[pixels];
		pencolor = Color.black;

		// fill color array with a transparent color
		for (var i = 0; i < pixels; i++) {
			colors[i] = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		line(0, 0, 50, 50);
		canvasBackground.SetPixels(colors, 0); // rem 0
		canvasBackground.Apply(false);
	}

	void OnGUI() {
		// GUI.Box(Rect(xpos, ypos, 120, 120), "");
		GUI.Box(new Rect(0, 0, canvasBackground.width, canvasBackground.height), "");
		// Override the default texture with the custom texture.
		GUI.skin.box.normal.background = canvasBackground;
		
	}

	// Bresenham's line algorithm
	private void line(int x0, int y0, int x1, int y1) {
		var dx = Mathf.Abs(x1 - x0);
		var dy = Mathf.Abs(y1 - y0);
		var sx = (x0 < x1) ? 1 : -1;
		var sy = (y0 < y1) ? 1 : -1;
		var err = dx - dy;
		while (true) {
			
			// Do what you need to for this
			// setPixel(x0,y0);
			colors[x0 + Screen.width * y0] = pencolor;
			
			if ((x0 == x1) && (y0 == y1))
				break;
			var e2 = 2 * err;
			if (e2 > -dy) {
				err -= dy;
				x0 += sx;
			}
			if (e2 < dx) {
				err += dx;
				y0 += sy;
			}
		}
	}
}
