namespace SocialFeed;

public abstract class Post : IReportable
{
    private string _author = string.Empty;
    private int _likes;
    private int _reports;
    private readonly List<Comment> _comments;

    public string Author{get=>_author;set=>_author = value;}
    public int Likes{get=>_likes;}
    public List<Comment> Comments{get=>_comments;}

    protected Post(string author)
    {
        Author = author;
        _likes = 0;
        _reports = 0;
        _comments = new List<Comment>();
    }

    public virtual bool Like()
    {
        _likes++;
        return true;
    }

    public virtual string GetDescription() =>
        $"{Author}, {Likes} kedvelés{(_comments.Count > 0 ? $", {_comments.Count} hozzászólás" : string.Empty)}";

    public abstract int Score();

    public void Report() => _reports++;

    public int ReportCount() => _reports;

    public Comment AddComment(string author, string text)
    {
        Comment comment = new Comment(author, text, this);
        _comments.Add(comment);
        return comment;
    }
}
