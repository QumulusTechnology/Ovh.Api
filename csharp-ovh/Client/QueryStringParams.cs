using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Ovh.Api;

public class QueryStringParams : List<(string, string)>
{
    private readonly List<string> _existingKeys = [];

    public void Add(string key, string value)
    {
        if(_existingKeys.Contains(key))
            throw new ArgumentException("Duplicate keyword. This is currently not supported by OVH API");
        _existingKeys.Add(key);
        Add((key, value));
    }

    public void Add(IEnumerable<(string key, string value)> items)
    {
        foreach (var (key, value) in items) Add(key, value);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append('?');

        var firstParam = true;

        foreach (var param in this)
        {
            if(!firstParam) 
                sb.Append('&');

            sb.Append(HttpUtility.UrlEncode(param.Item1));
            sb.Append('=');
            sb.Append(HttpUtility.UrlEncode(param.Item2));

            firstParam = false;
        }

        return sb.ToString();
    }
}