using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

public class ImageRekognition
{
    public static async Task Main()
    {
        string photo = "input.jpg"; // Your image file name
        string bucket = "Your_Bucket_Name"; // Your S3 bucket name

        var rekognitionClient = new AmazonRekognitionClient();

        // Detect Faces
        var detectFacesRequest = new DetectFacesRequest()
        {
            Image = new Image()
            {
                S3Object = new S3Object()
                {
                    Name = photo,
                    Bucket = bucket,
                },
            },
            Attributes = new List<string>() { "ALL" },
        };

        try
        {
            // Face detection
            DetectFacesResponse detectFacesResponse = await rekognitionClient.DetectFacesAsync(detectFacesRequest);
            bool hasAll = detectFacesRequest.Attributes.Contains("ALL");
            Console.WriteLine("Faces Detected:");

            foreach (FaceDetail face in detectFacesResponse.FaceDetails)
            {
                Console.WriteLine($"BoundingBox: top={face.BoundingBox.Left} left={face.BoundingBox.Top} width={face.BoundingBox.Width} height={face.BoundingBox.Height}");
                Console.WriteLine($"Confidence: {face.Confidence}");
                Console.WriteLine($"Landmarks: {face.Landmarks.Count}");
                Console.WriteLine($"Pose: pitch={face.Pose.Pitch} roll={face.Pose.Roll} yaw={face.Pose.Yaw}");
                Console.WriteLine($"Brightness: {face.Quality.Brightness}\tSharpness: {face.Quality.Sharpness}");

                if (hasAll)
                {
                    Console.WriteLine($"Estimated age is between {face.AgeRange.Low} and {face.AgeRange.High} years old.");
                }
            }

            // Detect Text in Image
            var detectTextRequest = new DetectTextRequest()
            {
                Image = new Image()
                {
                    S3Object = new S3Object()
                    {
                        Name = photo,
                        Bucket = bucket,
                    },
                },
            };

            DetectTextResponse detectTextResponse = await rekognitionClient.DetectTextAsync(detectTextRequest);
            Console.WriteLine("\nText Detected:");
            foreach (TextDetection text in detectTextResponse.TextDetections)
            {
                Console.WriteLine($"Detected text: {text.DetectedText}, Type: {text.Type}");
            }

            // Detect Labels (Objects)
            var detectLabelsRequest = new DetectLabelsRequest()
            {
                Image = new Image()
                {
                    S3Object = new S3Object()
                    {
                        Name = photo,
                        Bucket = bucket,
                    },
                },
                MaxLabels = 10,  // You can adjust the number of labels to return
                MinConfidence = 75F,  // Minimum confidence for detected labels (optional)
            };

            DetectLabelsResponse detectLabelsResponse = await rekognitionClient.DetectLabelsAsync(detectLabelsRequest);
            Console.WriteLine("\nObjects/Labels Detected:");
            foreach (Label label in detectLabelsResponse.Labels)
            {
                Console.WriteLine($"Label: {label.Name}, Confidence: {label.Confidence}%");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
