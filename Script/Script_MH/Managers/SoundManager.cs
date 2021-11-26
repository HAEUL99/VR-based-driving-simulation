using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ü ���ӿ��� ũ�� �� ������ϴ� �Ҹ� 
// �ڵ��� ���� �Ҹ�

public class SoundManager
{
    AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount];
    // Dictionary�� �̸� ȿ���� Ŭ������ �ε��Ͽ� ���� 
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    public void Init()
    {
        GameObject root = GameObject.Find("@Sound");

        if (root == null)
        {
            root = new GameObject { name = "@Sound" };
            Object.DontDestroyOnLoad(root);

            string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));
            for (int i = 0; i < soundNames.Length - 1; i++)
            {
                GameObject go = new GameObject { name = soundNames[i] };
                _audioSources[i] = go.AddComponent<AudioSource>(); // audioSource���� component ����
                go.transform.parent = root.transform;
            }

            _audioSources[(int)Define.Sound.Background].loop = true; // Background ���� ��� 
            _audioSources[(int)Define.Sound.Background].volume = 0.5f;
        }
    }

    // AudioClip�� �޾Ƽ� ����� ��� 
    public void Play(AudioClip audioClip, Define.Sound type = Define.Sound.LowEngine, float pitch = 1.0f, float volume = 1.0f)
    {
        AudioSource audioSource = null;

        if (audioClip == null)
            return;

        // Background ��� Ʋ�� �������� �ѹ� �� ȿ���� 
        if (type == Define.Sound.Background || type == Define.Sound.Idle)
        {
            audioSource = _audioSources[(int)Define.Sound.Background];
            // ���� ����ǰ� �ִ� ���� ����
            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            audioSource.Play();

        }
        else
        {
            audioSource = _audioSources[(int)type];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip); // �ѹ��� Ʋ��
            audioSource.volume = volume; // �ش� �������� 
        }

    }

    // path�� �޾Ƽ� ���� ���
    public void Play(string path, Define.Sound type = Define.Sound.LowEngine, float pitch = 1.0f, float volume = 1.0f)
    {
        AudioClip audioClip = GetOrAddAudioClip(path, type);
        Play(audioClip, type, pitch, volume);
    }

    AudioClip GetOrAddAudioClip(string path, Define.Sound type = Define.Sound.LowEngine)
    {
        if (path.Contains("Sounds/") == false)
            path = $"Sounds/{path}";

        AudioClip audioClip = null;

        if (type == Define.Sound.Background)
        {
            audioClip = Managers.Resource.Load<AudioClip>(path);
        }
        else
        {
            if(_audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = Managers.Resource.Load<AudioClip>(path);
                _audioClips.Add(path, audioClip);
            }
        }

        if (audioClip == null)
            Debug.Log($"AudioClip Missing ! {path}");

        return audioClip;
    } 
    // Audio Clear
    public void Clear()
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
        // Dictionary ����
        _audioClips.Clear();
    }

}
