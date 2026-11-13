namespace SocialFeed;

public class Comment : IReportable
{
    private string _author =string.Empty;
    private string _text = string.Empty;
    private readonly Post _parentPost;
    private int _reports;

    public string Author{get=>_author;set=>_author = value;}

    public string Text{get=>_text;set=>_text = value;}
    public Post ParentPost{get=>_parentPost;}

    public Comment(string author, string text, Post parentPost)
    {
        Author = author;
        Text = text;
        _parentPost = parentPost;
        _reports = 0;
    }

    public void Report() => _reports++;

    public int ReportCount() => _reports;

    public string GetDescription() =>
        $"{Author} hozzászólása {ParentPost.Author} bejegyzéséhez: {Text}";
}
