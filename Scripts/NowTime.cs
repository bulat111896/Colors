using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NowTime : MonoBehaviour
{
    public GameObject Video, Tim, Number_txt;
    private DateTime datetime;
    private long fractPart, intPart, seconds;

    public void OnApplicationFocus()
    {
        StopAllCoroutines();
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return null;
        GetNetworkTime();
        PlayerPrefs.SetInt("VideoNowTime", 1);
        if (!PlayerPrefs.HasKey("LastDate"))
            PlayerPrefs.SetString("LastDate", seconds.ToString());
        intPart = seconds - Convert.ToInt64(PlayerPrefs.GetString("LastDate"));
        if (intPart < 57600)
        {
            datetime = new DateTime().AddSeconds(57600 - intPart);
            while (datetime.Hour + datetime.Minute + datetime.Second > 0)
            {
                datetime = datetime.AddSeconds(-1);
                if (PlayerPrefs.GetInt("VideoPosition") == 1)
                    Tim.GetComponent<Text>().text = datetime.Hour.ToString("00") + ":" + datetime.Minute.ToString("00") + ":" + datetime.Second.ToString("00");
                yield return new WaitForSeconds(1);
            }
        }
        PlayerPrefs.SetInt("Views", 0);
        PlayerPrefs.SetString("LastDate", seconds.ToString());
        Tim.GetComponent<Text>().text = "";
        Number_txt.GetComponent<Text>().text = "3";
        Video.transform.position = new Vector3(Video.transform.position.x, -0.75f, 0);
        PlayerPrefs.SetInt("VideoPosition", 0);
    }

    public void GetNetworkTime()
    {
        datetime = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var ntpData = new byte[48];
        ntpData[0] = 0x1B;
        using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
        {
            socket.ReceiveTimeout = 3000;
            socket.Connect(new IPEndPoint(Dns.GetHostEntry("time.windows.com").AddressList[0], 123));
            socket.Send(ntpData);
            socket.Receive(ntpData);
        }
        fractPart = SwapEndianness(BitConverter.ToUInt32(ntpData, 44));
        intPart = SwapEndianness(BitConverter.ToUInt32(ntpData, 40));
        seconds = (intPart * 1000 + (fractPart * 1000 / 0x100000000L)) / 1000;
    }

    static uint SwapEndianness(ulong x)
    {
        return (uint)(((x & 0x000000ff) << 24) + ((x & 0x0000ff00) << 8) + ((x & 0x00ff0000) >> 8) + ((x & 0xff000000) >> 24));
    }

    public void StartNewCoroutine()
    {
        StopAllCoroutines();
        StartCoroutine(Wait());
    }
}