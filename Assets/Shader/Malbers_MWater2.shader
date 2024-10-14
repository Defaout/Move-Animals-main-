Shader "Malbers/MWater2" {
	Properties {
		_WaterColor ("WaterColor", Vector) = (0.2074582,0.2643323,0.3962264,1)
		_EdgeColor ("Edge Color", Vector) = (0.7768779,0.7869238,0.8113208,1)
		[Normal] _WaterNormal ("Water Normal", 2D) = "bump" {}
		_NormalScale ("Normal Scale", Float) = 0
		_Specular ("Specular", Float) = 0
		_Smoothness ("Smoothness", Float) = 0
		_Distortion ("Distortion", Float) = 0.5
		_EdgeDistance ("Edge Distance", Float) = 0.24
		_EdgeStrength ("Edge Strength", Float) = 0.24
		_Wave1Tile ("Wave1 Tile", Float) = 1
		_Wave2Tile ("Wave2 Tile", Float) = 1
		[HideInInspector] __dirty ("", Float) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = 1;
		}
		ENDCG
	}
	//CustomEditor "ASEMaterialInspector"
}