Shader "Malbers/Color4x3" {
	Properties {
		[Header(Row 1)] _Color1 ("Color 1", Vector) = (1,0.1544118,0.1544118,0.397)
		_Color2 ("Color 2", Vector) = (1,0.1544118,0.8017241,0.334)
		_Color3 ("Color 3", Vector) = (0.2535501,0.1544118,1,0.228)
		_Color4 ("Color 4", Vector) = (0.1544118,0.5451319,1,0.472)
		[Header(Row 2)] _Color5 ("Color 5", Vector) = (0.9533468,1,0.1544118,0.353)
		_Color6 ("Color 6", Vector) = (0.2669384,0.3207547,0.0226949,0.341)
		_Color7 ("Color 7", Vector) = (0.1544118,0.6151115,1,0.316)
		_Color8 ("Color 8", Vector) = (0.4849697,0.5008695,0.5073529,0.484)
		[Header(Row 3)] _Color9 ("Color 9", Vector) = (0.9099331,0.9264706,0.6267301,0.353)
		_Color10 ("Color 10", Vector) = (0.1544118,0.1602434,1,0.341)
		_Color11 ("Color 11", Vector) = (1,0.1544118,0.381846,0.316)
		_Color12 ("Color 12", Vector) = (0.02270761,0.1632713,0.2205882,0.484)
		[Header(Smoothness (Alphas))] _Smoothness ("Smoothness", Range(0, 1)) = 1
		_Metallic ("Metallic", Range(0, 1)) = 0
		[Header(Emmision)] [HDR] _Color11Emmision ("Color 11 Emmision", Vector) = (0,0,0,1)
		[HDR] _Color12Emmision ("Color 12 Emmision", Vector) = (0,0,0,1)
		[Header(Gradient)] _Gradient ("Gradient", 2D) = "white" {}
		_GradientIntensity ("Gradient Intensity", Range(0, 1)) = 0.75
		_GradientColor ("Gradient Color", Vector) = (0,0,0,0)
		_GradientScale ("Gradient Scale", Float) = 1
		_GradientOffset ("Gradient Offset", Float) = 0
		_GradientPower ("Gradient Power", Float) = 1
		[HideInInspector] _texcoord ("", 2D) = "white" {}
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
	Fallback "Diffuse"
	//CustomEditor "ASEMaterialInspector"
}