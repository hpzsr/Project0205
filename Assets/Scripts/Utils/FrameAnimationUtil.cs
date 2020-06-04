using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameData
{
    public Image image;
    public Sprite[] sprites;
    public Consts.FrameAnimationSpeed speed = Consts.FrameAnimationSpeed.normal;
    public int curIndex = 0;

    public FrameData(Image _image, string path, Consts.FrameAnimationSpeed _speed)
    {
        image = _image;
        speed = _speed;
        sprites = Resources.LoadAll<Sprite>(path);
        image.sprite = sprites[curIndex];
    }
}

public class FrameAnimationUtil : MonoBehaviour
{
    public static FrameAnimationUtil instance = null;
    public List<FrameData> frameDataList = new List<FrameData>();

    static public FrameAnimationUtil getInstance()
    {
        if (FrameAnimationUtil.instance == null)
        {
            GameObject obj = new GameObject();
            FrameAnimationUtil.instance = obj.AddComponent<FrameAnimationUtil>();
            obj.name = "FrameAnimationUtil";
            DontDestroyOnLoad(obj);
        }

        return FrameAnimationUtil.instance;
    }

    void Start()
    {
        InvokeRepeating("Timer_low", 0.1f, 1.0f / 30.0f);
        InvokeRepeating("Timer_normal", 0.1f, 1.0f / 60.0f);
    }

    public void startAnimation(Image _image, string path, Consts.FrameAnimationSpeed _speed)
    {
        if(getFrameData(_image) != null)
        {
            stopAnimation(_image);
        }

        FrameData data = new FrameData(_image, path, _speed);
        frameDataList.Add(data);
    }

    public void stopAnimation(Image _image)
    {
        FrameData data = getFrameData(_image);
        if(data != null)
        {
            frameDataList.Remove(data);
        }
    }

    FrameData getFrameData(Image _image)
    {
        for (int i = 0; i < frameDataList.Count; i++)
        {
            if (frameDataList[i].image == _image)
            {
                return frameDataList[i];
            }
        }

        return null;
    }

    void Timer_low()
    {
        for (int i = 0; i < frameDataList.Count; i++)
        {
            if (frameDataList[i].speed == Consts.FrameAnimationSpeed.low)
            {
                if (frameDataList[i].curIndex >= (frameDataList[i].sprites.Length - 1))
                {
                    frameDataList[i].curIndex = 0;
                }
                else
                {
                    ++frameDataList[i].curIndex;
                }
                frameDataList[i].image.sprite = frameDataList[i].sprites[frameDataList[i].curIndex];
            }
        }
    }

    void Timer_normal()
    {
        for(int i = 0; i < frameDataList.Count; i++)
        {
            if(frameDataList[i].speed == Consts.FrameAnimationSpeed.normal)
            {
                if(frameDataList[i].curIndex >= (frameDataList[i].sprites.Length - 1))
                {
                    frameDataList[i].curIndex = 0;
                }
                else
                {
                    ++frameDataList[i].curIndex;
                }
                frameDataList[i].image.sprite = frameDataList[i].sprites[frameDataList[i].curIndex];
            }
        }
    }
}