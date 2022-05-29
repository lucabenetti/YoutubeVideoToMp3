namespace YoutubeVideoToMp3.Contracts
{
    public interface IYoutubeService
    {
        ValueTask<Stream> GetAudioStream(string videoId);
        ValueTask<string> GetTitle(string videoId);
    }
}
