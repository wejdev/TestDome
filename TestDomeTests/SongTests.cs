using JetBrains.Annotations;
using TestDome;

namespace TestDomeTests;

[TestSubject(typeof(Song))]
public class SongTests
{
    [Fact]
    public void IsInRepeatingPlaylistGivenTest()
    {
        var first = new Song("Hello");
        var second = new Song("Eye of the tiger");

        first.NextSong = second;
        second.NextSong = first;

        Assert.True(first.IsInRepeatingPlaylist());
    }

    [Fact]
    public void IsInRepeatingPlaylistSample1Test()
    {
        var s1 = new Song("Track 1");
        var s2 = new Song("Track 2");
        var s3 = new Song("Track 3");
        var s4 = new Song("Track 4");

        s1.NextSong = s2;
        s2.NextSong = s3;
        s3.NextSong = s4;
        s4.NextSong = s2; // cycle to s2

        Assert.True(s1.IsInRepeatingPlaylist());
    }

    [Fact]
    public void IsInRepeatingPlaylistSample2Test()
    {
        var a = new Song("A");
        var b = new Song("B");
        var c = new Song("C");

        a.NextSong = b;
        b.NextSong = c;
        c.NextSong = a; // cycle back to "A"

        Assert.True(a.IsInRepeatingPlaylist());
    }

    [Fact]
    public void IsInRepeatingPlaylistSample3Test()
    {
        var x = new Song("X");
        var y = new Song("Y");
        var z = new Song("Z");

        x.NextSong = y;
        y.NextSong = z;
        z.NextSong = null;

        Assert.False(x.IsInRepeatingPlaylist());
    }

    [Fact]
    public void IsInRepeatingPlaylistSample4Test()
    {
        var solo = new Song("Solo");

        solo.NextSong = null;

        Assert.False(solo.IsInRepeatingPlaylist());
    }
}
