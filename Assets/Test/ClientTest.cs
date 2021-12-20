// OSC Jack - Open Sound Control plugin for Unity
// https://github.com/keijiro/OscJack

using UnityEngine;
using System.Collections;
using OscJack;

class ClientTest : MonoBehaviour
{
    OscClient _client;

    void Start()
    {
        // IP address, port number
        _client = new OscClient("127.0.0.1", 6001);

        var m = new Message
            {
                header = "その晩、私は隣室のアレキサンダー君に案内されて、始めて横浜へ遊びに出かけた。",
                message = "私達は予定通り、恰度一時間を費して、インタアナショナルを出た。真暗な河岸通りに青い街灯が惨めに凍えて、烈しい海の香りをふくんだ夜風が吹きまくっていた。"
            };

        _client.Send("/test", JsonUtility.ToJson(m));

    }

    void OnDestroy()
    {
        _client?.Dispose();
        _client = null;
    }
}

public struct Message
{
    public string header;
    public string message;
}
