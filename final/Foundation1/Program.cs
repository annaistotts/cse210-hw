using System;
using System.Collections.Generic;

// I had ChatGPT create the comments and usernames for me. I like tennis, so there's a tennis theme. 

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Top 10 Federer Moments", "TennisHighlights", 480);
        video1.AddComment(new Comment("FedererFan", "Federer’s backhand is pure art!"));
        video1.AddComment(new Comment("AceMachine", "That Wimbledon shot at #3 gave me chills."));
        video1.AddComment(new Comment("NetMaster", "Can’t believe he did that in a Grand Slam!"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("How to Serve Like a Pro", "TennisTipsDaily", 360);
        video2.AddComment(new Comment("VolleyQueen", "My serve improved instantly! Thank you!"));
        video2.AddComment(new Comment("BaselineBeast", "The slow-mo breakdown really helped."));
        video2.AddComment(new Comment("ClayKing", "Wish I saw this before last week’s match."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Nadal vs Djokovic Epic Rally", "GrandSlamRecaps", 600);
        video3.AddComment(new Comment("SpinDoctor", "This rally was insane—pure athleticism."));
        video3.AddComment(new Comment("DropShotDiva", "Watched it 5 times already!"));
        video3.AddComment(new Comment("HardCourtHero", "Nadal’s serve is on another level."));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("History of the US Open", "TennisTime", 720);
        video4.AddComment(new Comment("RacketRon", "Loved learning about the early years."));
        video4.AddComment(new Comment("SliceAndDice", "That trivia at the end was awesome!"));
        video4.AddComment(new Comment("CourtCraze", "I need more!"));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            video.DisplayInfo();
        }
    }
}
