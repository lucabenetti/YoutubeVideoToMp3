using YoutubeVideoToMp3.Contracts;
using YoutubeVideoToMp3.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IYoutubeService, YoutubeExplodeService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/{videoId}", async (IYoutubeService youtubeService, string videoId) =>
{
    var audioStream = await youtubeService.GetAudioStream(videoId);
    var videoTitle = await youtubeService.GetTitle(videoId);

    return Results.File(audioStream, contentType: "audio/mpeg", $"{videoTitle}.mp3");
});

app.Run();