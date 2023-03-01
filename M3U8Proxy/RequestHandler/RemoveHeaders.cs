﻿using RestSharp;

namespace M3U8Proxy.RequestHandler;

public partial class ReqHandler
{
    public void RemoveBlockedHeaders(IRestResponse response)
    {
        var headersToRemove = new HashSet<string>(_corsBlockedHeaders, StringComparer.InvariantCultureIgnoreCase);
        for (int i = response.Headers.Count - 1; i >= 0; i--)
        {
            var header = response.Headers[i];
            if (headersToRemove.Contains(header.Name))
            {
                response.Headers.RemoveAt(i);
            }
        }
    }
}