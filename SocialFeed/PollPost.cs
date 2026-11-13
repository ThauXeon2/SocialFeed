namespace SocialFeed;

public class PollPost : Post
{
    private int _votes;
    private bool _isClosed;

    public int Votes{get=>_votes;}
    public bool IsClosed{get=>_isClosed;}

    public PollPost(string author) : base(author)
    {
        _votes = 0;
        _isClosed = false;
    }

    public bool Vote()
    {
        if (_isClosed)
        {
            return false;
        }

        _votes++;
        return true;
    }

    public void Close() => _isClosed = true;

    public override bool Like() => _isClosed ? false : base.Like();

    public override int Score() => Likes + Votes;

    public override string GetDescription() =>
        $"{base.GetDescription()}, {Votes} szavazat{(IsClosed ? ", lezárva" : string.Empty)}";
}
