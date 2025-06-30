Shader "Unlit/estatica"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _NoiseStrength ("Noise Strength", Range(0,1)) = 0.3
        _GlitchAmount ("Glitch Amount", Range(0,1)) = 0.05
        _Speed ("Speed", Float) = 20
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _NoiseStrength;
            float _GlitchAmount;
            float _Speed;

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

            float rand(float2 co)
            {
                return frac(sin(dot(co.xy ,float2(12.9898,78.233))) * 43758.5453);
            }

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;

                // Glitch horizontal offset
                float glitch = rand(float2(_Time.y * _Speed, uv.y)) * _GlitchAmount;
                uv.x += glitch;

                // Sample texture
                fixed4 col = tex2D(_MainTex, uv);

                // Estática (ruido blanco)
                float noise = rand(float2(_Time.y * _Speed * 1.5, uv.y));
                col.rgb += (noise - 0.5) * _NoiseStrength;

                // Blanco y negro
                float gray = dot(col.rgb, float3(0.299, 0.587, 0.114));
                return fixed4(gray, gray, gray, col.a);
            }
            ENDHLSL
        }
    }
}
