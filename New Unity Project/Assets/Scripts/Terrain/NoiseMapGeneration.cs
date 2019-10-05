using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMapGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [System.Serializable]
    public class Wave
    {
        public float m_Seed;
        public float m_Frequency;
        public float m_Amplitude;
    }

    public float[,] GeneratePerlinNoiseMap( int _MapDepth, int _MapWidth, float _Scale, float _OffsetX, float _OffsetZ, Wave[] _Waves)
    {
        float[,] m_NoiseMap = new float[_MapDepth, _MapWidth];

        for (int m_Z = 0; m_Z < _MapDepth; m_Z++)
        {
            for (int m_X = 0; m_X< _MapWidth; m_X++)
            {
                float m_TempX = (m_X + _OffsetX) / _Scale;
                float m_Tempz = (m_Z + _OffsetZ)/ _Scale;

                //float m_Noise = Mathf.PerlinNoise(m_TempX, m_Tempz);
                float m_Noise = 0f;
                float normalization = 0f;
                foreach (Wave wave in _Waves)
                {
                    // generate noise value using PerlinNoise for a given Wave
                    m_Noise += wave.m_Amplitude * Mathf.PerlinNoise(m_TempX * wave.m_Frequency + wave.m_Seed, m_Tempz * wave.m_Frequency + wave.m_Seed);
                    normalization += wave.m_Amplitude;
                }
                // normalize the noise value so that it is within 0 and 1
                m_Noise /= normalization;

                m_NoiseMap[m_Z, m_X] = m_Noise;
            }
        }
        return m_NoiseMap;
    }

    public float[,] GenerateUniformNoiseMap(int _MapDepth, int _MapWidth, float _CenterVertexZ, float _MaxDistanceZ, float _OffsetZ)
    {
        float[,] m_NoiseMap = new float[_MapDepth, _MapWidth];

        for (int m_z = 0; m_z < _MapDepth; m_z++)
        {
            float m_TempZ = m_z + _OffsetZ;
            float m_Noise = Mathf.Abs(m_TempZ - _CenterVertexZ) / _MaxDistanceZ;

            for(int m_X = 0; m_X < _MapWidth; m_X++)
            {
                m_NoiseMap[_MapDepth - m_z - 1, m_X] = m_Noise;
            }
        }
        return m_NoiseMap;
    }
}
