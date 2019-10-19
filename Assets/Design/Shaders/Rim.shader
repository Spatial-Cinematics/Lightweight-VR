Shader "CStamp/Rim"
{
    Properties {
        _MainColor ("Main Color", Color) = (1,1,1,1)
        _RimColor ("Rim Color", Color) = (0, .5, .5, .5)
        _RimPower ("Rim Power", Range(.5, 8)) = 3
    }

    SubShader{

        CGPROGRAM
        #pragma surface surf Lambert

        struct Input {
            float3 viewDir;
        };

        float4 _RimColor;
        float4 _MainColor;
        float _RimPower;

        void surf(Input IN, inout SurfaceOutput o){
            half rim = 1 - saturate(dot(normalize(IN.viewDir), o.Normal));
            o.Emission = _RimColor.rgb * pow(rim, _RimPower);
            o.Albedo = _MainColor * rim;
        }
        ENDCG
    }
    Fallback "Diffuse"
}