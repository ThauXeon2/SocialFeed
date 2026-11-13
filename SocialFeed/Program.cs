namespace SocialFeed;

class Program
{
    static void Main(string[] args)
    {
        TextPost shortPost = new TextPost("Kata", "Rövid bejegyzés");
        TextPost longPost = new TextPost("Bence", "Ma reggel láttam egy nagyon érdekes dolgot a parkban.");
        shortPost.Like();
        shortPost.Like();
        shortPost.Like();
        Console.WriteLine($"{shortPost.GetDescription()} (pontszám: {shortPost.Score()})");
        Console.WriteLine($"{longPost.GetDescription()} (pontszám: {longPost.Score()})");

        ImagePost imagePost = new ImagePost("Dóra", 3);
        for (int i = 0; i < 5; i++)
        {
            imagePost.Like();
        }

        Console.WriteLine($"{imagePost.GetDescription()} (pontszám: {imagePost.Score()})");
        ImagePost invalidImagePost = new ImagePost("Ádám", 15);
        Console.WriteLine(invalidImagePost.GetDescription());

        PollPost pollPost = new PollPost("Feri");
        pollPost.Like();
        pollPost.Like();
        for (int i = 0; i < 4; i++)
        {
            pollPost.Vote();
        }

        pollPost.Close();
        Console.WriteLine($"Lezárt szavazás kedvelése: {pollPost.Like()}");
        Console.WriteLine($"Lezárt szavazásra szavazás: {pollPost.Vote()}");
        Console.WriteLine($"{pollPost.GetDescription()} (pontszám: {pollPost.Score()})");

        longPost.AddComment("Gábor", "Ez nem igaz!");
        Comment secondComment = longPost.AddComment("Eszter", "Én is ott voltam.");
        Console.WriteLine(longPost.GetDescription());
        foreach (Comment comment in longPost.Comments)
        {
            Console.WriteLine(comment.GetDescription());
        }

        ModerationQueue moderationQueue = new ModerationQueue();
        for (int i = 0; i < 3; i++)
        {
            moderationQueue.ReportItem(longPost);
        }

        for (int i = 0; i < 4; i++)
        {
            moderationQueue.ReportItem(secondComment);
        }

        moderationQueue.ReportItem(imagePost);
        foreach (IReportable item in moderationQueue.ToReview)
        {
            Console.WriteLine($"{item.GetDescription()} ({item.ReportCount()} bejelentés)");
        }
    }
}