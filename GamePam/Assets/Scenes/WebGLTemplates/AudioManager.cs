
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [System.Serializable]
    public class Sound
    {
        public string name; // �������§
        public AudioClip clip; // ��Ի���§
        [Range(0f, 1f)] public float volume = 1f; // �дѺ���§
        public bool loop = false;
        [Range(0f, 1f)] public float spatialBlend = 0f; // �дѺ������ 3D (0 = 2D, 1 = 3D)
        public float minDistance = 1f; // ���Т�鹵�ӷ�����§�дѧ������
        public float maxDistance = 500f; // ���з�����§�����Ŵŧ
    }

    public List<Sound> sounds = new List<Sound>(); // ��¡�����§

    private Dictionary<string, AudioSource> soundSources = new Dictionary<string, AudioSource>();

    private void Awake()
    {
        // ����� AudioManager �� Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // ���� AudioSource ���Ѻ���§������
        foreach (var sound in sounds)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = sound.clip;
            source.volume = sound.volume;
            source.loop = sound.loop;
            soundSources[sound.name] = source;
        }
    }

    // ������§�������
    public void PlaySound(string name)
    {
        if (soundSources.ContainsKey(name))
        {
            AudioSource source = soundSources[name];
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
        else
        {
            Debug.LogWarning($"Sound {name} not found!");
        }
    }

    // ��ش���§�������
    public void StopSound(string name)
    {
        if (soundSources.ContainsKey(name))
        {
            soundSources[name].Stop();
        }
    }

    // ��駤���дѺ���§ (�� ����١�õ�駤��)
    public void SetVolume(float volume)
    {
        foreach (var source in soundSources.Values)
        {
            source.volume = volume;
        }
    }
}
