using System;

namespace DustyPig.TVDB;

public static class Utils
{
    public static string GetArtworkPath(string artworkPath)
    {
        if (string.IsNullOrWhiteSpace(artworkPath))
            return null;

        if(artworkPath.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
            return artworkPath;

        if(artworkPath.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            return artworkPath;

        if(!artworkPath.StartsWith('/'))
            artworkPath = '/' + artworkPath;

        return "https://artworks.thetvdb.com" + artworkPath;
    }
}
