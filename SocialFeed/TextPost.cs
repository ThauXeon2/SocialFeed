namespace SocialFeed;

public class TextPost : Post
{
    private string _text = string.Empty;

    public string Text{get=>_text;set=>_text = value;}

    public TextPost(string author, string text) : base(author)
    {
        Text = text;
    }

    public override int Score() => Likes;

    public override string GetDescription() =>
        $"{base.GetDescription()}: {(Text.Length > 20 ? $"{Text[..20]}..." : Text)}";
}
