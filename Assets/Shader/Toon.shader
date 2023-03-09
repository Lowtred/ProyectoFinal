Shader "Diplomado/Toon"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        //_MainTex("Color", COLOR) = (1,1,1,1)
        [Space(10)]
        _OutColor("Outline Color", Color) = (1,1,1,1)
        _OutValue("Outline Value", Range(0.0, 0.2)) = 0.03
        _Brightness("Brightness", Range(0,1))=0.3
        _Strength("Strength", range(0,1))=0.5
        _Color("Color", COLOR)=(1,1,1,1)
        _Detail("Detail",Range(0,1))=0.3
    }
        SubShader
        {
            //Outline pass
            Pass
            {
                Tags
                {
                    "Queue" = "Transparent"
                }

                Blend SrcAlpha OneMinusSrcAlpha
                Zwrite Off

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float4 _OutColor;
                float _OutValue;

                float4 outline(float4 vertexPos, float outValue)
                {
                    float4x4 scale = float4x4
                    (
                            1 + outValue, 0, 0, 0,
                            0, 1 + outValue, 0, 0,
                            0, 0, 1 + outValue, 0,
                            0, 0, 0, 1 + outValue
                    );
                    return mul(scale, vertexPos);
                }

                v2f vert(appdata v)
                {
                    v2f o;
                    float4 vertexPos = outline(v.vertex, _OutValue);
                    o.vertex = UnityObjectToClipPos(vertexPos);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    // sample the texture
                    fixed4 col = tex2D(_MainTex, i.uv);
                return float4(_OutColor.r,_OutColor.g,_OutColor.b, col.a);
                }
                ENDCG
            }
            //Texture pass
            Pass
            {
                Tags
                {
                    "Queue" = "Transparent+1"
                }

                Blend SrcAlpha OneMinusSrcAlpha

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                    float normal : NORMAL;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                    half3 worldNormal: NORMAL;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float _Brightness;
                float _Strength;
                float4 _Color;
                float _Detail;

                float Toon(float3 normal, float3 lightDir)
                {
                    float NdotL = max(0.0,dot(normalize(normal),normalize(lightDir)));
                    return floor(NdotL/_Detail);
                }

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    o.worldNormal = UnityObjectToWorldNormal(v.normal);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    // sample the texture
                    fixed4 col = tex2D(_MainTex, i.uv);
                    col *= Toon(i.worldNormal, _WorldSpaceLightPos0.xyz)*_Strength*_Color+_Brightness;
                    return col;
                }
                ENDCG
            }
        }
}