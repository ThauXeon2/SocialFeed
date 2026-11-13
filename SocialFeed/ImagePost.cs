namespace SocialFeed;

public class ImagePost : Post
{
    private int _imageCount;

    public int ImageCount{get=>_imageCount;set=>_imageCount = value is >= 1 and <= 10 ? value : 1;}

    public ImagePost(string author, int imageCount) : base(author)
    {
        ImageCount = imageCount;
    }

    public override int Score() => Likes * 2;

    public override string GetDescription() => $"{base.GetDescription()}, {ImageCount} kép";
}
