using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        Video firstVideo = new Video("How to Make Homemade Pizza", "Cooking with Maya", 735);
        firstVideo.AddComment(new Comment("Jordan Lee", "The dough recipe worked perfectly!"));
        firstVideo.AddComment(new Comment("Sam Patel", "I added mushrooms and it was delicious."));
        firstVideo.AddComment(new Comment("Avery Chen", "Clear instructions. Thanks for sharing!"));
        videos.Add(firstVideo);

        Video secondVideo = new Video("Beginner's Guide to Hiking", "Trail Notes", 528);
        secondVideo.AddComment(new Comment("Riley Morgan", "The packing checklist was really helpful."));
        secondVideo.AddComment(new Comment("Casey Brooks", "Which trail shoes do you recommend?"));
        secondVideo.AddComment(new Comment("Taylor Kim", "Beautiful views. I want to visit!"));
        videos.Add(secondVideo);

        Video thirdVideo = new Video("Building a Simple Birdhouse", "Weekend Workshop", 642);
        thirdVideo.AddComment(new Comment("Jamie Rivera", "Made this with my kids this weekend."));
        thirdVideo.AddComment(new Comment("Alex Johnson", "What size drill bit did you use?"));
        thirdVideo.AddComment(new Comment("Morgan Davis", "A great project for beginners."));
        videos.Add(thirdVideo);

        foreach (Video video in videos)
        {
            video.Display();
            Console.WriteLine();
        }
    }
}
