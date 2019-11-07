package com.zagayevskiy.pacman;

import android.content.res.AssetManager;

public class PacmanLib {
	
	static{
		System.loadLibrary("Pacman");
	}
	
	public static final String tag = "Pacman";
	
	public static native void init(int width, int height, PngManager pngManager, AssetManager assetManager, StoreManager storeManager);
	public static native void step();
	
	public static native void actionUp(float x, float y);
	public static native void actionDown(float x, float y);
	public static native void actionMove(float x, float y);
	public static native boolean stop();
	
	public static native void free();
}
