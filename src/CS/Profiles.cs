using System.Collections.Generic;

public static class profiles
{
    public static readonly string jsonPath = @"..\..\..\userData.json";

    public static List<Dictionary<string, string>> Profiles = new List<Dictionary<string, string>>();
    public static Dictionary<string, string> oauthKeys = new Dictionary<string, string>();
    public static string uName { get; set; }
    public static string Oauth { get ; set; }
}

public class loaded
{
    public List<Dictionary<string, string>> _profiles { get; set; }
}