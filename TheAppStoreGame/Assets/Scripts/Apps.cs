using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apps //: App

{

	public App app1 = new App("App 1", "Text för app 1", Resources.Load<Sprite>("PAWsitive"), "Konsekvens för app1");
	public App app2 = new App("App 2", "Text för app 2", Resources.Load<Sprite>("PAWsitive"), "Konsekvens för app2");
	public App app3 = new App("App 3", "Text för app 3", Resources.Load<Sprite>("PAWsitive"), "Konsekvens för app3");

}

