Shader "Animasi/Warna" {
Properties {
_MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader {
Tags { "RenderType"="Opaque" }
LOD 200

CGPROGRAM
#pragma surface surf Standard fullforwardshadows
#pragma target 3.0

sampler2D _MainTex;

struct Input {
float2 uv_MainTex;
};

void surf (Input IN, inout SurfaceOutputStandard o) {
fixed4 c = tex2D (_MainTex, IN.uv_MainTex);

// Animasi warna
    float time = _Time.y * 1;
    c.rgb = lerp(c.rgb, c.rgb + 1, sin(time));
    
    c.rgb = lerp(c.rgb, c.rgb + float3(0.1, 0.1, 0.1), sin(_Time.y * 1));

o.Albedo = c.rgb;
o.Metallic = 0.0;
o.Smoothness = 0.5;
}
ENDCG
}
Fallback "Diffuse"
}
