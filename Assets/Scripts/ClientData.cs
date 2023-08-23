using Newtonsoft.Json;
public class ClientData
{
    [JsonProperty("1")]
    public _1 _1 { get; set; }

    [JsonProperty("2")]
    public _2 _2 { get; set; }

    [JsonProperty("3")]
    public _3 _3 { get; set; }
}

public class _1
{
    public string address { get; set; }
    public string name { get; set; }
    public int points { get; set; }
}

public class _2
{
    public string address { get; set; }
    public string name { get; set; }
    public int points { get; set; }
}

public class _3
{
    public string address { get; set; }
    public string name { get; set; }
    public int points { get; set; }
}
