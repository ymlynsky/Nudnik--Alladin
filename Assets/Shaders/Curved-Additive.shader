Shader "Mobile/Aladdin Project/Curved-Additive" {
    
   Properties {
	_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
	_MainTex ("Particle Texture", 2D) = "white" {}
	_InvFade ("Soft Particles Factor", Range(0.01,3.0)) = 1.0
	_QOffset ("Offset", Vector) = (0,0,0,0)
    _Dist ("Distance", Float) = 100.0
}

Category {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	Blend SrcAlpha One
	AlphaTest Greater .01
	ColorMask RGB
	Cull Off Lighting Off ZWrite Off
	
	SubShader {
		Pass {
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_particles

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			fixed4 _TintColor;
			uniform float4 _QOffset;
       		uniform float _Dist;
        
			struct appdata_t {
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
			};
			
			float4 _MainTex_ST;

			v2f vert (appdata_t v)
			{
			   v2f o;
			   float4 vPos = mul (UNITY_MATRIX_MV, v.vertex);
			   float zOff = vPos.z/_Dist;
			   vPos += _QOffset*zOff*zOff;
			  // o.vertex = mul (UNITY_MATRIX_P, vPos);
			   o.vertex=mul(UNITY_MATRIX_MVP,vPos);
			   o.color=v.color;
			   o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
			   return o;
			}

			sampler2D_float _CameraDepthTexture;
			float _InvFade;
			
			fixed4 frag (v2f i) : SV_Target
			{
				
				fixed4 col = 2.0f * i.color * _TintColor * tex2D(_MainTex, i.texcoord);
				return col;
			}
			ENDCG 
		}
	}	
}
    
}
