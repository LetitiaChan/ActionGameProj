using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// 音频管理类（项目中音频剪辑统一管理）
/// 使用说明：
///     空对象_AudioManager，挂组件AudioListener、3个AudioSource（去勾PlayOnAwake）、本脚本
///     对于大的音频文件（背景音乐），采用PlayBackground(AudioClip audioClip)方式
/// </summary>
public class AudioManager : MonoBehaviour
{
    #region Unity Inspector Fields
    public AudioClip[] AudioClipArray;                                         //剪辑数组
    #endregion

    private static float _AudioBackgroundVolumns = 1f;
    private static float _AudioEffectVolumns = 1f;
    private static Dictionary<string, AudioClip> _DicAudioClipLib;
    private static AudioSource[] _AudioSourceArray;
    private static AudioSource _AudioSource_BackgroundAudioA;
    private static AudioSource _AudioSource_BackgroundAudioB;
    private static AudioSource _AudioSource_AudioEffectA;
    private static AudioSource _AudioSource_AudioEffectB;

    public static float AudioBackgroundVolumns
    {
        get
        {
            return _AudioBackgroundVolumns;
        }

        set
        {
            _AudioBackgroundVolumns = Mathf.Clamp01(value);

            _AudioSource_BackgroundAudioA.volume = _AudioBackgroundVolumns;

            PlayerPrefs.SetFloat("AudioBackgroundVolumns", _AudioBackgroundVolumns);
            PlayerPrefs.Save();
        }
    }

    public static float AudioEffectVolumns
    {
        get
        {
            return _AudioEffectVolumns;
        }

        set
        {
            _AudioEffectVolumns = Mathf.Clamp01(value);

            _AudioSource_AudioEffectA.volume = _AudioEffectVolumns;
            _AudioSource_AudioEffectB.volume = _AudioEffectVolumns;

            PlayerPrefs.SetFloat("AudioEffectVolumns", _AudioEffectVolumns);
            PlayerPrefs.Save();
        }
    }


    void Awake()
    {
        //音频库加载
        _DicAudioClipLib = new Dictionary<string, AudioClip>();
        foreach (AudioClip audioClip in AudioClipArray)
        {
            _DicAudioClipLib.Add(audioClip.name, audioClip);
        }
        //处理音频源
        _AudioSourceArray = this.GetComponents<AudioSource>();
        _AudioSource_BackgroundAudioA = _AudioSourceArray[0];
        _AudioSource_BackgroundAudioB = _AudioSourceArray[1];
        _AudioSource_AudioEffectA = _AudioSourceArray[2];
        _AudioSource_AudioEffectB = _AudioSourceArray[3];

        //从数据持久化中得到音量数值
        if (PlayerPrefs.GetFloat("AudioBackgroundVolumns") >= 0)
        {
            AudioBackgroundVolumns = PlayerPrefs.GetFloat("AudioBackgroundVolumns");
        }
        if (PlayerPrefs.GetFloat("AudioEffectVolumns") >= 0)
        {
            AudioEffectVolumns = PlayerPrefs.GetFloat("AudioEffectVolumns");
        }
    }

    public static void PlayBackgroundA(AudioClip audioClip)
    {
        if (_AudioSource_BackgroundAudioA.clip == audioClip)
        {
            return;
        }
        //处理全局背景音乐音量
        _AudioSource_BackgroundAudioA.volume = AudioBackgroundVolumns;
        if (audioClip)
        {
            _AudioSource_BackgroundAudioA.loop = true;
            _AudioSource_BackgroundAudioA.clip = audioClip;
            _AudioSource_BackgroundAudioA.Play();
        }
        else
        {
            Debug.LogWarning("[AudioManager.cs/PlayBackgroundA()] audioClip==null !");
        }
    }
    public static void PlayBackgroundA(string strAudioName)
    {
        if (!string.IsNullOrEmpty(strAudioName))
        {
            PlayBackgroundA(_DicAudioClipLib[strAudioName]);
        }
        else
        {
            Debug.LogWarning("[AudioManager.cs/PlayBackgroundA()] strAudioName==null !");
        }
    }
    public static void PlayBackgroundB(AudioClip audioClip)
    {
        if (_AudioSource_BackgroundAudioB.clip == audioClip)
        {
            return;
        }
        //处理全局背景音乐音量
        _AudioSource_BackgroundAudioB.volume = AudioBackgroundVolumns;
        if (audioClip)
        {
            _AudioSource_BackgroundAudioB.loop = true;
            _AudioSource_BackgroundAudioB.clip = audioClip;
            _AudioSource_BackgroundAudioB.Play();
        }
        else
        {
            Debug.LogWarning("[AudioManager.cs/PlayBackgroundB()] audioClip==null !");
        }
    }
    public static void PlayBackgroundB(string strAudioName)
    {
        if (!string.IsNullOrEmpty(strAudioName))
        {
            PlayBackgroundB(_DicAudioClipLib[strAudioName]);
        }
        else
        {
            Debug.LogWarning("[AudioManager.cs/PlayBackgroundB()] strAudioName==null !");
        }
    }


    public static void PlayAudioEffectA(AudioClip audioClip)
    {
        //处理全局音效音量
        _AudioSource_AudioEffectA.volume = AudioEffectVolumns;

        if (audioClip)
        {
            _AudioSource_AudioEffectA.clip = audioClip;
            _AudioSource_AudioEffectA.Play();
        }
        else
        {
            Debug.LogWarning("[AudioManager.cs/PlayAudioEffectA()] audioClip==null ! Please Check! ");
        }
    }


    public static void PlayAudioEffectB(AudioClip audioClip)
    {
        //处理全局音效音量
        _AudioSource_AudioEffectB.volume = AudioEffectVolumns;

        if (audioClip)
        {
            _AudioSource_AudioEffectB.clip = audioClip;
            _AudioSource_AudioEffectB.Play();
        }
        else
        {
            Debug.LogWarning("[AudioManager.cs/PlayAudioEffectB()] audioClip==null ! Please Check! ");
        }
    }


    public static void PlayAudioEffectA(string strAudioEffctName)
    {
        if (!string.IsNullOrEmpty(strAudioEffctName))
        {
            PlayAudioEffectA(_DicAudioClipLib[strAudioEffctName]);
        }
        else
        {
            Debug.LogWarning("[AudioManager.cs/PlayAudioEffectA()] strAudioEffctName==null ! Please Check! ");
        }
    }


    public static void PlayAudioEffectB(string strAudioEffctName)
    {
        if (!string.IsNullOrEmpty(strAudioEffctName))
        {
            PlayAudioEffectB(_DicAudioClipLib[strAudioEffctName]);
        }
        else
        {
            Debug.LogWarning("[AudioManager.cs/PlayAudioEffectB()] strAudioEffctName==null ! Please Check! ");
        }
    }

}