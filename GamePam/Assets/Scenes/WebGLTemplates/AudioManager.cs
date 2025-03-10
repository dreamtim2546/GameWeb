
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [System.Serializable]
    public class Sound
    {
        public string name; // ชื่อเสียง
        public AudioClip clip; // คลิปเสียง
        [Range(0f, 1f)] public float volume = 1f; // ระดับเสียง
        public bool loop = false;
        [Range(0f, 1f)] public float spatialBlend = 0f; // ระดับความเป็น 3D (0 = 2D, 1 = 3D)
        public float minDistance = 1f; // ระยะขั้นต่ำที่เสียงจะดังเต็มที่
        public float maxDistance = 500f; // ระยะที่เสียงเริ่มลดลง
    }

    public List<Sound> sounds = new List<Sound>(); // รายการเสียง

    private Dictionary<string, AudioSource> soundSources = new Dictionary<string, AudioSource>();

    private void Awake()
    {
        // ทำให้ AudioManager เป็น Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // เพิ่ม AudioSource ให้กับเสียงทั้งหมด
        foreach (var sound in sounds)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = sound.clip;
            source.volume = sound.volume;
            source.loop = sound.loop;
            soundSources[sound.name] = source;
        }
    }

    // เล่นเสียงตามชื่อ
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

    // หยุดเสียงตามชื่อ
    public void StopSound(string name)
    {
        if (soundSources.ContainsKey(name))
        {
            soundSources[name].Stop();
        }
    }

    // ตั้งค่าระดับเสียง (เช่น ในเมนูการตั้งค่า)
    public void SetVolume(float volume)
    {
        foreach (var source in soundSources.Values)
        {
            source.volume = volume;
        }
    }
}
