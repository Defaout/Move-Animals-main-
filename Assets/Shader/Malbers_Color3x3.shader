Shader "Malbers/Color3x3" {
	Properties {
		[Header(Albedo (A Gradient))] _Color1 ("Color 1", Vector) = (1,0.1544118,0.1544118,0)
		_Color2 ("Color 2", Vector) = (1,0.1544118,0.8017241,1)
		_Color3 ("Color 3", Vector) = (0.2535501,0.1544118,1,1)
		[Space(10)] _Color4 ("Color 4", Vector) = (0.9533468,1,0.1544118,1)
		_Color5 ("Color 5", Vector) = (0.2669384,0.3207547,0.0226949,1)
		_Color6 ("Color 6", Vector) = (1,0.4519259,0.1529412,1)
		[Space(10)] _Color7 ("Color 7", Vector) = (0.9099331,0.9264706,0.6267301,1)
		_Color8 ("Color 8", Vector) = (0.1544118,0.1602434,1,1)
		_Color9 ("Color 9", Vector) = (0.1529412,0.9929401,1,1)
		[Header(Metallic(R) Rough(G) Emmission(B))] _MRE1 ("MRE 1", Vector) = (0,1,0,0)
		_MRE2 ("MRE 2", Vector) = (0,1,0,0)
		_MRE3 ("MRE 3", Vector) = (0,1,0,0)
		[Space(10)] _MRE4 ("MRE 4", Vector) = (0,1,0,0)
		_MRE5 ("MRE 5", Vector) = (0,1,0,0)
		_MRE6 ("MRE 6", Vector) = (0,1,0,0)
		[Space()] _MRE7 ("MRE 7", Vector) = (0,1,0,0)
		_MRE8 ("MRE 8", Vector) = (0,1,0,0)
		_MRE9 ("MRE 9", Vector) = (0,1,0,0)
		[Header(Emmision)] _EmissionPower ("Emission Power", Float) = 1
		[SingleLineTexture] [Header(Gradient)] _Gradient ("Gradient", 2D) = "white" {}
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
}