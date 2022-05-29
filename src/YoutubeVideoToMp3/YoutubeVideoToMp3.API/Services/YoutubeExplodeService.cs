using YoutubeVideoToMp3.Contracts;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YoutubeVideoToMp3.Services
{
    public class YoutubeExplodeService : IYoutubeService
    {
        private readonly YoutubeClient _youtubeClient;

        public YoutubeExplodeService()
        {
            _youtubeClient = new YoutubeClient();
        }

        public async ValueTask<string> GetTitle(string videoId)
        {
            var videoInfo = await _youtubeClient.Videos.GetAsync(videoId);
            return videoInfo.Title;
        }

        public async ValueTask<Stream> GetAudioStream(string videoId)
        {
            var streamManifest = await _youtubeClient.Videos.Streams.GetManifestAsync(videoId);
            var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            var stream = await _youtubeClient.Videos.Streams.GetAsync(streamInfo);
            return stream;
        }
    }
}
