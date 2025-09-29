using System.Numerics;
using NiTEWrapper;
using OpenNIWrapper;

Console.WriteLine("Initializing NiTE library");

if (NiTE.Initialize() is not NiTE.Status.Ok)
{
    Console.WriteLine("Error initializing NiTE");
    return;
}

Console.WriteLine($"Running NiTE v{NiTE.Version}");

var tracker = UserTracker.Create();
tracker.OnNewData += userTracker =>
{
    if (!userTracker.IsValid) return;
    using var frame = userTracker.ReadFrame();
    foreach (var user in frame.Users)
        if (user.IsNew)
        {
            Console.WriteLine($"New user {user.UserId}");
            userTracker.StartSkeletonTracking(user.UserId);
        }
        else if (user.IsLost)
        {
            Console.WriteLine($"Lost user {user.UserId}");
        }
        else if (user.Skeleton.State == Skeleton.SkeletonState.Tracked)
        {
            var head = user.Skeleton.GetJoint(SkeletonJoint.JointType.Head);
            Console.WriteLine($"{user.UserId}: {head.Position.ToVector()}");
        }
};

Console.WriteLine("Press any key to exit...");
Console.ReadKey();

Console.WriteLine("Shutting down...");
NiTE.Shutdown();
OpenNI.Shutdown();

public static class Extensions
{
    public static Vector3 ToVector(this Point3D point)
    {
        return new Vector3(point.X, point.Y, point.Z) * 0.001f;
    }
}