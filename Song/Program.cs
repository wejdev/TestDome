namespace TestDome;

public class Song
{
    private string _name;
    public Song? NextSong { get; set; }

    public Song(string name)
    {
        this._name = name;
    }

    public bool IsInRepeatingPlaylist()
    {
        var slow = this;
        var fast = this;

        while (fast?.NextSong != null)
        {
            slow = slow.NextSong;
            fast = fast.NextSong.NextSong;

            if (slow == fast)
                return true;
        }

        return false;
    }

    public bool IsInRepeatingPlaylistHashSet()
    {
        var visited = new HashSet<Song>();
        var current = this;

        while (current != null)
        {
            if (!visited.Add(current)) // Already seen this song
                return true;

            current = current.NextSong;
        }

        return false;
    }

    public static void Main(string[] args)
    {
        Song first = new Song("Hello");
        Song second = new Song("Eye of the tiger");

        first.NextSong = second;
        second.NextSong = first;

        Console.WriteLine(first.IsInRepeatingPlaylist());
    }
}

/*

A playlist is considered a repeating playlist if any of the songs contain a reference to a previous song in the playlist. Otherwise, the playlist will end with the last song which points to null.

Implement a function `IsInRepeatingPlaylist` that, **efficiently** with respect to time used, returns true if a playlist is repeating or false if it is not.

For example, the following code prints "True" as both songs point to each other.

Song first = new Song("Hello");
Song second = new Song("Eye of the tiger");

first.NextSong = second;
second.NextSong = first;

Console.WriteLine(first.IsInRepeatingPlaylist());

*/
