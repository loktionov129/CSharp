using Google.Cloud.Firestore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "firestore-creds.json");
            var t = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
            new Program().Run("firestore-projectname").Wait();
        }

        public async Task Run(string projectName)
        {
            FirestoreDb db = FirestoreDb.Create(projectName);
            CollectionReference postsRef = db.Collection("posts");
            var post = postsRef.Document("----post_id-----");
            var comments = post.Collection("comments")
               .WhereEqualTo("headCommentId", "")
                .OrderByDescending("publishedAt")
                .Limit(3);
            var lastCommets = await comments.GetSnapshotAsync();
            var x = lastCom.FirstOrDefault()?.ToDictionary();
            Console.WriteLine(x);
        }
    }
}
