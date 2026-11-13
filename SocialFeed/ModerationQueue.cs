namespace SocialFeed;

public class ModerationQueue
{
    private readonly List<IReportable> _toReview;

    public List<IReportable> ToReview{get=>_toReview;}

    public ModerationQueue()
    {
        _toReview = new List<IReportable>();
    }

    public void ReportItem(IReportable item)
    {
        item.Report();
        if (item.ReportCount() >= 3 && !_toReview.Contains(item))
        {
            _toReview.Add(item);
        }
    }
}
