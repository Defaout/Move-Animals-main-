Shader "Malbers/Color4x4" {
	Properties {
		[Header(Row 1)] _Color1 ("Color 1", Vector) = (1,0.1544118,0.1544118,0.291)
		_Color2 ("Color 2", Vector) = (1,0.1544118,0.8017241,0.253)
		_Color3 ("Color 3", Vector) = (0.2535501,0.1544118,1,0.541)
		_Color4 ("Color 4", Vector) = (0.1544118,0.5451319,1,0.253)
		[Header(Row 2)] _Color5 ("Color 5", Vector) = (0.9533468,1,0.1544118,0.553)
		_Color6 ("Color 6", Vector) = (0.2720588,0.1294625,0,0.097)
		_Color7 ("Color 7", Vector) = (0.1544118,0.6151115,1,0.178)
		_Color8 ("Color 8", Vector) = (0.4849697,0.5008695,0.5073529,0.078)
		[Header(Row 3)] _Color9 ("Color 9", Vector) = (0.3164301,0,0.7058823,0.134)
		_Color10 ("Color 10", Vector) = (0.362069,0.4411765,0,0.759)
		_Color11 ("Color 11", Vector) = (0.6691177,0.6691177,0.6691177,0.647)
		_Color12 ("Color 12", Vector) = (0.5073529,0.1574544,0,0.128)
		[Header(Row 4)] _Color13 ("Color 13", Vector) = (1,0.5586207,0,0.272)
		_Color14 ("Color 14", Vector) = (0,0.8025862,0.875,0.047)
		_Color15 ("Color 15", Vector) = (1,0,0,0.391)
		_Color16 ("Color 16", Vector) = (0.4080882,0.75,0.4811866,0.134)
		[Header(Emmision)] [HDR] _Color15Emmision ("Color 15 Emmision", Vector) = (0,0,0,1)
		[HDR] _Color16Emmision ("Color 16 Emmision", Vector) = (0,0,0,1)
		[Header(Smoothness (Alphas))] _Smoothness ("Smoothness", Range(0, 1)) = 1
		_Metallic ("Metallic", Range(0, 1)) = 0
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